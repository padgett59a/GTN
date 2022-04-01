exec msdb.dbo.rds_restore_database 
@restore_db_name='gtn-restored', 
@s3_arn_to_restore_from='arn:aws:s3:::gtn-sql-backup/akp-4-18-20.bak'