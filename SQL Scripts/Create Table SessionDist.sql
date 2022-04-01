USE [gtn-dev]
GO

/****** Object:  Table [dbo].[SessionDist]    Script Date: 3/7/2022 7:37:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SessionDist](
	[semesterID] [int] NOT NULL,
	[langID] [int] NOT NULL,
	[locID] [int] NOT NULL,
	[medTypeID] [int] NOT NULL,
	[ArchiveFormat] [char](1) NOT NULL,
	[personID] [int] NULL,
	[DistDate] [datetime] NULL,
	[Masters] [bit] NULL,
 CONSTRAINT [PK_SemesterDist] PRIMARY KEY CLUSTERED 
(
	[semesterID] ASC,
	[langID] ASC,
	[locID] ASC,
	[medTypeID] ASC,
	[ArchiveFormat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([langID])
REFERENCES [dbo].[Languages] ([langID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([locID])
REFERENCES [dbo].[Locations] ([locID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([medTypeID])
REFERENCES [dbo].[MediaTypes] ([mediaTypeID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([semesterID])
REFERENCES [dbo].[Semesters] ([semesterID])
GO


