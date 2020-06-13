import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from 'src/app/services/copago.service';
import { SignalRService } from 'src/app/services/signal-r.service';

@Component({
  selector: 'app-copago-consulta',
  templateUrl: './copago-consulta.component.html',
  styleUrls: ['./copago-consulta.component.css']
})
export class CopagoConsultaComponent implements OnInit {

  copagos:Copago[] = [];
  searchText:string;

  constructor(private copagoService: CopagoService,private signalRService: SignalRService) { }

  ngOnInit() {

    this.get();
    
    this.signalRService.signalReceived.subscribe((copago: Copago) => {
      this.copagos.push(copago);
    });

  }

  get(){
    
    this.copagoService.get().subscribe(result => {
      this.copagos = result;
    });

  }

}
