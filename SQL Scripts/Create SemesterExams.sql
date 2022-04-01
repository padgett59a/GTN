--SemesterExams

CREATE TABLE [dbo].[SemesterExams](
    [semexamID] [int] IDENTITY(1,1) NOT NULL,
    [semesterID] [int] NOT NULL
	      REFERENCES [Semesters](semesterID),
    [SemesterExamCode] [varchar](12) NOT NULL,
    [statusID] [int] NOT NULL
	      REFERENCES [Statuses](statusID),
    [notes] [varchar](200) NULL
 CONSTRAINT [PK_SemesterExams] PRIMARY KEY CLUSTERED 
(
    [semexamID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)