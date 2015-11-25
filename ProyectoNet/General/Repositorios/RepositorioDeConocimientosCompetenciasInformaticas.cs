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
                    niveles.Add(new CvConocimientoCompetenciaInformatica(row.GetSmallintAsInt("Id"), row.GetString("Descripcion"), row.GetSmallintAsInt("IdTipo"), row.GetInt("SoloVisiblePara", -1)));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CvConocimientoCompetenciaInformatica objeto)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@descripcion", objeto.Descripcion);
            parametros.Add("@tipo", objeto.Tipo);
            parametros.Add("@solo_visible_para", objeto.SoloVisiblePara);
            objeto.Id = Convert.ToInt32(conexion.EjecutarEscalar("dbo.CV_AgregarConocimientosCompetenciasInformaticas", parametros));
        }

        protected override void QuitarDeLaBase(CvConocimientoCompetenciaInformatica objeto)
        {
            throw new NotImplementedException();
        }











    }
}
