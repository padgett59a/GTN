/*
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
*/ 

--drop table personTypes
use gtn
create table PersonTypes(
personTypeID int IDENTITY(1,1) NOT NULL,
personType varchar (120) NOT NULL
 CONSTRAINT [PK_PersonType] PRIMARY KEY CLUSTERED 
(
    [personTypeID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

use gtn
delete from PersonTypes
DBCC CHECKIDENT ('[PersonTypes]', RESEED, 0);
select * from PersonTypes

insert into PersonTypes values('Customer')
insert into PersonTypes values('Administrator')
insert into PersonTypes values('Translator')
insert into PersonTypes values('Masterer')
insert into PersonTypes values('Archiver')

select * from PersonTypes



