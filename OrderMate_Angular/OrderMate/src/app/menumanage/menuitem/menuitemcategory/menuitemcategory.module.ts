import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 

import { MenuitemcategoryListComponent } from './menuitemcategory-list/menuitemcategory-list.component';
import { MenuitemcategoryCreateComponent } from './menuitemcategory-create/menuitemcategory-create.component';
import { MenuitemcategoryUpdateComponent } from './menuitemcategory-update/menuitemcategory-update.component';
import { MenuitemcategoryDeleteComponent } from './menuitemcategory-delete/menuitemcategory-delete.component';
import { MenuitemcategoryDetailsComponent } from './menuitemcategory-details/menuitemcategory-details.component';



@NgModule({
  declarations: [
    MenuitemcategoryListComponent, 
    MenuitemcategoryCreateComponent, 
    MenuitemcategoryUpdateComponent, 
    MenuitemcategoryDeleteComponent, 
    MenuitemcategoryDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: MenuitemcategoryListComponent},
      {path: 'details/:id', component: MenuitemcategoryDetailsComponent},
      {path: 'create', component: MenuitemcategoryCreateComponent},
      {path: 'delete/:id', component: MenuitemcategoryDeleteComponent},
      {path: 'update/:id', component: MenuitemcategoryUpdateComponent}
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})   
export class MenuitemcategoryModule { }
