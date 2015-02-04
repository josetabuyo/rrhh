using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeInstitucionesEventosAcademicos : RepositorioLazySingleton<CVInstitucionesEventos>
    {


        private static RepositorioDeInstitucionesEventosAcademicos _instancia;

        private RepositorioDeInstitucionesEventosAcademicos(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeInstitucionesEventosAcademicos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeInstitucionesEventosAcademicos(conexion);
            return _instancia;
        }

        public List<CVInstitucionesEventos> All()
        {
            return this.Obtener();
        }

        protected override List<CVInstitucionesEventos> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetInstitucionesEvento");
            var niveles = new List<CVInstitucionesEventos>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CVInstitucionesEventos(row.GetSmallintAsInt("Id"), row.GetString("Descripcion"), row.GetInt("SoloVisiblePara", -1)));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CVInstitucionesEventos objeto)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@descripcion", objeto.Descripcion);
            parametros.Add("@solo_visible_para", objeto.SoloVisiblePara);
            objeto.Id =Convert.ToInt32(conexion.EjecutarEscalar("dbo.CV_AgregarInstitucionEvento", parametros));
        }


        protected override void QuitarDeLaBase(CVInstitucionesEventos objeto)
        {
            throw new NotImplementedException();
        }









    }
}
