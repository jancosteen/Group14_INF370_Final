import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 

import { ReservationstatusComponent } from '../../reservationmanage/reservationstatus/reservationstatus.component';
import { ReservationstatusListComponent } from './reservationstatus-list/reservationstatus-list.component';
import { ReservationstatusUpdateComponent } from './reservationstatus-update/reservationstatus-update.component';
import { ReservationstatusDetailsComponent } from './reservationstatus-details/reservationstatus-details.component';

import { ReservationstatusDeleteComponent } from './reservationstatus-delete/reservationstatus-delete.component';
import { ReservationstatusCreateComponent } from './reservationstatus-create/reservationstatus-create.component';


@NgModule({
  declarations: [ReservationstatusComponent, 
    ReservationstatusListComponent, 
    ReservationstatusUpdateComponent, 
    ReservationstatusDetailsComponent,  
    ReservationstatusDeleteComponent, 
    ReservationstatusCreateComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: ReservationstatusListComponent},
        {path: 'details/:id', component: ReservationstatusDetailsComponent},
        {path: 'create', component: ReservationstatusCreateComponent},
        {path: 'delete/:id', component: ReservationstatusDeleteComponent},
        {path: 'update/:id', component: ReservationstatusUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class ReservationstatusModule { }
