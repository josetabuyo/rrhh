using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeNivelesDeIdioma : RepositorioLazySingleton<NivelDeIdioma>
    {
        private static RepositorioDeNivelesDeIdioma _instancia;

        private RepositorioDeNivelesDeIdioma(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNivelesDeIdioma Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNivelesDeIdioma(conexion);
            return _instancia;
        }

        public List<NivelDeIdioma> All()
        {
            return this.Obtener();
        }       

        protected override List<NivelDeIdioma> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetNivelesDeIdioma");
            var nacionalidades = new List<NivelDeIdioma>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    nacionalidades.Add(new NivelDeIdioma(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return nacionalidades;
        }

        protected override void GuardarEnLaBase(NivelDeIdioma objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(NivelDeIdioma objeto)
        {
            throw new NotImplementedException();
        }
    }
}
