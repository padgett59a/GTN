USE [gtn-dev]
-- USE [gtn]

GO
/****** Object:  StoredProcedure [dbo].[[SP_Sem_Course]]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_Sem_Course] 
	@langID int,
	@semCode varchar(16),
	@corsCodes varchar(500),
	@genExams bit
AS   
    SET NOCOUNT ON; 

--NOTE if using CourseCore codes they must all be from the same Semester
begin tran

declare	@semCodeE varchar(16), @bAlreadyInTrx bit

--default to not in translation
set @bAlreadyInTrx = 0

-- resolve list of courses to be translated
if (LEN(@semCode) > 0 )
	begin
		--Create list of course codes
		SELECT @corsCodes = COALESCE(@corsCodes + ', ', '') + 
		   CAST(courseCoreID AS varchar(7))
		FROM CourseCores
		WHERE semesterCode = @semCode
	end


-- resolve semester code
if (LEN(@semCode) > 0 )
	begin
		set @semCodeE = @semCode
	end
else
	begin
		--Resolve the semester code 
		SELECT distinct @semCodeE = semesterCode 
		FROM CourseCores
		WHERE courseCoreID in 
		(select * from dbo.SplitCSVs(@corsCodes)) 
	end

 --Insert Semester record if not already there
Declare @semID int;
if ((select count(*) from Semesters where semesterCode = @semCodeE and LangID = @langID) = 0)
begin
	insert into semesters values (@semCodeE, @langID, 0, 0)
end

--Check Course records and insert if not already there
If ((select count(*) from courses where coursecoreID in (select * from dbo.SplitCSVs(@corsCodes)) and langID = @langID) = 0)
Begin
	insert into courses
	select value, @langID, 0, 0 from dbo.SplitCSVs(@corsCodes)
End
Else
Begin
	-- Don't put these into translation again
	--print 'One or more of the input courses is already in translation'
	--rollback tran
	--Return (1)
	
	-- Don't put these into translation again
	--skip to output creation
	set @bAlreadyInTrx = 1

End


if(@bAlreadyInTrx = 0)
begin
	--SemesterExams
	if (@genExams = 1 AND LEN(@semCode) > 0)
	Begin
		select @semID = semesterID from Semesters where SemesterCode = @semCode and langID = @langID
	   insert into SemesterExams values (@semID, @semCode, NULL, 0)
	   insert into SemesterExams values (@semID, @semCode, NULL, 1)
		-- ExamTranslationLog
		insert into ExamTranslationLog --(examtsID, semexamID, NULL, NULL, NULL, 1 ,NULL)
		select a.examtsID, b.semexamID, NULL, NULL, NULL, 1 ,NULL 
		from ExamTranslationSteps A, SemesterExams B
		where b.semesterID = @semID
	End

	-- Sessions 
	-- Note: dbo.SplitCSVs is a CUSTOM function
	insert into Sessions
	Select sessionCoreID, @langID from
	CourseCores B,
	SessionCores C
	where C.courseCoreID = B.courseCoreID
	--and B.semesterCode = @semCode
	and B.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes))

	-- TranslationLog
	insert into TranslationLog 
	select A.tsID, B.sessionID, 1, NULL, NULL, 1, NULL
	from 
	TranslationSteps A,
	Sessions B,
	SessionCores C,
	CourseCores D
	where 
	D.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes)) and
	C.courseCoreID = D.courseCoreID and 
	B.sessionCoreID = C.sessionCoreID and B.langID = @langID

	--Update TranslationLog pay amounts Defalut, Custom
	-- Default Amounts
	update A set A.StepPaymentAmount = D.DefaultPayDollars
	from 
	translationlog A
	Join translationSteps D on A.tsID = D.tsID
	Join sessions S on A.sessionID = S.sessionID
	Join sessionCores SC on SC.sessionCoreID = S.sessionCoreID
	Where 
	D.DefaultPayDollars is not null
	and S.langID = @langID
	and SC.CourseCoreID in (select * from dbo.SplitCSVs(@corsCodes))

	-- Custom Amounts
	update A set A.StepPaymentAmount = C.CustomPayDollars 
	from 
	translationlog A
	Join translationCustomPay C on A.tsID = C.tsID 
	Join sessions S on A.sessionID = S.sessionID
	Join sessionCores SC on SC.sessionCoreID = S.sessionCoreID
	Where C.CustomPayDollars is not null
	and S.langID = C.langID
	and S.langID = @langID
	and SC.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes))

	-- MasteringLog
	insert into MasteringLog
	select A.msID, 1, B.sessionID, 1, NULL, NULL, NULL
	from 
	MasteringSteps A,
	Sessions B,
	SessionCores C,
	CourseCores D
	where 
	D.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes)) and
	C.courseCoreID = D.courseCoreID and 
	B.sessionCoreID = C.sessionCoreID and B.langID = @langID

	--Update MasteringLog pay amounts Defalut, Custom
	-- Default Amounts
	update A set A.StepPaymentAmount = D.DefaultPayDollars
	from 
	masteringlog A
	Join masteringSteps D on A.msID = D.msID
	Join sessions S on A.sessionID = S.sessionID
	Join sessionCores SC on SC.sessionCoreID = S.sessionCoreID
	Where 
	D.DefaultPayDollars is not null
	and S.langID = @langID
	and SC.CourseCoreID in (select * from dbo.SplitCSVs(@corsCodes))

	-- Custom Amounts
	update A set A.StepPaymentAmount = C.CustomPayDollars 
	from 
	masteringlog A
	Join masteringCustomPay C on A.msID = C.msID 
	Join sessions S on A.sessionID = S.sessionID
	Join sessionCores SC on SC.sessionCoreID = S.sessionCoreID
	Where C.CustomPayDollars is not null
	and S.langID = C.langID
	and S.langID = @langID
	and SC.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes))

end -- if @bAlreadyInTrx

-- Output Rows
select A.*, B.SessionName, E.courseName, D.semesterName, F.LangName, G.Step, H.status, I.FullName
from 
TranslationLog A,
SessionCores B,
Sessions C,
SemesterCores D,
CourseCores E, 
Languages F,
TranslationSteps G,
Statuses H
,Persons I
where 
B.sessionCoreID = C.sessionCoreID and C.sessionID =  A.sessionID and
B.courseCoreID = E.courseCoreID and E.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes)) and
c.langID = @langID and
D.semesterCode = E.semesterCode and
F.langID = @langID and
G.tsID = A.tsID and 
H.statusID = a.statusID 
and I.personID = a.translatorID 

--select * from MasteringLog

commit tran


-- TESTING 
--select * from TranslationLog
--begin tran
--exec  [SP_Sem_Course] 18, 'o', 1
--exec  [SP_Sem_Course] 18, NULL, '2,94,133,141,293', 1
--exec  [SP_Sem_Course] 18, NULL, '94,133', 1
--rollback tran

--select * from semesters where semesterID = @semID
--select * from courses
--select * from semesterExams where semesterID = @semID
--select * from ExamTranslationLog
--select * from Sessions
--select * from TranslationLog
--select * from MasteringLog

--delete from MasteringLog
--delete from TranlationLog
--delete from Sessions
--delete from ExamTranslationLog
--delete from SemesterExams
--delete from Courses
--delete from Semesters


