using System;
using System.Collections.Generic;
using System.Linq;
using General.Repositorios;
using System.Net.Mail;

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

        public Usuario GetUsuarioPorAlias(string alias, bool incluir_bajas=false)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@alias", alias);
            if(incluir_bajas) parametros.Add("@incluir_bajas", 1);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            if (tablaDatos.Rows.Count > 1) throw new Exception("hay mas de un usuario con el mismo alias: " + alias);

            return GetUsuarioDeTablaDeDatos(tablaDatos);                                 
        }
        public List<Usuario> GetUsuariosQueAdministranLaFuncionalidadDelArea(int id_funcionalidad, Area area) {

            var usuarios_1 = RepositorioDePermisosSobreAreas.NuevoRepositorioDePermisosSobreAreas(conexion, RepositorioDeAreas.NuevoRepositorioDeAreas(conexion)).UsuariosQueAdministranElArea(area.Id);
            var usuarios_2 = RepositorioDeFuncionalidadesDeUsuarios.NuevoRepositorioDeFuncionalidadesDeUsuarios(conexion, RepositorioDeFuncionalidades.NuevoRepositorioDeFuncionalidades(conexion)).UsuariosConLaFuncionalidad(id_funcionalidad);
            return usuarios_1.Intersect(usuarios_2).ToList();
        }

        public Usuario GetUsuarioPorId(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            return GetUsuarioDeTablaDeDatos(tablaDatos);
        }

        /*public Usuario GetUsuarioPorIdSinPersona(int id)
        {
            //var parametros = new Dictionary<string, object>();
            //parametros.Add("@id", id);
            //var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuario", parametros);
            List<Usuario> usuarios = GetUsuarios()
            return GetUsuarioDeTablaDeDatosSinPersona(tablaDatos);
        }*/

        public List<Usuario> GetUsuarios()
        {
            //var parametros = new Dictionary<string, object>();
            //parametros.Add("@id", id);
            var tablaDatos = conexion.Ejecutar("dbo.RH_GET_Usuarios");
            return GetUsuariosDeTablaDeDatosSinPersona(tablaDatos);
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
            usuario.MailRegistro = row.GetString("MailRegistro", "");
            if (!(row.GetObject("Id_Persona") is DBNull))
            {
                usuario.Owner = repositorio_de_personas.GetPersonaPorId(row.GetInt("Id_Persona"));
            }
            usuario.Verificado = row.GetBoolean("Verificado", false);
            return usuario;     
        }

        private List<Usuario> GetUsuariosDeTablaDeDatosSinPersona(TablaDeDatos tablaDatos)
        {

            List<Usuario> usuarios = new List<Usuario>();

            tablaDatos.Rows.ForEach((row) =>
            {

                Usuario un_usuario = new Usuario(row.GetSmallintAsInt("id"), row.GetString("nombre"), "", !row.GetBoolean("baja"));
                if (un_usuario != null)
                {
                    if (!(row.GetObject("IdPersona") is DBNull))
                    {
                        un_usuario.Owner = new Persona
                        {
                            Id = row.GetInt("IdPersona"),
                            Documento = row.GetInt("nroDocumento", 0),
                            Nombre = row.GetString("nombrePersona", row.GetString("Nombre_Real","")),
                            Apellido = row.GetString("apellidoPersona", row.GetString("Apellido", ""))
                        };

                        usuarios.Add(un_usuario);
                    }
                }
                
            });

            return usuarios;
 
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
            while (!GetUsuarioPorAlias(alias, true).Equals(new UsuarioNulo()))
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

            var usuario = new Usuario(id_usuario, alias, clave_encriptada, persona, true);
            repo_funcionalidades_usuarios.ConcederBasicas(usuario);

            return usuario;
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

        public bool ModificarMailRegistro(int id_usuario, string mail)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Usuario", id_usuario);
            parametros.Add("@NuevoMail", mail);

            conexion.Ejecutar("dbo.GEN_Modificar_email_registro", parametros);
            return true;
        }

        public string ResetearPassword(int id_usuario)
        {
            var clave_nueva = ClaveRandom();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id_usuario);
            parametros.Add("@clave_encriptada", Encriptador.EncriptarSHA1(clave_nueva));

            conexion.Ejecutar("dbo.MAU_GuardarUsuario", parametros);
            //Enviar Mail de reseteo
            var usuario = this.GetUsuarioPorId(id_usuario);
            var titulo = "Bienvenido al SIGIRH";
            var cuerpo = "Nombre de Usuario: " + usuario.Alias + Environment.NewLine + "Contraseña: " + clave_nueva;
           // EnviadorDeMails.EnviarMail(usuario.MailRegistro, titulo, cuerpo);
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
                lista_de_usuarios = corteControl(tablaDatos, 2);
            }

            return ordenarUsuariosAlfabeticamente(lista_de_usuarios);
        }


        private List<Usuario> corteControl(TablaDeDatos tablaDatos, int idProceso) { 
        
            List<Usuario> usuarios = new List<Usuario>();
            Usuario un_usuario = new Usuario();
            int idUsuario_original = 0;
            string alias_usuario_original = "";
            tablaDatos.Rows.ForEach((row) => {
                if ((row.GetObject("Id_Persona") is DBNull))
                {
                    un_usuario = GetUsuarioDeRow(row);
                    usuarios.Add(un_usuario);
                    //un_usuario.AgregarFuncionalidad(new Funcionalidad(row.GetInt("idFuncionalidad"), row.GetString("NombreFuncionalidad"))); 
                    alias_usuario_original = row.GetString("Alias");

                } else if (idUsuario_original != row.GetInt("Id_Persona"))
                {
                    un_usuario = GetUsuarioDeRow(row);
                    if (idProceso == 1) {
                        un_usuario.Owner.Area = new Area(0, row.GetString("descripcionAreaReal","Sin Definir"));
                    }
                    
                    usuarios.Add(un_usuario);
                    un_usuario.AgregarFuncionalidad(new Funcionalidad(
                        row.GetInt("idFuncionalidad", 0), 
                        row.GetString("NombreFuncionalidad", ""), 
                        row.GetString("GrupoFuncionalidad", ""), 
                        row.GetBoolean("FuncSoloParaVerificados", false),
                        row.GetBoolean("FuncSoloParaEmpleados", false),
                        row.GetBoolean("FuncBasica", false)));
                    idUsuario_original = row.GetInt("Id_Persona");
                }
                else
                {
                    un_usuario.AgregarFuncionalidad(new Funcionalidad(
                        row.GetInt("idFuncionalidad", 0),
                        row.GetString("NombreFuncionalidad", ""),
                        row.GetString("GrupoFuncionalidad", ""),
                        row.GetBoolean("FuncSoloParaVerificados", false),
                        row.GetBoolean("FuncSoloParaEmpleados", false),
                        row.GetBoolean("FuncBasica", false)));
                }
            });

            return usuarios;
        }

        private Usuario GetUsuarioDeRow(RowDeDatos row) {
            
            Usuario usuario = new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"), !row.GetBoolean("Baja"));
            if (!(row.GetObject("Id_Persona") is DBNull))
            {
                usuario.Owner = repositorio_de_personas.GetPersonaPorId(row.GetInt("Id_Persona"));
            }
            usuario.Verificado = row.GetBoolean("Verificado", false);
            return usuario;   
        }

        public List<Usuario> GetUsuariosPorArea(string nombre_area)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@area", nombre_area);
            var tablaDatos = conexion.Ejecutar("dbo.GEN_GetAreasUsuarios",parametros);
            List<Usuario> lista_de_usuarios = new List<Usuario>();

            if (tablaDatos.Rows.Count > 0)
            {
                    lista_de_usuarios = corteControl(tablaDatos, 1);
            }

            return ordenarUsuariosAlfabeticamente(lista_de_usuarios);
        }

        private List<Usuario> ordenarUsuariosAlfabeticamente(List<Usuario> lista_de_usuarios)
        {
            //Obtengo todos los usuarios sin persona asociada
            var lista_usuarios_sin_personas = lista_de_usuarios.FindAll(usu => usu.Owner == null);
            
            //Borro esas personas del listado original
            lista_de_usuarios.RemoveAll(usu => usu.Owner == null);

            //Ordeno el listado original ahora que saque esos null
            lista_de_usuarios.Sort((emp1, emp2) => emp1.Owner.Apellido.CompareTo(emp2.Owner.Apellido));
            
            //Agrego los usuarios sin personas al listado ordenado
            lista_de_usuarios.AddRange(lista_usuarios_sin_personas);

            return lista_de_usuarios;
        }


        public bool SolicitarCambioImagen(int id_usuario, int id_imagen)
        {
            RepositorioDeTickets repo = new RepositorioDeTickets(this.conexion);
            var id_ticket = repo.crearTicket("cambio_imagen", id_usuario);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@id_ticket", id_ticket);

            var tablaDatos = conexion.Ejecutar("dbo.MAU_SolicitarCambioImagen",parametros);

            return true;
        }


        public List<SolicitudDeCambioDeImagen> GetSolicitudesDeCambioDeImagenPendientesPara(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetSolicitudesDeCambioDeImagenPendientes", parametros);

            var repo = new RepositorioDeTickets(this.conexion);

            var solicitudes = new List<SolicitudDeCambioDeImagen>();
            tablaDatos.Rows.ForEach((row) =>
            {
                var solicitud = new SolicitudDeCambioDeImagen();
                solicitud.idImagenAnterior = row.GetInt("id_imagen_anterior", -1);
                solicitud.idImagenNueva = row.GetInt("id_imagen_nueva", -1);
                solicitud.usuario = GetUsuarioPorId(row.GetInt("id_usuario"));

                solicitudes.Add(solicitud);
            });

            return solicitudes;
        }

        public List<SolicitudDeCambioDeImagen> GetSolicitudesDeCambioDeImagenPendientes()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetSolicitudesDeCambioDeImagenPendientes");

            var solicitudes = new List<SolicitudDeCambioDeImagen>();
            tablaDatos.Rows.ForEach((row) =>
            {
                var solicitud = new SolicitudDeCambioDeImagen();
                solicitud.idImagenAnterior = row.GetInt("id_imagen_anterior", -1);
                solicitud.idImagenNueva = row.GetInt("id_imagen_nueva", -1);
                solicitud.usuario = GetUsuarioPorId(row.GetInt("id_usuario"));
                solicitudes.Add(solicitud);
            });

            return solicitudes;
        }

        public SolicitudDeCambioDeImagen GetCambioImagenPorIdTicket(int id_ticket)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_ticket", id_ticket);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetCambioImagenPorIdTicket", parametros);

            var repo = new RepositorioDeTickets(this.conexion);

            var solicitudes = new List<SolicitudDeCambioDeImagen>();
            var row = tablaDatos.Rows[0];

            var solicitud = new SolicitudDeCambioDeImagen();
            solicitud.idImagenAnterior = row.GetInt("id_imagen_anterior", -1);
            solicitud.idImagenNueva = row.GetInt("id_imagen_nueva", -1);
            solicitud.usuario = GetUsuarioPorId(row.GetInt("id_usuario"));

            solicitudes.Add(solicitud);

            return solicitud;
        }

        public bool CambiarImagenPerfil(int id_usuario, int id_imagen, int id_administrador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_imagen", id_imagen);
            parametros.Add("@id_administrador", id_administrador);
            conexion.Ejecutar("dbo.MAU_CambiarImagenPerfil", parametros);
            return true;
        }

        public bool AceptarCambioDeImagen(int id_usuario_solicitante, int id_administrador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario_solicitante);
            conexion.Ejecutar("dbo.MAU_AceptarCambioDeImagen", parametros);
            
            new RepositorioDeAlertasPortal(this.conexion)
               .crearAlerta("Solicitud de Cambio de Imágen", "Tu solicitud ha sido aprobada", id_usuario_solicitante, id_administrador);
            return true;
        }

        public bool RechazarCambioDeImagen(string razon_de_rechazo, int id_usuario_solicitante, int id_administrador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario_solicitante);
            parametros.Add("@razon_rechazo", razon_de_rechazo);
            conexion.Ejecutar("dbo.MAU_RechazarCambioDeImagen", parametros);

            new RepositorioDeAlertasPortal(this.conexion)
                .crearAlerta("Solicitud de Cambio de Imágen", "Tu solicitud ha sido rechazada por:" + razon_de_rechazo, id_usuario_solicitante, id_administrador);
            return true;
        }

        public bool AceptarCambioImagenConImagenRecortada(int id_imagen_recortada, int id_usuario_solicitante, int id_administrador)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario_solicitante);
            parametros.Add("@id_imagen_recortada", id_imagen_recortada);
            conexion.Ejecutar("dbo.MAU_AceptarCambioDeImagenConImagenRecortada", parametros);
            
            new RepositorioDeAlertasPortal(this.conexion)
               .crearAlerta("Solicitud de Cambio de Imágen", "Tu solicitud ha sido aprobada con retoques a la imagen original", id_usuario_solicitante, id_administrador);
            return true;
        }
    }
}
