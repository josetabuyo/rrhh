using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeNivelesDeEstudio : RepositorioLazySingleton<NivelDeEstudio>
    {
        private static RepositorioDeNivelesDeEstudio _instancia;

        private RepositorioDeNivelesDeEstudio(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeNivelesDeEstudio Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeNivelesDeEstudio(conexion);
            return _instancia;
        }

        public List<NivelDeEstudio> All()
        {
            return this.Obtener();
        }        

        protected override List<NivelDeEstudio> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.CV_GET_NivelesDeEstudio");
            var niveles = new List<NivelDeEstudio>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    niveles.Add(new NivelDeEstudio(row.GetSmallintAsInt("Id"), row.GetString("Descripcion")));
                });
            }

            return niveles;
        }
    
        protected override void  GuardarEnLaBase(NivelDeEstudio objeto)
        {
 	        throw new NotImplementedException();
        }

        protected override void  QuitarDeLaBase(NivelDeEstudio objeto)
        {
 	        throw new NotImplementedException();
        }
    }
}
