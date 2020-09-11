import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardPageModule' },
  {
    path: 'create-reservation',
    loadChildren: () => import('./create-reservation/create-reservation.module').then( m => m.CreateReservationPageModule)
  },
  {
    path: 'reservation-list',
    loadChildren: () => import('./reservation-list/reservation-list.module').then( m => m.ReservationListPageModule)
  },
  {
    path: 'my-orders',
    loadChildren: () => import('./my-orders/my-orders.module').then( m => m.MyOrdersPageModule)
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class MemberRoutingModule { }
