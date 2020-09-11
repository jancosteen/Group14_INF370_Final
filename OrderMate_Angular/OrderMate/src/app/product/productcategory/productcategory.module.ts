import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductcategoryListComponent } from './productcategory-list/productcategory-list.component';
import { ProductcategoryCreateComponent } from './productcategory-create/productcategory-create.component';
import { ProductcategoryDetailsComponent } from './productcategory-details/productcategory-details.component';
import { ProductcategoryUpdateComponent } from './productcategory-update/productcategory-update.component';
import { ProductcategoryDeleteComponent } from './productcategory-delete/productcategory-delete.component';



@NgModule({
  declarations: [ProductcategoryListComponent, 
    ProductcategoryCreateComponent, 
    ProductcategoryDetailsComponent, 
    ProductcategoryUpdateComponent, 
    ProductcategoryDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ProductcategoryListComponent},
      {path: 'details/:id', component: ProductcategoryDetailsComponent},
      {path: 'create', component: ProductcategoryCreateComponent},
      {path: 'delete/:id', component: ProductcategoryDeleteComponent},
      {path: 'update/:id', component: ProductcategoryUpdateComponent}
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class ProductcategoryModule { }
