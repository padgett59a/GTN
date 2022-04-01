
-- update session flags, course flags for completion
-- if the (session, course) records exist, and these queries return no rows, the entity is complete
-- then show status on Manage Trx, Mrx pages (%complete?)

--select * from Languages

--select * from CourseCores where courseCoreID in (133,138,141)

--select CC.CourseName,CC.courseCoreID, SC.SessionName, s.* 
--from sessions S
--join SessionCores SC on SC.sessionCoreID =S.sessionCoreID 
--join CourseCores CC on CC.courseCoreID = SC.courseCoreID  
--where SC.courseCoreID in (99)


use [gtn-dev]

drop table #tempTrxMrxStatus

--for temp table, all courseCoreIDs and Langs
select coursecoreid, langid, 
0 as SessionTrxInWork, 0 as SessionTrxTotal, CAST(0.00 AS DECIMAL(5,2)) as SessionTrxCompletePct, 
0 as SessionMrxInWork, 0 as SessionMrxTotal, CAST(0.00 AS DECIMAL(5,2)) as SessionMrxCompletePct  
into #tempTrxMrxStatus
from Courses


-- Update status temp table with total session trxlog counts
update tS set tS.SessionTrxTotal = txS.SessionTrxTotal
from #tempTrxMrxStatus tS
join (select A.courseCoreID, A.LangID, count(TL.tsID) as SessionTrxTotal
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID and S.langID = A.langID
join TranslationLog TL on TL.sessionID = S.sessionID -- and TL.statusID = 1
group by A.courseCoreID, A.LangID) txS
  on (txS.courseCoreID = tS.courseCoreID
  and txs.langID = tS.langID); 

-- Update status temp table with sessions in work
update tS set tS.SessionTrxInWork = txS.SessionTrxInWork
from #tempTrxMrxStatus tS
join (select A.courseCoreID, A.LangID, count(TL.tsID) as SessionTrxInWork
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID and S.langID = A.langID
join TranslationLog TL on TL.sessionID = S.sessionID and TL.statusID = 1
group by A.courseCoreID, A.LangID) txS
  on (txS.courseCoreID = tS.courseCoreID
  and txs.langID = tS.langID); 


-- Update counts of Total ML session MrxLogs 
update tS set tS.SessionMrxTotal = mxS.SessionMrxTotal
from #tempTrxMrxStatus tS
join (select A.courseCoreID, A.LangID, count(ML.msID) as SessionMrxTotal
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID and S.langID = A.langID
join MasteringLog ML on ML.sessionID = S.sessionID -- and ML.statusID = 1
group by A.courseCoreID, A.LangID) mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 


-- Update counts of ML sessions Not Started (In Work)
update tS set tS.SessionMrxInWork = mxS.SessionMrxInWork
from #tempTrxMrxStatus tS
join (select A.courseCoreID, A.LangID, count(ML.msID) as SessionMrxInWork
from courses A
join SessionCores SC on SC.courseCoreID = A.courseCoreID 
join Sessions S on S.SessionCoreID = SC.SessionCoreID and S.langID = A.langID
join MasteringLog ML on ML.sessionID = S.sessionID and ML.statusID = 1
group by A.courseCoreID, A.LangID) mxS
  on (mxS.courseCoreID = tS.courseCoreID
  and mxs.langID = tS.langID); 


--calculate Trx % completes per session
update tS set tS.SessionTrxCompletePct = 100.00 - 100.00*(CAST(tS.SessionTrxInWork as FLOAT)/(CAST(tS.SessionTrxTotal as FLOAT)))
from #tempTrxMrxStatus tS


--calculate Mrx % completes per session
update tS set tS.SessionMrxCompletePct = 100.00 - 100.00*(CAST(tS.SessionMrxInWork as FLOAT)/(CAST(tS.SessionMrxTotal as FLOAT)))
from #tempTrxMrxStatus tS

update C set C.TrxComplete = 1
from courses C
join #tempTrxMrxStatus B 
on b.courseCoreID = C.courseCoreID and b.langID = c.langID
where B.SessionTrxCompletePct = 100

update C set C.MrxComplete = 1
from courses C
join #tempTrxMrxStatus B 
on b.courseCoreID = C.courseCoreID and b.langID = c.langID
where B.SessionMrxCompletePct = 100


select C.*,  CC.semesterCode
from courses C
join CourseCores CC on C.courseCoreID = CC.courseCoreID
where TrxComplete = 1

select count(langID)
from courses C
join CourseCores CC on C.courseCoreID = CC.courseCoreID
where TrxComplete = 1


select * from semesters
select * from courses where TrxComplete = 1

--drop table tempSemTrxComplete

--select into temp table
select S.langID, S.SemesterCode, count(S.langID) as TrxTotal, Null as TrxComplete
into tempSemTrxComplete from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode

update A set A.TrxComplete = TC.TrxComplete 
from tempSemTrxComplete A
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

--update semesters set TrxComplete = 0

update S set S.TrxComplete = 1 
from semesters S
join 
(select SemesterCode, langID from tempSemTrxComplete where TrxTotal = TrxComplete) SC
on S.SemesterCode = SC.SemesterCode and S.langID = SC.langID



select * from semesters

drop table #tempSemMrxComplete
--*************** MRX ***************
--select into temp table
select S.langID, S.SemesterCode, count(S.langID) as MrxTotal, Null as MrxComplete
into tempSemMrxComplete from semesters S
join CourseCores CC on CC.SemesterCode = S.SemesterCode
join Courses C on C.courseCoreID = CC.courseCoreID 
   and C.langID = S.langID
group by S.langID, S.SemesterCode

select * from #tempSemMrxComplete 

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

--update semesters set MrxComplete = 0
select * from #tempSemMrxComplete 

update S set S.MrxComplete = 1 
from semesters S
join 
(select SemesterCode, langID from #tempSemMrxComplete where MrxTotal = MrxComplete) SC
on S.SemesterCode = SC.SemesterCode and S.langID = SC.langID

select * from tempSemMrxComplete 
select * from semesters

exec SP_GetTrxCourses 1
select * from semesters
select * from courses

drop table tempSemMrxComplete
Drop table tempSemTrxComplete


