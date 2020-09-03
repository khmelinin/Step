declare @orderId int;
declare @orderNumber nvarchar(10);
declare @orderDate datetime;

 

declare order_cur cursor for select orderId, orderNumber, orderDate from Orders

 

open order_cur
fetch next from order_cur
into @orderId, @orderNumber, @orderDate

 

while @@FETCH_STATUS = 0 
begin
    print N'' + cast(@orderId as nvarchar(10)) + N' ' + @orderNumber + N' ' + format(@orderDate, N'dd.mm.yyyy'); 
    
    
    fetch next from order_cur
    into @orderId, @orderNumber, @orderDate 
end
close order_cur
deallocate order_cur