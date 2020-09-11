import { MenuItemCategory } from '../menuitemcategory/menuitemcategory.model';
import {Menu} from '../Menu/menu.model';

export interface MenuItem {
    menuItemId: string; 
    menuItemName:string;
    menuItemDescription:string;
    menuIdFk:  number;
    menuItemCategoryIdFk: number;
    menuItemCategoryName?: string;
}
 
 