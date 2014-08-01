using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeTiposdeDocumento : RepositorioLazySingleton<TipoDeDocumento>
    {
        private static RepositorioDeTiposdeDocumento _instancia;

        private RepositorioDeTiposdeDocumento(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeTiposdeDocumento Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeTiposdeDocumento(conexion);
            return _instancia;
        }

        public List<TipoDeDocumento> All()
        {
            return this.Obtener();
        }

        protected override List<TipoDeDocumento> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetTiposDeDocumento");
            var tipos = new List<TipoDeDocumento>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    tipos.Add(new TipoDeDocumento(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return tipos;
        }

        protected override void GuardarEnLaBase(TipoDeDocumento objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(TipoDeDocumento objeto)
        {
            throw new NotImplementedException();
        }
    }
}
