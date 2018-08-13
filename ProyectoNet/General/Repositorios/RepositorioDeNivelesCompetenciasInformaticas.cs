using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeNivelesCompetenciasInformaticas : RepositorioLazySingleton<CvNivelCompetenciaInformatica>
    {

        private static RepositorioDeNivelesCompetenciasInformaticas _instancia;

        private RepositorioDeNivelesCompetenciasInformaticas(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNivelesCompetenciasInformaticas Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNivelesCompetenciasInformaticas(conexion);
            return _instancia;
        }

        public List<CvNivelCompetenciaInformatica> All()
        {
            return this.Obtener();
        }

        protected override List<CvNivelCompetenciaInformatica> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetNivelesCompetenciasInformaticas");
            var niveles = new List<CvNivelCompetenciaInformatica>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CvNivelCompetenciaInformatica(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CvNivelCompetenciaInformatica objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CvNivelCompetenciaInformatica objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }















    }
}
