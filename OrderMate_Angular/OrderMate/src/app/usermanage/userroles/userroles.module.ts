import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';

import { UserrolesComponent } from '../userroles/userroles.component';
import {UserrolesCreateComponent} from '../userroles/userroles-create/userroles-create.component';
import {UserrolesListComponent} from './userroles-list/userroles-list.component';
import {UserrolesUpdateComponent}from './userroles-update/userroles-update.component';
import {UserrolesDeleteComponent} from '../userroles/userroles-delete/userroles-delete.component';
import {UserrolesDetailsComponent} from '../userroles/userroles-details/userroles-details.component';




@NgModule({
  declarations: [UserrolesComponent,
    UserrolesListComponent,
    UserrolesCreateComponent,
    UserrolesUpdateComponent,
    UserrolesDeleteComponent,
    UserrolesDetailsComponent,],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: UserrolesListComponent},
        {path: 'details/:id', component: UserrolesDetailsComponent},
        {path: 'create', component: UserrolesCreateComponent},
        {path: 'delete/:id', component: UserrolesDeleteComponent},
        {path: 'update/:id', component: UserrolesUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class UserrolesModule { }
