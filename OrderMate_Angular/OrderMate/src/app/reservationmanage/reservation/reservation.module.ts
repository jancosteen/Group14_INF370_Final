import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

 



import { ReservationListComponent } from './reservation-list/reservation-list.component';
import { ReservationComponent} from '../reservation/reservation.component';
import { ReservationDetailsComponent } from './reservation-details/reservation-details.component';
import { ReservationUpdateComponent } from './reservation-update/reservation-update.component';
import { ReservationDeleteComponent } from './reservation-delete/reservation-delete.component';
import { ReservationCreateComponent } from './reservation-create/reservation-create.component';



@NgModule({
  declarations: [
    ReservationListComponent,
    ReservationComponent,
    ReservationDetailsComponent,
    ReservationUpdateComponent,
    ReservationDeleteComponent,
    ReservationCreateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: ReservationListComponent},
      {path: 'create', component: ReservationCreateComponent},
      {path: 'update/:id', component: ReservationUpdateComponent},
      {path: 'details/id', component: ReservationDetailsComponent},
      {path: 'delete/:id', component: ReservationDeleteComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class ReservationModule { }
