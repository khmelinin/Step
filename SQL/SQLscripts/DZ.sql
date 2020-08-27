create database shop;
use shop;

create Table Products(
productId int not null identity primary key,
productName nvarchar(20) not null,
productProvider nvarchar(20) not null,
productPrice money
);

insert into Products(productName, productProvider, productPrice) values
('Tomatoes1','Kharkiv',33),
('Apples1','Kherson',41),
('Onion1', 'Moldova',23),
('Cherry1', 'Kharkiv',43);

create Table Checks(
checkId int not null identity primary key,
customerName nvarchar(20) not null,
customerAddress nvarchar(20) not null,
productId int not null,
productCount int not null
);

insert into Checks(customerName, customerAddress, productId, productCount) values
('Vasya','Kiev',1,1),
('Kiril','Dnepr',1,2),
('Fedor','Kharkiv',3,3),
('Ivan','Kiev',4,1),
('Victor','Ternopil',2,10),
('Vladimir','Zaporozhie',4,4),
('Svyatoslav','Kherkiv',4,6),
('Denis','Kharkiv',2,1),
('Danil','Dnepr',1,9),
('Alexander','Dnepr',3,8);

select Checks.customerName, Checks.customerAddress, Products.productName, Products.productProvider, Products.productPrice, Checks.productCount,Products.productPrice*Checks.productCount as checkSums into Profits
from Checks join Products on Products.productId=Checks.productId

select * from Profits

select SUM(checkSums) as TOTAL into Total from Profits

select customerName, productName, productPrice, productCount, checkSums, total into ProfitsConclusion from Profits, Total
select customerName, productName, productPrice, productCount, checkSums from ProfitsConclusion
select total from Total
