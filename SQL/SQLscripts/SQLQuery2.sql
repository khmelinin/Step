
--create database shop;

--use shop;
--go

--create table Recepts (
--receipsID int not null identity(1,2) primary key,
--receiptTitle nvarchar(20),
--receiptDate date);
--go


--insert into Recepts (receiptTitle, receiptDate)
--values (N'First', '2020-07-13')

--select * from Recepts

--create table Articles (
--	articleID int not null identity primary key,
--	articleTitle nvarchar(20) not null,
--	articleDescription nvarchar(500)
--);

--create table [Receipt Details] (
--	id int not null identity primary key,
--	receiptId int not null,
--	articleId int not null,
--	price money not null,
--	amount decimal
--);

--insert into Articles (articleTitle, articleDescription)
--values (N'Plombire' ,N'Bread Ukrainian')
--(N'Kolbasa'),
--(N'Vodka')

--insert into [Receipt Details] (receiptId, articleId, price, amount)
--values
--(1,1,14.0,1),
--(1,2,14.0,0.5),
--(1,3,85.0,1),

--(2,1,64.0,1),
--(2,2,124.0,1),
--(2,4,454.0,1),

--(3,7,24.0,0.8),
--(3,4,40.0,5)

--create unique index ind on [Receipt Details] (receiptId, articleId)

--select price, amount, price*amount from [Receipt Details] where (price = 85.00 and amount = 1)

-- ctrl + shift + r

--select a.articleTitle, rd.price, rd.amount, rd.price*rd.amount as summa from [Receipt Details] as rd, [Articles] as a where rd.articleId=a.articleId

--select a.articleTitle, rd.price, rd.amount, rd.price*rd.amount as summa from [Receipt Details] as rd right join [Articles] as a on rd.articleId=a.articleId

--- 3 ---

/*
use shop;

go

select * from [Receipt Details] as rd
where articleId in (1,2,3)

select 1 as [row], rd.receiptId, a.articleTitle, rd.amount, rd.amount*rd.price as summa
from [Receipt Details] as rd left join [Articles] as a on rd.articleId=a.articleID
union
select 2, rd.receiptId, N' TOGETHER', null, SUM(rd.amount*rd.price) from [Receipt Details] as rd
group by rd.receiptId
order by rd.receiptId,[row]

select r.receiptTitle, r.receiptDate
from Recepts as r inner join [Receipt Details] as rd
on r.receipsID=rd.receiptId
inner join Articles as a on rd.articleId=a.articleID
where a.articleTitle like N'Kol%'

select r.receiptTitle, r.receiptDate, SUM(rd.amount*rd.price)
from [Receipt Details] as rd
inner join Recepts as r on rd.receiptId=r.receipsID
group by r.receiptTitle, r.receiptDate
having SUM(rd.amount*rd.price) > 300

select a.articleTitle, SUM(rd.amount*rd.price)
from [Receipt Details] as rd
right join Articles as a on a.articleID=rd.articleId
group by a.articleTitle

alter table [Receipt Details]
add constraint FK_RD_Articles foreign key (articleId) references Articles (articleID)

alter table [Receipt Details]
add constraint FK_RD_R foreign key (receiptId) references Recepts on delete cascade

delete from Recepts where receipsID=3
*/

--- 4 ---
use school;

create table Students (
	studentId int not null identity primary key,
	name_ nvarchar(20) not null
);

create table Subjects (
	subjectId int not null identity primary key,
	name_ nvarchar(20) not null
);

create table Marks (
	studentId int not null identity primary key,
	mark int not null
);

create table Teachers (
	teacherId int not null identity primary key,
	teacherName nvarchar(20) not null
);

create table TeacherSubject (
	subjectId int not null foreign key references Subjects,
	teacherId int not null foreign key references Teachers
);

insert into Students(name_)
values
(N'Vasya Pupkin'),
(N'Petya Petuhov'),
(N'Nina Kalashnikov')

insert into Subjects(name_)
values
(N'C'),
(N'C++'),
(N'C#'),
(N'Objective C'),
(N'Swift')

insert into Marks(studentId, mark)
values
(1, 8),
(1, 9),
(2, 10),
(2, 6),
(3, 11),
(3, 9)

insert into Teachers(teacherName)
values
(N'Ganzenko'),
(N'Vasilenko'),
(N'Chumak')

select * from Teachers
select * from TeacherSubject

insert into TeacherSubject (teacherId, subjectId)
select teacherId, subjectId from Teachers, Subjects
where teacherId=2 and name_ like N'C[+#]%'



select * from Students as s left join Marks as m on s.studentId=m.studentId
left join Subjects as sb on s.studentId=sb.subjectId
group by s.name_, sb.name_

/*
use shop;
update Articles
set
articleTitle=N'Chocolate icecream'
where
articleID=7
*/

create database shop;
use shop;

create Table Products(
productId int not null identity primary key,
productName nvarchar(20) not null,
productProvider nvarchar(20) not null,
productPrice money
);

insert Products values
('Tomatoes1','Kharkiv',33),
('Apples1','Kherson',41),
('Onion1', 'Moldova',23),
('Cherry1', 'Kharkiv',43);

create Table Checks(
checkId int not null identity primary key,
customerName nvarchar(20) not null,
customerAddress nvarchar(20) not null,
productId int not null
);

insert Checks values
('Vasya','Kiev',1),
('Kiril','Dnepr',1),
('Fedor','Kharkiv',3),
('Ivan','Kiev',4),
('Victor','Ternopil',2),
('Vladimir','Zaporozhie',4),
('Svyatoslav','Kherkiv',4),
('Denis','Kharkiv',2),
('Danil','Dnepr',1),
('Alexander','Dnepr',3);

select Checks.customerName, Checks.customerAddress, Products.productName, Products.productProvider, Products.productPrice
from Checks join Products on Products.productId=Checks.productId