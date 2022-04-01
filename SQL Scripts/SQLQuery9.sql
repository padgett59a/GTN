use [gtn-dev]
exec SP_GetTrxCourses 1

select * from translationsteps

update translationsteps set defaultPayDollars = null where tsID = 1;

select * from masteringsteps