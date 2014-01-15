using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeMenues:IRepositorioDeMenues
    {
        protected IConexionBD conexion;
        protected  IRepositorioDeAccesosAURL repositorio_accesos;

        public RepositorioDeMenues(IConexionBD conexion, IRepositorioDeAccesosAURL repo_accesos)
        {
            this.conexion = conexion;
            this.repositorio_accesos = repo_accesos;
        }

        public List<MenuDelSistema> TodosLosMenues()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetMenues");
            return GetMenuesDeTablaDeDatos(tablaDatos);
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
                if(!menu_actual.Items.Exists(i => i.Id == row.GetInt("IdItem"))){
                    var item = new ItemDeMenu();
                    item.Id = row.GetInt("IdItem");
                    item.NombreItem = row.GetString("NombreItem");
                    item.Orden = row.GetInt("OrdenItemMenu");
                    item.Acceso = accesos.Find(a=> a.Id==row.GetInt("IdAccesoAURL"));
                    menu_actual.Items.Add(item);
                };                
            });
            return menues;
        }
    }
}
