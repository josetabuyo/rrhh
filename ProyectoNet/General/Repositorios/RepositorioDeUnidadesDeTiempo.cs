using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
   public class RepositorioDeUnidadesDeTiempo : RepositorioLazySingleton<UnidadDeTiempo>
    {
                     

       private static RepositorioDeUnidadesDeTiempo _instancia;

       private RepositorioDeUnidadesDeTiempo(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeUnidadesDeTiempo Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeUnidadesDeTiempo(conexion);
            return _instancia;
        }

        public List<UnidadDeTiempo> All()
        {
            return this.Obtener();
        }

        protected override List<UnidadDeTiempo> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetUnidadesDeTiempo");
            var unidades = new List<UnidadDeTiempo>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    unidades.Add(new UnidadDeTiempo(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return unidades;
        }

        protected override void GuardarEnLaBase(UnidadDeTiempo objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(UnidadDeTiempo objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }





















    }
}
