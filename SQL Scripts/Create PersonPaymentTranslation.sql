CREATE TABLE [dbo].[PersonPaymentTranslation](
    [personpaytID] [int] IDENTITY(1,1) NOT NULL,
    [personID] [int] NOT NULL
	      REFERENCES [Persons](personID),
    [translationStepID] [int] NOT NULL
	      REFERENCES [TranslationSteps](tsID),
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL,
 CONSTRAINT [PK_PersonPaymentTranslation] PRIMARY KEY CLUSTERED 
(
    [personpaytID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)