import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateReservationPageRoutingModule } from './create-reservation-routing.module';

import { CreateReservationPage } from './create-reservation.page';
import {MaterialModule} from './../../material.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreateReservationPageRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  declarations: [CreateReservationPage]
})
export class CreateReservationPageModule {}
