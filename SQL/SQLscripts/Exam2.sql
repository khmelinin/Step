create database CarParts
go 

use CarParts

-- #1 
create table Providers
(
providerId int not null identity primary key,
providerTitle nvarchar(30) not null
)

insert into Providers (providerTitle) values
(N'SpecialExpress'), 
(N'AllPartsHave'), 
(N'MegaParts'), 
(N'YesCars')

-- #2 
create table ProviderShop 
(
providerId int not null,
partId int not null, 
amount int not null
)

insert into ProviderShop (providerId, partId, amount) values
(1, 1, 3), 
(1, 2, 4), 
(1, 3, 1), 
(1, 4, 3), 
(2, 1, 1), 
(2, 2, 1),
(2, 5, 6),
(2, 3, 4)

create table Creators 
(
creatorId int not null identity primary key,
creatorTitle nvarchar(30) not null
)

insert into Creators (creatorTitle) values
(N'Machina'),
(N'PowerExpress')

-- #3 
create table Replacements 
(
partId1 int not null,
partId2 int not null
)

insert into Replacements (partId1, partId2) values
(1, 2), 
(2, 1), 
(4, 2), 
(1 ,4), 
(4, 1),
(5, 3),
(2, 4), 
(3, 5) 

-- #4 
create function SetUniqueId (@partId int, @partTitle nvarchar(30), @creatorId int) 
returns nvarchar(40)
as begin
declare @result nvarchar(40)=(@partTitle+cast(@partId as nvarchar(30))+N'_'+cast(@creatorId as nvarchar(30)))
return @result
end

create table Parts 
(
partId int not null identity primary key, 
uniqueId nvarchar(40) not null unique, 
partTitle nvarchar(30) not null, 
creatorId int not null 
)

insert into Parts (partTitle, creatorId, uniqueId) values
(N'SuperEngine', 2, dbo.SetUniqueId(1, N'SuperEngine', 2)),
(N'MiddleEngine', 2, dbo.SetUniqueId(2, N'MiddleEngine', 2)),
(N'BodyKit1', 1, dbo.SetUniqueId(3, N'BodyKit1', 1)),
(N'MachinaEngine', 1, dbo.SetUniqueId(4, N'MachinaEngine', 1)),
(N'ExpressBodyKit',2, dbo.SetUniqueId(5, N'ExpressBodyKit', 2))

--create function SetUniqueId1 () 
--returns nvarchar(40)
--as begin
--declare @tmp1 int = 0
--declare @tmp2 nvarchar(30)='_'
--declare @tmp3 int = 0

--if (select max(p.partId) from Parts as p) is not null and (select max(c.creatorId) from Creators as c) is not null
--begin
--	set @tmp1 = (select max(p.partId) from Parts as p) 
--	set @tmp2 = (select p.partTitle from Parts as p where p.partId = max(p.partId)) 
--	set @tmp3 = (select max(c.creatorId) from Creators as c) 
--end
--declare @result nvarchar(40)=(@tmp2+cast(@tmp1 as nvarchar(30))+N'_'+cast(@tmp3 as nvarchar(30)))
--return @result
--end

create table Characteristics
(
partId int not null,
strenght int null,
[power] int null,
color nvarchar(30) null
)

insert into Characteristics (partId, strenght, [power], color) values
(1, 10, 900, null), 
(2, 7, 300, null), 
(3, 9, null, N'Black'), 
(4, 6, 600, null), 
(5, 6, null, N'White')

-- #5 

declare @providerId int = 1 

select p.partTitle, p.creatorId, pr.providerTitle, ch.color, ch.[power], ch.strenght, p.uniqueId from Parts as p 
inner join Characteristics as ch on ch.partId=p.partId 
inner join ProviderShop as ps on ps.partId=p.partId 
inner join Providers as pr on pr.providerId=ps.providerId where pr.providerId=@providerId

declare @creatorId int = 1 

select p.partTitle, p.creatorId, pr.providerTitle, ch.color, ch.[power], ch.strenght, p.uniqueId from Parts as p 
inner join Characteristics as ch on ch.partId=p.partId 
inner join ProviderShop as ps on ps.partId=p.partId 
inner join Providers as pr on pr.providerId=ps.providerId where p.creatorId=@creatorId

-- #6 
declare @partId int = 1

select p.partTitle, p.creatorId, pr.providerTitle, ch.color, ch.[power], ch.strenght, p.uniqueId from Parts as p 
inner join Characteristics as ch on ch.partId=p.partId 
inner join ProviderShop as ps on ps.partId=p.partId 
inner join Providers as pr on pr.providerId=ps.providerId 
inner join Replacements as r on r.partId1 = p.partId where r.partId2=@partId
