CREATE TABLE [dbo].[SemesterDist](
    [semesterID] [int] NOT NULL
	      REFERENCES [semester](semesterID),
    [LangID] [int] NOT NULL
	      REFERENCES [Languages](LangID),
    [LocID] [int] NOT NULL
	      REFERENCES [Locations](LocID),
    [medTypeID] [int] NOT NULL
	      REFERENCES [MediaTypes](mediaTypeID),
    [ArchiveFormat] [char](1) NOT NULL
 CONSTRAINT [PK_SemesterDist] PRIMARY KEY CLUSTERED 
(
    semesterID, LangID, LocID, medTypeID, ArchiveFormat ASC

 )WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
 )
 