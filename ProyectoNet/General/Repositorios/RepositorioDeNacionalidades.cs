using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeNacionalidades : RepositorioLazySingleton<Nacionalidad>
    {
        private static RepositorioDeNacionalidades _instancia;

        private RepositorioDeNacionalidades(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNacionalidades Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNacionalidades(conexion);
            return _instancia;
        }

        public List<Nacionalidad> All()
        {
            return this.Obtener();
        }

        protected override List<Nacionalidad> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetNacionalidades");
            var nacionalidades = new List<Nacionalidad>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    nacionalidades.Add(new Nacionalidad(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return nacionalidades;
        }

        protected override void GuardarEnLaBase(Nacionalidad objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Nacionalidad objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }
    }
}
