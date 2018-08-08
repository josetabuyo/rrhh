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

        public Usuario GetUsuarioPorDNI(int dni)
        {
            return usuarios.FirstOrDefault(u => u.Owner.Documento == dni) ?? new UsuarioNulo();
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

        public SolicitudDeCambioDeImagen GetCambioImagenPorIdTicket(int id_ticket)
        {
            throw new NotImplementedException();
        }


        public bool AceptarCambioDeImagen(int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        public bool RechazarCambioDeImagen(string razon_de_rechazo, int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        public bool AceptarCambioImagenConImagenRecortada(int id_imagen_recortada, int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorioDeUsuarios.GetUsuarioPorAlias(string alias, bool incluir_bajas)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorioDeUsuarios.GetUsuarioPorIdPersona(int id_persona)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorioDeUsuarios.CrearUsuarioPara(int id_persona)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.CambiarPassword(int id_usuario, string pass_actual, string pass_nueva)
        {
            throw new NotImplementedException();
        }

        string IRepositorioDeUsuarios.ResetearPassword(int id_usuario)
        {
            throw new NotImplementedException();
        }

        int IRepositorioDeUsuarios.GetDniPorAlias(string alias)
        {
            throw new NotImplementedException();
        }

        void IRepositorioDeUsuarios.AsociarUsuarioConMail(Usuario usuario, string mail)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorioDeUsuarios.GetUsuarioPorId(int id_usuario)
        {
            throw new NotImplementedException();
        }

        Persona IRepositorioDeUsuarios.GetPersonaPorIdUsuario(int id_usuario)
        {
            throw new NotImplementedException();
        }

        List<Usuario> IRepositorioDeUsuarios.GetUsuariosConPersonasDeBaja()
        {
            throw new NotImplementedException();
        }

        List<Usuario> IRepositorioDeUsuarios.GetUsuariosPorArea(string nombre_area)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.ModificarMailRegistro(int id_usuario, string mail)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.SolicitarCambioImagen(int id_usuario, int id_imagen)
        {
            throw new NotImplementedException();
        }

        List<SolicitudDeCambioDeImagen> IRepositorioDeUsuarios.GetSolicitudesDeCambioDeImagenPendientesPara(int id_usuario)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.AceptarCambioDeImagen(int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.RechazarCambioDeImagen(string razon_de_rechazo, int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        SolicitudDeCambioDeImagen IRepositorioDeUsuarios.GetCambioImagenPorIdTicket(int id_ticket)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.AceptarCambioImagenConImagenRecortada(int id_imagen_recortada, int id_usuario_solicitante, int id_administrador)
        {
            throw new NotImplementedException();
        }

        bool IRepositorioDeUsuarios.CambiarImagenPerfil(int id_usuario, int id_imagen, int id_administrador)
        {
            throw new NotImplementedException();
        }
    }
}
