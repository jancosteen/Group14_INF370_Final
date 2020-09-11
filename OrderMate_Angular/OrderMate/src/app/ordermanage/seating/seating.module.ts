import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 



import { SeatingComponent } from './seating.component';
import { SeatingListComponent } from './seating-list/seating-list.component';
import { SeatingUpdateComponent } from './seating-update/seating-update.component';
import { SeatingCreateComponent } from './seating-create/seating-create.component';
import { SeatingDetailsComponent } from './seating-details/seating-details.component';
import { SeatingDeleteComponent } from './seating-delete/seating-delete.component';



@NgModule({
  declarations: [
    SeatingComponent, 
    SeatingListComponent, SeatingUpdateComponent, SeatingCreateComponent, SeatingDetailsComponent, SeatingDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: SeatingListComponent},
     // {path: 'details/:id', component: ReservationstatusDetailsComponent},
     // {path: 'create', component: ReservationstatusCreateComponent},
    //  {path: 'delete/:id', component: ReservationstatusDeleteComponent},
     // {path: 'update/:id', component: ReservationstatusUpdateComponent}
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class SeatingModule { }
