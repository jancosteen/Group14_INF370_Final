import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables'; 
import { ReactiveFormsModule } from '@angular/forms';


import { OrderstatusListComponent } from './orderstatus-list/orderstatus-list.component';
import { OrderstatusCreateComponent } from './orderstatus-create/orderstatus-create.component';
import { OrderstatusUpdateComponent } from './orderstatus-update/orderstatus-update.component';
import { OrderstatusDetailsComponent } from './orderstatus-details/orderstatus-details.component';
import { OrderstatusDeleteComponent } from './orderstatus-delete/orderstatus-delete.component';



@NgModule({
  declarations: [
    OrderstatusListComponent, 
    OrderstatusCreateComponent, 
    OrderstatusUpdateComponent, 
    OrderstatusDetailsComponent, 
    OrderstatusDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: OrderstatusListComponent},
      
      {path: 'details/:id', component: OrderstatusDetailsComponent},
      {path: 'create', component: OrderstatusCreateComponent},
      {path: 'delete/:id', component: OrderstatusDeleteComponent},
      {path: 'update/:id', component: OrderstatusUpdateComponent}
      
    
  ])
  ],
  exports: [
    MatTableModule
  ]
})
export class OrderstatusModule { }
