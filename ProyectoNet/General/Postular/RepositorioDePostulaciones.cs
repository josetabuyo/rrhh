using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.MAU;

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
            parametros.Add("@idPuesto", postulacion.Puesto.Id);
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
            var tablaPostulaciones = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones");

            return ArmarPostulaciones(tablaPostulaciones);

        }

        public List<Postulacion> GetPostulacionesDe(int idpersona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idpersona);
            var tablaPostulaciones = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones", parametros);

            return ArmarPostulaciones(tablaPostulaciones);

        }

        private List<Postulacion> ArmarPostulaciones(TablaDeDatos tablaCVs)
        {
            List<Postulacion> postulaciones = new List<Postulacion>();

            tablaCVs.Rows.ForEach(row =>
            {
                var postulacion = new Postulacion(row.GetInt("IdPostulacion"), ArmarPuesto(row), row.GetInt("IdPersona"), row.GetDateTime("FechaInscripcion"),
                                                  row.GetString("Motivo"), row.GetString("Observaciones"), row.GetString("Postulacion_Numero", ""), GetEtapasPotulacion(row.GetInt("IdPostulacion")));
                
                postulaciones.Add(postulacion);

            });
            return postulaciones;
        }

        public List<EtapaPostulacion> GetEtapasPotulacion(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPostulacion", id);

            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_HistorialEtapasPostulacion", parametros);

            var etapas = new List<EtapaPostulacion>();

            tablaCVs.Rows.ForEach(row =>
            etapas.Add(new EtapaPostulacion()
            {
                Descripcion = row.GetString("Descripcion"),
                Fecha = row.GetDateTime("Fecha"),
                Usuario = row.GetSmallintAsInt("IdUsuario").ToString()
            }));


            return etapas;

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

        private Puesto ArmarPuesto(RowDeDatos row)
        {
            var repo_comite = new RepositorioDeComites(this.conexion_bd);
            return new Puesto(
                              row.GetInt("IdPuesto"),
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
                parametros.Add("@IdPuesto", postulacion.Puesto.Id);
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
            parametros.Add("@Descripcion", etapa_postulacion.Descripcion);
            parametros.Add("@Usuario", etapa_postulacion.Usuario);

            conexion_bd.EjecutarSinResultado("dbo.CV_Ins_Etapa_Postulacion", parametros);

        }
    }
}
