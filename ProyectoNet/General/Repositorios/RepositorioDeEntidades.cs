using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;

namespace General.Repositorios
{
    public class RepositorioDeEntidades : RepositorioLazySingleton<Entidad>
    {
        private static RepositorioDeEntidades _instancia;

        private RepositorioDeEntidades(IConexionBD conexion)
            : base(conexion, 10)
        {
        }

        public static RepositorioDeEntidades NuevoRepositorioDeEntidades(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeEntidades(conexion);
            return _instancia;
        }


         public List<Entidad> BuscarEntidades(string criterio)
         {
             var palabras_busqueda = criterio.Split(' ').Select(p => p.ToUpper().Trim());
             return GetTodasLasEntidadesCompletas().FindAll(entidad =>
                 palabras_busqueda.All(palabra => entidad.Nombre.ToUpper().Contains(palabra.ToUpper())));
         }

         

        public List<Entidad> GetTodasLasEntidadesCompletas()
        {
            return this.Obtener(); 
        }

        

        public Entidad GetEntidadPorId(int id_entidad)
        {
            Entidad entidadEncontrada = this.GetTodasLasEntidadesCompletas().Find(a => a.Id == id_entidad);

            return entidadEncontrada;
        }
        

        protected override List<Entidad> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.PRGSOC_GET_Entidades");
            List<Entidad> entidades = GetEntidadesDeTablaDeDatos(tablaDatos);
            return entidades;
        }

        public static List<Entidad> GetEntidadesDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            List<Entidad> entidades = new List<Entidad>();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                    entidades.Add(new Entidad(row.GetInt("Id_Entidad"), row.GetString("Nombre_Entidad")))
                    );



            }
            
            return entidades;
        }

        protected override void GuardarEnLaBase(Entidad objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Entidad objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }
    }
}
