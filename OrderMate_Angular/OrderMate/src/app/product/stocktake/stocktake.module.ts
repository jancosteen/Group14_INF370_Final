import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { StocktakeComponent } from './stocktake.component';
import { StocktakeListComponent } from './stocktake-list/stocktake-list.component';
import { StocktakeCreateComponent } from './stocktake-create/stocktake-create.component';
import { StocktakeUpdateComponent } from './stocktake-update/stocktake-update.component';
import { StocktakeDetailsComponent } from './stocktake-details/stocktake-details.component';
import { StocktakeDeleteComponent } from './stocktake-delete/stocktake-delete.component';



@NgModule({
  declarations: [
    StocktakeComponent, 
    StocktakeListComponent, 
    StocktakeCreateComponent, 
    StocktakeUpdateComponent, 
    StocktakeDetailsComponent, 
    StocktakeDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: StocktakeListComponent},
      {path: 'details/:id', component: StocktakeDetailsComponent},
      {path: 'update/:id', component: StocktakeUpdateComponent},
      {path: 'create', component: StocktakeCreateComponent},
      {path: 'delete/:id', component: StocktakeDeleteComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class StocktakeModule { }
