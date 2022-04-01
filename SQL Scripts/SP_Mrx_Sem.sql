USE [gtn-dev]
-- USE [gtn]

GO
/****** Object:  StoredProcedure [dbo].[[SP_Mrx_Sem]]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE [dbo].[SP_Mrx_Sem] 
ALTER PROCEDURE [dbo].[SP_Mrx_Sem] 
	@langID int,
	@semCode varchar(16),
	@corsCodes varchar(500)
AS   
    SET NOCOUNT ON; 

--This SP returns MasterLog records for a given semester or list of courseCodes
--The SP_Trx_Sem procedure is always called to put courses into translation and this SP should never get called to put things into translation by the UI

--NOTE if using CourseCore codes they must all be from the same Semester
begin tran

declare	@semCodeE varchar(16), @bAlreadyInTrx bit

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


-- Output Rows
select A.*, B.SessionName, E.courseName, D.semesterName, F.LangName, G.Step, H.status, I.FullName
from 
MasteringLog A,
SessionCores B,
Sessions C,
SemesterCores D,
CourseCores E, 
Languages F,
MasteringSteps G,
Statuses H
,Persons I
where 
B.sessionCoreID = C.sessionCoreID and C.sessionID =  A.sessionID and
B.courseCoreID = E.courseCoreID and E.courseCoreID in (select * from dbo.SplitCSVs(@corsCodes)) and
c.langID = @langID and
D.semesterCode = E.semesterCode and
F.langID = @langID and
G.msID = A.msID and 
H.statusID = A.statusID 
and I.personID = A.mastererID 

--select * from MasteringLog

commit tran


-- TESTING 
--select * from TranslationLog
--begin tran
--exec  [SP_Mrx_Sem] 18, 'o', 1
--exec  [SP_Mrx_Sem] 18, NULL, '2,94,133,141,293', 1
--exec  [SP_Mrx_Sem] 18, NULL, '94,133', 1
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


