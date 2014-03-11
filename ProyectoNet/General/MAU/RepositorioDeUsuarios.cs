using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Security.Cryptography;

namespace General.MAU
{
    public class RepositorioDeUsuarios:IRepositorioDeUsuarios
    {
        private IConexionBD conexion;
        private IRepositorioDePersonas repositorio_de_personas;

        public RepositorioDeUsuarios(IConexionBD conexion, IRepositorioDePersonas repo_personas)
        {
            this.conexion = conexion;
            this.repositorio_de_personas = repo_personas;
        }

        public Usuario GetUsuarioPorAlias(string alias)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@alias", alias);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            if (tablaDatos.Rows.Count > 1) throw new Exception("hay mas de un usuario con el mismo alias: " + alias);

            return GetUsuarioDeTablaDeDatos(tablaDatos);                                 
        }

        public Usuario GetUsuarioPorId(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            return GetUsuarioDeTablaDeDatos(tablaDatos);
        }

        public Usuario GetUsuarioPorIdPersona(int id_persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_persona", id_persona);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            
            if (tablaDatos.Rows.Count > 1) throw new Exception("hay mas de un usuario con el mismo id persona: " + id_persona);
            return GetUsuarioDeTablaDeDatos(tablaDatos);
        }

        private Usuario GetUsuarioDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            if (tablaDatos.Rows.Count == 0) return new UsuarioNulo();
            var row = tablaDatos.Rows.First();
            if (!(row.GetObject("Id_Persona") is DBNull))
            {
                var persona = repositorio_de_personas.GetPersonaPorId(row.GetInt("Id_Persona"));
                return new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"), persona, !row.GetBoolean("Baja"));
            }
            return new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"));            
        }
        
        public Usuario CrearUsuarioPara(int id_persona)
        {
            var persona = repositorio_de_personas.GetPersonaPorId(id_persona);
            var alias = (persona.Nombre.First() + persona.Apellido).Replace(" ", "");
            var contador = 1;
            while (!GetUsuarioPorAlias(alias).Equals(new UsuarioNulo()))
            {
                alias = (persona.Nombre.First() + persona.Apellido + contador.ToString()).Replace(" ", "");
                contador++;
            }

            var clave_encriptada = Encriptador.EncriptarSHA1(ClaveRandom());

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_persona", id_persona);
            parametros.Add("@alias", alias);
            parametros.Add("@clave_encriptada", clave_encriptada);
            int id_usuario = (int)conexion.EjecutarEscalar("dbo.MAU_CrearUsuario", parametros);

            return new Usuario(id_usuario, alias, clave_encriptada, persona, true);
        }

        public bool CambiarPassword(int id_usuario, string clave_actual, string clave_nueva)
        {
            return CambiarPassword(this.GetUsuarioPorId(id_usuario), clave_actual, clave_nueva);
        }

        public bool CambiarPassword(Usuario usuario, string clave_actual, string clave_nueva)
        {
            if (!usuario.CambiarClave(clave_actual, clave_nueva)) return false;

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", usuario.Id);
            parametros.Add("@clave_encriptada", Encriptador.EncriptarSHA1(clave_nueva));

            conexion.Ejecutar("dbo.MAU_GuardarUsuario", parametros);

            return true;
        }

        public string ResetearPassword(int id_usuario)
        {
            var clave_nueva = ClaveRandom();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id_usuario);
            parametros.Add("@clave_encriptada", Encriptador.EncriptarSHA1(clave_nueva));

            conexion.Ejecutar("dbo.MAU_GuardarUsuario", parametros);
            return clave_nueva;
        }

        private static string ClaveRandom()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var clave_nueva = new string(
                Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)])
              .ToArray());
            return clave_nueva;
        }
    }
}
