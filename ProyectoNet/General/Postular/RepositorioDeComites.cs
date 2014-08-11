using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class RepositorioDeComites
    {
        protected IConexionBD conexion_bd;

        public RepositorioDeComites(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Comite> GetComites()
        {
            var parametros = new Dictionary<string, object>();
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_Comites", parametros);

            List<Comite> comites = new List<Comite>();

            tablaCVs.Rows.ForEach(row =>
            comites.Add(new Comite(row.GetInt("Id"), row.GetInt("Numero"), row.GetString("Integrantes"))));

            return comites;

        }


        public Comite GetComiteById(int id)
        {
            return this.GetComites().Find(c => c.Id.Equals(id));
        }
    }
}
