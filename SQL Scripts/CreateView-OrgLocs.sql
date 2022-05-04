--use [gtn-dev]

CREATE VIEW dbo.OrgLocs
AS
select O.*, L.City, L.State, L.Country from organizations O
join locations L on L.locID = O.locID


