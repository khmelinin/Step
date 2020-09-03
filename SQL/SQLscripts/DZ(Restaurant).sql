create database Restaurant
use Restaurant

create table Articles
(
articleId int not null identity primary key,
articleTitle nvarchar(20),
articlePrice money
)

insert into Articles (articleTitle, articlePrice) values
(N'Tomatoes', 13),
(N'Eggs', 1),
(N'Flour', 10),
(N'Cheese', 30),
(N'Chicken meat', 40),
(N'Fresh tomatoes', 14)

create table Dishes 
(
dishId int not null identity primary key,
dishTitle nvarchar(20),
[begin] date not null,
[end] date null
)

insert into Dishes (dishTitle, [begin], [end]) values
(N'Margaritta', '09-02-2010', null),
(N'Margaritta and meat', '09-02-2010', null),
(N'Shaverma', '02-03-2011', '09-04-2017')

create table DishesDetails
(
id int not null identity primary key,
dishId int not null foreign key references Dishes(dishId),
articleId int not null foreign key references Articles(articleId),
amount int not null,
[begin] date not null,
[end] date null
)

insert into DishesDetails(dishId, articleId, amount, [begin], [end]) values
(1, 1, 1, '09-02-2010', '09-02-2011'),
(1, 2, 2, '09-02-2010', null),
(1, 3, 1, '09-02-2010', null),
(1, 4, 1, '09-02-2010', null),
(1, 6, 1, '09-02-2011', null),
(2, 1, 1, '09-02-2010', '09-02-2011'),
(2, 2, 2, '09-02-2010', null),
(2, 3, 1, '09-02-2010', null),
(2, 4, 1, '09-02-2010', null),
(2, 5, 1, '09-02-2011', null),
(2, 6, 1, '09-02-2011', null),
(3, 1, 2, '02-03-2011', '09-04-2017'),
(3, 2, 1, '02-03-2011', '09-04-2017'),
(3, 3, 1, '02-03-2011', '09-04-2017'),
(3, 4, 1, '02-03-2011', '09-04-2017'),
(3, 5, 1, '02-03-2011', '09-04-2017') 

-- Menu
select d.dishTitle, sum(a.articlePrice*dd.amount) from DishesDetails as dd 
inner join Dishes as d on d.dishId=dd.dishId
inner join Articles as a on a.articleId=dd.articleId
group by d.dishTitle

--Detailed Menu by dish
declare @dishId int = 1
select a.articleTitle, a.articlePrice as price_per_one, dd.amount as amount, a.articlePrice*dd.amount as price_total from DishesDetails as dd
inner join Dishes as d on d.dishId=dd.dishId
inner join Articles as a on a.articleId=dd.articleId where dd.dishId=@dishId