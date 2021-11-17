import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AngularMaterialModule } from 'src/app/components/angular-material/angular-material.module';
import { NavComponent } from 'src/app/components/nav/nav.component';
import { ComponentsModule } from 'src/app/components/components.module';
import { GenericFormComponent } from 'src/app/components/generic-form/generic-form.component';
import { GenericTableComponent } from 'src/app/components/generic-table/generic-table.component';
import { MessageComponent } from 'src/app/components/message/message.component';
import { TestersProjectComponent } from 'src/app/components/admin/tester-project/tester-project.component';


@NgModule({
  declarations: [
    AdminComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    AngularMaterialModule, // EXP: se tiene que importar en cada modulo que use algo de material no solo en el app.module.ts
    ComponentsModule,
  ]
})
export class AdminModule {

}
