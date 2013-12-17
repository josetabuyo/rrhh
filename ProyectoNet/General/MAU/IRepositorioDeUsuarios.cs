using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public interface IRepositorioDeUsuarios
    {
        string GetPasswordEncriptadoDeUnUsuario(Usuario usuario);
        Usuario GetUsuarioPorNombre(string nombre_usuario);
    }
}
