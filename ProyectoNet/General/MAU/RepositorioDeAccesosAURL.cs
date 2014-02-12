using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeAccesosAURL : RepositorioLazy<List<AccesoAURL>>, IRepositorioDeAccesosAURL
    {
        private IConexionBD conexion;
        private IRepositorioDeFuncionalidades repositorio_funcionalidades;

        private static RepositorioDeAccesosAURL _instancia;
        private static DateTime _fecha_creacion;

        private RepositorioDeAccesosAURL(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            this.conexion = conexion;
            this.repositorio_funcionalidades = repo_funcionalidades;
            this.cache = new CacheNoCargada<List<AccesoAURL>>();
        }

        public static RepositorioDeAccesosAURL NuevoRepositorioDeAccesosAURL(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            if (_instancia == null || ExpiroTiempoDelRepositorio())
            {
                _instancia = new RepositorioDeAccesosAURL(conexion, repo_funcionalidades);
                _fecha_creacion = DateTime.Now;
            }
            return _instancia;
        }

        private static bool ExpiroTiempoDelRepositorio()
        {
            if (FechaExpiracion() < DateTime.Now)
	        {
                return true;
	        }
            return false;
        }

        private static DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(10);

        }

        public List<AccesoAURL> ObtenerTodosLosAccesoDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetAccesosAURL");
            var funcionalidades = this.repositorio_funcionalidades.TodasLasFuncionalidades();
            var accesos = new List<AccesoAURL>();
            tablaDatos.Rows.ForEach(row =>
            {
                var acceso = new AccesoAURL(row.GetInt("Id"), funcionalidades.Find(f => f.Id == row.GetInt("IdFuncionalidad")), row.GetString("Url"));
                accesos.Add(acceso);
            });
            return accesos;
        }

        public List<AccesoAURL> TodosLosAccesos()
        {
            return cache.Ejecutar(ObtenerTodosLosAccesoDesdeLaBase, this);
        }
    }
}
