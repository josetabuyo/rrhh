using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
  public class RepositorioDeCaracterDeEventoAcademico: RepositorioLazySingleton<CVCaracterDeParticipacionEvento>
    {

   
        private static RepositorioDeCaracterDeEventoAcademico _instancia;

        private RepositorioDeCaracterDeEventoAcademico(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

         public static RepositorioDeCaracterDeEventoAcademico Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeCaracterDeEventoAcademico(conexion);
            return _instancia;
        }

        public List<CVCaracterDeParticipacionEvento> All()
        {
            return this.Obtener();
        }

        protected override List<CVCaracterDeParticipacionEvento> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetCaracterDeParticipacionEvento");
            var niveles = new List<CVCaracterDeParticipacionEvento>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CVCaracterDeParticipacionEvento(row.GetInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CVCaracterDeParticipacionEvento objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CVCaracterDeParticipacionEvento objeto)
        {
            throw new NotImplementedException();
        }









    }
}
