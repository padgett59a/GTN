--Use [gtn]
--Use [gtn-dev]

--returns rows from a comma separated string
--USAGE: SELECT * FROM dbo.SplitCSVs('aby,123')

CREATE FUNCTION dbo.SplitCSVs (@CSVString varchar(1000))

RETURNS @SeparatedValues TABLE (Value VARCHAR(100))
AS
BEGIN
 DECLARE @CommaPosition INT
 WHILE (CHARINDEX(',', @CSVString, 0) > 0)
 BEGIN
  SET @CommaPosition = CHARINDEX(',', @CSVString, 0)
  INSERT INTO @SeparatedValues (Value)
  SELECT SUBSTRING(@CSVString, 0, @CommaPosition)
  SET @CSVString = STUFF(@CSVString, 1, @CommaPosition, '')
 END
  INSERT INTO @SeparatedValues (Value)
  SELECT @CSVString

 RETURN
END
