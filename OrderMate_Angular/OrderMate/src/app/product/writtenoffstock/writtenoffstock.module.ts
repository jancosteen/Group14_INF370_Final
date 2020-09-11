import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { WrittenoffstockListComponent } from './writtenoffstock-list/writtenoffstock-list.component';
import { WrittenoffstockCreateComponent } from './writtenoffstock-create/writtenoffstock-create.component';
import { WrittenoffstockUpdateComponent } from './writtenoffstock-update/writtenoffstock-update.component';
import { WrittenoffstockDeleteComponent } from './writtenoffstock-delete/writtenoffstock-delete.component';
import { WrittenoffstockDetailsComponent } from './writtenoffstock-details/writtenoffstock-details.component';



@NgModule({
  declarations: [
    WrittenoffstockListComponent, 
    WrittenoffstockCreateComponent, 
    WrittenoffstockUpdateComponent, 
    WrittenoffstockDeleteComponent, 
    WrittenoffstockDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: WrittenoffstockListComponent},
      {path: 'details/:id', component: WrittenoffstockDetailsComponent},
      {path: 'create', component: WrittenoffstockCreateComponent},
      {path: 'update/:id', component: WrittenoffstockUpdateComponent},
      {path: 'delete', component: WrittenoffstockDeleteComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class WrittenoffstockModule { }
