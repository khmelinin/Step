sp_configure 'show advanced options', 1
RECONFIGURE
go

 

sp_configure 'clr enabled', 1
RECONFIGURE
go

 

sp_configure 'clr strict security', 0
RECONFIGURE
go

 

sp_configure 'show advanced options', 0
RECONFIGURE
go

-- Create / Alter / Drop
alter Assembly [SQL]
from 'C:\Users\AdmiN\source\repos\khmelinin\Step\SQL\SQL\bin\Release\SQL.dll'
go

Create Function Split_demo(@StringToSplit nvarchar(max), @splitOnChars nvarchar(max) )
returns Table (Results nvarchar(max))
AS External name SQL.[One.Class1].Split
GO

select * from Split_demo(N'q w e r t y', N' ')

Create function CalcDeposit (@start money, @percent float, @add money, @all money) 
returns int
as external name SQL.[One.Class1].CalculateDeposit
go

select dbo.CalcDeposit(1000, 18, 1000, 4000000)
