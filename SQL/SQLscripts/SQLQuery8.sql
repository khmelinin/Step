create database Groups;
go

use Groups

create table Students
(
studentId int not null identity primary key,
studentName nvarchar(20) not null,
studentSurname nvarchar(20) not null,
studentPatronymic nvarchar(20) not null,
studentBirthday date null
);

insert into Students (studentSurname, studentName, studentPatronymic, studentBirthday) values 
(N'Petuhov', N'Petya', N'Igorevich', '08-26-2002'),
(N'Neruha', N'Jack', N'Ivanovich', '01-02-2003'),
(N'Makarov', N'Vasya', N'Vasilievich', '04-07-2001'),
(N'Takov', N'Ivan', N'Sergeevich', null);

create table [Group]
(
groupId int not null identity primary key,
title nvarchar(20) not null,
createdDate date not null,
closedDate date null
);

insert into [Group] (title, createdDate, closedDate) values 
('A', '01-01-2000', null),
('B', '02-02-2001', '03-14-2011');

create table StudentsInGroups
(
studentId int not null,
groupId int not null,
dateIn date not null,
dateOut date null
);

insert into StudentsInGroups (studentId, groupId, dateIn, dateOut) values 
(1,1,'09-01-2008', null),
(2,1,'09-01-2008', null),
(3,1,'09-01-2008', null),
(4,2,'09-01-2008', '03-14-2011');

create trigger StopDeleteSIG on StudentsInGroups 
instead of delete
as
begin
	print N'no no no'
end

create function Function1(@groupId int) returns table
return
select studentSurname+N' '+left(studentName,1)+N'. '+left(studentPatronymic,1)+N'. ' as pib from StudentsInGroups as sig 
inner join Students as s on sig.studentId=s.studentId
where sig.groupId=@groupId

select * from Function1(1)

create function Function2(@date1 date) returns table 
return 
select studentSurname+N' '+left(studentName,1)+N'. '+left(studentPatronymic,1)+N'. ' as pib from StudentsInGroups as sig 
inner join Students as s on sig.studentId=s.studentId
where sig.dateOut is null or @date1<sig.dateOut

select * from Function2('01-01-2012')

create proc Proc1 @groupTitle nvarchar(20), @surname nvarchar(20), @name nvarchar(20), @patronymic nvarchar(20), @birthday date=null
as 
begin

if exists(select g.title from [Group] as g where g.title=@groupTitle)
	begin
	insert into Students (studentSurname, studentName, studentPatronymic, studentBirthday) values 
	(@surname, @name, @patronymic, @birthday);
	insert into StudentsInGroups (studentId, groupId, dateIn, dateOut) 
	select s.studentId, g.groupId, getdate(), null from Students as s 
	inner join [Group] as g on g.title=@groupTitle
	where s.studentSurname=@surname and s.studentName=@name and s.studentPatronymic=@patronymic
	end
end

execute Proc1 N'A', N'Pupkin', N'Vasya', N'Vasilievich', null

create proc Proc2 @groupTitle nvarchar(20)
as 
begin 
	insert into [Group] (title, createdDate, closedDate) values
	(@groupTitle, getdate(), null);
end 

execute Proc2 N'C'
execute Proc2 N'D'

create proc Proc3 @groupId int 
as 
begin 
	update [Group] 
	set [Group].closedDate=getdate()
	where [Group].groupId=@groupId
	update StudentsInGroups
	set dateOut=getdate()
	where StudentsInGroups.groupId=@groupId
end 

execute Proc3 3

create proc Proc4 @studentId int, @group1Id int, @group2Id int 
as 
begin 
	update StudentsInGroups
	set dateOut=getdate()
	where studentId=@studentId and groupId=@group1Id and dateOut is null

	insert into StudentsInGroups (studentId, groupId, dateIn, dateOut) values 
	(@studentId, @group2Id, getdate(), null);
end 

execute Proc4 1, 1, 4
