import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';



import { OrderlineComponent } from './orderline.component';
import { OrderlineListComponent } from './orderline-list/orderline-list.component';
import { OrderlineCreateComponent } from './orderline-create/orderline-create.component';
import { OrderlineUpdateComponent } from './orderline-update/orderline-update.component';
import { OrderlineDetailsComponent } from './orderline-details/orderline-details.component';
import { OrderlineDeleteComponent } from './orderline-delete/orderline-delete.component';



@NgModule({
  declarations: [OrderlineComponent, OrderlineListComponent, OrderlineCreateComponent, OrderlineUpdateComponent, OrderlineDetailsComponent, OrderlineDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: OrderlineListComponent}
      /*
      {path: 'details/:id', component: ReservationDetailsComponent},
      {path: 'create', component: ReservationCreateComponent},
      {path: 'delete/:id', component: ReservationDeleteComponent},
      {path: 'update/:id', component: ReservationUpdateComponent}
      */
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class OrderlineModule { }
