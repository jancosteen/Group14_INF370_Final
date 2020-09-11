import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuard} from 'src/app/auth/auth.guard';


import { HomeComponent } from '../home/home.component';
import { NotFoundComponent } from '../error-pages/not-found/not-found.component';
import { InternalServerComponent } from '../error-pages/internal-server/internal-server.component';
import { InventoryComponent} from '../inventory/inventory.component';
import {UsermanageComponent} from '../usermanage/usermanage.component';
import { EmployeemanageComponent} from '../employeemanage/employeemanage.component';
import { AdministrationComponent} from '../administration/administration.component';
import {OrdermanageComponent} from '../ordermanage/ordermanage.component';
import { MenuComponent } from '../menumanage/menu/menu.component';
import { ReservationComponent } from '../reservationmanage/reservation/reservation.component';
import { ShiftmanageComponent } from '../shiftmanage/shiftmanage.component';
import {MenumanageComponent} from '../menumanage/menumanage.component';
import {MenuitemComponent} from "../menumanage/menuitem/menuitem.component";
import {MenuitemsComponent} from "../menumanage/menu/menuitems/menuitems.component";

import {LoginComponent} from '../usermanage/login/login.component';
import {RestaurantComponent} from '../administration/restaurant/restaurant.component'
import { RestaurantModule } from '../administration/restaurant/restaurant.module';
import { RestaurantListComponent } from '../administration/restaurant/restaurant-list/restaurant-list.component';
import { UserListComponent } from '../usermanage/user/user-list/user-list.component';
import { UserDetailsComponent } from '../usermanage/user/user-details/user-details.component';
import { UserDeleteComponent } from '../usermanage/user/user-delete/user-delete.component';
import { UserUpdateComponent } from '../usermanage/user/user-update/user-update.component';
import { OrderCreateComponent } from '../ordermanage/order/order-create/order-create.component';
import { OrderDetailsComponent } from '../ordermanage/order/order-details/order-details.component';
import { OrderDeleteComponent } from '../ordermanage/order/order-delete/order-delete.component';
import { OrderUpdateComponent } from '../ordermanage/order/order-update/order-update.component';
import { SpecialCreateComponent } from '../ordermanage/special/special-create/special-create.component';
import { SpecialDeleteComponent } from '../ordermanage/special/special-delete/special-delete.component';
import { SpecialDetailsComponent } from '../ordermanage/special/special-details/special-details.component';
import { SpecialUpdateComponent } from '../ordermanage/special/special-update/special-update.component';
import { SpecialListComponent } from '../ordermanage/special/special-list/special-list.component';
import { ReservationmanageComponent } from '../reservationmanage/reservationmanage.component';
import { ReservationDeleteComponent } from '../reservationmanage/reservation/reservation-delete/reservation-delete.component';
import { ReservationUpdateComponent } from '../reservationmanage/reservation/reservation-update/reservation-update.component';
import { ReservationListComponent } from '../reservationmanage/reservation/reservation-list/reservation-list.component';
import { ReservationCreateComponent } from '../reservationmanage/reservation/reservation-create/reservation-create.component';
import { ReservationDetailsComponent } from '../reservationmanage/reservation/reservation-details/reservation-details.component';
import { ReservationstatusListComponent } from '../reservationmanage/reservationstatus/reservationstatus-list/reservationstatus-list.component';
import { ReservationstatusCreateComponent } from '../reservationmanage/reservationstatus/reservationstatus-create/reservationstatus-create.component';
import { ReservationstatusDetailsComponent } from '../reservationmanage/reservationstatus/reservationstatus-details/reservationstatus-details.component';
import { ReservationstatusUpdateComponent } from '../reservationmanage/reservationstatus/reservationstatus-update/reservationstatus-update.component';
import { ReservationstatusDeleteComponent } from '../reservationmanage/reservationstatus/reservationstatus-delete/reservationstatus-delete.component';
import { MenuitemListComponent} from '../menumanage/menuitem/menuitem-list/menuitem-list.component';
import { UserrolesListComponent } from '../usermanage/userroles/userroles-list/userroles-list.component';
import { UserrolesCreateComponent } from '../usermanage/userroles/userroles-create/userroles-create.component';
import { UserrolesUpdateComponent } from '../usermanage/userroles/userroles-update/userroles-update.component';
import { UserrolesDeleteComponent } from '../usermanage/userroles/userroles-delete/userroles-delete.component';
import { UserrolesDetailsComponent } from '../usermanage/userroles/userroles-details/userroles-details.component';
import { UserCreateComponent } from '../usermanage/user/user-create/user-create.component';


