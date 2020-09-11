import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'restaurant/:id',
    loadChildren: () => import('./restaurants/restaurant/restaurant.module').then( m => m.RestaurantPageModule)
  },
  {
    path: 'menu/:id',
    loadChildren: () => import('./menus/menu/menu.module').then( m => m.MenuPageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./public/login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'register',
    loadChildren: () => import('./public/register/register.module').then( m => m.RegisterPageModule)
  },
  { 
    path: 'members', 
    canActivate: [AuthGuard],
    loadChildren: './members/member-routing.module#MemberRoutingModule'
  },
  {
    path: 'restaurant-list',
    loadChildren: () => import('./restaurants/restaurant-list/restaurant-list/restaurant-list.module').then( m => m.RestaurantListPageModule)
  },
  {
    path: 'cart-modal',
    loadChildren: () => import('./cart/cart-modal/cart-modal.module').then( m => m.CartModalPageModule)
  },
  {
    path: 'qr-scanner',
    loadChildren: () => import('./qr-scanner/qr-scanner.module').then( m => m.QrScannerPageModule)
  },   {
    path: 'login-modal',
    loadChildren: () => import('./public/login-modal/login-modal.module').then( m => m.LoginModalPageModule)
  },
  {
    path: '500',
    loadChildren: () => import('./error-pages/internal-server/internal-server.module').then( m => m.InternalServerPageModule)
  },
  {
    path: 'forgot-password',
    loadChildren: () => import('./public/forgot-password/forgot-password.module').then( m => m.ForgotPasswordPageModule)
  }
 
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
