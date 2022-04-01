USE [gtn-dev]
--USE [gtn]

GO
/****** Object:  StoredProcedure [dbo].[SP_GetMrxCourses]    Script Date: 2/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE [dbo].[SP_GetMrxCourses] 
ALTER PROCEDURE [dbo].[SP_GetMrxCourses] 
--@inTrxOnly bit

AS   
    SET NOCOUNT ON; 

--Returns all courses with those already in translation marked
-- Language, SemesterName, CourseName, CourseCoreID, InTranslation(bit)


--************************************ SET UP STATUS TEMP TABLE *****************************************************
IF OBJECT_ID(N'dbo.#LangCoursesTemp', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#LangCoursesTemp];  
IF OBJECT_ID(N'dbo.#tempTrxMrxStatus', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#tempTrxMrxStatus];  
IF OBJECT_ID(N'dbo.#tempMrxCourseTotals', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#tempMrxCourseTotals];  
IF OBJECT_ID(N'dbo.#tempMrxCourseInWork', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#tempMrxCourseInWork];  


declare @checkTimes bit;
--set @checkTimes = 1;
set @checkTimes = 0;

if (@checkTimes = 1) 
begin
	DECLARE @t1 DATETIME;
	DECLARE @t2 DATETIME;
	SET @t1 = GETDATE();
	select 'Start'
end 

--for temp table, all courseCoreIDs and Langs
select coursecoreid, langid, 
0 as SessionTrxInWork, 0 as SessionTrxTotal, CAST(0.00 AS DECIMAL(5,2)) as SessionTrxCompletePct, 
0 as SessionMrxInWork, 0 as SessionMrxTotal, CAST(0.00 AS DECIMAL(5,2)) as SessionMrxCompletePct  
into #tempTrxMrxStatus
from Courses

CREATE CLUSTERED INDEX idx_temp_coursecoreid_langid ON #tempTrxMrxStatus ([coursecoreid],[langid]);
--CREATE NONCLUSTERED INDEX idx_trxlog_sessionid ON TranslationLog ([sessionid]);

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 1: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 2: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 3: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

select SC.courseCoreID, S.LangID, count(ML.msID) as SessionMrxTotal
into #tempMrxCourseTotals
from MasteringLog ML
join sessions S on S.sessionid = ML.sessionid 
Join sessioncores SC on SC.sessioncoreID = S.SessionCoreID
group by SC.courseCoreID, S.LangID

CREATE CLUSTERED INDEX idx_tempTotals_coursecoreid ON #tempMrxCourseTotals ([coursecoreid]);
CREATE NONCLUSTERED INDEX idx_tempTotals_langid ON #tempMrxCourseTotals ([langid]);

---- Update counts of Total ML sessions from MrxLogs 
update tS set tS.SessionMrxTotal = mxS.SessionMrxTotal
from #tempTrxMrxStatus tS
join  #tempMrxCourseTotals mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 4: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


select SC.courseCoreID, S.LangID, count(ML.msID) as SessionMrxInWork
into #tempMrxCourseInWork
from MasteringLog ML
join sessions S on S.sessionid = ML.sessionid 
Join sessioncores SC on SC.sessioncoreID = S.SessionCoreID
where ML.statusID = 1
group by SC.courseCoreID, S.LangID

CREATE CLUSTERED INDEX idx_tempInWork_coursecoreid ON #tempMrxCourseInWork ([coursecoreid]);
CREATE NONCLUSTERED INDEX idx_tempInWork_langid ON #tempMrxCourseInWork ([langid]);


---- Update counts of ML sessions In Work (status of Not Started)
update tS set tS.SessionMrxInWork = mxS.SessionMrxInWork
from #tempTrxMrxStatus tS
join #tempMrxCourseInWork mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 5: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 6: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

----calculate Mrx % completes per session
update tS set tS.SessionMrxCompletePct = 100.00 - 100.00*(CAST(tS.SessionMrxInWork as FLOAT)/(CAST(tS.SessionMrxTotal as FLOAT)))
from #tempTrxMrxStatus tS

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 7: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 8: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

update C set C.MrxComplete = 1
from courses C
join #tempTrxMrxStatus B 
on b.courseCoreID = C.courseCoreID and b.langID = c.langID
where B.SessionMrxCompletePct = 100

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 9: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--************************************* END  STATUS TEMP TABLE ******************************************************

CREATE TABLE [dbo].[#LangCoursesTemp](
	[lcID] [int] IDENTITY(1,1) NOT NULL,
	[LangName] [varchar](50) NULL,
	[langID] [int] NOT NULL,
	[SemesterName] [varchar](100) NULL,
	[SemesterCode] [varchar](16) NULL,
	[CourseName] [varchar](100) NULL,
	[courseCoreID] [int] NOT NULL,
	[InTranslation] bit Not Null,
	[PercentComplete] DECIMAL(5,2) NULL 
) ON [PRIMARY]

CREATE CLUSTERED INDEX idx_temp_ccid_langid ON #LangCoursesTemp ([coursecoreid],[langid]);

Insert into #LangCoursesTemp (LangName, langID, SemesterName, SemesterCode, CourseName, courseCoreID, InTranslation)
select L.LangName, L.LangID, SC.SemesterName, CC.SemesterCode, CC.CourseName, CC.CourseCoreID, 0 as 'InTranslation'
from coursecores CC
join SemesterCores SC on SC.SemesterCode = CC.SemesterCode
cross join Languages L

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 10: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

--TBD: Remove courses that have been completed

--update the InTranslation bit for courses that are in translation
update LT set InTranslation = 1
From 
#LangCoursesTemp LT
Join Courses C on C.CourseCoreID = LT.CourseCoreID and C.LangID = LT.LangID

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 11: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

--update SessionMrxCompletePct [CHECK THIS]
update LT set LT.PercentComplete = tS.SessionMrxCompletePct
From 
#LangCoursesTemp LT
Join #tempTrxMrxStatus tS on tS.courseCoreID = LT.courseCoreID 
  and tS.langID = LT.langID



if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 12: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--*************** Update Semester TRX Complete ***************

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 13: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 14: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 15: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 16: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--*************** Update Semester MRX Complete ***************
--select into temp table
select S.langID, S.SemesterCode, count(S.langID) as MrxTotal, Null as MrxComplete
into #tempSemMrxComplete from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 17: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


update A set A.MrxComplete = TC.MrxComplete 
from #tempSemMrxComplete A
Join
(select count(S.langID) MrxComplete, S.langID, S.SemesterCode
--select S.*, CC.courseCoreID, C.courseID, C.MrxComplete, S.MrxComplete
from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode, c.MrxComplete
having c.MrxComplete = 1) TC
on A.langID = TC.langID and A.semesterCode = TC.semesterCode 

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 18: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

--update semester MrxComplete
update S set S.MrxComplete = 1 
from semesters S
join 
(select SemesterCode, langID from #tempSemMrxComplete where MrxTotal = MrxComplete) SC
on S.SemesterCode = SC.SemesterCode and S.langID = SC.langID

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 19: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

-- Output Rows
Select * from #LangCoursesTemp where InTranslation = 1 order by InTranslation desc

-- Clean Up

Drop table #tempMrxCourseInWork
Drop table #tempMrxCourseTotals
drop table #tempSemMrxComplete
Drop table #LangCoursesTemp
drop table #tempTrxMrxStatus

-- use [gtn-dev]
-- exec SP_GetMrxCourses 0
-- exec SP_GetMrxCourses 1  --(In translation only)

