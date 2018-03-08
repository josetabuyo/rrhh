using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Recibos;

namespace General.Repositorios
{
    public class RepositorioRecibosFirmados : RepositorioLazySingleton<ReciboFirmado>    
    {
        private static RepositorioRecibosFirmados _instancia;

        private RepositorioRecibosFirmados(IConexionBD conexion)
            : base(conexion, 10)
        {
        }

        public static RepositorioRecibosFirmados NuevoRepositorioRecibosFirmados(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioRecibosFirmados(conexion);
            return _instancia;
        }

        public bool actualizarReciboFirmado(int idRecibo, int idArchivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idRecibo", idRecibo);
            parametros.Add("@idArchivo", idArchivo);
            var resultado = conexion.EjecutarSinResultado("dbo.[PLA_UPD_Recibo_Firmado]", parametros);
            //en ejecutar sinresultado hay un try catch pero en caso de catch no retorna false sino eleva una excepcion
            //no deberia retornar false? en caso de elevar la excepcion se la atenderia en el javascript del cliente
            return resultado;

        }

        protected override void QuitarDeLaBase(ReciboFirmado reciboFirmado)
        {
            throw new NotImplementedException();
        }
        protected override List<ReciboFirmado> ObtenerDesdeLaBase()
        {
            throw new NotImplementedException();
        }

        protected override void GuardarEnLaBase(ReciboFirmado reciboFirmado)
        {
            throw new NotImplementedException();
        }

        //TODO agregar recibo firmado, leer recibo firmado
      

        /*
         public bool CambiarPassword(Usuario usuario, string pass_actual, string pass_nueva)
        {
            var pass_actual_encriptada = encriptarSHA1(pass_actual);
            var pass_nueva_encriptada = encriptarSHA1(pass_nueva);
            var parametros = new Dictionary<string, object>();
           // parametros.Add("@usuario", usuario.NombreDeUsuario);
            //parametros.Add("@password", pass_actual_encriptada);
            //Area area = new Area();

            //var tablaDatos = conexion_bd.Ejecutar("dbo.Web_Login", parametros);

           // if (tablaDatos.Rows.Count > 0)
           // {
                //parametros = new Dictionary<string, object>();

                parametros.Add("@idUsuario", usuario.Id);
                parametros.Add("@password_actual", pass_actual_encriptada);
                parametros.Add("@password_nuevo", pass_nueva_encriptada);
                var rto =   (int)conexion_bd.EjecutarEscalar("dbo.SACC_Upd_Password", parametros);

                if (rto > 0)
		            return true;
                return false;
                    
               
            //}

           // return false;
        }
         */


    }
}
