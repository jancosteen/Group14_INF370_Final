import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { SupplierorderlineUpdateComponent } from './supplierorderline-update/supplierorderline-update.component';
import { SupplierorderlineDeleteComponent } from './supplierorderline-delete/supplierorderline-delete.component';
import { SupplierorderlineDetailsComponent } from './supplierorderline-details/supplierorderline-details.component';
import { SupplierorderlineCreateComponent} from './supplierorderline-create/supplierorderline-create.component';
import {SupplierorderlineListComponent} from './supplierorderline-list/supplierorderline-list.component';

@NgModule({
  declarations: [
    SupplierorderlineUpdateComponent, 
    SupplierorderlineDeleteComponent, 
    SupplierorderlineDetailsComponent,
    SupplierorderlineListComponent,
    SupplierorderlineCreateComponent],
    imports: [
      CommonModule,
      SharedModule, 
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: SupplierorderlineListComponent},
        {path: 'details/:id', component: SupplierorderlineDetailsComponent},
        {path: 'create', component: SupplierorderlineCreateComponent },
        {path: 'update/:id', component: SupplierorderlineUpdateComponent },
        {path: 'delete/:id', component: SupplierorderlineDeleteComponent }
      ]),
    ],
    exports: [
      MatTableModule
    ]
})
export class SupplierorderlineModule { }
