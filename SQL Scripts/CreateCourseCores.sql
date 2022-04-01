USE [gtn]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 8/7/2021 11:49:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Courses]  WITH CHECK ADD FOREIGN KEY([instructorID])
REFERENCES [dbo].[Persons] ([personID])
GO


