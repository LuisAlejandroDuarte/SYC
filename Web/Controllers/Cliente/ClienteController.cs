using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ENTIDAD.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEGOCIO.Cliente;

namespace Web.Controllers.Cliente
{

    public class ClienteController : ControllerBase
    {
        [HttpGet]      
        [Produces("application/json")]
        [Route("api/Cliente/GetClientes")]
        public List<ClienteE> GetClientes()
        {

            return ClienteN.GetCliente(new Object[] {
                new SqlParameter("@Accion","SELECT")               
            });
        }
    }
}