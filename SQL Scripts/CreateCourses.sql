USE [gtn]
GO

--DROP TABLE Semesters
--GO

/****** Object:  Table [dbo].[Semesters]    Script Date: 8/7/2021 12:30:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Semesters](
	[semesterID] [int] IDENTITY(1,1) NOT NULL,
	[SemesterCode] [varchar](16) NULL,
	[langID] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Semesters]  WITH CHECK ADD FOREIGN KEY([semesterCode])
REFERENCES [dbo].[SemesterCores] ([semesterCode])

GO

ALTER TABLE [dbo].[Semesters]  WITH CHECK ADD FOREIGN KEY([langID])
REFERENCES [dbo].[Languages] ([langID])
GO 

SET ANSI_PADDING OFF
GO


