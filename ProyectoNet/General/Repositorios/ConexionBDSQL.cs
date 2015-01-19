using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace General.Repositorios
{
    public class ConexionBDSQL : General.Repositorios.IConexionBD
    {
        private string cadenaDeConexion;
        private SqlConnection conexion;

        public ConexionBDSQL(string StringConnection)
        {
            this.cadenaDeConexion = StringConnection;
        }

        private void AbrirBD()
        {
            conexion = new SqlConnection(this.cadenaDeConexion);
            conexion.Open();
        }

        private void CerrarBD()
        {
            conexion.Close();
            conexion.Dispose();
        }

        public bool EjecutarSinResultado(string nombreProcedimiento)
        {
            AbrirBD();
            var un_comando = CrearComando(nombreProcedimiento);
            try
            {
                un_comando.ExecuteNonQuery();
                CerrarBD();
                return true;
            }
            catch (Exception Ex)
            {
                CerrarBD();
                throw Ex;
            }

           
           
        }

        public bool EjecutarSinResultado(string nombreProcedimiento, Dictionary<string, object> parametros)
        {
            AbrirBD();
            var un_comando = CrearComando(nombreProcedimiento, parametros);
            try
            {
                un_comando.ExecuteNonQuery();
                CerrarBD();
                return true;
            }
            catch (Exception Ex)
            {
                CerrarBD();
                throw Ex;
            }

        }

        public object EjecutarEscalar(string nombreProcedimiento)
        {
            AbrirBD();
            var un_comando = CrearComando(nombreProcedimiento);
            object resultado = un_comando.ExecuteScalar();
            CerrarBD();
            return resultado;
        }

        public object EjecutarEscalar(string nombreProcedimiento, Dictionary<string, object> parametros)
        {
            AbrirBD();
            var un_comando = CrearComando(nombreProcedimiento, parametros);
            object resultado = new object();
            try
            {
                resultado = un_comando.ExecuteScalar();
            }
            catch (Exception e)
            {
                
                throw;
            }
           
            CerrarBD();
            return resultado;
        }

        private SqlCommand CrearComando(string nombreProcedimiento)
        {
            var un_comando = conexion.CreateCommand();
            un_comando.CommandText = nombreProcedimiento;
            un_comando.CommandType = System.Data.CommandType.StoredProcedure;
            return un_comando;
        }

        private SqlCommand CrearComando(string nombreProcedimiento, Dictionary<string, object> parametros)
        {
            var un_comando = CrearComando(nombreProcedimiento);
            parametros.Keys.ToList().ForEach(k => un_comando.Parameters.Add(new SqlParameter(k, parametros[k])));
            return un_comando;
        }

        public TablaDeDatos Ejecutar(string procedimiento, Dictionary<string, object> parametros)
        {
            AbrirBD();

            var data_adapter = new SqlDataAdapter();
            var data_table = new TablaDeDatos();

            try
            {
                data_adapter.SelectCommand = CrearComando(procedimiento, parametros);
                //data_adapter.SelectCommand = new SqlCommand
                //{
                //    Connection = conexion,
                //    CommandText = procedimiento,
                //    CommandType = CommandType.StoredProcedure
                //};
                //parametros.Keys.ToList().ForEach(k => data_adapter.SelectCommand.Parameters.Add(new SqlParameter(k, parametros[k])));

                //this._paramzetros.ForEach(parametro => data_adapter.SelectCommand.Parameters.Add(parametro));

                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CerrarBD();
                data_adapter.Dispose();
            }
        }

        public TablaDeDatos Ejecutar(string procedimiento)
        {
            AbrirBD();

            var data_adapter = new SqlDataAdapter();
            var data_table = new TablaDeDatos();

            try
            {
                data_adapter.SelectCommand = CrearComando(procedimiento);
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CerrarBD();
                data_adapter.Dispose();
            }
        }
    }
}
