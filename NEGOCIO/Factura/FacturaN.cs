using DATOS.Factura;
using ENTIDAD.Factura;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO.Factura
{
   public class FacturaN
    {
        private static readonly FacturaD factura = new FacturaD();

        public static List<ConsultaFacturaE> GetConsultaFactura(Object[] parametros)
        {
            return factura.GetConsulta(parametros);
        }

        public static FacturaE SetFactura(Object[] parametros)
        {
            return factura.SetFactura(parametros);
        }
    }
}
