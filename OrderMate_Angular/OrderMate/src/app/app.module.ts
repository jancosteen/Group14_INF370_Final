import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { JwtModule } from "@auth0/angular-jwt";
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RepositoryService} from './shared/services/repository.service'
import { FormsModule, ReactiveFormsModule, NgForm } from '@angular/forms'; 
import { AuthInterceptor} from './auth/auth.interceptor';
import { SharedModule } from './shared/shared.module';
import { AppComponent } from './app.component';
import { RoutingModule } from './routing/routing.module';

import { MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list'
import { MatToolbarModule } from '@angular/material/toolbar';

import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { InventoryComponent } from './inventory/inventory.component';
import { DataTablesModule } from 'angular-datatables';
import { ProductComponent } from './product/product.component';
import { UsermanageComponent} from './usermanage/usermanage.component';
import { EmployeemanageComponent} from './employeemanage/employeemanage.component';
import { AdministrationComponent} from './administration/administration.component';
import { ReservationmanageComponent } from './reservationmanage/reservationmanage.component';
import { ShiftmanageComponent } from './shiftmanage/shiftmanage.component';
import { OrderstatusComponent } from './ordermanage/orderstatus/orderstatus.component';
import {OrdermanageComponent} from './ordermanage/ordermanage.component';
import {MenumanageComponent} from './menumanage/menumanage.component';
import { HomeComponent} from './home/home.component';

import { LoginComponent } from './usermanage/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import {MenuComponent} from './menumanage/menu/menu.component';
import {MenuitemsComponent} from './menumanage/menu/menuitems/menuitems.component';
import { MenuitemListComponent } from './menumanage/menuitem/menuitem-list/menuitem-list.component';
import { MenuitemComponent } from './menumanage/menuitem/menuitem.component';


export function tokenGetter(){
  return localStorage.getItem('token');
}



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
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
    MenuComponent,
    LoginComponent,
    MenuitemsComponent,
    MenuitemListComponent,
    MenuitemComponent
    


  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    HttpClientModule,  
    RoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    DataTablesModule,
    MatListModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["http://localhost:5000"],
        throwNoTokenError: true,
        skipWhenExpired: true,
      }
    }),
  
    ToastrModule.forRoot({
      progressBar: true
    })
    
  ],
  exports:[
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatListModule
  ],
  providers: [
    RepositoryService,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
