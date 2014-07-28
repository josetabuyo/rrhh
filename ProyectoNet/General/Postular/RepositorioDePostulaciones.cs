using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class RepositorioDePostulaciones
    {
        protected IConexionBD conexion_bd;

        public RepositorioDePostulaciones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        //public List<Puesto> GetPostulaciones()
        //{
           
        //    return puestos;
        //}

        public Postulacion PostularseA(Postulacion postulacion, MAU.Usuario usuario)
        {
            var idPersona = usuario.Owner.Id;
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPuesto", postulacion.IdPuesto);
            parametros.Add("@idPersona", idPersona);
            //parametros.Add("@FechaPostulacion", postulacion.FechaPostulacion);
            parametros.Add("@Motivo", postulacion.Motivo);
            parametros.Add("@Observacion", postulacion.Observaciones);
            parametros.Add("@Usuario", usuario.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Postulaciones", parametros);
            postulacion.Id = Convert.ToInt32(id);
            postulacion.IdPersona = idPersona;

            return postulacion;
        }
    }
}