const routes: Routes = [
  /**the rest... */
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component:LoginComponent},
  {
      path: 'home', 
      component:HomeComponent, 
      canActivate:[AuthGuard],
  },

  
  {path: '404', component:NotFoundComponent},
  {path: '500', component:InternalServerComponent},
  
  

  /*Inventory Management*/
  {path: 'inventory', component:HomeComponent,
  children: [{
    path: '', component:InventoryComponent
  }]},



  {path: 'supplier', loadChildren: () => import('../supplier/supplier.module').then(x => x.SupplierModule)},
  {path: 'product', loadChildren: () => import('../product/product.module').then(x => x.ProductModule)},
  {path: 'prodCategory', loadChildren: () => import('../product/productcategory/productcategory.module').then(x => x.ProductcategoryModule)},
  {path: 'prodWrittenoff', loadChildren: () => import('../product/productwrittenoff/productwrittenoff.module').then(x => x.ProductwrittenoffModule)},
  {path: 'writtenoffstock', loadChildren: () => import('../product/writtenoffstock/writtenoffstock.module').then(x => x.WrittenoffstockModule)},
  {path: 'supplierorder', loadChildren: () => import('../supplier/supplierorder/supplierorder.module').then(x => x.SupplierorderModule)},
  {path: 'supplierorderline', loadChildren: () => import('../supplier/supplierorderline/supplierorderline.module').then(x => x.SupplierorderlineModule)},
  /*User Management*/
  {path: 'usermanage', component:HomeComponent,
 
  children: [{
    path: '', component:UsermanageComponent
  }]},
  {path: 'user/list', component:HomeComponent,
 
  children: [{
    path: '', component:UserListComponent
  }]},
  {path: 'user/create', component:HomeComponent,
 
  children: [{
    path: '', component:UserCreateComponent
  }]},
  {path: 'user/details/:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserDetailsComponent
  }]},
  {path: 'user/delete/:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserDeleteComponent
  }]},
  {path: 'user/update/:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserUpdateComponent
  }]},
  {path: 'userroles', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesListComponent
  }]},
  {path: 'userroles/list', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesListComponent
  }]},
  {path: 'userroles/create', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesCreateComponent
  }]},
  {path: 'userroles/update:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesUpdateComponent
  }]},
  {path: 'userroles/delete:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesDeleteComponent
  }]},
  {path: 'userroles/details/:id', component:HomeComponent,
 
  children: [{
    path: '', component:UserrolesDetailsComponent
  }]},

  {path: 'user', loadChildren: () =>import('../usermanage/user/user.module').then(x => x.UserModule)},
  {path: 'userroles', loadChildren: () =>import('../usermanage/userroles/userroles.module').then(x => x.UserrolesModule)},
  /*Employee Management*/
  {path: 'employeemanage', component:HomeComponent,
  children: [{
    path: '', component:EmployeemanageComponent
  }]},
  {path: 'employee', loadChildren: () => import('../employeemanage/employee/employee.module').then(x => x.EmployeeModule)},
  
  /*Administration*/
  {path: 'administration', component:HomeComponent,
  children: [{
    path: '', component:AdministrationComponent,
  }]},


  {path: 'Restaurant/list', component:HomeComponent,
  children:[{
    path: '', component:RestaurantListComponent,
  }]},
  
  
  {path: 'restaurantfacility', loadChildren: () => import('../administration/restaurant/restaurantfacility/restaurantfacility.module').then(x => x.RestaurantfacilityModule)},
  {path: 'restaurantstatus', loadChildren: () => import('../administration/restaurant/restaurantstatus/restaurantstatus.module').then(x => x.RestaurantstatusModule)},

  /*Shift Manage*/
  {path: 'shiftmanage', component:HomeComponent,
  
  children: [{
    path: '', component:ShiftmanageComponent
  }]},
  
  {path: 'attendancesheet', loadChildren: () => import('../shiftmanage/attendancesheet/attendancesheet.module').then(x => x.AttendancesheetModule)},
  {path: 'shift', loadChildren: () => import('../shiftmanage/shift/shift.module').then(x => x.ShiftModule)},
  {path: 'shiftstatus', loadChildren: () => import('../shiftmanage/shift/shiftstatus/shiftstatus.module').then(x => x.ShiftstatusModule)},

  /*Menu Management*/
  {path: 'menumanage', component:HomeComponent,
  
  children: [{
    path: '', component:MenumanageComponent
  }]},
  {path: 'menu', component:HomeComponent,
  
  children: [{
    path: '', component:MenuComponent
  }]},
  {path: 'menuitems/:id', component:HomeComponent,
  
  children: [{
    path: '', component:MenuitemsComponent
  }]},
  

  {path: 'menuitem', component:HomeComponent,
  
  children: [{
    path: '', component:MenuitemComponent
  }]},
  {path: 'menuitem/list', component:HomeComponent,
  
  children: [{
    path: '', component:MenuitemListComponent
  }]},
 

  /*Order Management*/
  {path: 'ordermanage', component:HomeComponent,
  children: [{
    path: '', component:OrdermanageComponent
  }]},
  {path: 'order/create', component:HomeComponent,
  children: [{
    path: '', component:OrderCreateComponent
  }]},
  {path: 'order/details/:id', component:HomeComponent,
  children: [{
    path: '', component:OrderDetailsComponent
  }]},
  {path: 'order/delete/:id', component:HomeComponent,
  children: [{
    path: '', component:OrderDeleteComponent
  }]},
  {path: 'order/update/:id', component:HomeComponent,
  children: [{
    path: '', component:OrderUpdateComponent
  }]},
  {path: 'special/create/:id', component:HomeComponent,
  children: [{
    path: '', component:SpecialCreateComponent
  }]},
  {path: 'special/delete/:id', component:HomeComponent,
  children: [{
    path: '', component:SpecialDeleteComponent
  }]},
  {path: 'special/details/:id', component:HomeComponent,
  children: [{
    path: '', component:SpecialDetailsComponent
  }]},
  {path: 'special/list', component:HomeComponent,
  children: [{
    path: '', component:SpecialListComponent
  }]},
  {path: 'special/update/:id', component:HomeComponent,
  children: [{
    path: '', component:SpecialUpdateComponent
  }]},
  {path: 'special', loadChildren:()=> import('../ordermanage/special/special.module').then(x => x.SpecialModule)},
  {path: 'specialprice', loadChildren: ()=> import('../ordermanage/specialprice/specialprice.module').then(x => x.SpecialpriceModule)},
  {path: 'order', loadChildren: ()=> import('../ordermanage/order/order.module').then(x => x.OrderModule)},
  {path: 'orderstatus', loadChildren: ()=> import('../ordermanage/orderstatus/orderstatus.module').then(x => x.OrderstatusModule)},
  {path: 'orderline', loadChildren: ()=> import('../ordermanage/orderline/orderline.module').then(x => x.OrderlineModule)},
  {path: 'seating', loadChildren: ()=> import('../ordermanage/seating/seating.module').then(x => x.SeatingModule)},
  {path: 'qrcodeseating', loadChildren: ()=> import('../ordermanage/qrcodeseating/qrcodeseating.module').then(x => x.QrcodeseatingModule)},
  
  /*Reservation Management*/
  {path: 'reservationmanage', component:HomeComponent,
  children: [{
    path: '', component:ReservationmanageComponent 
  }]},
  {path: 'reservation', component:HomeComponent,
  children: [{
    path: '', component:ReservationComponent
  }]},
  {path: 'reservation/create', component:HomeComponent,
  children: [{
    path: '', component:ReservationCreateComponent
  }]},
  {path: 'reservation/list', component:HomeComponent,
  children: [{
    path: '', component:ReservationListComponent
  }]},
  {path: 'reservation/update/:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationUpdateComponent
  }]},
  {path: 'reservation/delete/:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationDeleteComponent
  }]},
  {path: 'reservation/details/:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationDetailsComponent
  }]},
  {path: 'reservationstatus/list', component:HomeComponent,
  children: [{
    path: '', component:ReservationstatusListComponent
  }]},
  {path: 'reservationstatus/delete:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationstatusDeleteComponent
  }]},
  {path: 'reservationstatus/update:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationstatusUpdateComponent
  }]},
  {path: 'reservationstatus/details:id', component:HomeComponent,
  children: [{
    path: '', component:ReservationstatusDetailsComponent
  }]},
  {path: 'reservationstatus/create', component:HomeComponent,
  children: [{
    path: '', component:ReservationstatusCreateComponent
  }]},
  
  {path: 'reservation', loadChildren:() => import('../reservationmanage/reservation/reservation.module').then(x => x.ReservationModule)},
  {path: 'reservationstatus', loadChildren:() => import('../reservationmanage/reservationstatus/reservationstatus.module').then(x => x.ReservationstatusModule)},

  {path: '**', redirectTo: '/404', pathMatch: 'full'},
  
];


@NgModule({
  imports: [
    RouterModule,
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class RoutingModule { }
