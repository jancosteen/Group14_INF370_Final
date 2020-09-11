export interface SalesByMenuItem {
    menuItemId: number,
    dateFrom: Date,
    dateTo: Date
}

export interface ReturnedSalesByMenuItem{
    menu_Item_Id:number,
    menu_Item_Name: string,
    menu_Item_Price: string,
    order_Date_Created: Date
}