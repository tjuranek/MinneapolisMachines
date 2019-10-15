use master
go

-- if necessary, delete the backups, kick out any active users, and delete the database
if exists (select * from sys.databases where name = N'MinneapolisMachines')
begin
	exec msdb.dbo.sp_delete_database_backuphistory @database_name = N'MinneapolisMachines';
	alter database MinneapolisMachines set single_user with rollback immediate;
	drop database MinneapolisMachines;
end

-- create the database
create database MinneapolisMachines
go
