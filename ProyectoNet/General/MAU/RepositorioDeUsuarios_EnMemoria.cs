using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using AdministracionDeUsuarios;

namespace AdministracionDeUsuarios
{
    class RepositorioDeUsuarios_EnMemoria:IRepositorioDeUsuarios
    {
        public List<Usuario> usuarios { get; set; }

        public RepositorioDeUsuarios_EnMemoria(List<Usuario> usuarios)
        {
            this.usuarios = usuarios;
        }

        public Usuario GetUsuarioPorAlias(string alias)
        {
            return usuarios.FirstOrDefault(u => u.Alias == alias) ?? new UsuarioNulo();
        }

        public Usuario GetUsuarioPorIdPersona(int id_persona)
        {
            return usuarios.FirstOrDefault(u => u.Id == id_persona) ?? new UsuarioNulo();
        }
    }
}
