import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductcategoryComponent } from './productcategory/productcategory.component';
import { ProductwrittenoffComponent } from './productwrittenoff/productwrittenoff.component';
import { WrittenoffstockComponent } from './writtenoffstock/writtenoffstock.component';




@NgModule({
  declarations: [
    ProductListComponent, 
    ProductDetailsComponent, 
    ProductCreateComponent, 
    ProductcategoryComponent, 
    ProductwrittenoffComponent, WrittenoffstockComponent
   
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ProductListComponent},
      {path: 'details/:id', component: ProductDetailsComponent},
      {path: 'create', component: ProductCreateComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class ProductModule { }
 