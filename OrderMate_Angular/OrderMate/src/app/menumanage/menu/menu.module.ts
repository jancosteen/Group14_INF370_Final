import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MenuListComponent } from './menu-list/menu-list.component';
import { MenuDetailsComponent } from './menu-details/menu-details.component';
import { MenuDeleteComponent } from './menu-delete/menu-delete.component';
import { MenuCreateComponent } from './menu-create/menu-create.component';
import { MenuUpdateComponent } from './menu-update/menu-update.component';
import { BrowserModule } from '@angular/platform-browser';
import { ItemsMenuComponent } from './items-menu/items-menu.component';
import { MenuitemsComponent } from './menuitems/menuitems.component';



@NgModule({
  declarations: 
  [ 
    
    MenuListComponent, 
    MenuDetailsComponent, 
    MenuDeleteComponent,      
    MenuCreateComponent,
    MenuUpdateComponent,
    ItemsMenuComponent,
    MenuitemsComponent],
  imports: [
    CommonModule,
    BrowserModule,
  ]
})
export class MenuModule { }
