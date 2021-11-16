import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './views/login/login.component';
import { AngularMaterialModule } from './components/angular-material/angular-material.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthorizationGuard } from './guards/authorization.guard';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import '@angular/compiler';
import { MessageComponent } from './components/message/message.component';
import { ComponentsModule } from './components/components.module';
import { NotFoundComponent } from './views/not-found/not-found.component';
import { NavComponent } from './components/nav/nav.component';

@NgModule({
  declarations: [ // EXP: todo componente tiene que ser declarado por uno y uno solo modulo
    AppComponent,
    LoginComponent,
    NotFoundComponent
  ],
  imports: [ // EXP: son como las dependencias
    AngularMaterialModule, // EXP: importo todos los modulos de angular material para que no tenga problemas que me falte alguno
    AppRoutingModule,
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,// TODO ver si esta bien ponerlo aca
  ],
  providers: [AuthorizationGuard],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
