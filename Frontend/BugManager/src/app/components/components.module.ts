import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { MessageComponent } from './message/message.component';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { BugsTableComponent } from './bugs-table/bugs-table.component';
import { BugsComponent } from './admin/bugs/bugs.component';
import { ProjectsTableComponent } from './projects-table/projects-table.component';
import { ProjectsComponent } from './admin/projects/projects.component';
import { DevsScoreboardComponent } from './admin/devs-scoreboard/devs-scoreboard.component';
import { GenericFormComponent } from './generic-form/generic-form.component';
import { CreateUserComponent } from './admin/create-user/create-user.component';

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
    ProjectsTableComponent,
    ProjectsComponent,
    DevsScoreboardComponent,
    GenericFormComponent,
    CreateUserComponent,
  ],
  exports: [
    MessageComponent,
  ]
})
export class ComponentsModule { }
