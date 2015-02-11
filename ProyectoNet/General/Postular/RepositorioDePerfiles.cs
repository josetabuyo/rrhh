using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
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
            perfiles.Add(new Perfil(row.GetSmallintAsInt("IdPerfil"), row.GetString("Familia"), row.GetString("Profesion"), row.GetString("Denominacion"),
                        row.GetString("Nivel"),row.GetString("Agrupamiento"),row.GetSmallintAsInt("Vacantes"), row.GetString("Tipo"),row.GetString("NumeroDePuesto"),
                        repoComite.GetComiteById(row.GetSmallintAsInt("IdComite")))));

            return perfiles;

        }


        public Perfil GetPerfilById(int id)
        {
            return this.GetPerfiles().Find(p => p.Id.Equals(id));
        }

        public List<RequisitoPerfil> GetRequisitosDelPerfil(int id)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPerfil", id);
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_DocRequeridaDelPerfil", parametros);
            List<RequisitoPerfil> requisitos = new List<RequisitoPerfil>();

            tablaCVs.Rows.ForEach(row =>
            requisitos.Add(ArmarRequisitosSegunClase(row.GetString("NombreClaseFoliable"), row.GetString("DescripcionDocRequerida"), row.GetSmallintAsInt("Parametro")))
            );

            return requisitos;

        }

        private RequisitoPerfil ArmarRequisitosSegunClase(string nombreClase, string descripcion, int parametro)
        {
            // Get the type of a specified class.
            var tipoFiltro = "General." + nombreClase;
            var assembly = typeof(RequisitoPerfil).Assembly;

            // Foliable foliable;

            //return (Foliable)Activator.CreateInstance(assembly.GetType(tipoFiltro));
            //Si deseo mandarle argumentos al contructor
            return (RequisitoPerfil)Activator.CreateInstance(assembly.GetType(tipoFiltro), new Object[] { descripcion, parametro });


        }

        //public List<Foliable> GetFoliablesDelPerfil(int id)
        //{

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@idPerfil", id);
        //    var tablaCVs = conexion_bd.Ejecutar("dbo.CV_Get_DocRequeridaDelPerfil", parametros);
        //    List<Foliable> foliables = new List<Foliable>();

        //    tablaCVs.Rows.ForEach(row =>
        //    foliables.Add(ArmarFoliableSegunClase(row.GetString("NombreClaseFoliable"), row.GetString("DescripcionDocRequerida")))
        //    );

        //    return foliables;

        //}

        //private Foliable ArmarFoliableSegunClase(string nombreClase, string descripcion)
        //{
        //    // Get the type of a specified class.
        //    var tipoFiltro = "General." + nombreClase;
        //    var assembly = typeof(Foliable).Assembly;

        //    // Foliable foliable;

        //    //return (Foliable)Activator.CreateInstance(assembly.GetType(tipoFiltro));
        //    //Si deseo mandarle argumentos al contructor
        //    return (Foliable)Activator.CreateInstance(assembly.GetType(tipoFiltro), new Object[] { descripcion, nombreClase });


        //}


















    }
}
