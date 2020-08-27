create database company
use company

create table Stuff1
(
stuffId int not null identity primary key,
stuffName nvarchar(20) not null,
stuffSurename nvarchar(20) not null,
);

insert into Stuff1(stuffName,stuffSurename) values
('Nikolay','Koval'),
('Michael','Ivanov'),
('Vasya','Pupkin'),
('Petya', 'Petrenkov');

create table Departments
(
departmentId int not null identity primary key,
title nvarchar(20) not null
);

insert into Departments(title) values
('Management'),
('Security'),
('Direction'),
('Informatics');

create table Rangs
(
rangId int not null identity primary key,
title nvarchar(20) not null,
departmentId int not null foreign key references Departments(departmentId)
);

insert into Rangs(departmentId, title) values
(1, 'Manager'),
(1, 'General manager'),
(1, 'Deputy director'),
(2, 'Security guard'),
(2, 'Security director'),
(3, 'Director'),
(4, 'S. a. assistant'),
(4, 'System administrator');

create table RangsStuff
(
rangId int not null foreign key references Rangs(rangId),
stuffId int not null foreign key references Stuff1(stuffId),
date1 date not null,
date2 date
);

insert into RangsStuff(rangId, stuffId, date1) values
();
