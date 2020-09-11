import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { SpecialpriceComponent } from './specialprice.component';
import { SpecialpriceListComponent } from './specialprice-list/specialprice-list.component';
import { SpecialpriceUpdateComponent } from './specialprice-update/specialprice-update.component';
import { SpecialpriceDetailsComponent } from './specialprice-details/specialprice-details.component';
import { SpecialpriceDeleteComponent } from './specialprice-delete/specialprice-delete.component';



@NgModule({
  declarations: [
    SpecialpriceComponent, 
    SpecialpriceListComponent, 
    SpecialpriceUpdateComponent, 
    SpecialpriceDetailsComponent, 
    SpecialpriceDeleteComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: SpecialpriceListComponent},
        {path: 'create', component: SpecialpriceListComponent},
        {path: 'update/:id', component: SpecialpriceListComponent},
        {path: 'details/id', component: SpecialpriceListComponent},
        {path: 'delete/:id', component: SpecialpriceListComponent}
      ]),
    ],
    exports: [
      MatTableModule
    ]
})
export class SpecialpriceModule { }
