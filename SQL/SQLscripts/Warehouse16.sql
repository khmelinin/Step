--create database Warehouse;
--go

--use Warehouse;
--go

--create table Articles (
--articleId int not null identity primary key,
--articleTitle nvarchar(20) not null);
--go

--create unique index indTitle on Articles (articleTitle)
--go

--create table Customers (
--customerId int not null identity primary key,
--customerTitle nvarchar(20) not null);
--go

--create unique index indCustomers on Customers (customerTitle)
--go

--create trigger insArticles on Articles instead of insert
--as
--begin
--	if not exists (select * from Articles 
--	where lower(articleTitle) in (select lower(i.articleTitle) from inserted i))
--		insert into Articles (articleTitle) select articleTitle from inserted;
--end

--insert into Articles (articleTitle) values (N'Хліб')

--insert into Articles (articleTitle) values (N'хліб')

--insert into Articles (articleTitle) values (N'Молоко')

--create procedure addCustomer (@customerTitle nvarchar(20))
--as
--begin
--	if exists (select * from Customers 
--	where lower(customerTitle)= lower(@customerTitle))
--	begin
--		print N'Customer (' + @customerTitle +') is present'
--		return; 
--	end

--	insert into Customers (customerTitle) values (@customerTitle)
--end

--exec addCustomer N'First'