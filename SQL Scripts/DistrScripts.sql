use [gtn-dev]

select * from languages

insert into languages (LangName, Notes) 



select SC.SemesterCode, SemesterName, CC.CourseName, CC.courseCoreID 
from semestercores SC
join CourseCores CC on CC.SemesterCode = SC.SemesterCode
