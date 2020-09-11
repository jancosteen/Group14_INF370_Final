import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 




import { RestaurantfacilityComponent } from './restaurantfacility.component';
import { RestaurantfacilityListComponent } from './restaurantfacility-list/restaurantfacility-list.component';
import { RestaurantfacilityCreateComponent } from './restaurantfacility-create/restaurantfacility-create.component';
import { RestaurantfacilityUpdateComponent } from './restaurantfacility-update/restaurantfacility-update.component';
import { RestaurantfacilityDeleteComponent } from './restaurantfacility-delete/restaurantfacility-delete.component';



@NgModule({
  declarations: [
    RestaurantfacilityComponent, 
    RestaurantfacilityListComponent, RestaurantfacilityCreateComponent, RestaurantfacilityUpdateComponent, RestaurantfacilityDeleteComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: RestaurantfacilityListComponent},
       // {path: 'details/:id', component: ShiftDetailsComponent},
        {path: 'create', component: RestaurantfacilityCreateComponent},
        {path: 'delete/:id', component: RestaurantfacilityDeleteComponent},
        {path: 'update/:id', component: RestaurantfacilityUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class RestaurantfacilityModule { }
