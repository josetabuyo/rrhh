using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class RepositorioDePuestos
    {
        protected IConexionBD conexion_bd;

        public RepositorioDePuestos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Puesto> GetPuestos()
        {
            var parametros = new Dictionary<string, object>();
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_Puestos", parametros);
            var repoComite = new RepositorioDeComites(this.conexion_bd);
            List<Puesto> puestos = new List<Puesto>();

            tablaCVs.Rows.ForEach(row =>
            puestos.Add(new Puesto(row.GetInt("IdPuesto"),row.GetString("Familia"),row.GetString("Profesion"),row.GetString("Denominacion"),
                        row.GetString("Nivel"),row.GetString("Agrupamiento"),row.GetInt("Vacantes"), row.GetString("Tipo"),row.GetString("NumeroDePuesto"),
                        repoComite.GetComiteById(row.GetInt("IdComite")))));

            return puestos;

        }


        public Puesto GetPuestoById(int id)
        {
            return this.GetPuestos().Find(p => p.Id.Equals(id));
        }
    }
}
