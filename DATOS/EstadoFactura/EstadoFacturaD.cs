using ENTIDAD.EstadosFactura;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOS.EstadoFactura
{
    public class EstadoFacturaD
    {
        public List<EstadoFacturaE> GetEstadoFactura(Object[] parametros)
        {
            List<EstadoFacturaE> result = new List<EstadoFacturaE>();

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out Mensaje mensaje, parametros, "prEstadoFactura");

            if (mensaje.Titulo == "")
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new EstadoFacturaE()
                        {
                            CODI_ESTADO = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("CODI_ESTADO")),                            
                            DESCRIPCION = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("DESCRIPCION")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("DESCRIPCION"))
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
