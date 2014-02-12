using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeFuncionalidades : RepositorioLazy<List<Funcionalidad>>,  IRepositorioDeFuncionalidades
    {
        protected IConexionBD conexion;
        private static RepositorioDeFuncionalidades _instancia;
        private static DateTime _fecha_creacion;

        private RepositorioDeFuncionalidades(IConexionBD conexion)
        {
            this.conexion = conexion;
            this.cache = new CacheNoCargada<List<Funcionalidad>>();
        }

        public static RepositorioDeFuncionalidades NuevoRepositorioDeFuncionalidades(IConexionBD conexion)
        {
            if (_instancia == null || ExpiroTiempoDelRepositorio())
            {
                _instancia = new RepositorioDeFuncionalidades(conexion);
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

        public List<Funcionalidad> TodasLasFuncionalidades()
        {
            return cache.Ejecutar(GetFuncionalidadesDeBaseDeDatos, this);
        }

        public List<Funcionalidad> GetFuncionalidadesDeBaseDeDatos()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetFuncionalidades");
            return GetFuncionalidadesDeTablaDeDatos(tablaDatos);
        }

        private static List<Funcionalidad> GetFuncionalidadesDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            var funcionalidades = new List<Funcionalidad>();
            tablaDatos.Rows.ForEach(row =>
            {
                var func = new Funcionalidad(row.GetInt("Id"), row.GetString("Nombre"));
                funcionalidades.Add(func);
            });
            return funcionalidades;
        }

        public Funcionalidad GetFuncionalidadPorId(int id_funcionalidad)
        {
            return TodasLasFuncionalidades().Find(f => f.Id == id_funcionalidad);
        }
    }
}
