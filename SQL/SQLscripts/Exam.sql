/*
Запити
1. Сума по кожному чеку
2. Сума по кожному проданому товару.
3. На яку суму продав кожний менеджер, упорядкувати за збільшення суми
4. Які товари частіше купляють покупці
5. Які товари купляв покупець (вибрати одного), на яку сумму кожний товар і разом
6. В які міста доставлявся товар (вибрати один).
7. В яке місто найбільше поставок.
8. У які міста пішли закази манеджера (вибрати одного)
*/

-- 1 
select o.orderId, a.articlePrice*od.amount as total from Orders as o 
inner join OrderDetails as od  on od.orderId=o.orderId 
inner join Articles as a on a.articleId = od.articleId
-- 2 
select a.articleTitle, sum(a.articlePrice*od.amount) as articleSum from Articles as a 
inner join OrderDetails as od on od.articleId=a.articleId
group by a.articleTitle order by articleSum
--3 
select m.managerName, sum(od.amount*a.articlePrice) as managerProfit from Managers as m 
inner join Orders as o on o.managerId = m.managerId
inner join OrderDetails as od on od.orderId=o.orderId
inner join Articles as a on a.articleId=od.articleId 
group by m.managerName order by managerProfit
--4 
select a.articleTitle, sum(od.amount) as totalAmount from Articles as a 
inner join OrderDetails as od on a.articleId=od.articleId
group by a.articleTitle order by totalAmount desc
--5 
select c.cusomerNamd from Customers as c where c.customerId=1
select a.articleTitle, a.articlePrice from Articles as a
inner join OrderDetails as od on od.articleId=a.articleId
inner join Orders as o on o.orderId=od.orderId where o.customerId=1
select a.articleTitle, sum(a.articlePrice) as totalArticlePrice from Articles as a
inner join OrderDetails as od on od.articleId=a.articleId
inner join Orders as o on o.orderId=od.orderId where o.customerId=1
group by a.articleTitle
select SUM(a.articlePrice) as total from Articles as a
inner join OrderDetails as od on od.articleId=a.articleId
inner join Orders as o on o.orderId=od.orderId where o.customerId=1
-- 6 
select a.articleTitle from Articles as a where a.articleId=1
select c.cityTitle from Cities as c 
inner join Streets as s on s.cityId=c.cityId
inner join Orders as o on o.delivery=s.streetId
inner join OrderDetails as od on od.orderId=o.orderId and od.articleId=1
group by c.cityTitle
--7 
select c.cityTitle ,sum(od.amount) as amount from OrderDetails as od
inner join Orders as o on o.orderId=od.orderId 
inner join Streets as s on s.streetId=o.delivery 
inner join Cities as c on c.cityId=s.streetId
group by c.cityTitle
order by amount desc
--8 
select c.cityTitle from OrderDetails as od 
inner join Orders as o on o.orderId=od.orderId and o.managerId=1
inner join Streets as s on s.streetId=o.delivery 
inner join Cities as c on c.cityId=s.streetId
group by c.cityTitle
