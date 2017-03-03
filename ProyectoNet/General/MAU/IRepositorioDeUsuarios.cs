using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public interface IRepositorioDeUsuarios
    {
        Usuario GetUsuarioPorAlias(string alias);
        Usuario GetUsuarioPorIdPersona(int id_persona);
        Usuario CrearUsuarioPara(int id_persona);
        bool CambiarPassword(int id_usuario, string pass_actual, string pass_nueva);
        string ResetearPassword(int id_usuario);
        int GetDniPorAlias(string alias);
        void AsociarUsuarioConMail(Usuario usuario, string mail);
        Usuario GetUsuarioPorId(int id_usuario);
        Persona GetPersonaPorIdUsuario(int id_usuario);
        List<Usuario> GetUsuariosConPersonasDeBaja();
        List<Usuario> GetUsuariosPorArea(string nombre_area);
        bool ModificarMailRegistro(int id_usuario, string mail);
        bool SolicitarCambioImagen(int id_usuario, int id_imagen);
    }
}
