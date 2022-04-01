CREATE TABLE [dbo].[MasteringPay](
    [mpId] [int] IDENTITY(1,1) NOT NULL,
    [msId] [int] NOT NULL
	      REFERENCES [MasteringSteps](msID),
    [langID] [int] NOT NULL
	      REFERENCES [Languages](langID),
    [DefaultPayDollars] [decimal](19,2) NOT NULL,
    [Notes] [varchar](200) NULL,
 CONSTRAINT [PK_MasteringPay] PRIMARY KEY CLUSTERED 
(
    [mpId] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)