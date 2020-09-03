create database Geom
use Geom

CREATE TABLE SpatialTable_2  
    ( id int IDENTITY (1,1),
    GeogCol1 geometry,  
    GeogCol2 AS GeogCol1.STAsText() );
GO
 
INSERT INTO SpatialTable_2 (GeogCol1)
VALUES (geometry::STLineFromText('LINESTRING(-122.360 47.656, -122.343 47.656 )', 0));
 
INSERT INTO SpatialTable_2 (GeogCol1)
VALUES (geometry::STPolyFromText ('POLYGON((-122.358 47.653 , -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))', 0));
GO

select * from SpatialTable_2

DECLARE @g geography;  
DECLARE @h geography;  
SET @g = geography::STGeomFromText('POLYGON((-122.358 47.653, -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653))', 4326);  
SET @h = geography::STGeomFromText('POLYGON((-122.351 47.656, -122.341 47.656, -122.341 47.661, -122.351 47.661, -122.351 47.656))', 4326);  

 

create table spatialGeography (id int identity, geog geography);
insert into spatialGeography values (@g), (@h), (@g.STUnion(@h))

select * from spatialGeography 

DECLARE @gg geography; 
SET @gg = geography::STMLineFromText('MULTILINESTRING ((-122.358 47.653, -122.348 47.649, -122.348 47.658, -122.358 47.658, -122.358 47.653), (-122.357 47.654, -122.357 47.657, -122.349 47.657, -122.349 47.650, -122.357 47.654))', 4326); 
SELECT @gg.ToString();

create type IPN
from nvarchar(11) not null;

create type human as table ( 
humanId int not null identity primary key, 
[name] nvarchar(20) not null,
surname nvarchar(20)not null
)

create table udt_Table (
number IPN
)

declare @t as human

insert into @t values 
('Joseph', 'Joestar')

create assembly clr_udt 
from 'C:\Users\AdmiN\source\repos\khmelinin\Step\SQL\12\bin\Release\12.dll' 
with PERMISSION_SET=safe

create type Point 
external name clr_udt.[a12.Point]

declare @p1 Point 
declare @p2 Point 
declare @p3 Point 

set @p1 = convert(Point, '3,2');
set @p2 = cast('4,5' as Point);
set @p3 = Point::Parse('6,7')
print @p1.Distance(@p2);

print cast(@p1 as nvarchar(max));
print cast(@p3 as nvarchar(max));
print @p3.X
set @p3.X = 10
print cast(@p3 as nvarchar(max));
