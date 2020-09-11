import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { RoutingModule } from '../routing/routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule} from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { InventoryComponent } from '../inventory/inventory.component';
import { DataTablesModule } from 'angular-datatables';
import { ProductComponent } from '../product/product.component';
import { UsermanageComponent} from '../usermanage/usermanage.component';
import { EmployeemanageComponent} from '../employeemanage/employeemanage.component';
import { AdministrationComponent} from '../administration/administration.component';
import { ReservationmanageComponent } from '../reservationmanage/reservationmanage.component';
import { ShiftmanageComponent } from '../shiftmanage/shiftmanage.component';
import { OrderstatusComponent } from '../ordermanage/orderstatus/orderstatus.component';
import {OrdermanageComponent} from '../ordermanage/ordermanage.component';
import {MenumanageComponent} from '../menumanage/menumanage.component';




@NgModule({
  declarations: [
    InventoryComponent,
    ProductComponent,
    UsermanageComponent,
    EmployeemanageComponent,
    AdministrationComponent,
    ReservationmanageComponent,
    ShiftmanageComponent,
    OrderstatusComponent,
    OrdermanageComponent,
    MenumanageComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    DataTablesModule
  ],
  exports:[
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule
  ],
})
export class HomeModule { }
