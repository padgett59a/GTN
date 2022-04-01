CREATE TABLE [dbo].[TranslationPay](
    [tpId] [int] IDENTITY(1,1) NOT NULL,
    [tsId] [int] NOT NULL
	      REFERENCES [TranslationSteps](tsID),
    [langID] [int] NOT NULL
	      REFERENCES [Languages](langID),
    [DefaultPayDollars] [decimal](19,2) NOT NULL,
    [Notes] [varchar](200) NULL,
 CONSTRAINT [PK_TranslationPay] PRIMARY KEY CLUSTERED 
(
    [tpId] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)