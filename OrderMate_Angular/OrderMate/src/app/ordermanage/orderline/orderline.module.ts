import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms'; 



import { OrderlineComponent } from './orderline.component';
import { OrderlineListComponent } from './orderline-list/orderline-list.component';
import { OrderlineCreateComponent } from './orderline-create/orderline-create.component';
import { OrderlineUpdateComponent } from './orderline-update/orderline-update.component';
import { OrderlineDetailsComponent } from './orderline-details/orderline-details.component';
import { OrderlineDeleteComponent } from './orderline-delete/orderline-delete.component';
import { UpdatestatusComponent } from './updatestatus/updatestatus.component';



@NgModule({
  declarations: [OrderlineComponent, 
    OrderlineListComponent,
    OrderlineCreateComponent, 
    OrderlineUpdateComponent, 
    OrderlineDetailsComponent, 
    OrderlineDeleteComponent, 
    UpdatestatusComponent],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: OrderlineListComponent},
      
      {path: 'details/:id', component: OrderlineDetailsComponent},
      {path: 'create', component: OrderlineCreateComponent},
      {path: 'delete/:id', component: OrderlineDeleteComponent},
      {path: 'update/:id', component: OrderlineUpdateComponent}
      
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class OrderlineModule { }
