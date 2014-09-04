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

        public List<Postulacion> GetPostulacionesDe(int idpersona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idpersona);
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_Postulaciones", parametros);

            List<Postulacion> postulaciones = new List<Postulacion>();



            tablaCVs.Rows.ForEach(row =>
            postulaciones.Add(new Postulacion(row.GetInt("IdPostulacion"), ArmarPuesto(row),row.GetInt("IdPersona"),row.GetDateTime("FechaInscripcion"),
                                              row.GetString("Motivo"), row.GetString("Observaciones"), row.GetString("Postulacion_Numero",""))));
                      

            return postulaciones;

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
    }
}
