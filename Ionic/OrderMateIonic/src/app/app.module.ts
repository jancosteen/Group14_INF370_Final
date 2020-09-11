import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { IonicStorageModule} from '@ionic/storage';

import {HttpClientModule} from '@angular/common/http';
import { CartModalPageModule } from './cart/cart-modal/cart-modal.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {JwtModule} from '@auth0/angular-jwt';


@NgModule({
  declarations: [AppComponent],
  entryComponents: [],
  imports: [BrowserModule,
     IonicModule.forRoot(),
     AppRoutingModule,
    IonicStorageModule.forRoot(),
    HttpClientModule,
  CartModalPageModule,
  BrowserAnimationsModule,
MatSnackBarModule,
JwtModule.forRoot({
  config: {
    tokenGetter: function  tokenGetter() {
         return     localStorage.getItem('access_token');}
  }
})],
    
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
