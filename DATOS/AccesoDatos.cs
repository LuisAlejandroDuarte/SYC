

using MENSAJESDLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class AccesoDatos
    {
      SqlConnection SqlConection = new SqlConnection();

        /// <summary>
        /// Se Conecta a la base de datos devolviendo un resultado booleano de 
        /// éxito en la conexión
        /// </summary>
        /// <returns>true:Conexión exitosa, false:Falla la conexión</returns>
        private bool Conectar(Mensaje alerta)
        {
            bool result = true;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //builder.DataSource = "servercdt.database.windows.net";
            //builder.DataSource = "EQ-112";

            builder.DataSource = "CASA";
            //builder.UserID = "usercdt";
            //builder.Password = "ServerBD16*app";
            builder.InitialCatalog = "SYC";
            //builder.PersistSecurityInfo = true;
            builder.IntegratedSecurity = true;

            try
            {
                SqlConection.ConnectionString = builder.ConnectionString;

                if (SqlConection.State == ConnectionState.Closed)
                    SqlConection.Open();
            }
            catch (Exception ex)
            {

                alerta.Id = ex.HResult;
                alerta.Cuerpo = ex.Message;
                alerta.Titulo = "Error en la conexión";
                alerta.Botones = new List<Botones>();
                alerta.Botones.Add(new Botones { Label = "Aceptar", Tema = Tema.warn, Visible = true });
                result = false;
            }
            finally
            {

            }

            return result;
        }

        /// <summary>
        /// Desconexión a la base de datos
        /// </summary>
        /// <returns>true:Desconexión exitosa, false:Desconexión Fallida</returns>
        public bool Desconectar()
        {
            bool result = true;

            try
            {
                if (SqlConection != null)
                    if (SqlConection.State == ConnectionState.Open)
                    {
                        SqlConection.Close();
                        SqlConection.Dispose();

                    }
            }
            catch (Exception error)
            {
                result = false;
                throw new Exception("Error : " + error.Message);
            }

            return result;
        }



        /// <summary>
        /// Obtiene los datos con la clase dataReader para ser mostrados como una lista genérica
        /// </summary>
        /// <param name="Parametros"></param>
        /// <param name="procedimiento"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(out Mensaje alerta, Object[] Parametros, String procedimiento)
        {
            SqlDataReader result = null;
            SqlCommand Comando = null;
            Mensaje alertaConeccion = new Mensaje();
            alerta = new Mensaje();

            try
            {
                if (Conectar(alertaConeccion))
                {
                    Comando = new SqlCommand(procedimiento, SqlConection);
                    Comando.CommandType = CommandType.StoredProcedure;

                    foreach (Object Parametro in Parametros)
                    {
                        Comando.Parameters.Add(Parametro);
                    }

                    result = Comando.ExecuteReader();

                }
                else
                {
                    alerta = alertaConeccion;
                    return null;
                }
            }
            catch (Exception ex)
            {
                //if (SqlConection.State == ConnectionState.Closed)
                //    Conectar();

                alertaConeccion.Id = ex.HResult;
                alertaConeccion.Titulo = "ERROR DE LA BASE DE DATOS";
                alertaConeccion.Cuerpo = ex.Message;
                alertaConeccion.Botones = new List<Botones>();
                alertaConeccion.Botones.Add(new Botones { Label = "Aceptar", Tema = Tema.warn, Visible = true });
                SqlConection.Close();
                SqlConection = null;
                alerta = alertaConeccion;
                return null;
                // GetDataReader(Parametros, procedimiento);
                //String SQL;
                //SQL = "SELECT '" + error.Message.Replace("'", "") + "' AS MENSAJEERROR, " + error.HResult + " As IDERROR ";
                //Comando = new SqlCommand(SQL, SqlConection);
                //result = Comando.ExecuteReader();
            }

            finally
            {
                if (Comando != null)
                    Comando.Dispose();
                Comando = null;
            }


            return result;
        }
    }
}

