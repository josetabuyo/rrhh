using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.MAU;
using General.Postular;

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
            postulacion.IdPersona = usuario.Owner.Id;

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
                   IdPersona=row.GetInt("IdPersona"), 
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
            var repo_comite = new RepositorioDeComites(this.conexion_bd);
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
                              repo_comite.GetComiteById(row.GetSmallintAsInt("IdComite"))                            
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
            return this.GetPostulaciones(parametros).First();
        }


        public bool EliminarPostulacionPorUsuario(Postulacion postulacion, Usuario usuario)
        {
            if (postulacion.IdPersona == usuario.Owner.Id)
            {
                var baja = CrearBaja(usuario);

                var parametros = new Dictionary<string, object>();
                parametros.Add("@IdPostulacion", postulacion.Id);
             //   parametros.Add("@IdPuesto", postulacion.Puesto.Id);
                parametros.Add("@IdPerfil", postulacion.Perfil.Id);
                parametros.Add("@IdPersona", postulacion.IdPersona);
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

        public List<Postulacion> BuscarPostulacionesPorEtapas(int id_comite, List<EtapaConcurso> etapas)
        {
            List<Postulacion> postulaciones_buscadas = new List<Postulacion>();
            postulaciones_buscadas = GetPostulacionesPorComite(id_comite).FindAll(p => etapas.Exists(e => e.Id == p.EtapaEn(DateTime.Today).Etapa.Id) );
            return postulaciones_buscadas;
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
            var repo_comite = new RepositorioDeComites(this.conexion_bd);
            var etapa = new EtapaConcurso(tablaAnexo.Rows[0].GetSmallintAsInt("IdEtapa"),tablaAnexo.Rows[0].GetString("DescripcionEtapa"));
            List<Postulacion> postulaciones = new List<Postulacion>();

            tablaAnexo.Rows.ForEach(row => postulaciones.Add(GetPostulacionById(0, row.GetInt("IdPostulacion"))));
 
            AnexosDeEtapas anexo = new AnexosDeEtapas(tablaAnexo.Rows[0].GetSmallintAsInt("IdAnexo"), repo_comite.GetComiteById(tablaAnexo.Rows[0].GetSmallintAsInt("IdComite")), postulaciones, etapa, tablaAnexo.Rows[0].GetDateTime("Fecha"));

            return anexo;
        }

    }
}
