import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';



import { OrderComponent } from './order.component';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrderDeleteComponent } from './order-delete/order-delete.component';
import { OrderUpdateComponent } from './order-update/order-update.component';
import { OrderCreateComponent } from './order-create/order-create.component';



@NgModule({
  declarations: [OrderComponent, OrderListComponent, OrderDetailsComponent, OrderDeleteComponent, OrderUpdateComponent, OrderCreateComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: OrderListComponent}
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
export class OrderModule { }
