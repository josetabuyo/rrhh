using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
   public class RepositorioDeTiposDeEventoAcademico : RepositorioLazySingleton<CVTiposDeEventoAcademico>
    {


       private static RepositorioDeTiposDeEventoAcademico _instancia;

         private RepositorioDeTiposDeEventoAcademico(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeTiposDeEventoAcademico Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeTiposDeEventoAcademico(conexion);
            return _instancia;
        }

        public List<CVTiposDeEventoAcademico> All()
        {
            return this.Obtener();
        }

        protected override List<CVTiposDeEventoAcademico> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetTiposDeEventoAcademico");
            var tipos = new List<CVTiposDeEventoAcademico>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    tipos.Add(new CVTiposDeEventoAcademico(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return tipos;
        }

        protected override void GuardarEnLaBase(CVTiposDeEventoAcademico objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CVTiposDeEventoAcademico objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }
















    }
}
