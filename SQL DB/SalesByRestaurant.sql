create procedure SP_SALES_BY_RESTAURANT @restaurantId int, @DateFrom date, @DateTo date
AS

select 
	R.Restaurant_Name
	,MI.Menu_Item_Id
	,MI.Menu_Item_Name
	,MIP.Menu_Item_Price
	,O.Order_Date_Completed


from [dbo].[Order] O
left join [dbo].[Order_Line] OL on OL.Order_Id_FK= O.Order_Id
left join [dbo].[Menu_Item] MI on MI.Menu_Item_Id = OL.Menu_Item_Id_FK
left join [dbo].[Menu_Item_Price] MIP on MIP.Menu_Item_Id_FK = MI.Menu_Item_Id
left join [dbo].[Menu] M on M.Menu_Id = MI.Menu_Id_FK
left join [dbo].[Restaurant] R on R.Restaurant_Id = M.Restaurant_Id_FK

where
R.Restaurant_Id = @restaurantId and O.Order_Date_Created >= @DateFrom and O.Order_Date_Created <= @DateTo
