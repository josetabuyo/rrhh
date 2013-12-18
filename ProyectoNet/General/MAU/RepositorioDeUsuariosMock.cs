using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using AdministracionDeUsuarios;

namespace AdministracionDeUsuarios
{
    class RepositorioDeUsuariosMock:IRepositorioDeUsuarios
    {
        public List<Usuario> usuarios { get; set; }

        public RepositorioDeUsuariosMock(List<Usuario> usuarios)
        {
            this.usuarios = usuarios;
        }

        public Usuario GetUsuarioPorAlias(string alias)
        {
            return usuarios.FirstOrDefault(u => u.Alias == alias) ?? new UsuarioNulo(); ;
        }
    }
}
