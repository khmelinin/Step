create database Company1;
go
use Company1;
go

create table Departments(
departmentId int not null identity primary key, 
departmentTitle nvarchar(50) not null, 
parentId int null foreign key references Departments (departmentId));

INSERT INTO Departments (parentID, departmentTitle )
VALUES (null, 'Finance Director')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (1, 'Deputy Finance Director')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (1, 'Assistance Finance Director')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (3, 'Executive Bodget Office')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (3, 'Comptroller')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (3, 'Purchasing')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (3, 'Debt Management')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (3, 'Risk Management')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (2, 'Public Relations')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (2, 'Finance Personnel')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (2, 'Finance Accounting')
INSERT INTO Departments (parentID, departmentTitle )
VALUES (2, 'Liasion to Boards and Commissions')


go

create table Employes (
employeId int not null identity primary key, 
surename nvarchar(50) not null, 
[name] nvarchar(50) not null,
patronymic nvarchar(50) null,
birthday date null,
sex bit null
);
go 

-------
insert into Employes (surename, [name], patronymic)
values
(N'Ganzenko',N'Leonid',N'Micholayovich'),
(N'Burcev',N'Yaroslav',null)

create view SNP_Employes (employeId, SNP) as 
select employeId, surename+N' '+left([name],1)+N'. '+ 
case 
when patronymic is not null then left([patronymic],1)+N'.' 
when patronymic is null then N'' 
end
from Employes

select * from SNP_Employes 
order by SNP 
-------

create table Cadres ( 
departmentId int not null foreign key references Departments(departmentId),
employeId int not null foreign key references Employes(employeId),
date1 date not null,
date2 date not null
); 

--insert into Cadres(departmentId, employeId, date1, date2) values 
--( , 1,'10-10-2010', '11-11-2011'),
--( , 2,'09-10-2011', getdate());

with cte (departmentId, departmentTitle, level, parentTitle) as 
( 
 select d.departmentId, d.departmentTitle, 0 as level, CAST(N'' as nvarchar(50)) as parentTitle from Departments as d where d.parentId is null 
 union all
 select d.departmentId, d.departmentTitle, cte.level + 1, cte.departmentTitle from Departments as d 
 inner join cte on d.parentId = cte.departmentId
)
select * from cte order by level;


-------
declare @depart table(departmentId int, level int, parentTitle nvarchar(50), departmentTitle nvarchar(50), [status] int);

insert into @depart (departmentId, level, departmentTitle, status)
select d.departmentId, 0, d.departmentTitle, 0 from Departments as d where d.parentId is null;

declare @rowAdded int = @@ROWCOUNT
while @rowAdded>0
begin
	update @depart set status=1 where status=0 
	insert into @depart (departmentId, level, parentTitle, departmentTitle, status)
	select p.departmentId, d.level+1, d.departmentTitle, p.departmentTitle, 0
	from Departments as p inner join @depart as d on p.parentId=d.departmentId and d.status=1;
	set @rowAdded=@@ROWCOUNT;
	update @depart set status=2 where status=1;
end
select * from @depart
-------

create view EmployesView (LastName, FirstName, SecondName) 
as select e.surename, e.name, e.patronymic from Employes as e;

insert into EmployesView (LastName, FirstName, SecondName) values 
(N'Gazhemon', N'Vlodimir', N'Andreevich')

create view EmployesDepartment as 
select * from Employes, Departments
