using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using AdministracionDeUsuarios;
using General;

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

        public Usuario GetUsuarioPorId(int id_usuario)
        {
            return usuarios.FirstOrDefault(u => u.Id == id_usuario) ?? new UsuarioNulo();
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

        public Usuario RecuperarUsuario(string mail)
        {
            throw new NotImplementedException();
        }

        public void AsociarUsuarioConMail(Usuario usuario, string mail)
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

        public Persona GetPersonaPorIdUsuario(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuariosConPersonasDeBaja() {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuariosPorArea(string nombre_area)
        {
            throw new NotImplementedException();
        }


        public bool ModificarMailRegistro(int id_usuario, string mail)
        {
            throw new NotImplementedException();
        }


        public bool SolicitarCambioImagen(int id_usuario, int id_imagen)
        {
            throw new NotImplementedException();
        }


        public List<SolicitudDeCambioDeImagen> GetSolicitudesDeCambioDeImagenPendientesPara(int id_usuario)
        {
            throw new NotImplementedException();
        }


        public bool AceptarCambioDeImagen(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public bool RechazarCambioDeImagen(int id_usuario)
        {
            throw new NotImplementedException();
        }

        List<SolicitudDeCambioDeImagen> IRepositorioDeUsuarios.GetSolicitudesDeCambioDeImagenPendientes()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioPorAlias(string alias, bool incluir_bajas)
        {
            throw new NotImplementedException();
        }


        public bool RechazarCambioDeImagen(int id_usuario, string razon_rechazo)
        {
            throw new NotImplementedException();
        }


        public bool AceptarCambioImagenConImagenRecortada(int id_usuario, int id_imagen_recortada)
        {
            throw new NotImplementedException();
        }


        public SolicitudDeCambioDeImagen GetCambioImagenPorIdTicket(int id_ticket)
        {
            throw new NotImplementedException();
        }
    }
}
