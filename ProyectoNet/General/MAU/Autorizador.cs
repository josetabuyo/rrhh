using System.Collections.Generic;
using System.Linq;
using ExtensionesDeLista;
using General;
using System;
using System.Security.Cryptography;
using System.Text;
using General.Repositorios;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace General.MAU
{
    public class Autorizador
    {
        protected IRepositorioDeFuncionalidadesDeUsuarios repositorio_funcionalidades_usuarios;
        protected IRepositorioDePermisosSobreAreas repositorio_permisos_sobre_areas;
        protected IRepositorioDeMenues repositorio_menues;
        protected IRepositorioDeUsuarios repositorio_usuarios;
        protected IRepositorioDeAccesosAURL repositorio_accesos_a_url;
        protected IConexionBD conexion;

        public Autorizador(IRepositorioDeFuncionalidadesDeUsuarios repo_funcionalidades,
            IRepositorioDeMenues repo_menues,
            IRepositorioDeUsuarios repo_usuarios,
            IRepositorioDePermisosSobreAreas repo_permisos_sobre_areas,
            IRepositorioDeAccesosAURL repo_accesos_a_url,
            IConexionBD conexion)
        {
            this.repositorio_funcionalidades_usuarios = repo_funcionalidades;
            this.repositorio_menues = repo_menues;
            this.repositorio_usuarios = repo_usuarios;
            this.repositorio_permisos_sobre_areas = repo_permisos_sobre_areas;
            this.repositorio_accesos_a_url = repo_accesos_a_url;
            this.conexion = conexion;
        }

        public Autorizador(IRepositorioDeFuncionalidadesDeUsuarios repo_funcionalidades,
        IRepositorioDeMenues repo_menues,
        IRepositorioDeUsuarios repo_usuarios,
        IRepositorioDePermisosSobreAreas repo_permisos_sobre_areas,
        IRepositorioDeAccesosAURL repo_accesos_a_url)
        {
            this.repositorio_funcionalidades_usuarios = repo_funcionalidades;
            this.repositorio_menues = repo_menues;
            this.repositorio_usuarios = repo_usuarios;
            this.repositorio_permisos_sobre_areas = repo_permisos_sobre_areas;
            this.repositorio_accesos_a_url = repo_accesos_a_url;
        }

        public Autorizador()
        {
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, Funcionalidad funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Exists(f => f.Equals(funcionalidad));
        }

        public bool ElUsuarioTienePermisosPara(Usuario usuario, string nombre_funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Exists(f => f.Nombre == nombre_funcionalidad);
        }


        public bool ElUsuarioTienePermisosPara(int id_usuario, int id_funcionalidad)
        {
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(id_usuario).Exists(f => f.Id==id_funcionalidad);
        }


        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.ConcederFuncionalidadA(usuario, funcionalidad);
        }

        public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.ConcederFuncionalidadA(id_usuario, id_funcionalidad);
        }

        public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            this.repositorio_funcionalidades_usuarios.DenegarFuncionalidadA(id_usuario, id_funcionalidad);
        }

        public static Autorizador Instancia()
        {
            return new Autorizador();
        }

        public List<Area> AreasAdministradasPor(Usuario usuario)
        {
            return repositorio_permisos_sobre_areas.AreasAdministradasPor(usuario);
        }

        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            return repositorio_permisos_sobre_areas.AreasAdministradasPor(id_usuario);
        }

        public void AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            repositorio_permisos_sobre_areas.AsignarAreaAUnUsuario(usuario, area);
        }

        public void DesAsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            repositorio_permisos_sobre_areas.DesAsignarAreaAUnUsuario(usuario, area);
        }

        public bool Login(string nombre_usuario, string clave)
        {
            var usuario = this.repositorio_usuarios.GetUsuarioPorAlias(nombre_usuario);
            if (!usuario.Habilitado) return false;
            if (!usuario.ValidarClave(clave)) return false;
            this.loguearIngresoDe(usuario);
            return true;
        }

        private void loguearIngresoDe(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", usuario.Id);
            this.conexion.EjecutarSinResultado("MAU_Loguear_Ingreso", parametros); 
        }

        public MenuDelSistema GetMenuPara(string nombre_menu, Usuario usuario)
        {
            return repositorio_menues.TodosLosMenues().Find(m => m.SeLlama(nombre_menu)).FitrarPorFuncionalidades(repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario));
        }

        public Boolean ElUsuarioPuedeAccederALaURL(Usuario usuario, string url)
        {
            var funcionalidades_que_permiten_acceder_a_la_url = this.repositorio_accesos_a_url.TodosLosAccesos().FindAll(a => a.Url.ToUpper() == url.ToUpper()).Select(a => a.Funcionalidad);
            if (funcionalidades_que_permiten_acceder_a_la_url.Count() == 0) return true;
            return this.repositorio_funcionalidades_usuarios.FuncionalidadesPara(usuario).Any(f => funcionalidades_que_permiten_acceder_a_la_url.Contains(f));
        }

        public void AsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            repositorio_permisos_sobre_areas.AsignarAreaAUnUsuario(id_usuario, id_area);
        }

        public void DesAsignarAreaAUnUsuario(int id_usuario, int id_area)
        {
            repositorio_permisos_sobre_areas.DesAsignarAreaAUnUsuario(id_usuario, id_area);
        }

        public void RegistrarNuevoUsuario(AspiranteAUsuario aspirante)
        {            
            var repo_personas = RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion);
            if (repo_personas.BuscarPersonas(JsonConvert.SerializeObject(new { Documento=aspirante.Documento, ConLegajo=true})).Count > 0)
            {
                throw new Exception("Ya hay alguien registrado con su documento.");
            }
 
            if(aspirante.Nombre.Trim() == "") throw new Exception("El nombre no puede ser vacío.");
            if(aspirante.Apellido.Trim() == "") throw new Exception("El apellido no puede ser vacío.");

            var persona = new Persona();
            persona.Documento = aspirante.Documento;
            persona.Nombre = aspirante.Nombre;
            persona.Apellido = aspirante.Apellido;

            repo_personas.GuardarPersona(persona);
            

            var usuario = repositorio_usuarios.CrearUsuarioPara(persona.Id);
            var clave =  repositorio_usuarios.ResetearPassword(usuario.Id);
            repositorio_usuarios.AsociarUsuarioConMail(usuario, aspirante.Email);
            //mandarla por mail
            var titulo = "Bienvenido al SIGIRH";
            var cuerpo = "Nombre de Usuario: " + usuario.Alias + Environment.NewLine + "Password: " + clave;

            EnviarMail(aspirante.Email, titulo, cuerpo); 
        }


        public bool RecuperarUsuario(string criterio)
        {

            try
            {
                 var repo_personas = RepositorioDePersonas.NuevoRepositorioDePersonas(this.conexion);
                 var repo_usuarios = new RepositorioDeUsuarios(this.conexion, repo_personas);
                 var validador_datos = new Validador();
                var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
                if (criterio_deserializado["Mail"] != null)
                {

                    string mail = (string)((JValue)criterio_deserializado["Mail"]);
                    validador_datos.DeberiaSerMail(new string[] { "Mail" });

                    //hacer un validador de string o un object
                   // if (!validador_datos.EsValido(mail))
                   //     throw new ExcepcionDeValidacion("El tipo de dato no es correcto");

                    Usuario usuario_a_recuperar = repo_usuarios.RecuperarUsuario(mail);
   
                    EnviarMailDeRecupero(usuario_a_recuperar, mail);

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EnviarMailDeRecupero(Usuario usuario, string mail)
        {
            if (usuario.Habilitado)
            {
                var clave_nueva = repositorio_usuarios.ResetearPassword(usuario.Id);
                var  titulo = "Recupero de Datos de SIGIRH"; 
                var cuerpo = "Nombre de Usuario: " + usuario.Alias + Environment.NewLine + "Password: " + clave_nueva;

                EnviarMail(mail, titulo, cuerpo);

                
            }
        }

        private void EnviarMail(string mail, string titulo, string cuerpo)
        {
            var enviador = new EnviadorDeMails();
            MailAddress mail_re_recupero = new MailAddress(mail);
            enviador.EnviarMail(new NetworkCredential("no-reply@desarrollosocial.gov.ar", "1234"),
                    mail,
                   titulo,
                    cuerpo,
                    () => { },
                    () => { throw new Exception("No se pudo enviar un mail con la clave"); }
                );
        }
    }
}
