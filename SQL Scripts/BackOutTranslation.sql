
use [gtn-dev]

exec SP_GetTrxCourses 0
exec SP_GetTrxCourses 1


exec  [SP_Trx_Sem] 18, 'o',NULL, 1
exec  [SP_Trx_Sem] 14, NULL, '2,94,133,141,293', 1
exec  [SP_Trx_Sem] 18, NULL, '94,133', 1
exec  [SP_Trx_Sem] 14, NULL, '94,133', 1

exec  [SP_Trx_Sem] 18, NULL, '94', 1
exec  [SP_Trx_Sem] 18, NULL, '138', 1


exec SP_GetMrxCourses
exec  [SP_Mrx_Sem] 18, NULL, '94'
exec  [SP_Mrx_Sem] 18, NULL, '94,102'


--Course Information for lang, coursecoreid
select CC.CourseName,CC.courseCoreID, SC.SessionName, s.* 
from sessions S
join SessionCores SC on SC.sessionCoreID =S.sessionCoreID 
join CourseCores CC on CC.courseCoreID = SC.courseCoreID  
where SC.courseCoreID in (138) and s.langID = 18

--Semester Information for lang, semestercode
select SC.semestername, L.LangName, S.* 
from semesters S
join semestercores SC on sc.semestercode = s.semestercode
join languages L on L.langid = s.langid
where sc.semestercode = 'o' and s.langid = 19



select * from courses

select * from semesters 
select * from courses order by langid
select * from semesterExams 
select * from ExamTranslationLog
select * from Sessions
select * from TranslationLog
select * from MasteringLog

rollback tran

use [gtn-dev]
delete from MasteringLog
delete from TranslationLog
delete from Sessions
delete from ExamTranslationLog
delete from SemesterExams
delete from Courses
delete from Semesters

go
declare @corsCodes varchar(50);
declare @langID int;
set @langID = 18
set @corsCodes = '94,133'

