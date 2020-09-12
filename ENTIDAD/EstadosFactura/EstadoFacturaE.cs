using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDAD.EstadosFactura
{
    public class EstadoFacturaE
    {
        public int  CODI_ESTADO { get; set; }
        public string DESCRIPCION { get; set; }

        public Mensaje mensaje { get; set; }
    }
}
