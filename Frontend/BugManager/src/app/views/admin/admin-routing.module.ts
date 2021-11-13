import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BugsTableComponent } from 'src/app/components/bugs-table/bugs-table/bugs-table.component';
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
        component: BugsTableComponent
      },
      {
        path: 'add-user',
        component: TableComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
