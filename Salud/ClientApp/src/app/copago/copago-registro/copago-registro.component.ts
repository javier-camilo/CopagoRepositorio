import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from '../../services/copago.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-copago-registro',
  templateUrl: './copago-registro.component.html',
  styleUrls: ['./copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {

  copago:Copago;

  constructor(private copagoService: CopagoService) { }

  ngOnInit() {
    this.copago = new Copago();
  }


  add(formulario: NgForm){
    this.copagoService.post(this.copago).subscribe(p => {
      if (p != null) {
        alert('registro correcto!');
      }
    });

    this.clear(formulario);

  }
  
  clear(formulario:NgForm){
    formulario.reset();
  }
  
}
