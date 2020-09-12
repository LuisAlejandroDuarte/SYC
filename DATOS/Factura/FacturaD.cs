using ENTIDAD.Factura;
using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DATOS.Factura
{
    public class FacturaD
    {
        public FacturaE SetFactura(Object[] parametros)
        {
            FacturaE result = new FacturaE();


            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out Mensaje mensaje, parametros, "prFactura");

            if (mensaje.Titulo == "")
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result = new FacturaE()
                        {
                            Mensaje = new Mensaje(sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdError")),
                                "Error de la base de datos", sqlDataReader.GetString(sqlDataReader.GetOrdinal("MensajeError")), "", TipoMensaje.Error)
                        };
                    }
                }
            }
            else
                result.Mensaje = mensaje;

            if (sqlDataReader != null)
                sqlDataReader.Close();
            acceso.Desconectar();

            return result;
        }

        public List<ConsultaFacturaE> GetConsulta(Object[] parametros)
        {
            List<ConsultaFacturaE> result = new List<ConsultaFacturaE>();

            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader sqlDataReader = acceso.GetDataReader(out Mensaje mensaje, parametros, "prFactura");

            if (mensaje.Titulo == "")
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        result.Add(new ConsultaFacturaE()
                        {
                            Mensaje = new Mensaje(),
                            VALOR = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("VALOR")),                           
                            CLIENTE = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("CLIENTE")) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("CLIENTE")),
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
