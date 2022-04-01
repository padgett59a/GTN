CREATE TABLE [dbo].[ExamTranslationLog](
    [exam-tlID] [int] IDENTITY(1,1) NOT NULL,
    [exam-tsID] [int] NOT NULL
	      REFERENCES [ExamTranslationSteps]([exam-tsID]),
    [semexamID] [int] NOT NULL
	      REFERENCES [SemesterExams](semexamID),
    [personID] [int] NOT NULL
	      REFERENCES [Persons](personID),
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL
 CONSTRAINT [PK_ExamTranslationLog] PRIMARY KEY CLUSTERED 
(
    [exam-tlID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)