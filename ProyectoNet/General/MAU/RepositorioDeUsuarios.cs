using System;
using System.Collections.Generic;
using System.Linq;
using General.Repositorios;

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

        public int GetDniPorAlias(string alias)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@alias", alias);
            var tablaDatos = conexion.Ejecutar("dbo.Web_Get_UsuarioPorAlias", parametros);
            return GetDNIUsuarioDeTablaDeDatos(tablaDatos);
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
            Usuario usuario = new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"), !row.GetBoolean("Baja")); 
            if (!(row.GetObject("Id_Persona") is DBNull))
            {
                usuario.Owner = repositorio_de_personas.GetPersonaPorId(row.GetInt("Id_Persona"));
            }
            usuario.Verificado = row.GetBoolean("Verificado", false);
            return usuario;     
        }


        private int GetDNIUsuarioDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            if (tablaDatos.Rows.Count == 0) return 0;
            var row = tablaDatos.Rows.First();
            if ((row.GetObject("NroDocumento") is DBNull))
            {
                return 0;
            }
            return row.GetSmallintAsInt("NroDocumento");
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

            var repo_funcionalidades_usuarios = RepositorioDeFuncionalidadesDeUsuarios.NuevoRepositorioDeFuncionalidadesDeUsuarios(this.conexion, RepositorioDeFuncionalidades.NuevoRepositorioDeFuncionalidades(this.conexion));

            //Permisos básicos
            repo_funcionalidades_usuarios.ConcederFuncionalidadA(id_usuario, 3); //Menu principal
            repo_funcionalidades_usuarios.ConcederFuncionalidadA(id_usuario, 13); //Postular

            return new Usuario(id_usuario, alias, clave_encriptada, persona, true);
        }

        public void AsociarUsuarioConMail(Usuario usuario, string mail) {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Usuario", usuario.Id);
            parametros.Add("@Mail_Registro", mail);

            conexion.Ejecutar("dbo.CV_AsociarUsuarioConMailRegistrado", parametros);
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


        public Usuario RecuperarUsuario(string mail)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@mail_recupero", mail);
            var tablaCVs = conexion.Ejecutar("dbo.CV_GetDatosRecupero", parametros);
            Usuario usuario_a_recuperar = new Usuario();
            bool enviar_mail = true;
            if (tablaCVs.Rows.Count > 0)
            {
                var registros = tablaCVs.Rows.FindAll(row => row.GetInt("Baja", 0) == 0 && row.GetSmallintAsInt("enviarMail", 0) == 0);

                if (registros.Count > 0)
                {
                    var registro = registros.First();
                    usuario_a_recuperar = new Usuario(registro.GetSmallintAsInt("Id"), registro.GetString("Alias"), registro.GetString("Clave_Encriptada"), enviar_mail);
                    return usuario_a_recuperar;
                }
                else
                {
                    return new UsuarioNulo();
                }
            }
            else
            {
                return new UsuarioNulo();
            }
        }

        public Persona GetPersonaPorIdUsuario(int id_usuario)
        {
            var usr = GetUsuarioPorId(id_usuario);
            return repositorio_de_personas.GetPersonaPorId(usr.Owner.Id);
        }

        internal bool ValidarMailExistente(string mail)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@mail_recupero", mail);
            var tablaCVs = conexion.Ejecutar("dbo.CV_GetDatosRecupero", parametros);

            if (tablaCVs.Rows.Count > 0) return true;
            return false;
            
        }

        public List<Usuario> GetUsuariosConPersonasDeBaja()
        {
           // var parametros = new Dictionary<string, object>();
            //parametros.Add("@id_persona", id_persona);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetPersonasDeBajaConUsuarios");
            List<Usuario> lista_de_usuarios = new List<Usuario>();

            if (tablaDatos.Rows.Count > 1)
            {
                lista_de_usuarios = corteControl(tablaDatos);
            }

            return lista_de_usuarios;
        }

        private List<Usuario> corteControl(TablaDeDatos tablaDatos) { 
        
            List<Usuario> usuarios = new List<Usuario>();
            Usuario un_usuario = new Usuario();
            int idUsuario_original = 0;
            tablaDatos.Rows.ForEach((row) => {
                if (idUsuario_original != row.GetInt("Id_Persona"))
                {
                    un_usuario = GetUsuarioDeTablaDeDatos(tablaDatos);
                    usuarios.Add(un_usuario);
                    idUsuario_original = row.GetInt("Id_Persona");               
                } else {
                    un_usuario.AgregarFuncionalidad(new Funcionalidad(row.GetInt("idFuncionalidad"), row.GetString("NombreFuncionalidad")));  
                }
            });

            return usuarios;
        }
    }
}
