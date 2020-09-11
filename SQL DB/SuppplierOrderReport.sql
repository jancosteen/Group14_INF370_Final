create procedure SP_SUPPLIER_ORDER @orderDateFrom date, @orderDateTo date, @supplierId int
AS

SELECT 
	S.Supplier_Id
	,S.Supplier_Name
	,P.Product_Name
	,SOL.Product_Standard_Price
	,SOL.Ordered_Qty
	,SOL.Delivery_Lead_Time
	,SOL.Discount_Agreement

FROM [dbo].[Supplier] S
LEFT JOIN [dbo].[Supplier_Order] SO ON SO.Supplier_Id_FK = S.Supplier_Id
LEFT JOIN [dbo].[Supplier_Order_Line] SOL ON SOL.Supplier_Order_Id_FK = SO.Supplier_Order_Id
LEFT JOIN [dbo].[Product] P ON P.Product_Id = SOL.Product_Id_FK

where
SO.Supplier_Order_Date >= @orderDateFrom and SO.Supplier_Order_Date<=@orderDateTo and S.Supplier_Id = @supplierId
