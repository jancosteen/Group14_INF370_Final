import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';



import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserCreateComponent } from './user-create/user-create.component';
import { UserUpdateComponent } from './user-update/user-update.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserDeleteComponent } from './user-delete/user-delete.component';



@NgModule({
  declarations: [
    UserComponent, 
    UserListComponent, 
    UserCreateComponent, 
    UserUpdateComponent, 
    UserDetailsComponent, 
    UserDeleteComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: UserListComponent},
        {path: 'details/:id', component: UserDetailsComponent},
        {path: 'create', component: UserCreateComponent},
        {path: 'delete/:id', component: UserDeleteComponent},
        {path: 'update/:id', component: UserUpdateComponent}
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class UserModule { }
