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
            //parametros.Add("@FechaPostulacion", postulacion.FechaPostulacion);
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

        public List<Postulacion> GetPostulaciones()
        {
            var tablaPostulaciones = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones2");

            return ArmarPostulaciones(tablaPostulaciones);

        }

        public List<Postulacion> GetPostulacionesDe(int idpersona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idpersona);
            var tablaPostulaciones = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones2", parametros);

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
                                                IdEtapaConcurso = dRow.GetSmallintAsInt("IdEtapa"),
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

        public List<EtapaConcurso> GetEtapasConcurso()
        {
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_EtapasConcurso");

            var etapas = new List<EtapaConcurso>();

            tablaCVs.Rows.ForEach(row =>
            etapas.Add(new EtapaConcurso()
            {
                Id = row.GetSmallintAsInt("Id"),
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
                              row.GetInt("IdPerfil"),
                              row.GetString("Familia"),
                              row.GetString("Profesion"),
                              row.GetString("Denominacion"),
                              row.GetString("Nivel"),
                              row.GetString("Agrupamiento"),
                              row.GetInt("Vacantes"),
                              row.GetString("Tipo"),
                              row.GetString("Puesto_Numero"),
                              repo_comite.GetComiteById(row.GetInt("IdComite")
                              )
                );
        }
        


        public Postulacion GetPostulacionById(int idpersona, int idpostulacion)
        {
            return this.GetPostulacionesDe(idpersona).Find(p => p.Id.Equals(idpostulacion));
        
        }

        public Postulacion GetPostulacionesPorCodigo(string codigo)
        {
            return this.GetPostulaciones().Find(p => p.Numero.Equals(codigo));
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

        public void InsEtapaPostulacion(int id_postulacion,EtapaPostulacion etapa_postulacion)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPostulacion", id_postulacion);
            parametros.Add("@Descripcion", etapa_postulacion.Etapa.Id);
            parametros.Add("@Usuario", etapa_postulacion.IdUsuario);

            conexion_bd.EjecutarSinResultado("dbo.CV_Ins_EtapaPostulación", parametros);
        }
    }
}
