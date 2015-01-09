using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDePaises : RepositorioLazySingleton<Pais>
    {
        private static RepositorioDePaises _instancia;

        private RepositorioDePaises(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDePaises Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDePaises(conexion);
            return _instancia;
        }

        public List<Pais> All()
        {
            return this.Obtener();
        }

        protected override List<Pais> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetPaises");
            var nacionalidades = new List<Pais>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    nacionalidades.Add(new Pais(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return nacionalidades;
        }

        protected override void GuardarEnLaBase(Pais objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Pais objeto)
        {
            throw new NotImplementedException();
        }
    }
}
