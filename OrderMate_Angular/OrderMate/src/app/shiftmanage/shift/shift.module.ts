import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 

import { ShiftComponent } from './shift.component';
import { ShitstatusComponent } from './shiftstatus/shitstatus.component';
import { ShiftListComponent } from './shift-list/shift-list.component';
import { ShiftUpdateComponent } from './shift-update/shift-update.component';
import { ShiftDetailsComponent } from './shift-details/shift-details.component';
import { ShiftDeleteComponent } from './shift-delete/shift-delete.component';




@NgModule({
  declarations: [
    ShiftComponent, 
    ShitstatusComponent, 
    ShiftListComponent, 
    ShiftUpdateComponent, 
    ShiftDetailsComponent, 
    ShiftDeleteComponent 
    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ShiftListComponent},
      {path: 'details/:id', component: ShiftDetailsComponent},
     // {path: 'create', component: ProductcategoryCreateComponent},
      {path: 'delete/:id', component: ShiftDeleteComponent},
      {path: 'update/:id', component: ShiftUpdateComponent}
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class ShiftModule { }
