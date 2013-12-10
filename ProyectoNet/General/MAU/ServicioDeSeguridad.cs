using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace AdministracionDeUsuarios
{
    public class ServicioDeSeguridad
    {
        private List<Usuario> usuarios;
        private General.Repositorios.RepositorioDePersonas repositorioDePersonas;

        public ServicioDeSeguridad(RepositorioDePersonas repositorioDePersonas)
        {
            this.repositorioDePersonas = repositorioDePersonas;
        }

        public Usuario GetUsuarioPorIdPersona(int id_persona)
        {
            var persona = repositorioDePersonas.GetPersonas().Find(p=> p.Id==id_persona);
            var usuario = new Usuario()
            {
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Documento = persona.Documento,
                Legajo = persona.Legajo,
                Id = persona.Id,
                NombreDeUsuario = "prueba"
            };
            return usuario;
        }
    }
}
