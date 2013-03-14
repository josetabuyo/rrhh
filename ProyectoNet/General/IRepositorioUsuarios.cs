using System.Collections.Generic;

namespace General
{
    public interface IRepositorioUsuarios
    {
        bool LoginUsuario(Usuario unUsuario, string Password);

        List<Usuario> GetTodosLosUsuarios();
    }
}
