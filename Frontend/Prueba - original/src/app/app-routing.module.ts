import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
// import { AdminComponent } from './views/admin/admin.component'; TODO 
import { LoginComponent } from './views/login/login.component';
//import { NotFoundComponent } from './views/not-found/not-found.component';

const routes: Routes = [
  {
    path:'',    
    redirectTo: 'login', 
    pathMatch: 'full'

  },
  {
    path:'login',
    component: LoginComponent
  },
  // { TODO
  //   path:'admin',
  //   loadChildren: () => import('./views/admin/admin.module').then(a => a.AdminModule)
  // },
  // {
  //   path:'dev',
  //   loadChildren: () => import('./views/dev/dev.module').then(m => m.DevModule)
  // },
  // {
  //   path:'tester',
  //   loadChildren: () => import('./views/tester/tester.module').then(m => m.TesterModule)
  // },
  // {
  //   path:'404-not-found',
  //   component: NotFoundComponent
  // },
  // {
  //   path:'**',
  //   redirectTo: '404-not-found'
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }