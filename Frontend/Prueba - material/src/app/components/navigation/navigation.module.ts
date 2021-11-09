import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavigationRoutingModule } from './navigation-routing.module';
import { NavigationComponent } from './navigation.component';
import { AngularMaterialModule } from 'src/app/components/angular-material/angular-material.module';


@NgModule({
  declarations: [
    NavigationComponent
  ],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    AngularMaterialModule
  ]
})
export class NavigationModule { }
