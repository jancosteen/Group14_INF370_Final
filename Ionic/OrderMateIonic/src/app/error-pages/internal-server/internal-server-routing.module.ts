import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InternalServerPage } from './internal-server.page';

const routes: Routes = [
  {
    path: '',
    component: InternalServerPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InternalServerPageRoutingModule {}
