import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoginComponent } from './views/login/login.component';
//import { NotFoundComponent } from './views/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'

  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin',
    loadChildren: () => import('./views/admin/admin.module').then(a => a.AdminModule)
  },
  {
    path: 'nav',
    loadChildren: () => import('./components/navigation/navigation.module').then(m => m.NavigationModule)
  },
  // {
  //   path:'dev',
  //   loadChildren: () => import('./views/dev/dev.module').then(m => m.DevModule)
  // },
  // {
  //   path:'tester',
  //   loadChildren: () => import('./views/tester/tester.module').then(m => m.TesterModule)
  // },
  {
    path: '404-not-found',
    component: NotFoundComponent
  },
  {
    path: '**',
    redirectTo: '404-not-found'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }