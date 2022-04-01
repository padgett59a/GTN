USE [gtn]
GO
/****** Object:  StoredProcedure [dbo].[[SP_TableGetNotesShort]]    Script Date: 12/7/2021 12:32:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_TableGetNotesShort] 
	@TableName varchar(120),
	@charCount smallint
AS   
    SET NOCOUNT ON; 

DECLARE @colName varchar(100), @dynSQL nvarchar(2000);

DECLARE colCursor CURSOR for 
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName

set @dynSQL = 'select'

OPEN colCursor
Fetch next from colCursor into @colName

WHILE @@FETCH_STATUS = 0  
BEGIN  
	-- Include comma in case NOTES is not the last column in the table
	IF UPPER (@colName) = 'NOTES'
	BEGIN
		SET @dynSQL = @dynSQL + ' LEFT(' + @colName + ',' + TRIM(STR(@charCount)) + '),'
	END 
	ELSE
	BEGIN
		SET @dynSQL = @dynSQL + ' ' + @colName + ','
	END
	--Print @colName
	Fetch next from colCursor into @colName
END

SET @dynSQL = SUBSTRING (@dynSQL, 1, LEN(@dynSQL) -1)
SET @dynSQL = @dynSQL + ' FROM ' + @TableName

--print @dynSQL
EXECUTE sp_executesql @dynSQL

CLOSE colCursor
DEALLOCATE colCursor

-- exec [SP_TableGetNotesShort] 'SemesterCores', 5



