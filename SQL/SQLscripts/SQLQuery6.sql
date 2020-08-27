use ExamShop

declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';

create function getOrder(@orderNumber nvarchar(10)) returns table
return
select 1 as [level], N'#' as [Title], cast(orderNumber as nvarchar(50)) as [Value], cast(null as numeric) as Value2 from Orders 
where orderNumber=@orderNumber
union
select 2 N'Date', cast(orderDate as nvarchar(50)) from Orders 
where orderNumber=@orderNumber
union
select 3 N'Manager', m.managerName, null from Orders as o 
inner join Managers as m on o.managerId=m.managerId 
where orderNumber=@orderNumber
union
select 4, a.articleTitle, format(a.articlePrice, 'C'), od.amount from OrderDetails as od 
inner join Orders as o on od.orderId=o.orderId 
inner join Articles as a on od.articleId=a.articleId 
where o.orderNumber=@orderNumber
union
select 5 as level, N'Together', format(sum(a.articlePrice*od.amount),'C'), od.amount from OrderDetails as od 
inner join Orders as o on od.orderId=o.orderId 
inner join Articles as a on od.articleId=a.articleId 
where o.orderNumber=@orderNumber
group by od.orderId

declare @orderNumber nvarchar(10)=N'AAAAAAAAAA';
select * from getOrder(@orderNumber) order by level

----------------------------------------------

create function getOrder_v2 (@orderNumber nvarchar(10))
returns @result table ([level] int, [Title] nvarchar(50), [Value] nvarchar(50), [Value2] nvarchar(50))
as begin
	insert into @result (level, Title,Value, Value2)
	select 1 , N'Номер' , cast(orderNumber as nvarchar(50)), null
	from Orders where orderNumber=@orderNumber 

	insert into @result (level, Title,Value, Value2)
	select 2, N'Дата', cast(orderDate as nvarchar(50)), null from Orders where orderNumber=@orderNumber 

	insert into @result (level, Title,Value, Value2)
	select 3, N'Менеджер', m.managerName, null 
	from Orders o inner join Managers m 
	on o.managerId = m.managerId where orderNumber=@orderNumber 

	insert into @result (level, Title,Value, Value2)
	select 4, a.articleTitle, format(a.articlePrice, 'C'), format(od.amount, '#.##')
	from OrderDetails od inner join Orders o on od.orderId=o.orderId
	inner join Articles a on od.articleId=a.articleId
	where o.orderNumber=@orderNumber

	insert into @result (level, Title,Value, Value2)
	select 5 as level, N'Разом', format(sum(a.articlePrice* od.amount), 'C'), null
	from OrderDetails od inner join Orders o on od.orderId=o.orderId
	inner join Articles a on od.articleId=a.articleId
	where o.orderNumber=@orderNumber
	group by od.orderId
return
end

 

declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';
select *  from getOrder_v2(@orderNumber) order by level

create table properties
(
propertyId int not null identity primary key,
propertyTitle nvarchar(50) not null
)

create table characteristics
(
id int not null identity primary key,
articleId int not null foreign key references Articles(articleId),
propertyId int not null foreign key references properties(propertyId),
[value] nvarchar(100) not null)

--------------------------------
--- ...
--------------------------------

create function getListOfArticles(@n nvarchar(10))
returns nvarchar(50)
begin
    declare @result nvarchar(50) = N''
    select @result += a.articleTitle + N', ' from Orders o
    inner join OrderDetails od on od.orderId=o.orderId
    inner join Articles a on a.articleId=od.articleId
    where o.orderNumber=@n
    return LEFT(@result, LEN(@result) - 1)
end

 

select m.managerName, c.cusomerName, o.orderNumber, o.orderDate, dbo.getListOfArticles(N'#033452'), SUM(a.articlePrice*od.amount) from Orders o
inner join OrderDetails od on od.orderId = o.orderId
inner join Managers m on m.managerId = o.managerId
inner join Articles a on a.articleId = od.articleId
inner join Customers c on c.customerId = o.customerId
group by m.managerName, c.cusomerName, o.orderNumber, o.orderDate
having o.orderNumber=N'#033452'

------------------------------------------------------------------
--- teacher's \/ ---
------------------------------------------------------------------

use ExamShop
go

declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';

