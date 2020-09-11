import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms'; 

import { MenuitemtypeListComponent } from './menuitemtype-list/menuitemtype-list.component';
import { MenuitemtypeUpdateComponent } from './menuitemtype-update/menuitemtype-update.component';
import { MenuitemtypeCreateComponent } from './menuitemtype-create/menuitemtype-create.component';
import { MenuitemtypeDeleteComponent } from './menuitemtype-delete/menuitemtype-delete.component';
import { MenuitemtypeDetailsComponent } from './menuitemtype-details/menuitemtype-details.component';

 

@NgModule({
  declarations: [
    MenuitemtypeListComponent, 
    MenuitemtypeUpdateComponent,
    MenuitemtypeCreateComponent,
    MenuitemtypeDeleteComponent,
    MenuitemtypeDetailsComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: MenuitemtypeListComponent},
        {path: 'details/:id', component: MenuitemtypeDetailsComponent},
        {path: 'create', component: MenuitemtypeCreateComponent},
        {path: 'delete/:id', component: MenuitemtypeDeleteComponent},
        {path: 'update/:id', component: MenuitemtypeUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class MenuitemtypeModule { }
