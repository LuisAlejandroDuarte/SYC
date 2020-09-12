using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTIDAD.Cliente
{
    public class ClienteE
    {
        public int NUME_DOC { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }


        public Mensaje Mensaje { get; set; }


    }
}
