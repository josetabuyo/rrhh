using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeFuncionalidades : RepositorioLazySingleton<Funcionalidad>, IRepositorioDeFuncionalidades
    {
        private static RepositorioDeFuncionalidades _instancia;

        private RepositorioDeFuncionalidades(IConexionBD conexion)
            : base(conexion, 10)
        {
        }

        public static RepositorioDeFuncionalidades NuevoRepositorioDeFuncionalidades(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeFuncionalidades(conexion);
            return _instancia;
        }

        public List<Funcionalidad> TodasLasFuncionalidades()
        {
            return this.Obtener();
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

        protected override List<Funcionalidad> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetFuncionalidades");
            return GetFuncionalidadesDeTablaDeDatos(tablaDatos);
        }

        protected override void GuardarEnLaBase(Funcionalidad objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Funcionalidad objeto)
        {
            throw new NotImplementedException();
        }
    }
}
