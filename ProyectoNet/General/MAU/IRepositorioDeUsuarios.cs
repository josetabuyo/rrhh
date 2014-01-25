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
    }
}
