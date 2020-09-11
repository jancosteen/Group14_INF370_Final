import { Menu } from './menu.model';
import { MenuItemCategory } from './menuItemCategory.model';
import { MenuItemPrice } from './menuItemPrice.model';

export interface MenuItemDetails{
    menuItemId:number;
    menuItemName: string;
    menuItemDescription:string;
    menuIdFk:number;
    menuItemCategoryIdFk:number;

    menuDetails:Menu[];
    menuItemCategoryDetails:MenuItemCategory[];
    menuItemPrice:MenuItemPrice[];

}