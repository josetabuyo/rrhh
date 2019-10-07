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


        public bool agregarReciboFirmado(int idLiquidacion, int idRecibo, int idArchivo, int año, int mes, int tipoLiquidacion, int usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_Liquidacion", idLiquidacion);
            parametros.Add("@id_Recibo", idRecibo);
            parametros.Add("@id_Archivo", idArchivo);
            parametros.Add("@año", año);
            parametros.Add("@mes", mes);
            parametros.Add("@tipoLiquidacion", tipoLiquidacion);
            parametros.Add("@idUsuario", usuario);
            var resultado = conexion.EjecutarSinResultado("dbo.[PLA_ADD_Recibo_Firmado]", parametros);
            //en ejecutar sinresultado hay un try catch pero en caso de catch no retorna false sino eleva una excepcion
            //no deberia retornar false? en caso de elevar la excepcion se la atenderia en el javascript del cliente
            return resultado;

        }

        public bool conformarRecibo(int idRecibo, int idUsuario, DateTime hoy, int recibo_aceptado, string observacion, string hash )
        {
            var parametros = new Dictionary<string, object>();            
            parametros.Add("@id_Recibo", idRecibo);
            parametros.Add("@id_Usuario", idUsuario);
            parametros.Add("@fechaConformidadUsuario", hoy);
            parametros.Add("@recibo_aceptado", recibo_aceptado);
            parametros.Add("@observacion", observacion);
            parametros.Add("@hash", hash);
            var resultado = conexion.EjecutarSinResultado("dbo.[PLA_UPD_ConformarRecibo]", parametros);
            //en ejecutar sinresultado hay un try catch pero en caso de catch no retorna false sino eleva una excepcion
            //no deberia retornar false? en caso de elevar la excepcion se la atenderia en el javascript del cliente
            return resultado;

        }

        protected override void QuitarDeLaBase(ReciboFirmado reciboFirmado, int usuario)

        {
            throw new NotImplementedException();
        }
        public  List<ReciboFirmado> ObtenerDesdeLaBase(int idRecibo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idRecibo", idRecibo);
            var tablaDatos = conexion.Ejecutar("dbo.PLA_GET_Recibo_Firmado", parametros);
            var recibos = new List<ReciboFirmado>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    recibos.Add(new ReciboFirmado(row.GetInt("idRecibo"),row.GetInt("idArchivo"),row.GetSmallintAsInt("mes"),row.GetSmallintAsInt("año"),row.GetSmallintAsInt("tipoLiquidacion"),row.GetSmallintAsInt("conforme"),row.GetInt("idUsuario")));
                    
                    /*row.GetInt("Id"),
                    rto.GetString(8);
                    fechas.Add(row.GetDateTime("Fecha"));*/

                });
            }

            return recibos;
        }

        protected override List<ReciboFirmado> ObtenerDesdeLaBase()
        {
            throw new NotImplementedException();
        }

        protected override void GuardarEnLaBase(ReciboFirmado reciboFirmado, int id_usuario_logueado)
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
