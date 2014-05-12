using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Sacc.Seguridad
{
    public class AutorizadorSacc
    {
        protected List<MenuDelSistema> menues_del_sistema;
        private Autorizador autorizador;
        public AutorizadorSacc(List<MenuDelSistema> menues_del_sistema)
        {
            this.menues_del_sistema = menues_del_sistema;
        }

        public List<ItemDeMenu> ItemsPermitidos(string nombre_menu)
        {
            var menu = menues_del_sistema.Find(m => m.SeLlama(nombre_menu));
            if (menu == null) menu = MenuDelSistema.MenuNulo();
            return menu.Items;
        }

        public AutorizadorSacc()
        {

        }

        public AutorizadorSacc(Autorizador autorizador)
        {
            this.autorizador = autorizador;
        }

        public List<Curso> FiltrarCursosPorUsuario(List<Curso> cursos, Organigrama organigrama, Usuario usuario)
        {
            List<Area> areas_usuario = organigrama.GetAreasInferioresDeLasAreas(this.autorizador.AreasAdministradasPor(usuario));

            List<Curso> curso_filtrado_por_usuario = cursos.FindAll(c => areas_usuario.Contains(c.EspacioFisico.Edificio.Area));

            return curso_filtrado_por_usuario;
        }

        public List<EspacioFisico> FiltrarEspaciosFisicosPorUsuario(List<EspacioFisico> espacios_fisicos, Organigrama organigrama, Usuario usuario)
        {
            List<Area> areas_usuario = organigrama.GetAreasInferioresDeLasAreas(this.autorizador.AreasAdministradasPor(usuario));

            List<EspacioFisico> espacios_filtrado_por_usuario = espacios_fisicos.FindAll(e => areas_usuario.Contains(e.Edificio.Area));

            return espacios_filtrado_por_usuario;
        }

        public bool AlumnoVisibleParaUsuario(Alumno alumno, Organigrama organigrama, Usuario usuario)
        {
            return AlumnoPerteneceAListaDeAreas(organigrama.GetAreasInferioresDeLasAreas(this.autorizador.AreasAdministradasPor(usuario)), alumno);
        }
        

        public List<Alumno> FiltrarAlumnosPorUsuario(List<Alumno> alumnos, Organigrama organigrama, Usuario usuario)
        {

            List<Area> areas_del_usuario_logueado = organigrama.GetAreasInferioresDeLasAreas(this.autorizador.AreasAdministradasPor(usuario));

            return FiltrarAlumnosPorAreas(areas_del_usuario_logueado, alumnos);     
        }


    private List<Alumno> FiltrarAlumnosPorAreas(List<Area> areas_subordinadas_del_usuario_logueado, List<Alumno> alumnos)
        {
            List<Alumno> alumnos_filtrados = new List<Alumno>();

            foreach (Alumno alumno in alumnos)
            {
                if (AlumnoPerteneceAListaDeAreas(areas_subordinadas_del_usuario_logueado, alumno))
                {
                    alumnos_filtrados.Add(alumno);
                }
            }

            return alumnos_filtrados;
        }


        private bool AlumnoPerteneceAListaDeAreas(List<Area> areas_subordinadas_del_usuario_logueado, Alumno alumno) 
        {
            foreach (Area area in alumno.Areas)
	        {
                if (areas_subordinadas_del_usuario_logueado.Contains(area)) 
                {
                    return true;
                }
	        }
            return false;
        }
  
    }
}


