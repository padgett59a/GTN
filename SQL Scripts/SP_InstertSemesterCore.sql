USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSemesterCores]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_InsertSemesterCore] 
	@SemesterCode varchar(16), 
	@SemesterName varchar(100), 
	@CurriculumName varchar(100), 
	@NumberOfVideoSessions smallint
AS   

    SET NOCOUNT ON;  

	INSERT INTO SemesterCores
	Values (
		@SemesterCode, 
		@SemesterName, 
		(select curriculumID from Curriculums where CurriculumName like @CurriculumName), 
		@NumberOfVideoSessions)

--exec SP_InsertSemesterCore 'AKP', 'AKP Semester', 'ISOM', 2222