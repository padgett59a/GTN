USE [gtn-dev]
--USE [gtn]

GO
/****** Object:  StoredProcedure [dbo].[SP_GetTrxCourses]    Script Date: 1/24/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE [dbo].[SP_GetTrxCourses] 
ALTER PROCEDURE [dbo].[SP_GetTrxCourses] 
@inTrxOnly bit

AS   
    SET NOCOUNT ON; 

--Return all courses with those already in translation marked
-- Language, SemesterName, CourseName, CourseCoreID, InTranslation(bit)

-- Get all possible Courses into temp table
-- drop table #LangCoursesTemp


--************************************ SET UP STATUS TEMP TABLE *****************************************************
IF OBJECT_ID(N'dbo.#LangCoursesTemp', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#LangCoursesTemp];  
IF OBJECT_ID(N'dbo.#tempTrxMrxStatus', N'U') IS NOT NULL  
   DROP TABLE [dbo].[#tempTrxMrxStatus];  

declare @checkTimes bit;
set @checkTimes = 1;
--set @checkTimes = 0;

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

-- Update status temp table with total session trxlog counts
update tS set tS.SessionTrxTotal = txS.SessionTrxTotal
from #tempTrxMrxStatus tS
join (
select 	SC.courseCoreID, 	S.LangID,	count(TL.tsID) as SessionTrxTotal
from TranslationLog TL
join Sessions S on S.SessionID = TL.SessionID 
join SessionCores SC on SC.SessionCoreID  = S.SessionCoreID 
--where TL.statusID = 1
group by SC.courseCoreID, S.LangID
) txS
  on (txS.courseCoreID = tS.courseCoreID
  and txs.langID = tS.langID); 

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 2: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

-- Update status temp table with Trx sessions in work
update tS set tS.SessionTrxInWork = txS.SessionTrxInWork
from #tempTrxMrxStatus tS
join (
select 	SC.courseCoreID, 	S.LangID,	count(TL.tsID) as SessionTrxInWork
from TranslationLog TL
join Sessions S on S.SessionID = TL.SessionID 
join SessionCores SC on SC.SessionCoreID  = S.SessionCoreID 
where TL.statusID = 1
group by SC.courseCoreID, S.LangID
) txS
  on (txS.courseCoreID = tS.courseCoreID
  and txs.langID = tS.langID); 


if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 3: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end

-- Update counts of Total ML sessions from MrxLogs 
update tS set tS.SessionMrxTotal = mxS.SessionMrxTotal
from #tempTrxMrxStatus tS
join (
select SC.courseCoreID, S.LangID, count(ML.msID) as SessionMrxTotal
from MasteringLog ML
join sessions S on S.sessionid = ML.sessionid 
Join sessioncores SC on SC.sessioncoreID = S.SessionCoreID
group by SC.courseCoreID, S.LangID
) mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 4: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


-- Update counts of ML sessions In Work (status of Not Started)
update tS set tS.SessionMrxInWork = mxS.SessionMrxInWork
from #tempTrxMrxStatus tS
join (
select SC.courseCoreID, S.LangID, count(ML.msID) as SessionMrxInWork
from MasteringLog ML
join sessions S on S.sessionid = ML.sessionid 
Join sessioncores SC on SC.sessioncoreID = S.SessionCoreID
where ML.statusID = 1
group by SC.courseCoreID, S.LangID
) mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 5: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--calculate Trx % completes per session
update tS set tS.SessionTrxCompletePct = 100.00 - 100.00*(CAST(tS.SessionTrxInWork as FLOAT)/(CAST(tS.SessionTrxTotal as FLOAT)))
from #tempTrxMrxStatus tS

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 6: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--calculate Mrx % completes per session
update tS set tS.SessionMrxCompletePct = 100.00 - 100.00*(CAST(tS.SessionMrxInWork as FLOAT)/(CAST(tS.SessionMrxTotal as FLOAT)))
from #tempTrxMrxStatus tS

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 7: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


--update completion flags for Courses 
update C set C.TrxComplete = 1
from courses C
join #tempTrxMrxStatus B 
on b.courseCoreID = C.courseCoreID and b.langID = c.langID
where B.SessionTrxCompletePct = 100

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

--CREATE CLUSTERED INDEX idx_temp__sc_ccid_langid ON #LangCoursesTemp ([semestercode],[coursecoreid],[langid]);
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

update LT set LT.PercentComplete = tS.SessionTrxCompletePct
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


--select into temp table
select S.langID, S.SemesterCode, count(S.langID) as TrxTotal, Null as TrxComplete
into #tempSemTrxComplete from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode

CREATE CLUSTERED INDEX idx_temp_sc_langid ON #tempSemTrxComplete ([SemesterCode],[langID]);

if (@checkTimes = 1) 
begin
	SET @t1 = GETDATE();
	SELECT 'after step 14: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


update A set A.TrxComplete = TC.TrxComplete 
from #tempSemTrxComplete A
Join
(select count(S.langID) TrxComplete, S.langID, S.SemesterCode
--select S.*, CC.courseCoreID, C.courseID, C.TrxComplete, S.TrxComplete
from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode, c.TrxComplete
having c.TrxComplete = 1) TC
on A.langID = TC.langID and A.semesterCode = TC.semesterCode 

if (@checkTimes = 1) 
begin
	SET @t2 = GETDATE();
	SELECT 'after step 15: ' + CAST(DATEDIFF(second,@t1,@t2) AS nvarchar(200))
end


update S set S.TrxComplete = 1 
from semesters S
join 
(select SemesterCode, langID from #tempSemTrxComplete where TrxTotal = TrxComplete) SC
on S.SemesterCode = SC.SemesterCode and S.langID = SC.langID

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


-- output result set
if (@inTrxOnly = 0)
begin
	Select * from #LangCoursesTemp order by InTranslation desc
end
else
begin
	Select * from #LangCoursesTemp where InTranslation = 1 order by InTranslation desc
end

-- Clean Up

drop table #tempSemMrxComplete
Drop table #tempSemTrxComplete
Drop table #LangCoursesTemp
drop table #tempTrxMrxStatus

-- use [gtn-dev]
-- exec sp_GetTrxCourses 0
-- exec sp_GetTrxCourses 1  --(In translation only)



