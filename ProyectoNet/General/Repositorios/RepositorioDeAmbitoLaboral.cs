using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeAmbitoLaboral : RepositorioLazySingleton<AmbitoLaboral>
    {
        private static RepositorioDeAmbitoLaboral _instancia;

        private RepositorioDeAmbitoLaboral(IConexionBD conexion)
            : base(conexion, 10)
        {
        }

        public static RepositorioDeAmbitoLaboral Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeAmbitoLaboral(conexion);
            return _instancia;
        }

        public List<AmbitoLaboral> All()
        {
            return this.Obtener();
        }

        protected override List<AmbitoLaboral> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetAmbitoLaboral");
            var AmbitosLaborales = new List<AmbitoLaboral>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    AmbitosLaborales.Add(new AmbitoLaboral(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return AmbitosLaborales;
        }

        protected override void GuardarEnLaBase(AmbitoLaboral objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(AmbitoLaboral objeto)
        {
            throw new NotImplementedException();
        }
    }
}
