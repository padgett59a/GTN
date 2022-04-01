CREATE TABLE [dbo].[Organizations](
    [orgID] [int] IDENTITY(1,1) NOT NULL,
    [orgName] [varchar] NOT NULL,
 CONSTRAINT [PK_MasteringLog] PRIMARY KEY CLUSTERED 
(
    [orgID] ASC
) WITH (ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)