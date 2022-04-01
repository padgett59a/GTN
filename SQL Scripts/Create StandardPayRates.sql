CREATE TABLE [dbo].[StandardPayRates](
    [StandardPayRateID] [int] IDENTITY(1,1) NOT NULL,
    [stepID] [int] NOT NULL,
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL,
 CONSTRAINT [PK_StandardPayRates] PRIMARY KEY CLUSTERED 
(
    [StandardPayRateID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)