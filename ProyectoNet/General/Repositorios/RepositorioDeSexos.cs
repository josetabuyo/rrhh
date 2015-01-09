using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeSexos : RepositorioLazySingleton<Sexo>
    {
        private static RepositorioDeSexos _instancia;

        private RepositorioDeSexos(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeSexos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeSexos(conexion);
            return _instancia;
        }

        public List<Sexo> All()
        {
            return this.Obtener();
        }

        protected override List<Sexo> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetSexos");
            var sexos = new List<Sexo>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    sexos.Add(new Sexo(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return sexos;
        }

        protected override void GuardarEnLaBase(Sexo objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Sexo objeto)
        {
            throw new NotImplementedException();
        }
    }
}
