using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeAccesosAURL : RepositorioLazySingleton<AccesoAURL>, IRepositorioDeAccesosAURL
    {
        private IRepositorioDeFuncionalidades repositorio_funcionalidades;

        private static RepositorioDeAccesosAURL _instancia;

        private RepositorioDeAccesosAURL(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
            : base(conexion, 10)
        {
            this.repositorio_funcionalidades = repo_funcionalidades;
        }

        public static RepositorioDeAccesosAURL NuevoRepositorioDeAccesosAURL(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeAccesosAURL(conexion, repo_funcionalidades);
            return _instancia;
        }

        public List<AccesoAURL> ObtenerTodosLosAccesoDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetAccesosAURL");
            var funcionalidades = this.repositorio_funcionalidades.TodasLasFuncionalidades();
            var accesos = new List<AccesoAURL>();
            tablaDatos.Rows.ForEach(row =>
            {
                var func = funcionalidades.Find(f => f.Id == row.GetInt("IdFuncionalidad"));
                if (func != null)
                {
                    var acceso = new AccesoAURL(row.GetInt("Id"), func, row.GetString("Url"));
                    accesos.Add(acceso);
                }
            });
            return accesos;
        }

        public List<AccesoAURL> TodosLosAccesos()
        {
            return this.Obtener();
        }

        protected override List<AccesoAURL> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetAccesosAURL");
            var funcionalidades = this.repositorio_funcionalidades.TodasLasFuncionalidades();
            var accesos = new List<AccesoAURL>();
            tablaDatos.Rows.ForEach(row =>
            {
                var acceso = new AccesoAURL(row.GetInt("Id"), funcionalidades.Find(f => f.Id == row.GetInt("IdFuncionalidad")), row.GetString("Url"));
                if (acceso.Funcionalidad == null) throw new Exception("Se hace referencia a una funcionalidad que no existe. Funcionalidad:" + row.GetInt("IdFuncionalidad"));
                accesos.Add(acceso);
            });
            if (accesos.Count() == 0) throw new Exception("La lista de accesos a URL está vacía");
            return accesos;
        }

        protected override void GuardarEnLaBase(AccesoAURL objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(AccesoAURL objeto)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            objetos = ObtenerDesdeLaBase();
        }
    }
}
