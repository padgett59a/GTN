use [gtn-dev]
exec sp_fkeys sessioncores

alter table sessions drop constraint FK__Sessions__sessio__1D7B6025

alter table sessionCores drop constraint PK_Session

alter table sessioncores add constraint PK_SessionCores
Primary Key Clustered (sessionCoreID)

--put fk back
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD FOREIGN KEY([sessionCoreID])
REFERENCES [dbo].[SessionCores] ([sessionCoreID])

exec sp_fkeys sessions

ALTER TABLE [dbo].[MasteringLog] 
drop constraint FK__Mastering__sessi__24285DB4

ALTER TABLE [dbo].[TranslationLog] 
drop constraint FK__Translati__sessi__2334397B

alter table sessions drop constraint PK_SessionID 

alter table sessions add constraint PK_Sessions
Primary Key Clustered (sessionID)

--Drop FKs

-- Put FKs back
ALTER TABLE [dbo].[MasteringLog]  WITH CHECK ADD FOREIGN KEY([sessionID])
REFERENCES [dbo].[Sessions] ([sessionID])

ALTER TABLE [dbo].[TranslationLog]  WITH CHECK ADD FOREIGN KEY([sessionID])
REFERENCES [dbo].[Sessions] ([sessionID])
