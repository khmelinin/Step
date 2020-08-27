use ExamShop

create proc addArticleToOrder @orderNumber nvarchar(10), @articleTitle nvarchar(50), @amount numeric
as 
begin
	declare @orderId int;
	select @orderId = orderId from Orders where orderNumber = @orderNumber;
	if @orderId is null
		return;

	declare @articleId int;
	select @articleId=articleId from Articles where articleTitle=@articleTitle;
	if @articleId is null
		return;

	if exists (select * from OrderDetails where articleId=@articleId and orderId=@orderId) 
	begin
		update OrderDetails set amount = amount+@amount where articleId=@articleId and orderId=@orderId
	end
	else
	begin
		insert into OrderDetails (orderId, articleId, amount)
		values (@orderId, @articleId, @amount)
	end
end

execute addArticleToOrder N'AAAAAAAA', N'Milk', 20

create proc addArticle @articleTitle nvarchar(50), @price money, @id int output
as
begin
	declare @ins table (id int not null);
	if exists (select * from Articles where lower(articleTitle)=lower(@articleTitle))
		return

	insert into Articles (articleTitle, articlePrice)
	output inserted.articleId into @ins (id)
	values (@articleTitle, @price);
	
	select @id = id from @ins;
end

--declare @newId int = 0;
--execute addArticle N'Test2', 0.12, @id = @newId output;
--select @newId;
--select * from Articles
--delete from Articles where articlePrice=0.12

--create proc createOrder @manager, @customer, @orderId output

