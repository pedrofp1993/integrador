import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { APP_ROUTING } from './app.routes';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';


import { RegistrousuariotiendaComponent } from './components/registrousuariotienda/registrousuariotienda.component';
import { ObtenerusuariotiendaComponent } from './components/obtenerusuariotienda/obtenerusuariotienda.component';
import { ActualizarusuariotiendaComponent } from './components/actualizarusuariotienda/actualizarusuariotienda.component';


import { RegistrousuariojugadorComponent } from './components/registrousuariojugador/registrousuariojugador.component';
import { ObtenerusuariojugadorComponent } from './components/obtenerusuariojugador/obtenerusuariojugador.component';
import { ActualizarusuariojugadorComponent } from './components/actualizarusuariojugador/actualizarusuariojugador.component';


import { RegistrousuarioreguladorComponent } from './components/registrousuarioregulador/registrousuarioregulador.component';
import { ObtenerusuarioreguladorComponent } from './components/obtenerusuarioregulador/obtenerusuarioregulador.component';
import { ActualizarusuarioreguladorComponent } from './components/actualizarusuarioregulador/actualizarusuarioregulador.component';


import { RegistroeventoComponent } from './components/registroevento/registroevento.component';



import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Usuariojugadorservice } from './components/Services/usuariojugador.service';
import { Usuarioreguladorservice } from './components/Services/usuarioregulador.services';
import { Usuariotiendaservice } from './components/Services/usuariotienda.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    RegistrousuariotiendaComponent,
    RegistrousuariojugadorComponent,
    RegistrousuarioreguladorComponent,
    RegistroeventoComponent,
    ObtenerusuariotiendaComponent,
    ObtenerusuariojugadorComponent,
    ObtenerusuarioreguladorComponent,
    ActualizarusuarioreguladorComponent,
    ActualizarusuariotiendaComponent,
    ActualizarusuariojugadorComponent
  ],
  imports: [
    BrowserModule,APP_ROUTING,HttpClientModule,FormsModule,
    ReactiveFormsModule
  ],
  providers: [Usuariojugadorservice,Usuarioreguladorservice,Usuariotiendaservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
