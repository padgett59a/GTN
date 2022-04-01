CREATE TABLE [dbo].[PersonPayRates](
    [personPayRateID] [int] IDENTITY(1,1) NOT NULL,
    [personID] [int] NOT NULL
	      REFERENCES [Persons](personID),
    [stepID] [int] NOT NULL,
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL,
 CONSTRAINT [PK_PersonPayRates] PRIMARY KEY CLUSTERED 
(
    [personPayRateID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)