create database Restaurant
use Restaurant

create table Articles
(
articleId int not null primary key,
articleTitle nvarchar(20),
articlePrice money
)

create table Dishes 
(
dishId int not null primary key,
dishTitle nvarchar(20),
[begin] date not null,
[end] date null
)

create table DishesDetails
(
id int not null primary key
dishId int not null foreign key references Dishes(dishId),
articleId int not null foreign key references Articles(articleId),
amount double,
[begin] date not null,
[end] date null
)

