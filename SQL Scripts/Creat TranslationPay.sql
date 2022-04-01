CREATE TABLE [dbo].[TranslationPay](
    [tpId] [int] IDENTITY(1,1) NOT NULL,
    [tsId] [int] NOT NULL
	      REFERENCES [TranslationSteps](tsID),
    [langId] [int] NOT NULL
	      REFERENCES [Languages](personID),
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL,
 CONSTRAINT [PK_TranslationLog] PRIMARY KEY CLUSTERED 
(
    [tlID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)