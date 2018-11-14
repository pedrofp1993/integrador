import {RouterModule, Routes} from '@angular/router';

import {HomeComponent} from './components/home/home.component';
import {LoginComponent} from './components/login/login.component';

import { RegistrousuariojugadorComponent } from './components/registrousuariojugador/registrousuariojugador.component';
import { ActualizarusuariojugadorComponent } from './components/actualizarusuariojugador/actualizarusuariojugador.component';
import { ObtenerusuariojugadorComponent } from './components/obtenerusuariojugador/obtenerusuariojugador.component';



import { RegistrousuariotiendaComponent } from './components/registrousuariotienda/registrousuariotienda.component';
import { ObtenerusuariotiendaComponent } from './components/obtenerusuariotienda/obtenerusuariotienda.component';
import { ActualizarusuariotiendaComponent } from './components/actualizarusuariotienda/actualizarusuariotienda.component';



import { RegistrousuarioreguladorComponent } from './components/registrousuarioregulador/registrousuarioregulador.component';
import { ObtenerusuarioreguladorComponent } from './components/obtenerusuarioregulador/obtenerusuarioregulador.component';
import { ActualizarusuarioreguladorComponent } from './components/actualizarusuarioregulador/actualizarusuarioregulador.component';


const APP_ROUTES: Routes = [
  {path:'home',component: HomeComponent},
  {path:'login',component: LoginComponent},


  {path:'registrotienda',component: RegistrousuariotiendaComponent},
  {path:'Obtenerusuariotienda',component: ObtenerusuariotiendaComponent},
  {path:'Actualizarusuariotienda',component: ActualizarusuariotiendaComponent},


  {path:'registrojugador',component: RegistrousuariojugadorComponent},
  {path:'Obtenerusuariojugador',component: ObtenerusuariojugadorComponent},
  {path:'Actualizarusuariojugador',component: ActualizarusuariojugadorComponent},

  {path:'Registrousuarioregulador',component: RegistrousuarioreguladorComponent},
  {path:'Obtenerusuarioregulador',component: ObtenerusuarioreguladorComponent},
  {path:'Actualizarusuarioregulador',component: ActualizarusuarioreguladorComponent},

  {path:'**',pathMatch:'full',redirectTo:'home'}
];
export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);
