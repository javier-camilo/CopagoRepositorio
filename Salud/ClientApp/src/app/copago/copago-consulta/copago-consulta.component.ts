import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from 'src/app/services/copago.service';

@Component({
  selector: 'app-copago-consulta',
  templateUrl: './copago-consulta.component.html',
  styleUrls: ['./copago-consulta.component.css']
})
export class CopagoConsultaComponent implements OnInit {

  copagos:Copago[];
  searchText:string;

  constructor(private copagoService: CopagoService) { }

  ngOnInit() {
    this.get();
  }

  get(){
    
    this.copagoService.get().subscribe(result => {
      this.copagos = result;
    });

  }

}
