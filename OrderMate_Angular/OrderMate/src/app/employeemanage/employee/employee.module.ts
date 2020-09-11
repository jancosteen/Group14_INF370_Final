import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 

import { EmployeeListComponent } from './employee-list/employee-list.component';





@NgModule({
  declarations: [EmployeeListComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: EmployeeListComponent},
     /* {path: 'details/:id', component: ShiftDetailsComponent},
     {path: 'create', component: ProductcategoryCreateComponent},
      {path: 'delete/:id', component: ShiftDeleteComponent},
      {path: 'update/:id', component: ShiftUpdateComponent}
      */
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class EmployeeModule { }
