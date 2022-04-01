--use [gtn]
--use [gtn-dev]

CREATE VIEW  [dbo].[DistrSemesterCourse] (LangName, langID, SemesterName, CourseName, courseID)
AS

--List of Courses having sessions ready for distribution
select L.LangName, L.langID, SC.SemesterName, CC.CourseName, C.courseID 
from courses C 
join CourseCores CC on CC.courseCoreID = C.courseCoreID
join SemesterCores SC on SC.SemesterCode = CC.SemesterCode
join Languages L on C.langID = L.langID
where MrxComplete = 1


-- use [gtn-dev]
-- select * from DistrSemesterCourse







