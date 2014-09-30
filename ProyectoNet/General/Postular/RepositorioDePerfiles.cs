using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.Postular
{
   public class RepositorioDePerfiles
    {


        protected IConexionBD conexion_bd;

        public RepositorioDePerfiles(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Perfil> GetPerfiles()
        {
            var parametros = new Dictionary<string, object>();
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_Perfiles", parametros);
            var repoComite = new RepositorioDeComites(this.conexion_bd);
            List<Perfil> perfiles = new List<Perfil>();

            tablaCVs.Rows.ForEach(row =>
            perfiles.Add(new Perfil(row.GetInt("IdPerfil"), row.GetString("Familia"), row.GetString("Profesion"), row.GetString("Denominacion"),
                        row.GetString("Nivel"),row.GetString("Agrupamiento"),row.GetInt("Vacantes"), row.GetString("Tipo"),row.GetString("NumeroDePuesto"),
                        repoComite.GetComiteById(row.GetInt("IdComite")))));

            return perfiles;

        }


        public Perfil GetPuestoById(int id)
        {
            return this.GetPerfiles().Find(p => p.Id.Equals(id));
        }


















    }
}
