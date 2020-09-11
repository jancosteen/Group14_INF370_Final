import {Restaurant} from '../../../_interfaces/Administration/Restaurant/restaurant.model'
import { MenuItem } from '../MenuItem/menuitem.model';

export interface Menu {
    menuId: string;
    menuName:string,
    menuDescription:string,
    menuDateCreated:Date,
    menuTimeActiveFrom:Date, 
    menuTimeActiveTo:Date, 
    restaurant: string, 
    menuItems?: MenuItem
 
}