import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from '../../services/copago.service';
import { NgForm } from '@angular/forms';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';


@Component({
  selector: 'app-copago-registro',
  templateUrl: './copago-registro.component.html',
  styleUrls: ['./copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {

  formGroup: FormGroup;
  copago:Copago;

  constructor(private copagoService: CopagoService,  private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.copago = new Copago();
    this. buildForm();
  }

  private buildForm() {

          this.copago.identificacionPaciente="";
          this.copago.salarioTrabajador=0;
          this.copago.valorServicio=0;

          this.formGroup = this.formBuilder.group({ 

      identificacionPaciente: [this.copago.identificacionPaciente, [Validators.required, Validators.maxLength(11)]],
      valorServicio:  [this.copago.valorServicio,[Validators.required, Validators.min(1)]],
      salarioTrabajador: [this.copago.salarioTrabajador,[Validators.required, Validators.min(1)]]


    });
  
  }
   

  get control() { 
    return this.formGroup.controls;
  }

  onSubmit() {
  if (this.formGroup.invalid) {
          return;
        }
        this.add();
  }
    
    


  add(){

    this.copago=this.formGroup.value;
    this.copagoService.post(this.copago).subscribe(p => {
      if (p != null) {
        alert('registro correcto!');
      }
    });

  }
  
  clear(formulario:NgForm){
    formulario.reset();
  }
  
}
