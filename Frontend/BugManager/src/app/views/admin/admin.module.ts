import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { TableComponent } from 'src/app/components/table/table.component';
import { AngularMaterialModule } from 'src/app/components/angular-material/angular-material.module';
import { NavComponent } from 'src/app/components/nav/nav.component';


@NgModule({
  declarations: [
    AdminComponent,
    TableComponent,
    NavComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    AngularMaterialModule, // EXP: se tiene que importar en cada modulo que use algo de material no solo en el app.module.ts

  ]
})
export class AdminModule {

  addData() {
    console.log();
  }
}
