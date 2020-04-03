import { Injectable, Inject } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Copago } from '../copago/models/copago';


@Injectable({
  providedIn: 'root'
})
export class CopagoService {
  

  baseUrl: string;
  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService)
  {
      this.baseUrl = baseUrl;
  }

  post(copago: Copago): Observable<Copago> {
    return this.http.post<Copago>(this.baseUrl + 'api/Copago', copago)
        .pipe(
            tap(_ => this.handleErrorService.log('Datos enviados')),
            catchError(this.handleErrorService.handleError<Copago>('Registrar Persona', null))
   );
  }

  
  get(): Observable<Copago[]> {
    return this.http.get<Copago[]>(this.baseUrl + 'api/Copago')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Copago[]>('Consulta Persona', null))
        );
  }




}
