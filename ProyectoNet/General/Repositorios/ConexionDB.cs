using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace General.Repositorios
{
    public class ConexionDB 
    {
        private SqlConnection _Coneccion = new SqlConnection();
        private SqlCommand _Comando;
        private SqlTransaction _Transaccion;

        #region Conexion

        #region Conectar

        public ConexionDB(string nombreStoredProcedure)
        {
            this.Conectar();
            this.CrearComando(nombreStoredProcedure);
        }

        public bool Conectar()
        {
            try
            {
                _Coneccion.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString;
                _Coneccion.Open();
                return true;
            }
            catch (Exception Ex)
            {
                throw
                    Ex;
            }
        }
        #endregion

        #region Desconectar
        public bool Desconestar()
        {
            if (_Coneccion.State.Equals(ConnectionState.Open))
            {
                try
                {
                    _Coneccion.Close();
                    return true;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            return false;
        }
        #endregion

        #endregion

        #region Metodos

        private bool CrearComando(string nombreStoredProcedure)
        {
            _Comando = new SqlCommand();
            _Comando.Connection = _Coneccion;
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = nombreStoredProcedure;
            _Comando.CommandTimeout = 100;
            SqlCommandBuilder.DeriveParameters(_Comando);
            return true;
        }


        public bool CrearComandoConTransaccionIniciada(string nombreStoredProcedure)
        {
            _Comando = new SqlCommand();
            _Comando.Connection = _Coneccion;
            _Comando.Transaction = _Transaccion;
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.CommandText = nombreStoredProcedure;
            SqlCommandBuilder.DeriveParameters(_Comando);
            return true;
        }

        

        public SqlDataReader EjecutarConsulta()
        {
            try
            {
                return _Comando.ExecuteReader();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public bool EjecutarSinResultado()
        {
            try
            {
                _Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public object EjecutarEscalar()
        {
            try
            {
                return _Comando.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool AsignarParametro(string Name, int Value)
        {
            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {
                    if (p.ParameterName == Name)
                    {
                        //if (Value == 0)
                        //{
                        //    p.Value = null;
                        //    return false;
                        //}
                        //else
                        //{
                            p.Value = Value;
                            return true;

                        //}
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool AsignarParametro(string Name, DateTime Value)
        {


            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {
                    if (p.ParameterName == Name)
                    {
                        if (Value == DateTime.Parse("01/01/0001"))
                        {
                            p.Value = null;
                            return false;
                        }
                        else
                        {
                            p.Value = Value;
                            return true;
                        }

                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public bool AsignarParametro(string Name, float Value)
        {
            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {
                    if (p.ParameterName == Name)
                    {
                        p.Value = Value;
                        return true;

                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool AsignarParametro(string Name, string Value)
        {
            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {

                    if (p.ParameterName == Name)
                    {
                        p.Value = Value;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool AsignarParametro(string Name, bool Value)
        {

            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {
                    if (p.ParameterName == Name)
                    {
                        p.Value = Value;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool AsignarParametro(string Name, decimal Value)
        {

            try
            {
                foreach (SqlParameter p in _Comando.Parameters)
                {
                    if (p.ParameterName == Name)
                    {
                        p.Value = Value;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public void BeginTransaction()
        {
            _Transaccion = _Coneccion.BeginTransaction();
            _Comando.Transaction = _Transaccion;
        }

        public void RollbackTransaction()
        {
            _Transaccion.Rollback();
            Desconestar();
        }

        public void CommitTransaction()
        {
            _Transaccion.Commit();
            Desconestar();
        }

        #endregion

        
    }
}




