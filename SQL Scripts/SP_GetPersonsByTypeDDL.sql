USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetPersonsByTypeDDL]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GetPersonsByTypeDDL] 
	@PersonTypeText varchar(120)
AS   

    SET NOCOUNT ON; 
	select * from persons where persontypeID = (select persontypeID from personTypes where PersonType = @PersonTypeText)

--exec SP_GetPersonsByTypeDDL 'Instructor'

