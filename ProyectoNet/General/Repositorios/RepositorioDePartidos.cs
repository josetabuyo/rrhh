using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDePartidos : RepositorioLazySingleton<Partido>
    {
        private static RepositorioDePartidos _instancia;

        private RepositorioDePartidos(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDePartidos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDePartidos(conexion);
            return _instancia;
        }

        public List<Partido> All()
        {
            return this.Obtener();
        }

        public List<Partido> GetProvinciasDeLaZona(Zona zona)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.VIA_GetProvinciasDeLaZona");
            cn.AsignarParametro("@idZona", zona.Id);

            dr = cn.EjecutarConsulta();
            Partido unaProvincia;
            List<Partido> provincias = new List<Partido>();
            RepositorioDeLocalidades repositorio = RepositorioDeLocalidades.Nuevo(this.conexion);

            while (dr.Read())
            {
                unaProvincia = new Partido { Id = dr.GetInt16(0), Nombre = dr.GetString(1), IdProvincia = dr.GetInt16(0) };
                provincias.Add(unaProvincia);
               
            }
            return provincias;
        }

        protected override List<Partido> ObtenerDesdeLaBase()
        {
            var provincias = new List<Partido>();

            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetProvincias");
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    provincias.Add(new Partido(row.GetSmallintAsInt("id"), row.GetString("nombre"),1));
                });
            }

            //provincias.Add(new Provincia(1, "Buenos Aires"));
            //provincias.Add(new Provincia(2, "Entre Rios"));
            //provincias.Add(new Provincia(5, "Santa Fe"));
            //provincias.Add(new Provincia(8, "Mendoza"));

            return provincias;
        }

        protected override void GuardarEnLaBase(Partido objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Partido objeto)
        {
            throw new NotImplementedException();
        }
    }
}