alter function getOrder(@orderNumber nvarchar(10)) returns table
return
select 1 as [level], N'Номер' as [Title], 
cast(orderNumber as nvarchar(50)) as [Value], 
cast (null as nvarchar(50)) as Value2
from Orders where orderNumber=@orderNumber 
union
select 2, N'Дата', cast(orderDate as nvarchar(50)), null from Orders where orderNumber=@orderNumber 
union
select 3, N'Менеджер', m.managerName, null 
from Orders o inner join Managers m 
on o.managerId = m.managerId where orderNumber=@orderNumber 
union
select 4, a.articleTitle, format(a.articlePrice, 'C'), format(od.amount, '#.##')
from OrderDetails od inner join Orders o on od.orderId=o.orderId
inner join Articles a on od.articleId=a.articleId
where o.orderNumber=@orderNumber
union
select 5 as level, N'Разом', format(sum(a.articlePrice* od.amount), 'C'), null
from OrderDetails od inner join Orders o on od.orderId=o.orderId
inner join Articles a on od.articleId=a.articleId
where o.orderNumber=@orderNumber
group by od.orderId

declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';
select *  from getOrder(@orderNumber) order by level

alter function getOrder_v2 (@orderNumber nvarchar(10))
returns @result table ([level] int, [Title] nvarchar(50), [Value] nvarchar(50), [Value2] nvarchar(50))
as begin
if exists (select * from Orders where orderNumber=@orderNumber )
	insert into @result (level, Title,Value, Value2)
	select 1 , N'Номер' , cast(orderNumber as nvarchar(50)), null
	from Orders where orderNumber=@orderNumber 
else
	begin
		insert into @result (Title) values (N'Чек не знайдено')
		return
	end
insert into @result (level, Title,Value, Value2)
select 2, N'Дата', cast(orderDate as nvarchar(50)), null from Orders where orderNumber=@orderNumber 

insert into @result (level, Title,Value, Value2)
select 3, N'Менеджер', m.managerName, null 
from Orders o inner join Managers m 
on o.managerId = m.managerId where orderNumber=@orderNumber 

insert into @result (level, Title,Value, Value2)
select 4, a.articleTitle, format(a.articlePrice, 'C'), format(od.amount, '#.##')
from OrderDetails od inner join Orders o on od.orderId=o.orderId
inner join Articles a on od.articleId=a.articleId
where o.orderNumber=@orderNumber

insert into @result (level, Title,Value, Value2)
select 5 as level, N'Разом', format(sum(a.articlePrice* od.amount), 'C'), null
from OrderDetails od inner join Orders o on od.orderId=o.orderId
inner join Articles a on od.articleId=a.articleId
where o.orderNumber=@orderNumber
group by od.orderId
return
end

declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';
select *  from getOrder_v2(@orderNumber) order by level


declare @orderNumber nvarchar(10) = N'AAAAAAAAAA';

ManagerName, CustomerName, OrderNumber, OrderDate, ListOfArticles, Sum

declare @l nvarchar(max) = N''
select @l += articleTitle + N', ' from Articles 
select @l

create function getOrder_v3(@orderNumber nvarchar(10))
returns @result table (
	managerName nvarchar(50), 
	customerName nvarchar(50), 
	orderNumber nvarchar(10), 
	orderDate date,
	listOfArticles nvarchar(max),
	[sum] money)
begin
	declare @list nvarchar(max) = N'';
	select @list += a.ArticleTitle + N',' from Articles a inner join OrderDetails od on a.articleId=od.articleId
	inner join Orders o on od.orderId=o.orderId where o.orderNumber=@orderNumber;
	if (@list is not null)
		set @list = @list

	insert into @result (managerName, customerName, orderNumber, orderDate, listOfArticles, [sum])
	select m.managerName, c.customerName, o.orderNumber, o.orderDate, @list, sum(a.articlePrice*od.amount) 
	from Orders o inner join Managers m on o.managerId=m.managerId
	inner join Customers c on o.customerId = c.customerId
	inner join OrderDetails od on o.orderId=od.orderId
	inner join Articles a on od.articleId = a.articleId
	where o.orderNumber = @orderNumber
	group by m.managerName, c.customerName, o.orderNumber, o.orderDate
	return
end



select [Name] from getManagerAndCustomer(cityName);