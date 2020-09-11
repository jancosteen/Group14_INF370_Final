import { MenuItem } from './menuItem.model';
import { MenuItemPrice } from './menuItemPrice.model';

export interface OrderLine{
    orderLineId:number;
    itemQty:number;
    itemComments:string;
    specialIdFk?:number;
    menuItemIdFk:number;
    orderIdFk:number;
    employeeIdFk?:number;

    menuItems: MenuItem[];
    menuItemPrice?:MenuItemPrice[];
}