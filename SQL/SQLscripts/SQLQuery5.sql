use Company1

create function fMin(@a int, @b int) returns int
	begin
		declare @result int = @a;
		if @a > @b
			set @result = @b;

		return @result
	end

create table test(a int, b int)

declare @i int = 10

while @i>0
begin
	insert into test (a,b)
	values (RAND()*100, RAND()*100)
	set @i -= 1;
end

select a, b, dbo.fMin(a, b) from test

create function getPIB(@surname nvarchar(50), @name nvarchar(50), @patronymic nvarchar(50) = null)
returns nvarchar(160)
begin
declare @result nvarchar(160) = @surname+N' '+left(@name,1)+N'. '
	if @patronymic is not null
	set @result+=left(@patronymic,1)+N'. '
	
	return @result
end

select dbo.getPIB(surename, name, patronymic) from Employes

--create function urav (@a float, @b float, @c float, @x bit) return float
--begin
--	declare @d float = (@b*@b)-(4*@a*@c)
--	if(@d<0 or @a=0)
--	return null

--	...
--end

create function getEmployesByPattern(@p nvarchar(50)) 
returns table 
return select * from Employes where surename like @p;

select * from dbo.getEmployesByPattern(N'G%')
