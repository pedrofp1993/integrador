import { Component ,OnInit} from "@angular/core";
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Usuariojugadorservice } from '../Services/usuariojugador.service';
import{ Usuariojugador } from "../entidades/usuariojugador";
import { Router } from "@angular/router";
@Component({
  selector: 'app-registrousuariojugador',
  templateUrl: './registrousuariojugador.component.html',
  styleUrls: ['./registrousuariojugador.component.css']
})
export class RegistrousuariojugadorComponent implements OnInit {
  formulario: FormGroup;
  onSubmit: boolean = false;
  usuario: Usuariojugador;
  constructor(private _usuariojugadorService: Usuariojugadorservice,
              private _router:Router) { 
                this.formulario = new FormGroup({
                  'NOM_JUGADOR': new FormControl('', [Validators.required]),
                  'APELLIDO_JUGADOR': new FormControl('', [Validators.required]),
                  'CORREO_ELECTRONICO': new FormControl('', [Validators.required]),
                  'ID_USUARIO_JUG': new FormControl('', [Validators.required, Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]),
                  'CONTRASEÑA': new FormControl('', [Validators.required]),
                  'DIRECCION': new FormControl('', [Validators.required]),
                  'CIUDAD': new FormControl('', [Validators.required]),
                  'DNI': new FormControl('', [Validators.required]),
                  'FECHA_NACIMIENTO': new FormControl('', [Validators.required])
                });
  }

  registrar(){

    this.onSubmit = true;
    console.log(this.formulario);
    this.usuario = {
      COD_JUGADOR: 0,
      NOM_JUGADOR: this.formulario.controls['NOM_JUGADOR'].value,
      APELLIDO_JUGADOR: this.formulario.controls['APELLIDO_JUGADOR'].value,
      CORREO_ELECTRONICO: this.formulario.controls['CORREO_ELECTRONICO'].value,
      ID_USUARIO_JUG: this.formulario.controls['ID_USUARIO_JUG'].value,
      CONTRASEÑA: this.formulario.controls['CONTRASEÑA'].value,
      DIRECCION: this.formulario.controls['DIRECCION'].value,
      CIUDAD: this.formulario.controls['CIUDAD'].value,
      DNI: this.formulario.controls['DNI'].value,
      FECHA_NACIMIENTO: this.formulario.controls['FECHA_NACIMIENTO'].value
    }

    console.log(this.usuario);

    this._usuariojugadorService.registro(this.usuario)
      .subscribe(data => {
        console.log(data);
        //this.router.navigate(['/heroe',data['name']])
      },
        error => console.error(error));

  }
  ngOnInit(){

  }
}
