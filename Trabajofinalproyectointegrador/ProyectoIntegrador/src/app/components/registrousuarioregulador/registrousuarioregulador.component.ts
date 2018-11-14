import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Usuarioreguladorservice } from '../Services/usuarioregulador.services';
import{ Usuarioregulador } from "../entidades/usuarioregulador";
import { Router } from "@angular/router";
@Component({
  selector: 'app-registrousuarioregulador',
  templateUrl: './registrousuarioregulador.component.html',
  styleUrls: ['./registrousuarioregulador.component.css']
})
export class RegistrousuarioreguladorComponent implements OnInit {
  formulario: FormGroup;
  onSubmit: boolean = false;
  usuario: Usuarioregulador;
  constructor(private _usuarioreguladorService: Usuarioreguladorservice,
    private _router:Router) { 
        this.formulario = new FormGroup({
        'NOM_REG': new FormControl('', [Validators.required]),
        'APE_REG': new FormControl('', [Validators.required]),
        'CORREO': new FormControl('', [Validators.required]),
        'NIVEL': new FormControl('', [Validators.required, Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$")]),
        'CATEGORIA': new FormControl('', [Validators.required]),
        'COD_ID': new FormControl('', [Validators.required]),
        
      });
    }
    registrar(){

      this.onSubmit = true;
      console.log(this.formulario);
      this.usuario = {
        COD_REG: 0,
        NOM_REG: this.formulario.controls['NOM_REG'].value,
        APE_REG: this.formulario.controls['APE_REG'].value,
        CORREO: this.formulario.controls['CORREO'].value,
        NIVEL: this.formulario.controls['NIVEL'].value,
        CATEGORIA: this.formulario.controls['CATEGORIA'].value,
        COD_ID: this.formulario.controls['COD_ID'].value,
       
      }
  
      console.log(this.usuario);
  
      this._usuarioreguladorService.registro(this.usuario)
        .subscribe(data => {
          console.log(data);
          //this.router.navigate(['/heroe',data['name']])
        },
          error => console.error(error));
  
    }
  ngOnInit() {
  }

}
