using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeMenues : RepositorioLazySingleton<MenuDelSistema>, IRepositorioDeMenues
    {
        protected  IRepositorioDeAccesosAURL repositorio_accesos;

        private static RepositorioDeMenues _instancia;

        private RepositorioDeMenues(IConexionBD conexion, IRepositorioDeAccesosAURL repo_accesos)
            : base(conexion, 10)
        {
            this.repositorio_accesos = repo_accesos;
        }

        public static RepositorioDeMenues NuevoRepositorioDeMenues(IConexionBD conexion, IRepositorioDeAccesosAURL repo_accesos)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeMenues(conexion, repo_accesos);
            return _instancia;
        }

        public List<MenuDelSistema> TodosLosMenues()
        {
            return this.Obtener();
        }

        private List<MenuDelSistema> GetMenuesDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            var menues = new List<MenuDelSistema>();
            if(tablaDatos.Rows.Count == 0) return menues;
            var accesos = this.repositorio_accesos.TodosLosAccesos();
         
            tablaDatos.Rows.ForEach(row =>
            {                
                if(!menues.Exists(m => m.Id == row.GetInt("IdMenu"))){
                    var menu = new MenuDelSistema();
                    menu.Id = row.GetInt("IdMenu");
                    menu.Nombre = row.GetString("NombreMenu");
                    menues.Add(menu);
                };

                var menu_actual = menues.Find(m => m.Id == row.GetInt("IdMenu"));
                if (!(row.GetObject("IdItemMenu") is DBNull))
                {
                    if(!menu_actual.Items.Exists(i => i.Id == row.GetInt("IdItemMenu"))){
                        var item = new ItemDeMenu();
                        item.Id = row.GetInt("IdItemMenu");
                        item.NombreItem = row.GetString("NombreItemMenu");
                        item.Descripcion = row.GetString("DescripcionItemMenu");
                        item.Orden = row.GetInt("OrdenItemMenu");
                        item.Acceso = accesos.Find(a=> a.Id==row.GetInt("IdAccesoAURL"));
                        if (item.Acceso == null) throw new Exception("Se hace referencia a un acceso a URL que no existe. Acceso:" + row.GetInt("IdAccesoAURL"));
                        menu_actual.Items.Add(item);
                    };                
                }
            });
            return menues;
        }

        protected override List<MenuDelSistema> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetMenues");
            return GetMenuesDeTablaDeDatos(tablaDatos);
        }

        protected override void GuardarEnLaBase(MenuDelSistema objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(MenuDelSistema objeto)
        {
            throw new NotImplementedException();
            
        }
    }
}
