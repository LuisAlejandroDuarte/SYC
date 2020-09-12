import { Mensaje } from '../mensaje/entidad.mensaje';

export class  Factura
{ 
    id_factura:number;
    nume_doc:number;
    codi_estado:number;
    valor_fac:number;
    fecha_fac:Date;
    mensaje:Mensaje;
}

export class ConsultaFactura
{
   cliente:string;
   valor:number;    
   descripcion:string;    
   mensaje:Mensaje;
}