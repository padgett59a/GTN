USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteSemesterCoreById]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteSemesterCoreById] 
	@SemesterCode varchar(16)
AS   

    SET NOCOUNT ON; 
	DELETE from SemesterCores where SemesterCode like @SemesterCode

--exec SP_DeleteSemesterCoreById 'AKP08'

