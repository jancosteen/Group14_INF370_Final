import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';



import { SpecialListComponent } from './special-list/special-list.component';
import { SpecialUpdateComponent } from './special-update/special-update.component';
import { SpecialDetailsComponent } from './special-details/special-details.component';
import { SpecialDeleteComponent } from './special-delete/special-delete.component';
import { SpecialCreateComponent } from './special-create/special-create.component';




@NgModule({
  declarations: [
    SpecialListComponent, 
    SpecialUpdateComponent, 
    SpecialDetailsComponent, 
    SpecialDeleteComponent, 
    SpecialCreateComponent, 
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    MatTableModule,
    DataTablesModule,
    RouterModule.forChild([
      {path: 'list', component: SpecialListComponent},
      {path: 'create', component: SpecialCreateComponent},
      {path: 'update/:id', component: SpecialUpdateComponent},
      {path: 'details/id', component: SpecialDetailsComponent},
      {path: 'delete/:id', component: SpecialDeleteComponent}
    ]),
  ],
  exports: [
    MatTableModule
  ]
})
export class SpecialModule { }
