import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { MatTable, MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DataTablesModule } from 'angular-datatables';
import { ReactiveFormsModule } from '@angular/forms';


import { QrcodeseatingComponent } from './qrcodeseating.component';
import { QrcodeseatingListComponent } from './qrcodeseating-list/qrcodeseating-list.component';
import { QrcodeseatingUpdateComponent } from './qrcodeseating-update/qrcodeseating-update.component';
import { QrcodeseatingCreateComponent } from './qrcodeseating-create/qrcodeseating-create.component';
import { QrcodeseatingDetailsComponent } from './qrcodeseating-details/qrcodeseating-details.component';
import { QrcodeseatingDeleteComponent } from './qrcodeseating-delete/qrcodeseating-delete.component';






@NgModule({
  declarations: [
    QrcodeseatingComponent,
    QrcodeseatingListComponent,
    QrcodeseatingUpdateComponent,
    QrcodeseatingCreateComponent,
    QrcodeseatingDetailsComponent,
    QrcodeseatingDeleteComponent],
    imports: [
      CommonModule,
      SharedModule,
      ReactiveFormsModule,
      MatTableModule,
      DataTablesModule,
      RouterModule.forChild([
        {path: 'list', component: QrcodeseatingListComponent},
        {path: 'details/:id', component: QrcodeseatingDetailsComponent},
        {path: 'create', component: QrcodeseatingCreateComponent},
    //    {path: 'delete/:id', component: OrderstatusDeleteComponent},
        {path: 'update/:id', component: QrcodeseatingUpdateComponent}
        
      
    ])
    ],
    exports: [
      MatTableModule
    ]
})
export class QrcodeseatingModule { }
