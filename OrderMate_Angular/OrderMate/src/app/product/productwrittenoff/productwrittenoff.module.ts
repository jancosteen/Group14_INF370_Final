import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductwrittenoffListComponent } from './productwrittenoff-list/productwrittenoff-list.component';
import { ProductwrittenoffCreateComponent } from './productwrittenoff-create/productwrittenoff-create.component';
import { ProductwrittenoffUpdateComponent } from './productwrittenoff-update/productwrittenoff-update.component';
import { ProductwrittenoffDeleteComponent } from './productwrittenoff-delete/productwrittenoff-delete.component';
import { ProductwrittenoffDetailsComponent } from './productwrittenoff-details/productwrittenoff-details.component';



@NgModule({
  declarations: [
    ProductwrittenoffListComponent, 
    ProductwrittenoffCreateComponent, 
    ProductwrittenoffUpdateComponent, 
    ProductwrittenoffDeleteComponent,
    ProductwrittenoffDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ProductwrittenoffListComponent},
      {path: 'details/:id', component: ProductwrittenoffDetailsComponent},
      {path: 'create', component: ProductwrittenoffCreateComponent},
      {path: 'delete/:id', component: ProductwrittenoffDeleteComponent},
      {path: 'update/:id', component: ProductwrittenoffUpdateComponent}
      
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class ProductwrittenoffModule { }
