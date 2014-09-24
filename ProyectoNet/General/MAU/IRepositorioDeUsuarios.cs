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

        bool RecuperarUsuario(string criterio);
    }
}
