--use [gtn-dev]

CREATE VIEW dbo.SessionDistSetsJoined
AS

select SDS.*, LO.City, LO.State, LO.Country, P.FullName, LA.langName, SC.SessionName, CC.CourseName
from sessiondistsets SDS
inner join Locations LO on SDS.locID = LO.locID
Left outer join Persons P on P.personID = SDS.personID
inner join SessionDist SD on SD.sessionDistID = SDS.sessionDistID
inner join Sessions S on S.SessionID = SD.SessionID
inner Join SessionCores SC on S.sessionCoreID = SC.sessionCoreID
inner Join Languages LA on LA.langID = S.langID
inner Join CourseCores CC on CC.courseCoreID = SC.courseCoreID
--order by LA.langName, CC.CourseName, SC.SessionName

-- Select * from SessionDistSetsJoined