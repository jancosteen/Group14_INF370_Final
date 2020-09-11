import { MenuItemCategory } from '../menuitemcategory/menuitemcategory.model';
import {Menu} from '../Menu/menu.model';

export interface CreateMenuItem {
 
    menuItemName:string;
    menu: Menu;
    menuItemCategory: MenuItemCategory;
}

