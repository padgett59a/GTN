CREATE TABLE [dbo].[Curriculums](
	[curriculumID] [int] IDENTITY(1,1) NOT NULL,
	[CurriculumName] [varchar](100) NULL
 CONSTRAINT [PK_Curriculums] PRIMARY KEY CLUSTERED 
(
	[curriculumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into Curriculums values ('ISOM')
insert into Curriculums values ('Nation2Nation')
insert into Curriculums values ('Miscellaneous')