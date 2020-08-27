use Company1
go

create trigger insDepartments on Departments
after insert
as
begin
    select * from inserted
	select * from deleted
end

insert into Departments (departmentTitle, parentId)
values
(N'New Department(3)', 30)

select * from Departments
--Відключити тригер
disable trigger insDepartments on Departments
--Включити тригер
enable trigger insDepartments on Departments

create trigger insteadOfDepartments on Departments
instead of insert
as
begin
    print 'none'
end

alter trigger insteadOfDepartments on Departments
instead of insert, update, delete
as
begin
 declare @v nchar(1);
 if exists (select * from inserted)
 begin
    if exists (select * from deleted)
	    --update
		set @v = N'u'
	else
	    --insert
		set @v = N'i'
 end
 else
    --delete
	set @v = N'd'
	print @v
end

delete from Departments where departmentId=40

select * from Employes

create table Employes_log(
    employeId int not null,
	employeSurname nvarchar(50) not null,
	employeName nvarchar(50) not null,
	employePatronymic nvarchar(50) null,
	employeBirthday date null,
	sex bit null,
	operation nvarchar(1) not null,
	employeData datetime not null default getdate()
);

create trigger EmployesChanges on Employes
instead of insert, update, delete
as
begin
 declare @v nchar(1);
 if exists (select * from inserted)
 begin
    if exists (select * from deleted)
	    --update
		set @v = N'u'
	else
	    --insert
		set @v = N'i'
	insert into Employes_log (employeId, employeName, employeSurname, employePatronymic, employeBirthday, sex, operation)
	select i.employeId, i.employeSurname, i.employeName, i.employePatronymic, i.employeBirthday, i.sex, @v from inserted i
 end
 else
    --delete
	insert into Employes_log (employeId, employeName, employeSurname, employePatronymic, employeBirthday, sex, operation)
	select i.employeId, i.employeSurname, i.employeName, i.employePatronymic, i.employeBirthday, i.sex, N'd' from inserted i
end

insert into Employes(employeSurname, employeName, employePatronymic, employeBirthday, sex)
values (N'Гирський', N'Ярослав',N'Ігорович','22-04-2002', 1)

select * from Employes_log

update Employes set sex = 0 where employeSurname=N'Бурцев'

delete from Employes where employeId = 2

declare @a int = 9;
declare @result int = 1;

while @a > 1
begin
    set @result = @result * @a
	set @a = @a - 1
	if @a = 3
	    break
	else
	    continue
end

print @result;
select @result

begin try
    begin transaction
	insert into Employes(employeSurname, employeName) values (N'Донець', N'Іван')
	--помилка бо employeName - not null
	insert into Employes(employeSurname) values (N'Донець')
	commit transaction
	print N'transaction complete'
end try
begin catch
    rollback
	print N'transaction rollback'
end catch

select * from Employes