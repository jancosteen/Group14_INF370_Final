import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { AdvertisementCreateComponent } from './advertisement-create/advertisement-create.component';
import { AdvertisementListComponent } from './advertisement-list/advertisement-list.component';
import { AdvertisementUpdateComponent } from './advertisement-update/advertisement-update.component';
import { AdvertisementDeleteComponent } from './advertisement-delete/advertisement-delete.component';
import { AdvertisementDetailsComponent } from './advertisement-details/advertisement-details.component';



@NgModule({
  declarations: [
    AdvertisementCreateComponent, 
    AdvertisementListComponent, 
    AdvertisementUpdateComponent, 
    AdvertisementDeleteComponent, 
    AdvertisementDetailsComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: AdvertisementListComponent},
        {path: 'details/:id', component: AdvertisementDetailsComponent},
        {path: 'create', component: AdvertisementCreateComponent},
        {path: 'delete/:id', component: AdvertisementDeleteComponent},
        {path: 'update/:id', component: AdvertisementUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class AdvertisementModule { }
