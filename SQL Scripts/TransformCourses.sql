USE [gtn]
GO

/****** Object:  Table [dbo].[CoursesNew]    Script Date: 8/6/2021 5:51:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CoursesNew](
	[courseID] [int] NOT Null,
	[semesterID] [int] NOT NULL,
	[semesterCode] [varchar](16) NULL,
	[CourseName] [varchar](100) NULL,
	[CourseLetterCode] [varchar](16) NULL,
	[HasWorkbook] [bit] NULL,
	[HasVideoText] [bit] NULL,
	[instructorID] [int] NULL,
	[VideosInHand] [bit] NULL,
	[MasteringFilesInHand] [bit] NULL,
	[TextFilesInHand] [bit] NULL,
	[CourseNumberCode] [smallint] NULL,
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_CoursesNew] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--ALTER TABLE [dbo].[CoursesNew]  WITH CHECK ADD FOREIGN KEY([semesterCode])
--REFERENCES [dbo].[SemesterCores] ([semesterCode])
--GO

ALTER TABLE [dbo].[CoursesNew]  WITH CHECK ADD FOREIGN KEY([instructorID])
REFERENCES [dbo].[Persons] ([personID])
GO

drop table coursesnew

--select * into coursesOrig from courses 

begin tran
 
 ALTER TABLE coursesnew drop column semesterid
 
 insert into coursesNew
(
 	[courseID],
	[semesterID],
--	[semesterCode], 
	[CourseName], 
	[CourseLetterCode], 
	[HasWorkbook], 
	[HasVideoText],
	[instructorID], 
	[VideosInHand], 
	[MasteringFilesInHand],
	[TextFilesInHand], 
	[CourseNumberCode], 
	[Notes] 
)
select 
 	[courseID],
	[semesterID],
--	[semesterCode], 
	[CourseName], 
	[CourseLetterCode], 
	[HasWorkbook], 
	[HasVideoText],
	[instructorID], 
	[VideosInHand], 
	[MasteringFilesInHand],
	[TextFilesInHand], 
	[CourseNumberCode], 
	[Notes] [varchar]
	from coursesOrig -- order by courseID

delete from coursesnew

	commit tran

	select * from coursesNew

	drop table coursesNew

	select * from coursesorig
	select * from coursesnew

-- update semestercode from semestersorig
-- drop semesterid
-- add identity back (courseid)
-- add foreign key to semestercords.semestercode
-- coursesnew2, coursesorig


select * into coursesnew2 from coursesnew
drop table coursesnew
SET IDENTITY_INSERT coursesnew OFF

insert into coursesnew 
(
	[courseID],
	[semesterCode],
	[CourseName],
	[CourseLetterCode],
	[HasWorkbook],
	[HasVideoText],
	[instructorID],
	[VideosInHand],
	[MasteringFilesInHand],
	[TextFilesInHand],
	[CourseNumberCode],
	[Notes])
select 
	[courseID],
	[semesterCode],
	[CourseName],
	[CourseLetterCode],
	[HasWorkbook],
	[HasVideoText],
	[instructorID],
	[VideosInHand],
	[MasteringFilesInHand],
	[TextFilesInHand],
	[CourseNumberCode],
	[Notes]
from coursesnew2

select * from coursesnew

ALTER TABLE CoursesNew
ADD FOREIGN KEY (semesterCode)        
REFERENCES SemesterCores(semesterCode)



select * from coursesnew where instructorid is null

alter table sessions drop constraint [courseID FK]

drop table courses
exec sp_rename 'CoursesNew', 'Courses'

ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([courseID])

drop table coursesnew2

select * from semestercores

select * into Semesters from semestersorig 
select * from semesters