import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResolveBugsComponent } from 'src/app/components/dev/resolve-bugs/resolve-bugs.component';
import { DevComponent } from './dev.component';

const routes: Routes = [{
  path: '',
  component: DevComponent,
  children: [
    {
      path: '',
      redirectTo: 'bugs'
    },
    {
      path: 'bugs',
      component: ResolveBugsComponent
    }
  ]
}]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DevRoutingModule { }
