USE [gtn]
GO

/****** Object:  Table [dbo].[SessionDist]    Script Date: 5/5/2022 12:52:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

drop table [dbo].[SessionDist]
CREATE TABLE [dbo].[SessionDist](
	[sessionDistID] [int] NOT NULL,
	[sessionID] [int] NOT NULL,
	[mediaTypeIDs] [varchar](24) NOT NULL,
	[locID] [int] NOT NULL,
	[ArchiveFormat] [char](1) NOT NULL,
	[personID] [int] NULL,
	[Masters] [bit] NULL,
	[Notes] [varchar](max) NULL,
 CONSTRAINT [PK_SemesterDist] PRIMARY KEY CLUSTERED 
(
	[sessionDistID], [sessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([locID])
REFERENCES [dbo].[Locations] ([locID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([sessionID])
REFERENCES [dbo].[Sessions] ([sessionID])
GO

ALTER TABLE [dbo].[SessionDist]  WITH CHECK ADD FOREIGN KEY([sessionDistID])
REFERENCES [dbo].[SessionDistSets] ([sessionDistID])
GO


