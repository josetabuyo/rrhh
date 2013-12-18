using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public interface IRepositorioDeUsuarios
    {
        Usuario GetUsuarioPorAlias(string nombre_usuario);
    }
}
