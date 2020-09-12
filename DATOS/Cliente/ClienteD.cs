using ENTIDAD.Cliente;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOS.Cliente
{
    public class ClienteD
    {
        public List<ClienteE> GetCliente(Object[] parametros)
        {
            List<ClienteE> result = new List<ClienteE>();

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out Mensaje mensaje, parametros, "prCliente");

            if (mensaje.Titulo == "")
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new ClienteE()
                        {
                            NUME_DOC = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("NUME_DOC")),
                            NOMBRE = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("NOMBRE")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("NOMBRE"))
                        });
                    }
                }
            }
            if (sqlDataReader != null)
                sqlDataReader.Close();
            acceso.Desconectar();

            return result;
        }
    }
}
