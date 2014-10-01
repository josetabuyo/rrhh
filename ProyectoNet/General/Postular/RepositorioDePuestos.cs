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

            puestos.ForEach(p => p.DocumentacionRequerida = this.GetFoliablesDelPerfil(p.Id));

            return puestos;

        }

        public List<Foliable> GetFoliablesDelPerfil(int id) {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPerfil", id);
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_DocRequeridaDelPerfil", parametros);
            List<Foliable> foliables = new List<Foliable>();

            tablaCVs.Rows.ForEach(row =>
            foliables.Add(ArmarFoliableSegunClase(row.GetString("NombreClaseFoliable"), row.GetString("DescripcionDocRequerida")))
            );

            return foliables;

        }

        private Foliable ArmarFoliableSegunClase(string nombreClase, string descripcion)
        {
            // Get the type of a specified class.
            var tipoFiltro = "General." + nombreClase;
            var assembly = typeof(Foliable).Assembly;

           // Foliable foliable;

            //return (Foliable)Activator.CreateInstance(assembly.GetType(tipoFiltro));
            //Si deseo mandarle argumentos al contructor
            return (Foliable)Activator.CreateInstance(assembly.GetType(tipoFiltro), new Object[] { descripcion, nombreClase });

            
        }


        public Puesto GetPuestoById(int id)
        {
            return this.GetPuestos().Find(p => p.Id.Equals(id));
        }
  
    }
}
