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
                    func = new Funcionalidad(row.GetInt("Id"), row.GetString("Nombre"));
                    funcionalidades.Add(func);
                }catch(Exception e){
                    Logger.EscribirLog("---------------------------------------------");
                    Logger.EscribirLog(e);
                    Logger.EscribirLog("cant filas:");
                    Logger.EscribirLog(tablaDatos.Rows.Count.ToString());
                    Logger.EscribirLog("cant columnas:");
                    Logger.EscribirLog(tablaDatos.Columns.Count.ToString());
                    Logger.EscribirLog("nombres columnas:");
                    string nombres_cols = "";
                    foreach(var col in tablaDatos.Columns){
                        nombres_cols += " " + col.ToString();
                    }
                    Logger.EscribirLog(nombres_cols);
                    Logger.EscribirLog("---------------------------------------------");
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
