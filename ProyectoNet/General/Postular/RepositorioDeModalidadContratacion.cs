using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeModalidadContratacion : RepositorioLazySingleton<CvModalidadContratacion>
    {

        private static RepositorioDeModalidadContratacion _instancia;

        private RepositorioDeModalidadContratacion(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeModalidadContratacion Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeModalidadContratacion(conexion);
            return _instancia;
        }

        public List<CvModalidadContratacion> All()
        {
            return this.Obtener();
        }

        protected override List<CvModalidadContratacion> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetModalidadContratacion");
            var niveles = new List<CvModalidadContratacion>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CvModalidadContratacion(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CvModalidadContratacion objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(CvModalidadContratacion objeto)
        {
            throw new NotImplementedException();
        }















    }
}
