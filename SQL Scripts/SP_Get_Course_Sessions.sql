USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_Get_Course_Sessions]    Script Date: 3/29/2022 4:35:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE [dbo].[SP_Get_Course_Sessions] 
ALTER PROCEDURE [dbo].[SP_Get_Course_Sessions] 
	@corsCodes varchar(500)
AS   
    SET NOCOUNT ON; 

-- Get a list of Sessions based on the Course codes passed, for the language indicated
-- Note: dbo.SplitCSVs is a CUSTOM function
-- row_num is really just to provide a Key field for EF to make it happier

Select ROW_NUMBER() Over(order by SC.sessionCoreId) dsID, 
	L.LangName, L.langID, SMC.SemesterName, CC.CourseName, C.courseId, SC.SessionName, S.sessionID
from Courses C
Join CourseCores CC on CC.courseCoreID = C.courseCoreID
Join SemesterCores SMC on SMC.semesterCode = CC.semesterCode 
Join SessionCores SC on SC.courseCoreID = C.courseCoreID
Join Sessions S on S.sessionCoreID = SC.sessionCoreID and S.langID = C.langID
Join Languages L on L.langID = C.langID
where C.courseID in (select * from dbo.SplitCSVs(@corsCodes))
order by SMC.SemesterName, C.courseID


--exec SP_Get_Course_Sessions '186,187,188,215,217,218,219'



