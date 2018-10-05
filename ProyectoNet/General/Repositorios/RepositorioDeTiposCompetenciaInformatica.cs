using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeTiposCompetenciaInformatica : RepositorioLazySingleton<CvTipoCompetenciaInformatica>
    {

        private static RepositorioDeTiposCompetenciaInformatica _instancia;

         private RepositorioDeTiposCompetenciaInformatica(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

         public static RepositorioDeTiposCompetenciaInformatica Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeTiposCompetenciaInformatica(conexion);
            return _instancia;
        }

        public List<CvTipoCompetenciaInformatica> All()
        {
            return this.Obtener();
        }

        protected override List<CvTipoCompetenciaInformatica> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetTiposCompetenciasInformaticas");
            var tipos = new List<CvTipoCompetenciaInformatica>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    tipos.Add(new CvTipoCompetenciaInformatica(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return tipos;
        }

        protected override void GuardarEnLaBase(CvTipoCompetenciaInformatica objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CvTipoCompetenciaInformatica objeto, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }









    }
}
