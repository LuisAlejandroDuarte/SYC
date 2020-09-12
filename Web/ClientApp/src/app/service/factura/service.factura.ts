import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConsultaFactura, Factura } from 'src/app/entidad/factura/entidad.factura';






@Injectable()
export class FacturaService {
      

    constructor(
        public http: HttpClient
    ){}


    setFactura(factura:Factura) : Observable<Factura>{
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json charset=utf-8','Accept': 'application/json' })
          };
        return this.http.post<Factura>('api/Factura/CrearFactura/',JSON.stringify(factura), httpOptions);
      }


      getFactura() : Observable<ConsultaFactura[]>{
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json charset=utf-8','Accept': 'application/json' })
          };
        return this.http.get<ConsultaFactura[]>('api/Factura/GetFacturas/',httpOptions);
      }

   

}