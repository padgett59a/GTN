ALTER TABLE Courses
ADD FOREIGN KEY (semesterCode)           <-- this needs to be a column of the Employees table
REFERENCES SemesterCores(semesterCode)