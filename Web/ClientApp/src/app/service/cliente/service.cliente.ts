import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/entidad/cliente/entidad.cliente';





@Injectable()
export class ClienteService {
      

    constructor(
        public http: HttpClient
    ){}


    getClientes(id:number) : Observable<Cliente[]>{
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json charset=utf-8','Accept': 'application/json' })
          };
        return this.http.get<Cliente[]>('api/Cliente/GetClientes/', httpOptions);
      }

   

}