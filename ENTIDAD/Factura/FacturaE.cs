using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDAD.Factura
{
    public class FacturaE
    {
        public int ID_FACTURA { get; set; }
        public int NUME_DOC { get; set; }
        public int CODI_ESTADO { get; set; }
        public double VALOR_FAC { get; set; }

        public DateTime FECHA_FAC { get; set; }


        public Mensaje Mensaje { get; set; }
    }

    public class ConsultaFacturaE
    {
        public string CLIENTE { get; set; }

        public decimal VALOR { get; set; }

        public string DESCRIPCION { get; set; }

        public Mensaje Mensaje { get; set; }

    }
}
