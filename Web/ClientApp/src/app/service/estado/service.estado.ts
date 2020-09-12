import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estado } from 'src/app/entidad/estado/entidad.estado';






@Injectable()
export class EstadoService {
      

    constructor(
        public http: HttpClient
    ){}


    getEstados(id:number) : Observable<Estado[]>{
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json charset=utf-8','Accept': 'application/json' })
          };
        return this.http.get<Estado[]>('api/EstadoFactura/GetEstadoFactura/', httpOptions);
      }

   

}