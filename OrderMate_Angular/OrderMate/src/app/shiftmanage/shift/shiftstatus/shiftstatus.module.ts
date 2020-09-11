import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { ShiftstatusListComponent } from '../shiftstatus/shiftstatus-list/shiftstatus-list.component';
import { ShiftstatusCreateComponent } from '../shiftstatus/shiftstatus-create/shiftstatus-create.component';
import { ShiftstatusUpdateComponent } from '../shiftstatus/shiftstatus-update/shiftstatus-update.component';
import { ShiftstatusDetailsComponent } from '../shiftstatus/shiftstatus-details/shiftstatus-details.component';
import { ShiftstatusDeleteComponent } from '../shiftstatus/shiftstatus-delete/shiftstatus-delete.component';



@NgModule({
  declarations: [
    ShiftstatusListComponent, 
    ShiftstatusCreateComponent, 
    ShiftstatusUpdateComponent, 
    ShiftstatusDetailsComponent, 
    ShiftstatusDeleteComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ShiftstatusListComponent},
      {path: 'details/:id', component: ShiftstatusDetailsComponent},
      {path: 'create', component: ShiftstatusCreateComponent},
      {path: 'delete/:id', component: ShiftstatusDeleteComponent},
      {path: 'update/:id', component: ShiftstatusUpdateComponent}
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class ShiftstatusModule { }
