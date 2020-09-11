export interface OrderLineForCreation{
    itemQty:number;
    itemComments:string;
    specialIdFk?:number;
    menuItemIdFk?:number;
    orderIdFk:number;
    employeeIdFk?:number;
}