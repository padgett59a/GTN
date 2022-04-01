USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInstructorsDDL]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetPersonsByTypeDDL] 
AS   

    SET NOCOUNT ON; 
	select personID, FullName from persons where persontypeID = (select persontypeID from personTypes where PersonType = 'Instructor')

--exec SP_GetInstructorsDDL

