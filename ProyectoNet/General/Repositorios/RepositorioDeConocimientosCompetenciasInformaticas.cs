using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeConocimientosCompetenciasInformaticas : RepositorioLazySingleton<CvConocimientoCompetenciaInformatica>
    {

        private static RepositorioDeConocimientosCompetenciasInformaticas _instancia;

         private RepositorioDeConocimientosCompetenciasInformaticas(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

         public static RepositorioDeConocimientosCompetenciasInformaticas Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeConocimientosCompetenciasInformaticas(conexion);
            return _instancia;
        }

        public List<CvConocimientoCompetenciaInformatica> All()
        {
            return this.Obtener();
        }

        protected override List<CvConocimientoCompetenciaInformatica> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetConocimientosCompetenciasInformaticas");
            var niveles = new List<CvConocimientoCompetenciaInformatica>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CvConocimientoCompetenciaInformatica(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CvConocimientoCompetenciaInformatica objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CvConocimientoCompetenciaInformatica objeto)
        {
            throw new NotImplementedException();
        }











    }
}
