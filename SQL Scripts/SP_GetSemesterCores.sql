USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSemesterCores]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GetSemesterCores]
AS   

    SET NOCOUNT ON;  

	SELECT A.SemesterName, A.SemesterCode, B.CurriculumName, IsNull(A.NumberOfVideoSessions, 0) NumberOfVideoSessions
	FROM SemesterCores A, curriculums B
	where A. curriculumID = b.curriculumID
	order by b.CurriculumName