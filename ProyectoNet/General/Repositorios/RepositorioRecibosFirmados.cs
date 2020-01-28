using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Recibos;
using Newtonsoft.Json;

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


        public bool agregarReciboFirmado(int idLiquidacion, int idRecibo, int idArchivo, int año, int mes, int tipoLiquidacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_Liquidacion", idLiquidacion);
            parametros.Add("@id_Recibo", idRecibo);
            parametros.Add("@id_Archivo", idArchivo);
            parametros.Add("@año", año);
            parametros.Add("@mes", mes);
            parametros.Add("@tipoLiquidacion", tipoLiquidacion);
            var resultado = conexion.EjecutarSinResultado("dbo.[PLA_ADD_Recibo_Firmado]", parametros);
            //en ejecutar sinresultado hay un try catch pero en caso de catch no retorna false sino eleva una excepcion
            //no deberia retornar false? en caso de elevar la excepcion se la atenderia en el javascript del cliente
            return resultado;

        }

        public bool conformarRecibo(int idRecibo, int idPersona, DateTime hoy, int recibo_aceptado, string observacion, string hash )
        {
            var parametros = new Dictionary<string, object>();            
            parametros.Add("@id_Recibo", idRecibo);
            parametros.Add("@id_Usuario", idPersona);
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

        /*obtencion de recibos segun el modo: historica o no*/
        public string GetRecibos(int idPersona, int modo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@idPersona", idPersona);
            parametros.Add("@orden", 0);/*para que no retorne la lista segun un orden definido sino segun el modo enviado*/
            parametros.Add("@modo", 1);/*para obtener los recibos para la busqueda web de recibos por persona*/
            parametros.Add("@Historico", modo);

            var recibo = new object();
            var listaRecibos = new List<object>();

            var tablaDatos = conexion.Ejecutar("dbo.PLAD_GET_Impresion_Recibos_Haberes", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {/*Tambien se puede crear un objeto contenedor de cada fila, esto me sirve para  retornar una 
                  * lista en lugar de un objeto string json
                  * 
                    Persona persona = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Respuesta respuesta = new Respuesta(
                        row.GetInt("id_orden"),
                        persona,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("texto"));
                    */

                    recibo = new
                    {
                        //Id_Recibo = row.GetInt("Id_Recibo"),
                        idArchivo = row.GetInt("idArchivo",0),
                        idLiquidacion = row.GetInt("idLiquidacion"),
                        idRecibo = row.GetInt("idRecibo"),
                        descripcionLiquidacion = row.GetString("descripcionLiquidacion"),
                        area_desc = row.GetString("area_desc"),
                        conformado = row.GetSmallintAsInt("conformado",-1),

                    };


                    listaRecibos.Add(recibo);
                });

            }

            return JsonConvert.SerializeObject(listaRecibos);

        }

        public ConfiguracionReciboDigital GetConfiguracionReciboDigital()
        {
            ConfiguracionReciboDigital crd =null;

            var tablaDatos = conexion.Ejecutar("dbo.PLA_GET_Configuracion_ReciboDigital");

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {/* Persona persona = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Respuesta respuesta = new Respuesta(
                        row.GetInt("id_orden"),
                        persona,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("texto"));
                    */

                    crd = new ConfiguracionReciboDigital(row.GetInt("fecha_añoInicio_reciboDigital"), row.GetInt("fecha_mesInicio_reciboDigital"), row.GetInt("fecha_añoHastaAca_recibosHistoricos"), row.GetInt("fecha_mesHastaAca_recibosHistoricos"));
                                       
                });

            }

            return crd;

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
