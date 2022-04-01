CREATE TABLE [dbo].[PersonPaymentMastering](
    [personpaymID] [int] IDENTITY(1,1) NOT NULL,
    [personID] [int] NOT NULL
	      REFERENCES [Persons](personID),
    [masteringStepID] [int] NOT NULL
	      REFERENCES [MasteringSteps](msID),
    [amount] [decimal](19,2) NOT NULL,
    [notes] [varchar](200) NULL,
 CONSTRAINT [PK_PersonPaymentMastering] PRIMARY KEY CLUSTERED 
(
    [personpaymID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)