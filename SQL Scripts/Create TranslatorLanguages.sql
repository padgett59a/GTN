--TranslatorLanguages

CREATE TABLE [dbo].[TranslatorLanguages](
    [personID] [int] NOT NULL
	      REFERENCES [Persons](personID),
    [langID] [int] NOT NULL
	      REFERENCES [Languages](langID),
)