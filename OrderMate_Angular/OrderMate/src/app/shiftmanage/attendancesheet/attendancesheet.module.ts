import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

import {AttendancesheetListComponent} from '../attendancesheet/attendancesheet-list/attendancesheet-list.component';



@NgModule({
  declarations: [
    AttendancesheetListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: AttendancesheetListComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class AttendancesheetModule { }
