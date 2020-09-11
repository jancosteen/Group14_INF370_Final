import { MenuItemPrice } from './menuItemPrice.model';

export interface MenuItem{
    menuItemId:number;
    menuItemName:string;
    menuItemDescription:string;
    menuIdFk:number;
    menuItemCategoryIdFk:number;
    menuItemAmount:number;
    menuId?:number;

    menuItemPrice: MenuItemPrice[];
}