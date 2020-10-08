create database OnlineShop
go
use OnlineShop
go

create table Categories(
categoryId int not null identity primary key,
categoryTitle nvarchar(30) not null
)

insert into Categories(categoryTitle) values 
(N'Calculators'),
(N'Laptops')

create table Characteristics(
characteristicId int not null identity primary key,
characteristicTitle nvarchar(30) not null
)

insert into Characteristics(characteristicTitle) values 
(N'Red'),
(N'Black'),
(N'Powerful'),
(N'Compact')

create table Item(
itemId int not null identity primary key,
itemTitle nvarchar(30) not null,
creator nvarchar(30) not null,
info nvarchar(max),
categoryId int not null
)

insert into Item(itemTitle, creator, info, categoryId) values 
(N'BX310', N'Toshiba', N'simple calculator', 1), 
(N'Cerberus', N'Acer', N'Gamic laptop', 2)

create table ItemCharacteristics
(
itemId int not null,
characteristicId int not null
);

insert into ItemCharacteristics (itemId, characteristicId) values
(1, 2),
(1,4),
(2,3),
(2,1)