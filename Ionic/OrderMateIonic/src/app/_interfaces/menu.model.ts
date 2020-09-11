import { MenuItem } from './menuItem.model';
import { MenuItemPrice } from './menuItemPrice.model';

export interface Menu {
    menuId:number;
    menuName:string;
    menuDescription:string;
    menuDateCreated:string;
    menuTimeActiveFrom:string;
    menuTimeActiveTo:string;
    restaurantIdFk:number;

    menuItem?:MenuItem[];
    menuItemPrice?:MenuItemPrice[];
}