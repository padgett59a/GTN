
use [gtn-dev]
alter table SessionDistSets add 
	[mediaTypeIDs] [varchar](24) NOT NULL,
	[locID] [int] NOT NULL,
	[ArchiveFormat] [char](1) NOT NULL,
	[personID] [int] NULL,
	[Masters] [bit] Not NULL,
	[Notes] [varchar](max) NULL

alter table SessionDist drop column 
	[mediaTypeIDs],
	[locID],
	[ArchiveFormat],
	[personID],
	[Masters],
	[Notes] 

ALTER TABLE [dbo].[SessionDistSets]  WITH CHECK ADD FOREIGN KEY([locID])
REFERENCES [dbo].[Locations] ([locID])

ALTER TABLE [dbo].[SessionDistSets]  WITH CHECK ADD FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])





