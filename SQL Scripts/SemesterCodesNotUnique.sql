select * from semesters
where semestercode in (
select distinct semestercode from semesters group by semestercode 
having count(semestercode) > 1
)

select * from semesters where semestercode in (30,38)

select semestercode, count(semestercode) from semesters group by semestercode 
having count(semestercode) > 1
30, 38

use gtn
select * from semestersorig
where semestercode in ('W','i','W1','W2','UI','CA')

begin tran
update semestersorig set semestercode = 'W1' where semesterID = 8
commit tran

commit tran
