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

--insert into Articles (articleTitle) values (N'’Î≥·')

--insert into Articles (articleTitle) values (N'ıÎ≥·')

--insert into Articles (articleTitle) values (N'ÃÓÎÓÍÓ')

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

create table Documents (
documentId timestamp not null primary key,
documentType nchar(3) not null,
articleId int not null foreign key references Articles (articleId),
customerId int not null foreign key references Customers (customerId),
documentDate date not null, 
price money not null,
amount int not null)
go

create function getArticleId (@articleTitle nvarchar(20))
returns int
as
begin
	declare @result int;
	select @result=articleId from Articles where lower(articleTitle) = lower(@articleTitle);
	return @result
end


create proc addDocument @type nchar(3), @articleTitle nvarchar(20), @customerTitle nvarchar(20),
@date date, @price money, @amount int
as
begin
	declare @articleId int;
	declare @customerId int;
	set @articleId = dbo.getArticleId(@articleTitle);
	if @articleId is null
	begin
		declare @temp table (id int)
		insert into Articles (articleTitle)
		output inserted.articleId into @temp (id)
		values (@articleTitle);
		select @articleId=id from @temp;
	end

	exec addCustomer @customerTitle;
	select @customerId=customerId from Customers where lower(customerTitle)= lower(@customerTitle)
	insert into Documents (documentType, articleId, customerId, documentDate, price, amount)
	values (@type, @articleId, @customerId, @date, @price, @amount)
end;



create proc addInputDocument @articleTitle nvarchar(20), @customerTitle nvarchar(20),
@date date, @price money, @amount int
as
begin
	exec addDocument N'IN', @articleTitle, @customerTitle, @date, @price, @amount
end
go

create proc addOutputDocument @articleTitle nvarchar(20), @customerTitle nvarchar(20),
@date date, @price money, @amount int
as
begin
	exec addDocument N'OUT', @articleTitle, @customerTitle, @date, @price, @amount
end
go