import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { RestaurantListComponent } from './restaurant-list/restaurant-list.component';
import { RestaurantDetailsComponent } from './restaurant-details/restaurant-details.component';
import { RestaurantUpdateComponent } from './restaurant-update/restaurant-update.component';
import { RestaurantCreateComponent } from './restaurant-create/restaurant-create.component';
import { RestaurantDeleteComponent } from './restaurant-delete/restaurant-delete.component';



@NgModule({
  declarations: [
    RestaurantListComponent,
    RestaurantDetailsComponent,
    RestaurantUpdateComponent,
    RestaurantCreateComponent,
    RestaurantDeleteComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: RestaurantListComponent},
      {path: 'create', component: RestaurantListComponent},
      {path: 'update/:id', component: RestaurantListComponent},
      {path: 'details/id', component: RestaurantListComponent},
      {path: 'delete/:id', component: RestaurantListComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class RestaurantModule { }
