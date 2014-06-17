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
            try{
                return usuarios.First(u => u.Id == id_persona);
            }catch(InvalidOperationException exc){
                Exception e = new Exception();
                e.Data["codigo"] = "NO_EXISTE_EL_USUARIO";
                throw e;
            }
        }

        public Usuario CrearUsuarioPara(int id_persona)
        {
            throw new NotImplementedException();
        }


        public bool CambiarPassword(Usuario usuario, string pass_actual, string pass_nueva)
        {
            throw new NotImplementedException();
        }


        public bool CambiarPassword(int id_usuario, string pass_actual, string pass_nueva)
        {
            throw new NotImplementedException();
        }


        public string ResetearPassword(int id_usuario)
        {
            throw new NotImplementedException();
        }


        public int GetDniPorAlias(string alias)
        {
            throw new NotImplementedException();
        }
    }
}
