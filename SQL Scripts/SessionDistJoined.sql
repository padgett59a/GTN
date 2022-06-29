--use [gtn-dev]
--use [gtn]

Create VIEW dbo.SessionDistJoined
AS

select SD.*, LA.langName
, SC.SessionName
, CC.CourseName
from sessiondist SD
inner join sessions S on S.sessionID = SD.sessionID
inner Join Languages LA on LA.langID = S.langID
inner Join SessionCores SC on S.sessionCoreID = SC.sessionCoreID
inner Join CourseCores CC on CC.courseCoreID = SC.courseCoreID

-- Select * from SessionDistJoined