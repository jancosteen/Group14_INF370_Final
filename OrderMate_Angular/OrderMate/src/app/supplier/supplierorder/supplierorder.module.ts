import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

import { SupplierorderListComponent } from './../supplierorder/supplierorder-list/supplierorder-list.component';
import { SupplierorderCreateComponent } from './../supplierorder/supplierorder-create/supplierorder-create.component';
import { SupplierorderDetailsComponent } from './../supplierorder/supplierorder-details/supplierorder-details.component';
import { SupplierorderUpdateComponent } from './../supplierorder/supplierorder-update/supplierorder-update.component';
import { SupplierorderDeleteComponent } from './../supplierorder/supplierorder-delete/supplierorder-delete.component';


@NgModule({
  declarations: [
    SupplierorderListComponent,
    SupplierorderCreateComponent,
    SupplierorderDetailsComponent,
    SupplierorderUpdateComponent,
    SupplierorderDeleteComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: SupplierorderListComponent},
      {path: 'details/:id', component: SupplierorderDetailsComponent},
      {path: 'create', component: SupplierorderCreateComponent },
      {path: 'update/:id', component: SupplierorderUpdateComponent },
      {path: 'delete/:id', component: SupplierorderDeleteComponent }
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class SupplierorderModule { }
