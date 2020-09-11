
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
import {MenuitemUpdateComponent} from './menumanage/menuitem/menuitem-update/menuitem-update.component';
import {MenuitemDeleteComponent} from './menumanage/menuitem/menuitem-delete/menuitem-delete.component';
import { MenuitemCreateComponent} from './menumanage/menuitem/menuitem-create/menuitem-create.component';
import { SalesbymenuitemComponent } from './administration/reports/salesbymenuitem/salesbymenuitem.component';
import { OrdersbetweenComponent } from './administration/reports/ordersbetween/ordersbetween.component';
import { SalesbyrestaurantComponent } from './administration/reports/salesbyrestaurant/salesbyrestaurant.component';
import { SupplierreportComponent } from './administration/reports/supplierreport/supplierreport.component';
import { AdvertisementCreateComponent } from './administration/advertisement/advertisement-create/advertisement-create.component';
import { AdvertisementListComponent } from './administration/advertisement/advertisement-list/advertisement-list.component';
import { AdvertisementDeleteComponent } from './administration/advertisement/advertisement-delete/advertisement-delete.component';
import { AdvertisementUpdateComponent } from './administration/advertisement/advertisement-update/advertisement-update.component';
import { MenuitemtypeDetailsComponent } from './menumanage/menuitem/menuitemtype/menuitemtype-details/menuitemtype-details.component';
import { MenuitemtypeListComponent } from './menumanage/menuitem/menuitemtype/menuitemtype-list/menuitemtype-list.component';
import { MenuitemtypeDeleteComponent } from './menumanage/menuitem/menuitemtype/menuitemtype-delete/menuitemtype-delete.component';

import { MenuitemcategoryDeleteComponent } from './menumanage/menuitem/menuitemcategory/menuitemcategory-delete/menuitemcategory-delete.component';
import { MenuitemcategoryDetailsComponent } from './menumanage/menuitem/menuitemcategory/menuitemcategory-details/menuitemcategory-details.component';
import { MenuitemcategoryCreateComponent } from './menumanage/menuitem/menuitemcategory/menuitemcategory-create/menuitemcategory-create.component';
import { MenuitemcategoryUpdateComponent } from './menumanage/menuitem/menuitemcategory/menuitemcategory-update/menuitemcategory-update.component';
import { MenuitemcategoryListComponent } from './menumanage/menuitem/menuitemcategory/menuitemcategory-list/menuitemcategory-list.component';


    

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
    MenuitemComponent,
    MenuitemDeleteComponent,
    MenuitemUpdateComponent,
    MenuitemCreateComponent,
    SalesbymenuitemComponent,
    OrdersbetweenComponent,
    SalesbyrestaurantComponent,
    SupplierreportComponent,
    AdvertisementCreateComponent,
    AdvertisementListComponent,
    AdvertisementDeleteComponent,
    AdvertisementUpdateComponent,
    MenuitemtypeDeleteComponent,
    MenuitemtypeListComponent,
    MenuitemtypeDetailsComponent,
    MenuitemcategoryDeleteComponent,
    MenuitemcategoryDetailsComponent,
    MenuitemcategoryCreateComponent,
    MenuitemcategoryUpdateComponent,
    MenuitemcategoryListComponent
  
    


  
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
