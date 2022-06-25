USE [gtn-dev]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetNext_SessionDistr]    Script Date: 5/5/2022 4:35:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE PROCEDURE [dbo].[SP_GetNext_SessionDistr] 
ALTER PROCEDURE [dbo].[SP_GetNext_SessionDistr] 
	@mmYear varchar(7)
AS   
    SET NOCOUNT ON; 

-- Get a list of Session Dist Sets based on the Course codes passed, for the language indicated

declare @maxIndex varchar(3)
declare @retVal varchar(10)
declare @nextId varchar(3)

--select * from SessionDistSets
select @maxIndex = max(Cast(substring(DistMonthYear,8,3) AS INT)) from SessionDistSets where DistMonthYear like concat(@mmYear, '%')

if @maxIndex IS NULL
begin
	-- insert TEMP row and return next value
	insert into SessionDistSets values (@mmYear + '-001', 'TEMP', (select max(locID) from Locations),'T',Null,0,Null)
	select @mmYear + '-001'
end
else
begin
	-- insert TEMP row and return next value
	set @nextId = (select cast(@maxIndex as int)) + 1
	insert into SessionDistSets values (@mmYear + '-' + Right('00000' + @nextId,3), 'TEMP', (select max(locID) from Locations),'T',Null,0,Null)
	select @mmYear + '-' + Right('00000' + @nextId,3)
end

--exec SP_GetNext_SessionDistr '062022'
-- select * from SessionDistSets 
-- delete from SessionDistSets where mediaTypeIDs like 'TEMP'







