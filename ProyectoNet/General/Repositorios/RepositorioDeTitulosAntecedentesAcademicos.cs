using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General.Repositorios
{
    public class RepositorioDeTitulosAntecedentesAcademicos : RepositorioLazySingleton<CVTitulosAntecedentesAcademicos>
    {


        private static RepositorioDeTitulosAntecedentesAcademicos _instancia;

        private RepositorioDeTitulosAntecedentesAcademicos(IConexionBD conexion)
            :base(conexion, 1)
        {
        }

        public static RepositorioDeTitulosAntecedentesAcademicos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeTitulosAntecedentesAcademicos(conexion);
            return _instancia;
        }

        public List<CVTitulosAntecedentesAcademicos> All()
        {
            return this.Obtener();
        }

        protected override List<CVTitulosAntecedentesAcademicos> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GetTitulosAntecedentesAcademicos");
            var niveles = new List<CVTitulosAntecedentesAcademicos>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new CVTitulosAntecedentesAcademicos(row.GetSmallintAsInt("Id"), row.GetString("Descripcion"), row.GetInt("SoloVisiblePara", -1)));
                });
            }

            return niveles;
        }

        protected override void GuardarEnLaBase(CVTitulosAntecedentesAcademicos objeto)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@descripcion", objeto.Descripcion);
            parametros.Add("@solo_visible_para", objeto.SoloVisiblePara);
            objeto.Id = Convert.ToInt32(conexion.EjecutarEscalar("dbo.CV_AgregarTitulosAntecedentesAcademicos", parametros));
        }


        protected override void QuitarDeLaBase(CVTitulosAntecedentesAcademicos objeto)
        {
            throw new NotImplementedException();
        }









    }
}
