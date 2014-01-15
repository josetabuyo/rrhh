using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeAccesosAURL:IRepositorioDeAccesosAURL
    {
        private IConexionBD conexion;
        private IRepositorioDeFuncionalidades repositorio_funcionalidades;

        public RepositorioDeAccesosAURL(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            this.conexion = conexion;
            this.repositorio_funcionalidades = repo_funcionalidades;
        }

        public List<AccesoAURL> TodosLosAccesos()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetAccesosAURL");
            var funcionalidades = this.repositorio_funcionalidades.TodasLasFuncionalidades();
            var accesos = new List<AccesoAURL>();
            tablaDatos.Rows.ForEach(row =>
            {
                var acceso = new AccesoAURL(row.GetInt("Id"), funcionalidades.Find(f => f.Id==row.GetInt("IdFuncionalidad")), row.GetString("Url"));
                accesos.Add(acceso);
            });
            return accesos;
        }
    }
}
