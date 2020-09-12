import { Component, OnInit } from '@angular/core';
import { ConsultaFactura } from '../entidad/factura/entidad.factura';
import { FacturaService } from '../service/factura/service.factura';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.css']
})
export class FacturaComponent implements OnInit {
  facturas:ConsultaFactura[]=[];
  constructor(private serviceFactura:FacturaService) { }

  ngOnInit(): void {

    this.serviceFactura.getFactura().subscribe(res=>{
      this.facturas=res;
    })
  }

}
