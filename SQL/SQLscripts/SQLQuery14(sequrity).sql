create login test with password='123456' must_change, CHECK_EXPIRATION=ON --, check_policy=on
-- test1234
go

--create login <domain_name>\<login> from windows

alter server role dbcreator add member test
alter server role dbcreator drop member test

create server role testServerRole 
drop server role testServerRole 

create user test_new for login test

alter role testServerRole add member test_new

grant select on dbo.Orders to test_custom
