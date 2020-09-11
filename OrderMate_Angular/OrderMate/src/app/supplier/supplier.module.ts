import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { SupplierListComponent } from './supplier-list/supplier-list.component';
import { SupplierComponent } from '../supplier/supplier.component';
import { SupplierDetailsComponent } from './supplier-details/supplier-details.component';
import { SupplierCreateComponent } from './supplier-create/supplier-create.component';
import { SupplierUpdateComponent} from './supplier-update/supplier-update.component';
import { SupplierDeleteComponent } from './supplier-delete/supplier-delete.component';
import { SupplierorderComponent } from './supplierorder/supplierorder.component';
import { SupplierorderlineComponent } from './supplierorderline/supplierorderline.component';




@NgModule({
  declarations: [
    SupplierListComponent, 
    SupplierComponent, 
    SupplierDetailsComponent, 
    SupplierCreateComponent,
    SupplierUpdateComponent,
    SupplierDeleteComponent,
    SupplierorderComponent,
    SupplierorderlineComponent
    
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: SupplierListComponent},
      {path: 'details/:id', component: SupplierDetailsComponent},
      {path: 'create', component: SupplierCreateComponent },
      {path: 'update/:id', component: SupplierUpdateComponent },
      {path: 'delete/:id', component: SupplierDeleteComponent }
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class SupplierModule { }
