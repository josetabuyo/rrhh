using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Autorizador
    {
        protected List<MenuDelSistema> menues_del_sistema;
        public Autorizador(List<MenuDelSistema> menues_del_sistema)
        {
            this.menues_del_sistema = menues_del_sistema;
        }


        public Autorizador()
        {
            
        }

        public Dictionary<string, string> ItemsPermitidos(string nombre_menu)
        {
            var menu = menues_del_sistema.Find(m => m.SeLlama(nombre_menu));
            if (menu == null) menu = MenuDelSistema.MenuNulo();
            return menu.Items();
        }

        public List<Curso> FiltrarCursosPorUsuario(List<Curso> cursos, Organigrama organigrama, Usuario usuario)
        {
            List<Area> areas_usuario = organigrama.GetAreasInferioresDeLasAreas(usuario.Areas);

            List<Curso> curso_filtrado_por_usuario = cursos.FindAll(c => areas_usuario.Contains(c.EspacioFisico.Edificio.Area));

            return curso_filtrado_por_usuario;
        }
    }
}
