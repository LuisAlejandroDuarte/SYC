using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDAD.EstadosFactura;
using ENTIDAD.Factura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Factura;

namespace Web.Controllers.Factura
{
    public class FacturaController : ControllerBase
    {
        private FacturaE result = new FacturaE();

        [HttpPost]       
        [Produces("application/json")]
        [Route("api/Factura/CrearFactura")]
        public FacturaE CrearFactura([FromBody] FacturaE value)
        {          
            result = FacturaN.SetFactura(new Object[] {
                new SqlParameter("@Accion","INSERT"),
                new SqlParameter("@NUME_DOC",value.NUME_DOC),
                new SqlParameter("@CODI_ESTADO",value.CODI_ESTADO),
                new SqlParameter("@VALOR_FAC",value.VALOR_FAC),
                new SqlParameter("@FECHA_FAC",value.FECHA_FAC)
                
            });


            return result;


        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/Factura/GetFacturas")]
        public List<ConsultaFacturaE> GetFacturas()
        {
            return FacturaN.GetConsultaFactura(new Object[] {
                new SqlParameter("@Accion","CONSULTA")                

            });


        }

    }
}