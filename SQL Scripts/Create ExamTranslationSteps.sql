USE [gtn]
GO

/****** Object:  Table [dbo].[MasteringSteps]    Script Date: 4/11/2020 1:52:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ExamTranslationSteps](
	[exam-tsID] [int] IDENTITY(200,1) NOT NULL,
    [semexamID] [int] NOT NULL
	      REFERENCES [SemesterExams](semexamID),
	[Step] [varchar](50) NOT NULL,
	[DefaultPayDollars] [decimal](19, 2) NULL,
    [statusID] [int] NOT NULL
	      REFERENCES [Statuses](statusID),
	[Notes] [varchar](500) NULL,
 CONSTRAINT [PK_ExamTranslationSteps] PRIMARY KEY CLUSTERED 
(
	[exam-tsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


