USE [gtn]
GO

--DROP TABLE Sessions
--GO

/****** Object:  Table [dbo].[Sessions]    Script Date: 8/7/2021 12:30:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Sessions](
	[sessionID] [int] IDENTITY(1,1) NOT NULL,
	[sessionCoreID] [int] NOT NULL,
	[langID] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD FOREIGN KEY([sessionCoreID])
REFERENCES [dbo].[SessionCores] ([sessionCoreID])

GO

ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD FOREIGN KEY([langID])
REFERENCES [dbo].[Languages] ([langID])
GO 

SET ANSI_PADDING OFF
GO


