USE [gtn]
GO
/****** Object:  StoredProcedure [sys].[SP_FkTables]    Script Date: 1/10/2022 1:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SP_FkTables]
(
    @pktable_name        sysname = null,    -- Wildcard pattern matching IS NOT supported.
    @pktable_owner       sysname = null,    -- Wildcard pattern matching IS NOT supported.
    @pktable_qualifier   sysname = null,    -- Wildcard pattern matching IS NOT supported.
    @fktable_name        sysname = null,    -- Wildcard pattern matching IS NOT supported.
    @fktable_owner       sysname = null,    -- Wildcard pattern matching IS NOT supported.
    @fktable_qualifier   sysname = null     -- Wildcard pattern matching IS NOT supported.
)
as
    set nocount on

    declare @pktable_id             int
    declare @fktable_id             int
    declare @tcount		            int

	SELECT @tcount = count(*) FROM SYSOBJECTS WHERE xtype = 'U' and name = @pktable_name
	if @tcount = 0 
	begin
		select 'XXXCouldNotFindPassedTable' As KeyedTable
		RETURN -1
	end

    -- select 'XXX starting parameter analysis'
    if (@pktable_name is null) and (@fktable_name is null)
    begin   -- If neither primary key nor foreign key table names given
        raiserror (15252,-1,-1)
        return
    end

    if @fktable_qualifier is not null
    begin
        if db_name() <> @fktable_qualifier
        begin   -- If qualifier doesn't match current database
            raiserror (15250, -1,-1)
            return
        end
    end

    if @pktable_qualifier is not null
    begin
        if db_name() <> @pktable_qualifier
        begin   -- If qualifier doesn't match current database
            raiserror (15250, -1,-1)
            return
        end
    end

    if @pktable_owner = ''
    begin   -- If empty owner name
        select @pktable_id = object_id(quotename(@pktable_name))
    end
    else
    begin
        select @pktable_id = object_id(isnull(quotename(@pktable_owner), '') + '.' + quotename(@pktable_name))
    end

    if @fktable_owner = ''
    begin   -- If empty owner name
        select @fktable_id = object_id(quotename(@fktable_name))
    end
    else
    begin
        select @fktable_id = object_id(isnull(quotename(@fktable_owner), '') + '.' + quotename(@fktable_name))
    end

    if @fktable_name is not null
    begin
        if @fktable_id is null
            select @fktable_id = 0  -- fk table name is provided, but there is no such object
    end

    if @pktable_name is not null
    begin
        if @pktable_id is null
            select @pktable_id = 0  -- pk table name is provided, but there is no such object

        select
            --PKTABLE_QUALIFIER   = convert(sysname,db_name()),
            --PKTABLE_OWNER       = convert(sysname,schema_name(o1.schema_id)),
            --PKTABLE_NAME        = convert(sysname,o1.name),
            --PKCOLUMN_NAME       = convert(sysname,c1.name),
            --FKTABLE_QUALIFIER   = convert(sysname,db_name()),
            --FKTABLE_OWNER       = convert(sysname,schema_name(o2.schema_id)),
            KeyedTable	          = convert(sysname,o2.name) 
            --FKCOLUMN_NAME       = convert(sysname,c2.name),
            -- Force the column to be non-nullable (see SQL BU 325751)
            --KEY_SEQ             = isnull(convert(smallint,k.constraint_column_id), sysconv(smallint,0)),
            --UPDATE_RULE         = convert(smallint,
            --                                case f.update_referential_action
            --                               when 1 then 0
            --                              when 0 then 1
            --                             else f.update_referential_action
            --                            end),
            --DELETE_RULE         = convert(smallint,
            --                                case f.delete_referential_action
            --                                when 1 then 0
            --                                when 0 then 1
            --                                else f.delete_referential_action
            --                                end),
            --FK_NAME             = convert(sysname,object_name(f.object_id)),
            --PK_NAME             = convert(sysname,i.name),
            --DEFERRABILITY       = convert(smallint, 7)   -- SQL_NOT_DEFERRABLE
        from
            sys.objects o1,
            sys.objects o2,
            sys.columns c1,
            sys.columns c2,
            sys.foreign_keys f inner join
            sys.foreign_key_columns k on (k.constraint_object_id = f.object_id) inner join
            sys.indexes i on (f.referenced_object_id = i.object_id and f.key_index_id = i.index_id)
        where
            o1.object_id = f.referenced_object_id and
            (o1.object_id = @pktable_id) and
            o2.object_id = f.parent_object_id and
            (@fktable_id is null or o2.object_id = @fktable_id) and
            c1.object_id = f.referenced_object_id and
            c2.object_id = f.parent_object_id and
            c1.column_id = k.referenced_column_id and
            c2.column_id = k.parent_column_id
        --order by 5, 6, 7, 9, 8
    end
--[SP_FkTables] Curriculums
