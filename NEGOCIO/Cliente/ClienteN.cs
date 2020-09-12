using DATOS.Cliente;
using ENTIDAD.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO.Cliente
{
    public class ClienteN
    {
        private static readonly ClienteD cliente = new ClienteD();

        public static List<ClienteE> GetCliente(Object[] parametros)
        {
            return cliente.GetCliente(parametros);
        }
        
    }
}
