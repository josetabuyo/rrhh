using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            if (!(row.GetObject("Id_Persona") is DBNull))
            {
                var persona = repositorio_de_personas.GetPersonaPorId(row.GetInt("Id_Persona"));
                return new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"), persona, !row.GetBoolean("Baja"));
            }
            return new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"), !row.GetBoolean("Baja"));            
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





        public bool RecuperarUsuario(string criterio)
        {
            try
            {
                var validador_datos = new Validador();
                var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
                if (criterio_deserializado["Mail"] != null)
                {

                    string mail = (string)((JValue)criterio_deserializado["Mail"]);
                    validador_datos.DeberiaSerMail(new string[] { "Mail" });

                    if (!validador_datos.EsValido(mail))
                        throw new ExcepcionDeValidacion("El tipo de dato no es correcto");

                    var parametros = new Dictionary<string, object>();
                    //var estudios = new List<CvEstudios>();
                    //var docencias = new List<CvDocencia>();

                    parametros.Add("@mail", mail);
                    var tablaCVs = conexion.Ejecutar("dbo.CV_GetDatosRecupero", parametros);

                    if (tablaCVs.Rows.Count > 0)
                    {
                        tablaCVs.Rows.ForEach(row => EnviarMailDeRecupero(row.GetBoolean("enviarMail"), row.GetString("Usuario")));

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EnviarMailDeRecupero(bool enviar_mail, string usuario)
        {
            if (enviar_mail)
            {

            }
        }
    }
}
