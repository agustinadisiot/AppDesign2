import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { MessageComponent } from './message/message.component';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { BugsTableComponent } from './bugs-table/bugs-table/bugs-table.component';
import { BugsComponent } from './admin/bugs/bugs.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgbModule,
    AngularMaterialModule,
  ],
  declarations: [
    GenericTableComponent,
    MessageComponent,
    BugsTableComponent,
    BugsComponent,
  ],
  exports: [
    MessageComponent,
  ]
})
export class ComponentsModule { }
