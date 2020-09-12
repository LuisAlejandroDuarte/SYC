using DATOS.EstadoFactura;
using ENTIDAD.EstadosFactura;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO.EstadoFactura
{
    public class EstadoFacturaN
    {
        private static readonly EstadoFacturaD estado = new EstadoFacturaD();

        public static List<EstadoFacturaE> GetEstadoFactura(Object[] parametros)
        {
            return estado.GetEstadoFactura(parametros);
        }

    }
}
