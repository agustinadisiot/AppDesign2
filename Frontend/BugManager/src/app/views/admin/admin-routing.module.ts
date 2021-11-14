import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BugsComponent } from 'src/app/components/admin/bugs/bugs.component';
import { DevsScoreboardComponent } from 'src/app/components/admin/devs-scoreboard/devs-scoreboard.component';
import { ProjectsComponent } from 'src/app/components/admin/projects/projects.component';
import { TableComponent } from 'src/app/components/table/table.component';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: 'bugs'
      },
      {
        path: 'bugs',
        component: BugsComponent
      },
      {
        path: 'add-user',
        component: TableComponent
      },
      {
        path: 'projects',
        component: ProjectsComponent
      },
      {
        path: 'devs-scoreboard',
        component: DevsScoreboardComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
