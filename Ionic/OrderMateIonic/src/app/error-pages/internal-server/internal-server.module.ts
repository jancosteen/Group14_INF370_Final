import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { InternalServerPageRoutingModule } from './internal-server-routing.module';

import { InternalServerPage } from './internal-server.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    InternalServerPageRoutingModule
  ],
  declarations: [InternalServerPage]
})
export class InternalServerPageModule {}
