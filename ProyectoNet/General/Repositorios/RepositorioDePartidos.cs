using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDePartidos : RepositorioLazySingleton<Partido>
    {
        private static RepositorioDePartidos _instancia;

        private RepositorioDePartidos(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDePartidos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDePartidos(conexion);
            return _instancia;
        }

        public List<Partido> All()
        {
            return this.Obtener();
        }

        public List<Partido> GetPartidosDeLaProvincia(int idProvincia)
        {

            List<Partido> partidos = this.ObtenerDesdeLaBase();
            List<Partido> partidosDeLaProvincia = partidos.FindAll(p => p.IdProvincia == idProvincia);

            return partidosDeLaProvincia;
        }

        protected override List<Partido> ObtenerDesdeLaBase()
        {
            var partidos = new List<Partido>();

            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetPartidos");
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    partidos.Add(new Partido(row.GetSmallintAsInt("id"), row.GetString("Descripcion"), row.GetSmallintAsInt("idProvincia")));
                });
            }

            //provincias.Add(new Provincia(1, "Buenos Aires"));
            //provincias.Add(new Provincia(2, "Entre Rios"));
            //provincias.Add(new Provincia(5, "Santa Fe"));
            //provincias.Add(new Provincia(8, "Mendoza"));

            return partidos;
        }

        protected override void GuardarEnLaBase(Partido objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Partido objeto)
        {
            throw new NotImplementedException();
        }
    }
}
