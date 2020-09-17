create database Warehouse;
go

use Warehouse;
go

create table Articles (
articleId int not null identity primary key,
articleTitle nvarchar(20) not null);
go

create unique index indTitle on Articles (articleTitle)
go

create table Customers (
customerId int not null identity primary key,
customerTitle nvarchar(20) not null);
go

create unique index indCustomers on Customers (customerTitle)
go

create trigger insArticles on Articles instead of insert
as
begin
	if not exists (select * from Articles 
	where lower(articleTitle) in (select lower(i.articleTitle) from inserted i))
		insert into Articles (articleTitle) select articleTitle from inserted;
end

insert into Articles (articleTitle) values (N'Õë³á')

insert into Articles (articleTitle) values (N'õë³á')

insert into Articles (articleTitle) values (N'Ìîëîêî')

create procedure addCustomer (@customerTitle nvarchar(20))
as
begin
	if exists (select * from Customers 
	where lower(customerTitle)= lower(@customerTitle))
	begin
		print N'Customer (' + @customerTitle +') is present'
		return; 
	end

	insert into Customers (customerTitle) values (@customerTitle)
end

exec addCustomer N'First'

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


create function getArticleAmount(@articleTitle nvarchar(20))
returns @tbl table (articleId int, articleTitle nvarchar(20), price money, amount int)
as
begin
	declare @articleId int;
	set @articleId = dbo.getArticleId(@articleTitle);
	if @articleId is null
		return
	insert into @tbl (articleId, articleTitle, price, amount)
	select i.articleId, a.articleTitle, i.price, 
		case when o.outAmount is null then i.inAmount 
			else i.inAmount - o.outAmount end
	from
		(select d.articleId, d.price, sum(d.amount) inAmount
		 from Documents d 
		 where d.documentType=N'IN'
		 group by d.articleId, d.price) i
	left join
		(select d.articleId, d.price, sum(d.amount) outAmount
		from Documents d 
		where d.documentType=N'OUT'
		group by d.articleId, d.price) o
	on i.articleId=o.articleId and i.price=o.price
	inner join Articles a on i.articleId=a.articleId
	where a.articleId=@articleId
	return
end


alter proc addOutputDocument @articleTitle nvarchar(20), @customerTitle nvarchar(20),
@date date, @amount int
as
begin
	declare @tbl table (articleId int, articleTitle nvarchar(20), price money, amount int)
	insert into @tbl select * from dbo.getArticleAmount(@articleTitle);
	if exists (select sum(amount) from @tbl having sum(amount)>@amount)
	begin
		declare @price money;
		declare @amountExist int;
		declare article_cursor cursor for 
		select price, amount from @tbl;
		open article_cursor;
		fetch next from article_cursor into @price, @amountExist;
		while @@FETCH_STATUS = 0
		begin
			declare @a int;
			if @amount > @amountExist
				set @a = @amountExist
			else
				set @a = @amount;

			exec addDocument N'OUT', @articleTitle, @customerTitle, @date, @price, @a;
			set @amount -= @a;
			if  @amount = 0
				break;

			fetch next from article_cursor into @price, @amountExist;
		end
	end
end
go

declare @d date;
set @d = GETDATE();
exec addOutputDocument N'õë³á', N'Third', @d, 25
