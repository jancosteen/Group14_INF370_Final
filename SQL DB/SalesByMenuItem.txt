create procedure SP_SALES_BY_MENUITEM @menuItemId int, @DateFrom date, @DateTo date
as

select MI.Menu_Item_Id [Menu_Item_Id]
	,MI.Menu_Item_Name [Menu_Item_Name]
	,MIP.Menu_Item_Price
	,O.Order_Date_Created

from [dbo].[Order] O
left join [dbo].[Order_Line] OL on OL.Order_Id_FK= O.Order_Id
left join [dbo].[Menu_Item] MI on MI.Menu_Item_Id = OL.Menu_Item_Id_FK
left join [dbo].[Menu_Item_Price] MIP on MIP.Menu_Item_Id_FK = MI.Menu_Item_Id

where 
MI.Menu_Item_Id = @menuItemId and O.Order_Date_Created >= @DateFrom and O.Order_Date_Created <= @DateTo