using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.MAU;
using General.Postular;
using System.Data;

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

            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPuesto", postulacion.Perfil.Id);
            parametros.Add("@idPersona", usuario.Owner.Id);
            parametros.Add("@Motivo", postulacion.Motivo);
            parametros.Add("@Observacion", postulacion.Observaciones);
            parametros.Add("@Usuario", usuario.Id);
            RepositorioDeTickets repoTicket = new RepositorioDeTickets(conexion_bd);
            postulacion.Numero = repoTicket.GenerarTicket("POSTULAR");
            parametros.Add("@Numero", postulacion.Numero);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Postulaciones", parametros);
            postulacion.Id = Convert.ToInt32(id);
            postulacion.Postulante = usuario.Owner;
            postulacion.FechaPostulacion = DateTime.Now;

            return postulacion;
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
                var postulacion = new Postulacion(){
                   Id= row.GetInt("IdPostulacion"), 
                   Perfil=ArmarPuesto(row),
                   Postulante = new Persona() {
                       Id = row.GetInt("IdPostulante"),
                       Nombre = row.GetString("NombrePostulante"),
                       Apellido = row.GetString("ApellidoPostulante")
                   }, 
                   FechaPostulacion=row.GetDateTime("FechaInscripcion"),
                   Motivo=row.GetString("Motivo"), 
                   Observaciones=row.GetString("Observaciones"), 
                   Numero= row.GetString("Postulacion_Numero", "")
                };
                

                if(!postulaciones.Exists( p => p.Id == postulacion.Id))
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
                    new EtapaPostulacion(){
                        Etapa = new EtapaConcurso(e.IdEtapaConcurso, e.Descripcion), Fecha = e.Fecha, IdUsuario = e.IdUsuario
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

        //private Puesto ArmarPuesto(RowDeDatos row)
        //{
        //    var repo_comite = new RepositorioDeComites(this.conexion_bd);
        //    return new Puesto(
        //                      row.GetInt("IdPuesto"),
        //                      row.GetString("Familia"),
        //                      row.GetString("Profesion"),
        //                      row.GetString("Denominacion"),
        //                      row.GetString("Nivel"),
        //                      row.GetString("Agrupamiento"),
        //                      row.GetInt("Vacantes"),
        //                      row.GetString("Tipo"),
        //                      row.GetString("Puesto_Numero"),
        //                      repo_comite.GetComiteById(row.GetInt("IdComite")
        //                      )
        //        );
        //}

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
                              row.GetDateTime("PerfilFechaDesde",DateTime.Today),
                              row.GetDateTime("PerfilFechaHasta", DateTime.Today),
                              row.GetBoolean("PerfilBaja",false)
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
            return this.GetPostulaciones(parametros).First();
        
        }

        public Postulacion GetPostulacionesPorCodigo(string codigo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@NumeroPostulacion", codigo);
            try
            {
                 return this.GetPostulaciones(parametros).First();
            }
            catch (Exception e)
            {

                return null;
                //throw e;
            }
          
            //return this.GetPostulaciones(parametros).First();
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
            else {
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

        public void InsEtapaPostulacion(int id_postulacion,int id_etapa_postulacion, int id_usuario)
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

        private List<Postulacion> SoloPostulacionvigente(List<Postulacion> postulaciones_en_pantalla)
        {
            List<Postulacion> postulaciones_con_etapas_vigentes = new List<Postulacion>();
            postulaciones_en_pantalla.ForEach(p => {
                postulaciones_con_etapas_vigentes.Add(p.SoloEtapaVigente());
            });

            return postulaciones_con_etapas_vigentes;
        }

        public void GuardarCambiosEnAdmitidos(List<Postulacion> postulaciones, int id_usuario)
        {
            Postulacion postulacion_original;
            postulaciones.ForEach(postulacion => {

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
            var etapa = new EtapaConcurso(tablaAnexo.Rows[0].GetSmallintAsInt("IdEtapa"),tablaAnexo.Rows[0].GetString("DescripcionEtapa"));
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
                var registro = new ResumenDePostulaciones(row.GetSmallintAsInt("IdPerfil",0), row.GetString("PerfilDescripcion",""), row.GetString("PerfilNivel"), row.GetString("PerfilNumero"), row.GetString("PerfilAgrupamiento"), row.GetSmallintAsInt("NumeroComite",0), row.GetInt("Postulados",0), row.GetInt("Inscriptos",0));

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
    }
}
