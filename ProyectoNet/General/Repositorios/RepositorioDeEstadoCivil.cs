using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeEstadosCiviles : RepositorioLazySingleton<EstadoCivil>
    {
        private static RepositorioDeEstadosCiviles _instancia;

        private RepositorioDeEstadosCiviles(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeEstadosCiviles NuevoRepositorioDeEstadoCivil(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeEstadosCiviles(conexion);
            return _instancia;
        }

        public List<EstadoCivil> TodosLosEstadosCiviles()
        {
            return this.Obtener();
        }

        protected override List<EstadoCivil> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetEstadosCiviles");
            var estados_civiles = new List<EstadoCivil>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    estados_civiles.Add(new EstadoCivil(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return estados_civiles;
        }

        protected override void GuardarEnLaBase(EstadoCivil objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(EstadoCivil objeto)
        {
            throw new NotImplementedException();
        }
    }
}
