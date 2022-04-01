exec msdb.dbo.rds_backup_database 
@source_db_name='gtn',
@s3_arn_to_backup_to='arn:aws:s3:::gtn-sql-backup/akp-4-18-20.bak',
@overwrite_s3_backup_file=1,
@type='FULL';