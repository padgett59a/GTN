--use [gtn]
--use [gtn-dev]

CREATE VIEW  dbo.SemesterCourse (SemesterName, CourseName, courseCoreID)
AS

select SC.SemesterName, CC.CourseName, CC.courseCoreID 
from coursecores CC
join SemesterCores SC on SC.SemesterCode = CC.SemesterCode

--select * from SemesterCourse



