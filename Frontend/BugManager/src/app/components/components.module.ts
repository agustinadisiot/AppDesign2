import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NotFoundComponent } from './not-found/not-found.component';
import { NavComponent } from './nav/nav.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { MessageComponent } from './message/message.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgbModule
  ],
  declarations: [
    NotFoundComponent,
    GenericTableComponent,
    MessageComponent,
  ],
  exports: [
    MessageComponent,
  ]
})
export class ComponentsModule { }
