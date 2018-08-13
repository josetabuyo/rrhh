using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public interface IRepositorioDePermisosSobreAreas
    {
        List<Area> AreasAdministradasPor(Usuario usuario);
        List<Area> AreasAdministradasPor(int id_usuario);
        List<Usuario> UsuariosQueAdministranElArea(Area area);
        void AsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado);
        void AsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado);
        void DesAsignarAreaAUnUsuario(Usuario usuario, Area area, int id_usuario_logueado);
        void DesAsignarAreaAUnUsuario(int id_usuario, int id_area, int id_usuario_logueado);
    }
}
