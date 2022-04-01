USE [gtn]
GO

/****** Object:  Table [dbo].[Semesters]    Script Date: 8/3/2021 4:29:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Semesters](
	[semesterID] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](100) NULL,
	[SemesterCode] [varchar](16) NULL,
	[curriculumID] [int] NULL,
	[NumberOfVideoSessions] [smallint] NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[semesterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Semesters]  WITH CHECK ADD FOREIGN KEY([curriculumID])
REFERENCES [dbo].[Curriculums] ([curriculumID])
GO


