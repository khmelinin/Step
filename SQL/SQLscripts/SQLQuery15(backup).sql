use Restaurant;
go

backup database Restaurant
-- right click on server -> properties -> database settings -> backups
to disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\Restaurant.bak' 
mirror to disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\Restaurant1.bak'
with differential -- with norecovery -- with description='bla bla bla', stats=1, format
go

backup log Restaurant 
to disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\Restaurant.log'

insert into R (title) values (N'qwerty')

restore database Restaurant 
from disk = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\Restaurant.bak'
