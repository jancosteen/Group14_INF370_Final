import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 



import { MenuitemtypeComponent } from './menuitemtype/menuitemtype.component';
import { MenuitemDetailsComponent } from './menuitem-details/menuitem-details.component';
import { MenuitemListComponent } from './menuitem-list/menuitem-list.component';
import { MenuitemDeleteComponent } from './menuitem-delete/menuitem-delete.component';
import { MenuitemCreateComponent } from './menuitem-create/menuitem-create.component';
import { MenuitemUpdateComponent } from './menuitem-update/menuitem-update.component';
import { MenuitemspecialListComponent } from './menuitemspecial/menuitemspecial-list/menuitemspecial-list.component';
import { MenuitemallergyListComponent } from './menuitemallergy/menuitemallergy-list/menuitemallergy-list.component';
import { MenuitempriceListComponent } from './menuitemprice/menuitemprice-list/menuitemprice-list.component';



@NgModule({
  declarations: [
    MenuitemtypeComponent, 
    MenuitemDetailsComponent,
    MenuitemListComponent,
    MenuitemDeleteComponent,
    MenuitemCreateComponent,
    MenuitemUpdateComponent,
    MenuitemspecialListComponent,
    MenuitemallergyListComponent,
    MenuitempriceListComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: MenuitemListComponent},
        {path: 'details/:id', component: MenuitemDetailsComponent},
       // {path: 'create', component: MenuitemcategoryCreateComponent},
       // {path: 'delete/:id', component: MenuitemcategoryDeleteComponent},
      //  {path: 'update/:id', component: MenuitemcategoryUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class MenuitemModule { }
