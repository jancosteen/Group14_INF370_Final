import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 




import { RestaurantstatusListComponent } from './restaurantstatus-list/restaurantstatus-list.component';
import { RestaurantstatusCreateComponent } from './restaurantstatus-create/restaurantstatus-create.component';
import { RestaurantstatusUpdateComponent } from './restaurantstatus-update/restaurantstatus-update.component';
import { RestaurantstatusDetailsComponent } from './restaurantstatus-details/restaurantstatus-details.component';
import { RestaurantstatusDeleteComponent } from './restaurantstatus-delete/restaurantstatus-delete.component';



@NgModule({
  declarations: [
    RestaurantstatusListComponent,
    RestaurantstatusCreateComponent,
    RestaurantstatusUpdateComponent,
    RestaurantstatusDetailsComponent,
    RestaurantstatusDeleteComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: RestaurantstatusListComponent},
        {path: 'details/:id', component: RestaurantstatusDetailsComponent},
        {path: 'create', component: RestaurantstatusCreateComponent},
        {path: 'delete/:id', component: RestaurantstatusDeleteComponent},
        {path: 'update/:id', component: RestaurantstatusUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class RestaurantstatusModule { }
