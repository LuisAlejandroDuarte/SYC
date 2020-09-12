using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ENTIDAD.EstadosFactura;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.EstadoFactura;

namespace Web.Controllers.EstadoFactura
{

    public class EstadoFacturaController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        [Route("api/EstadoFactura/GetEstadoFactura")]
        public List<EstadoFacturaE> GetEstadoFactura()
        {

            return EstadoFacturaN.GetEstadoFactura(new Object[] {
                new SqlParameter("@Accion","SELECT")
            });
        }
    }
}
