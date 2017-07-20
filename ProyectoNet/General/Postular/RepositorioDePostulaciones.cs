using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.MAU;
using General.Postular;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace General
{
    public class RepositorioDePostulaciones
    {
        protected IConexionBD conexion_bd;

        public RepositorioDePostulaciones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public Postulacion PostularseA(Postulacion postulacion, Usuario usuario)
        {

            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idPuesto", postulacion.Perfil.Id);
                parametros.Add("@idPersona", usuario.Owner.Id);
                parametros.Add("@Motivo", postulacion.Motivo);
                parametros.Add("@Observacion", postulacion.Observaciones);
                parametros.Add("@Usuario", usuario.Id);
                GeneradorDeEtiquetas repoTicket = new GeneradorDeEtiquetas(conexion_bd);
                postulacion.Numero = repoTicket.GenerarTicket("POSTULAR");
                parametros.Add("@Numero", postulacion.Numero);

                var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Postulaciones", parametros);
                postulacion.Id = Convert.ToInt32(id);
                postulacion.Postulante = usuario.Owner;
                postulacion.FechaPostulacion = DateTime.Now;

                if (!GuardarNumerosGDE(postulacion))
                {
                    throw new Exception("Fallo el insertado de los numeros de GDE");
                }
            }
            catch (Exception e)
            {
                //return e.Message;
            }

            return postulacion;
        }

        public bool GuardarNumerosGDE(Postulacion postulacion)
        {

            try
            {
                foreach (string numeroDeInforme in postulacion.NumerosDeInformeGDE)
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@idPostulacion", postulacion.Id);
                    parametros.Add("@numeroInformeGDE", numeroDeInforme);

                    conexion_bd.Ejecutar("dbo.CV_Ins_InformeGDEPostulacion", parametros);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
       

        public List<Postulacion> GetPostulacionesDe(int idpersona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idpersona);
            return GetPostulaciones(parametros);
        }

        public List<Postulacion> GetPostulaciones(Dictionary<string, object> parametros)
        {
            var tablaPostulaciones = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones", parametros);

            return ArmarPostulaciones(tablaPostulaciones);
        }

        private List<Postulacion> ArmarPostulaciones(TablaDeDatos tablaCVs)
        {
            List<Postulacion> postulaciones = new List<Postulacion>();


            tablaCVs.Rows.ForEach(row =>
            {
                var postulacion = new Postulacion()
                {
                    Id = row.GetInt("IdPostulacion"),
                    Perfil = ArmarPuesto(row),
                    Postulante = new Persona()
                    {
                        Id = row.GetInt("IdPostulante"),
                        Nombre = row.GetString("NombrePostulante"),
                        Apellido = row.GetString("ApellidoPostulante")
                    },
                    FechaPostulacion = row.GetDateTime("FechaInscripcion"),
                    Motivo = row.GetString("Motivo"),
                    Observaciones = row.GetString("Observaciones"),
                    Numero = row.GetString("Postulacion_Numero", "")
                };


                if (!postulaciones.Exists(p => p.Id == postulacion.Id))
                    postulaciones.Add(postulacion);

            });

            postulaciones.ForEach(p =>
                CorteDeControlEtapas(tablaCVs, p)
            );
            return postulaciones;
        }

        private void CorteDeControlEtapas(TablaDeDatos tablaCVs, Postulacion postulacion)
        {
            //CORTE DE CONTROL PARA OTRAS CAPACIDADES
            //1.- Controlo que haya al menos 1 resultado
            var lista = ArmarFilas(tablaCVs, "IdUsuarioPostulacion");
            new List<RowDeDatos>();

            if (lista.Count > 0)
            {
                var etapas = (from RowDeDatos dRow in lista
                              select new //CvEventoAcademico ()
                              {
                                  Descripcion = dRow.GetString("EtapaDescripcion", ""),
                                  IdEtapaConcurso = dRow.GetInt("IdEtapa"),
                                  Fecha = dRow.GetDateTime("FechaPostulacion"),
                                  IdUsuario = dRow.GetSmallintAsInt("IdUsuarioPostulacion"),
                                  IdPostulacion = dRow.GetInt("IdPostulacion")
                              }).Where(r => r.IdPostulacion == postulacion.Id).Distinct().ToList();

                etapas.Select(e =>
                    new EtapaPostulacion()
                    {
                        Etapa = new EtapaConcurso(e.IdEtapaConcurso, e.Descripcion),
                        Fecha = e.Fecha,
                        IdUsuario = e.IdUsuario
                    }).ToList().ForEach(ep => postulacion.AgregarPostulacion(ep));
            }
        }


        private List<RowDeDatos> ArmarFilas(TablaDeDatos tabla, string id_usuario_postulacion)
        {
            var lista = new List<RowDeDatos>();
            tabla.Rows.ForEach(r =>
            {
                if (!(r.GetObject(id_usuario_postulacion) is DBNull))
                    lista.Add(r);
            });
            return lista;
        }

        public List<EtapaConcurso> BuscarEtapasConcurso()
        {
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_EtapasConcurso");

            var etapas = new List<EtapaConcurso>();

            tablaCVs.Rows.ForEach(row =>
            etapas.Add(new EtapaConcurso()
            {
                Id = row.GetInt("Id"),
                Descripcion = row.GetString("Descripcion")
            }));


            return etapas;

        }

        private Perfil ArmarPuesto(RowDeDatos row)
        {
            var repo_comite = RepositorioDeComites.Nuevo(this.conexion_bd);
            return new Perfil(
                              row.GetSmallintAsInt("IdPerfil"),
                              row.GetString("Familia"),
                              row.GetString("Profesion"),
                              row.GetString("Denominacion"),
                              row.GetString("Nivel"),
                              row.GetString("Agrupamiento"),
                              row.GetSmallintAsInt("Vacantes"),
                              row.GetString("Tipo"),
                              row.GetString("Puesto_Numero"),
                              repo_comite.GetComiteById(row.GetSmallintAsInt("IdComite")),
                              row.GetDateTime("PerfilFechaDesde", DateTime.Today),
                              row.GetDateTime("PerfilFechaHasta", DateTime.Today),
                              row.GetBoolean("PerfilBaja", false)
                );
        }

        public List<Postulacion> GetPostulacionesPorComite(int id_comite)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //parametros.Add("@idPerfil", id_perfil);
            parametros.Add("@IdComite", id_comite);
            return this.GetPostulaciones(parametros);
        }

        public Postulacion GetPostulacionById(int idpersona, int idpostulacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@IdPostulacion", idpostulacion);
            parametros.Add("@IdPersona", idpersona);
            Postulacion postulacion = this.GetPostulaciones(parametros).First();
            postulacion.NumerosDeInformeGDE = this.GetNumerosDeInformeGDE(postulacion.Id);
            return postulacion;

        }

        public Postulacion GetPostulacionesPorCodigo(string codigo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@NumeroPostulacion", codigo);
            try
            {
                Postulacion postulacion = this.GetPostulaciones(parametros).First();
                postulacion.NumerosDeInformeGDE = this.GetNumerosDeInformeGDE(postulacion.Id);
                return postulacion;
            }
            catch (Exception e)
            {
                return null;
                //throw e;
            }
        }

        private List<string> GetNumerosDeInformeGDE(int idPostulacion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPostulacion", idPostulacion);

            var tabla = conexion_bd.Ejecutar("dbo.CV_Get_NumerosDeInformeGDE", parametros);

            var informes = new List<string>();

            tabla.Rows.ForEach(row =>
                informes.Add(row.GetString("NumeroInforme"))
            );

            return informes;
        }


        public bool EliminarPostulacionPorUsuario(Postulacion postulacion, Usuario usuario)
        {
            if (postulacion.Postulante.Id == usuario.Owner.Id)
            {
                var baja = CrearBaja(usuario);

                var parametros = new Dictionary<string, object>();
                parametros.Add("@IdPostulacion", postulacion.Id);
                //   parametros.Add("@IdPuesto", postulacion.Puesto.Id);
                parametros.Add("@IdPerfil", postulacion.Perfil.Id);
                parametros.Add("@IdPersona", postulacion.Postulante.Id);
                parametros.Add("@FechaInscripcion", postulacion.FechaPostulacion);
                parametros.Add("@Usuario", usuario.Id);
                parametros.Add("@idBaja", baja);

                conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Postulacion", parametros);

                return true;
            }
            else
            {
                return false;
            }
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.CV_Ins_Bajas", parametros).ToString());

            return id;
        }

        public void InsEtapaPostulacion(int id_postulacion, int id_etapa_postulacion, int id_usuario)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPostulacion", id_postulacion);
            parametros.Add("@IdEtapa", id_etapa_postulacion);
            parametros.Add("@IdUsuario", id_usuario);

            conexion_bd.EjecutarSinResultado("dbo.CV_Ins_EtapaPostulación", parametros);
        }

        protected static List<Postulacion> postulaciones_en_pantalla;
        public List<Postulacion> BuscarPostulacionesPorEtapas(int id_comite, List<EtapaConcurso> etapas)
        {
            List<Postulacion> postulaciones_buscadas = new List<Postulacion>();
            postulaciones_buscadas = GetPostulacionesPorComite(id_comite);
            postulaciones_en_pantalla = postulaciones_buscadas.FindAll(p => PerteneceA(p, etapas));
            postulaciones_en_pantalla = SoloPostulacionvigente(postulaciones_en_pantalla);
            return postulaciones_en_pantalla;
        }

        public void GuardarFolios(string nro_inscripcion, DateTime fecha, int nro_ficha_inscripcion, int nro_foto, int nro_foto_dni, int nro_foto_titulo, int nro_cv, int nro_doc_respaldo, int id_usuario)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_inscripcion", nro_inscripcion);
            parametros.Add("@fecha", fecha);
            parametros.Add("@nro_ficha_inscripcion", nro_ficha_inscripcion);
            parametros.Add("@nro_foto", nro_foto);
            parametros.Add("@nro_foto_dni", nro_foto_dni);
            parametros.Add("@nro_foto_titulo", nro_foto_titulo);
            parametros.Add("@nro_cv", nro_cv);
            parametros.Add("@nro_doc_respaldo", nro_doc_respaldo);
            parametros.Add("@id_usuario", id_usuario);

            conexion_bd.EjecutarSinResultado("dbo.CV_Ins_FoliosPostulacion", parametros);
        }

        public Folios ObtenerFolios(string nro_inscripcion, string dni_postulante, string fecha_postulacion)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@nro_inscripcion", nro_inscripcion);

            var TablaFolios = conexion_bd.Ejecutar("dbo.CV_Get_Folios", parametros);

            if (TablaFolios.Rows.Count > 0)
            {
                var folio = TablaFolios.Rows.First();
                return new Folios(folio.GetString("nro_postulacion"),
                                    folio.GetDateTime("fecha_carga"),
                                    folio.GetSmallintAsInt("nro_ficha_inscripcion"),
                                    folio.GetSmallintAsInt("nro_foto"),
                                    folio.GetSmallintAsInt("nro_foto_dni"),
                                    folio.GetSmallintAsInt("nro_foto_titulo"),
                                    folio.GetSmallintAsInt("nro_cv"),
                                    folio.GetSmallintAsInt("nro_doc_respaldo"),
                                    folio.GetInt("dni"), 
                                    true);
            }
            else {
                return new Folios(nro_inscripcion, dni_postulante, fecha_postulacion, false);
            }
            

        }


        private List<Postulacion> SoloPostulacionvigente(List<Postulacion> postulaciones_en_pantalla)
        {
            List<Postulacion> postulaciones_con_etapas_vigentes = new List<Postulacion>();
            postulaciones_en_pantalla.ForEach(p =>
            {
                postulaciones_con_etapas_vigentes.Add(p.SoloEtapaVigente());
            });

            return postulaciones_con_etapas_vigentes;
        }

        public void GuardarCambiosEnAdmitidos(List<Postulacion> postulaciones, int id_usuario)
        {
            Postulacion postulacion_original;
            postulaciones.ForEach(postulacion =>
            {

                postulacion_original = postulaciones_en_pantalla.Find(p => p.Id == postulacion.Id);
                if (postulacion.EtapaActual().Etapa.Id != postulacion_original.EtapaActual().Etapa.Id)
                {
                    InsEtapaPostulacion(postulacion.Id, postulacion.EtapaActual().Etapa.Id, id_usuario);
                }
            });

        }

        private bool PerteneceA(Postulacion postulacion, List<EtapaConcurso> etapas)
        {
            if (etapas.Exists(e => e.Id == postulacion.EtapaActual().Etapa.Id))
            {
                return true;
            }
            return false;
        }


        public AnexosDeEtapas GenerarAnexosPara(int id_etapa, Postulacion una_postulacion, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdEtapa", id_etapa);
            parametros.Add("@IdComite", una_postulacion.Perfil.Comite.Id);
            parametros.Add("@Fecha", DateTime.Today);
            parametros.Add("@IdPostualcion", una_postulacion.Id);
            parametros.Add("@Usuario", usuario.Id);

            var tablaAnexo = conexion_bd.Ejecutar("dbo.CV_Ins_Anexos", parametros);

            return new AnexosDeEtapas();
        }

        public AnexosDeEtapas GetAnexoById(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdAnexo", id);

            return GetAnexo(parametros);
        }

        public AnexosDeEtapas GetAnexo(Dictionary<string, object> parametros)
        {

            var tablaAnexo = conexion_bd.Ejecutar("dbo.CV_Get_Anexo", parametros);
            var repo_comite = RepositorioDeComites.Nuevo(this.conexion_bd);
            var etapa = new EtapaConcurso(tablaAnexo.Rows[0].GetSmallintAsInt("IdEtapa"), tablaAnexo.Rows[0].GetString("DescripcionEtapa"));
            List<Postulacion> postulaciones = new List<Postulacion>();

            tablaAnexo.Rows.ForEach(row => postulaciones.Add(GetPostulacionById(0, row.GetInt("IdPostulacion"))));

            AnexosDeEtapas anexo = new AnexosDeEtapas(tablaAnexo.Rows[0].GetSmallintAsInt("IdAnexo"), repo_comite.GetComiteById(tablaAnexo.Rows[0].GetSmallintAsInt("IdComite")), postulaciones, etapa, tablaAnexo.Rows[0].GetDateTime("Fecha"));

            return anexo;
        }


        public List<ResumenDePostulaciones> TableroDeControlPostulaciones()
        {
            var parametros = new Dictionary<string, object>();
            var tablaReporte = conexion_bd.Ejecutar("dbo.CV_Get_Reporte", parametros);

            List<ResumenDePostulaciones> lista_reportes = new List<ResumenDePostulaciones>();

            //var valores = tablaReporte.Rows.ToList();
            //valores.GroupBy(
            //var valores_unicos = tablaReporte.Rows.g.GroupBy(r => r.GetSmallintAsInt("IdPerfil"));

            //agrupo x perfil y x etapa. cuento postulaciones. 

            // var postulados = tablaReporte.Rows.GroupBy(r => r.GetSmallintAsInt("IdPerfil")).FindAll(r => r.GetSmallintAsInt("IdEtapa") == 1).Count();


            /*var resultado = from a in tablaReporte.Rows.AsEnumerable()
                            //where a.GetSmallintAsInt("IdEtapa") == 1// && a.GetSmallintAsInt("IdEtapa") == 3
                            group a by new { columna1 = a.GetSmallintAsInt("IdPerfil"), columna4 = a.GetSmallintAsInt("IdEtapa") } into g
                            select new { Perfil = g.Key.columna1,  Postulados = g.Key.columna4 };*/


            foreach (var row in tablaReporte.Rows)
            {
                var registro = new ResumenDePostulaciones(row.GetSmallintAsInt("IdPerfil", 0), row.GetString("PerfilDescripcion", ""), row.GetString("PerfilNivel"), row.GetString("PerfilNumero"), row.GetString("PerfilAgrupamiento"), row.GetSmallintAsInt("NumeroComite", 0), row.GetInt("Postulados", 0), row.GetInt("Inscriptos", 0));

                lista_reportes.Add(registro);

            }

            /*
                        foreach (var res in tablaReporte.Rows )
                        {
                            if (res.GetInt("IdEtapa") == 1)
                            {
                    
                            }
                            ReportePostular reporte = new ReportePostular();
                            reporte.DescripcionPerfil = res.GetString("PerfilDescripcion");
                            reporte.NumeroComite = res.GetSmallintAsInt("NumeroComite");
                            if (res.GetInt("IdEtapa"))
                            {
                    
                            }
                            reporte.Postulados = res.GetInt("Postulados");

                            lista_reportes.Add(reporte);
                        }*/

            return lista_reportes;
        }

        public string InscripcionManual(string postulacion, string datosPersonales, string folio, Usuario usuario) {

            var postulacion_deserializada = (JObject)JsonConvert.DeserializeObject(postulacion);
            var datosPersonales_deserializada = (JObject)JsonConvert.DeserializeObject(datosPersonales);
            var folio_deserializada = (JObject)JsonConvert.DeserializeObject(folio);

            var idPerfil = postulacion_deserializada["postulacion"]["Perfil"].ToString();
            var numerosGDE = postulacion_deserializada["postulacion"]["NumerosDeInformeGDE"].ToArray();

            var fechaInscripcion = postulacion_deserializada["postulacion"]["FechaInscripcion"].ToString();
            string[] fechas = fechaInscripcion.Split('/');
            DateTime fechaFormateada = new DateTime(int.Parse(fechas[2]), int.Parse(fechas[1]), int.Parse(fechas[0])); 

            var dniInscriptor = postulacion_deserializada["postulacion"]["DNIInscriptor"].ToString();
            var nombre = datosPersonales_deserializada["datosPersonales"]["Nombre"].ToString();
            var apellido = datosPersonales_deserializada["datosPersonales"]["Apellido"].ToString();
            var dni = datosPersonales_deserializada["datosPersonales"]["DNI"].ToString();
            var telefono = datosPersonales_deserializada["datosPersonales"]["Telefono"].ToString();
            var mail = datosPersonales_deserializada["datosPersonales"]["Mail"].ToString();

            var folioFicha = folio_deserializada["folio"]["FichaInscripcion"].ToString();
            var folioCarnet = folio_deserializada["folio"]["FotografiaCarnet"].ToString();
            var folioDNI = folio_deserializada["folio"]["FotocopiaDNI"].ToString();
            var folioTitulo = folio_deserializada["folio"]["Titulo"].ToString();
            var folioCV = folio_deserializada["folio"]["CV"].ToString();
            var folioRespaldo = folio_deserializada["folio"]["DocumentacionRespaldo"].ToString();

            var domicilio_personal_calle = datosPersonales_deserializada["datosPersonales"]["DomicilioCallePersonal"].ToString();
            var domicilio_personal_nro = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioNroPersonal"].ToString());
            var domicilio_personal_piso = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioPisoPersonal"].ToString());
            var domicilio_personal_depto = datosPersonales_deserializada["datosPersonales"]["DomicilioDeptoPersonal"].ToString();
            var domicilio_personal_cp = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioCpPersonal"].ToString());
            var domicilio_personal_prov = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioProvinciaPersonal"].ToString());
            var domicilio_personal_localidad = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioLocalidadPersonal"].ToString());

            var domicilio_legal_calle = datosPersonales_deserializada["datosPersonales"]["DomicilioCalleLegal"].ToString();
            var domicilio_legal_nro = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioNroLegal"].ToString());
            var domicilio_legal_piso = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioPisoLegal"].ToString());
            var domicilio_legal_depto = datosPersonales_deserializada["datosPersonales"]["DomicilioDeptoLegal"].ToString();
            var domicilio_legal_cp = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioCpLegal"].ToString());
            var domicilio_legal_prov = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioProvinciaLegal"].ToString());
            var domicilio_legal_localidad = int.Parse(datosPersonales_deserializada["datosPersonales"]["DomicilioLocalidadLegal"].ToString());


            //mockeado el tipo
            var modalidad = postulacion_deserializada["postulacion"]["Modalidad"].ToString();

           
            RepositorioDePersonas repoPersonas = RepositorioDePersonas.NuevoRepositorioDePersonas(conexion_bd);
            Persona personaAInscribir;
            try {
                //busco o creo la persona que se va a postular
                personaAInscribir = TraerPersonaPorDNI(repoPersonas, dni, nombre, apellido);
            }
            catch (Exception e) {
                return e.Message;
            }
           
            RepositorioDeUsuarios repoUsuarios = new RepositorioDeUsuarios(conexion_bd,repoPersonas);
            Usuario usuarioAInscribir;
            try {
                //busco el usuario de la persona que se va postular
                usuarioAInscribir = TraerUsuarioPorIdPersona(repoUsuarios, personaAInscribir.Id);
            }
            catch (Exception e ) {
                return e.Message;
            }
           
            Persona personaInscriptor;
          
            try {
                //busco la persona que fue el inscriptor
                personaInscriptor = TraerPersonaPorDNI(repoPersonas, dniInscriptor, "", "");
            }
            catch (Exception e) {
                return e.Message;
            }
            
            
             Usuario usuarioInscriptor;
             try {
                 //busco el usuario del inscriptor 
                 usuarioInscriptor = TraerUsuarioPorIdPersona(repoUsuarios, personaInscriptor.Id);
             }
             catch (Exception e) {
                 return e.Message;
             }

             //guardo el domicilio personal
             GuardarDomicilioInscripcionManual(int.Parse(dni), domicilio_personal_calle, domicilio_personal_nro, domicilio_personal_piso, domicilio_personal_depto, domicilio_personal_cp, domicilio_personal_prov, domicilio_personal_localidad, telefono, mail, 1, usuarioInscriptor.Id);
            //guardo el domicilio legal
             GuardarDomicilioInscripcionManual(int.Parse(dni), domicilio_legal_calle, domicilio_legal_nro, domicilio_legal_piso, domicilio_legal_depto, domicilio_legal_cp, domicilio_legal_prov, domicilio_legal_localidad, telefono, mail, 2, usuarioInscriptor.Id);

             //creo la postulacion
             var numeroPostulacion = CrearPostulacionManual(int.Parse(idPerfil), personaAInscribir.Id, usuarioAInscribir.Id, numerosGDE);

            //guardo los folios de la postulacion
            //OJO CAMBIAR LA FECHA
             GuardarFolios(numeroPostulacion, fechaFormateada, int.Parse(folioFicha), int.Parse(folioCarnet), int.Parse(folioDNI), int.Parse(folioTitulo), int.Parse(folioCV), int.Parse(folioRespaldo), usuarioInscriptor.Id);

            //guardo en la nueva tabla de postulacion manual
            GuardarDatosExtrasPostulacionManual(numeroPostulacion, DateTime.Now, usuario.Id, int.Parse(modalidad));

            //busco la postulacion para pasarla de etapa
            Postulacion mi_postul = this.GetPostulacionesPorCodigo(numeroPostulacion);
            InsEtapaPostulacion(mi_postul.Id, 2, usuarioInscriptor.Id);

            return numeroPostulacion;
        }

        private void GuardarDomicilioInscripcionManual(int dni, string domicilio_calle, int domicilio_nro, int domicilio_piso, string domicilio_depto, int domicilio_cod_postal, int domicilio_prov, int domicilio_localidad, string telefono, string mail, int tipo, int idUsuarioInscriptor)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Dni", dni);
            parametros.Add("@DomicilioCalle", domicilio_calle);
            parametros.Add("@DomicilioNumero", domicilio_nro);
            parametros.Add("@DomicilioPiso", domicilio_piso);
            parametros.Add("@DomicilioDepto", domicilio_depto);
            parametros.Add("@DomicilioCp", domicilio_cod_postal);
            parametros.Add("@DomicilioLocalidad", domicilio_localidad);
            parametros.Add("@DomicilioProvincia", domicilio_prov);
            parametros.Add("@DomicilioTipo", tipo);
            parametros.Add("@DomicilioTelefono", telefono);
            parametros.Add("@DomicilioCorreo_Electronico",mail );
            parametros.Add("@Usuario", idUsuarioInscriptor);
            parametros.Add("@Correo_Electronico_MDS", mail );
            parametros.Add("@DomicilioTelefono2", telefono);

            conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);
        }

        private bool GuardarDatosExtrasPostulacionManual(string codigoPostulacion, DateTime fechaInscripcionManual, int idUsuario, int modalidad)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@numeroPostulacion", codigoPostulacion);
            parametros.Add("@FechaInscripcionManual", fechaInscripcionManual);
            parametros.Add("@IdUsuario", idUsuario);
            parametros.Add("@ModalidadInscripcion", modalidad);

            conexion_bd.Ejecutar("dbo.CV_Ins_InscripcionManual", parametros);

            return true;
        }

        private Usuario TraerUsuarioPorIdPersona(RepositorioDeUsuarios repoUsuarios, int idPersona)
        {

            try
            {
                Usuario usuario = repoUsuarios.GetUsuarioPorIdPersona(idPersona);
                if (usuario.Id == 0)
                    return repoUsuarios.CrearUsuarioPara(idPersona);
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        private Persona TraerPersonaPorDNI(RepositorioDePersonas repoPersonas, string dni, string nombre, string apellido)
        {
            try 
	        {	        
		        List<Persona> personaAInscribir = repoPersonas.BuscarPersonas("{Documento:" + dni + "}");
                //si no encuentra a la persona la creo
                if (personaAInscribir.Count == 0 && nombre != "")
                {
                    repoPersonas.GuardarPersona(new Persona(0, int.Parse(dni), nombre, apellido, null));
                    personaAInscribir = repoPersonas.BuscarPersonas("{Documento:" + dni + "}");
                }
                                   
                             
                return personaAInscribir.First();

	        }
	        catch (Exception e)
	        {
                throw new Exception("No se encontró a la persona con el DNI: " + dni);
	        }
          
        }

        public string CrearPostulacionManual(int idPerfil, int idPersona, int idUsuario, Array numerosGDE)
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@idPuesto", idPerfil);
                parametros.Add("@idPersona", idPersona);
                parametros.Add("@Motivo", "");
                parametros.Add("@Observacion", "");
                parametros.Add("@Usuario", idUsuario);
                GeneradorDeEtiquetas repoTicket = new GeneradorDeEtiquetas(conexion_bd);
                var numeroPostulacion = repoTicket.GenerarTicket("POSTULAR");
                parametros.Add("@Numero", numeroPostulacion);

                var id = (int)conexion_bd.EjecutarEscalar("dbo.CV_Ins_Postulaciones", parametros);

                if (!GuardarNumerosGDEPorInscripcionManual(id, numerosGDE))
                {
                    throw new Exception("Fallo el insertado de los numeros de GDE");
                }


                //var datosPostulacion = new { numero = numeroPostulacion, idPostulacion = "Hello" };

                return numeroPostulacion;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool GuardarNumerosGDEPorInscripcionManual(int idPostulacion, Array numeroGDE)
        {

            try
            {
                foreach (Newtonsoft.Json.Linq.JValue numeroDeInforme in numeroGDE)
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@idPostulacion", idPostulacion);
                    parametros.Add("@numeroInformeGDE", numeroDeInforme.ToString());

                    conexion_bd.Ejecutar("dbo.CV_Ins_InformeGDEPostulacion", parametros);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<ModalidadDeInscripcion> BuscarModalidadesDeInscripcion()
        {
            var tablaModalidades = conexion_bd.Ejecutar("dbo.CV_Get_ModalidadDeInscripcion");

            var modalidades = new List<ModalidadDeInscripcion>();

            tablaModalidades.Rows.ForEach(row =>
            modalidades.Add(new ModalidadDeInscripcion(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")))
            );


            return modalidades;

        }

        public bool ActualizarInformesGDE(string numero, JArray setDeInformes, int idUsuario)
        {
            try
            {
                foreach (Newtonsoft.Json.Linq.JValue informesAceptados in setDeInformes[0])
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@numeroPostulacion", numero);
                    parametros.Add("@numeroInformeGDE", informesAceptados.ToString());
                    parametros.Add("@estado", 1);
                    parametros.Add("@idUsuario", idUsuario);

                    conexion_bd.Ejecutar("dbo.CV_UPD_InformeGDEPostulacion", parametros);
                }

                foreach (Newtonsoft.Json.Linq.JValue informesRechazados in setDeInformes[1])
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@numeroPostulacion", numero);
                    parametros.Add("@numeroInformeGDE", informesRechazados.ToString());
                    parametros.Add("@estado", 9);
                    parametros.Add("@idUsuario", idUsuario);

                    conexion_bd.Ejecutar("dbo.CV_UPD_InformeGDEPostulacion", parametros);
                }

                foreach (Newtonsoft.Json.Linq.JValue informesNuevos in setDeInformes[2])
                {
                    var parametros = new Dictionary<string, object>();
                    parametros.Add("@numeroPostulacion", numero);
                    parametros.Add("@numeroInformeGDE", informesNuevos.ToString());
                    parametros.Add("@estado", 0);
                    parametros.Add("@idUsuario", idUsuario);

                    conexion_bd.Ejecutar("dbo.CV_UPD_InformeGDEPostulacion", parametros);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
