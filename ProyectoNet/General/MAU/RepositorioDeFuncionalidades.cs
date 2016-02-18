using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.IO;

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
                Funcionalidad func;
                try
                {
                    func = new Funcionalidad(row.GetInt("Id"), row.GetString("Nombre"), row.GetString("GrupoNombre"));
                    funcionalidades.Add(func);
                }catch(Exception){
                    throw;
                }                
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
            var funcionalidades = GetFuncionalidadesDeTablaDeDatos(tablaDatos);
            if (funcionalidades.Count() == 0) throw new Exception("La lista de funcionalidades está vacía");
            return funcionalidades;
        }

        protected override void GuardarEnLaBase(Funcionalidad objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Funcionalidad objeto)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            objetos = ObtenerDesdeLaBase();
        }
    }
}
