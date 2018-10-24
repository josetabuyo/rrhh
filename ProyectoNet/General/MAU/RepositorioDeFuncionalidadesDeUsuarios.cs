using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeFuncionalidadesDeUsuarios : RepositorioLazySingleton<KeyValuePair<int, int>>, IRepositorioDeFuncionalidadesDeUsuarios
    {
        protected IRepositorioDeFuncionalidades repositorioDeFuncionalidades;

        private static RepositorioDeFuncionalidadesDeUsuarios _instancia;
       

        private RepositorioDeFuncionalidadesDeUsuarios(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
            :base(conexion, 10)
        {
            repositorioDeFuncionalidades = repo_funcionalidades;

        }

        public static RepositorioDeFuncionalidadesDeUsuarios NuevoRepositorioDeFuncionalidadesDeUsuarios(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeFuncionalidadesDeUsuarios(conexion, repo_funcionalidades);
            return _instancia;
        }

        public List<Funcionalidad> FuncionalidadesPara(Usuario usuario)
        {
            var funcionalidades = this.Obtener().FindAll(p => p.Key == usuario.Id)
            .Select(p => this.repositorioDeFuncionalidades.GetFuncionalidadPorId(p.Value))
            .Where(f => !f.NoPodriaUsarlaElUsuario(usuario))
            .ToList();
            if (funcionalidades.Any(f => f == null)) throw new Exception("El usuario tiene permisos para funcionalidades que no existen");
            return funcionalidades;   
        }

        public List<Funcionalidad> FuncionalidadesOtorgadasA(Usuario usuario)
        {
            var funcionalidades = this.Obtener().FindAll(p => p.Key == usuario.Id)
            .Select(p => this.repositorioDeFuncionalidades.GetFuncionalidadPorId(p.Value))
            .ToList();
            if (funcionalidades.Any(f => f == null)) throw new Exception("El usuario tiene permisos para funcionalidades que no existen");
            return funcionalidades;   
        }

        public List<Usuario> UsuariosConLaFuncionalidad(int id_funcionalidad) {
            
            RepositorioDeUsuarios repositorioDeUsuarios = new RepositorioDeUsuarios(conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(conexion));
            return this.Obtener().FindAll(p => p.Value == id_funcionalidad).Select(p => repositorioDeUsuarios.GetUsuarioPorId(p.Key)).ToList(); 
        }


        //public List<Funcionalidad> FuncionalidadesPara(int id_usuario)
        //{
        //    var funcionalidades = this.Obtener().FindAll(p => p.Key == id_usuario)
        //        .Select(p => this.repositorioDeFuncionalidades.GetFuncionalidadPorId(p.Value))
        //        .ToList();
        //    if (funcionalidades.Any(f => f == null)) throw new Exception("El usuario tiene permisos para funcionalidades que no existen");
        //    return funcionalidades;           
        //}

        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad, int id_usuario_logueado)
        {
            this.ConcederFuncionalidadA(usuario.Id, funcionalidad.Id, id_usuario_logueado);
        }

        public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado)
        {
            this.Guardar(new KeyValuePair<int, int>(id_usuario, id_funcionalidad), id_usuario_logueado);
        }

        public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado)
        {
            this.Quitar(new KeyValuePair<int, int>(id_usuario, id_funcionalidad), id_usuario_logueado);
        }

        protected override List<KeyValuePair<int, int>> ObtenerDesdeLaBase()
        {
            return conexion.Ejecutar("dbo.MAU_GetFuncionalidadesDeUsuarios")
                .Rows.Select(row => new KeyValuePair<int, int>(row.GetInt("id_usuario"), row.GetInt("id_funcionalidad")))
                .ToList();
        }

        protected override void GuardarEnLaBase(KeyValuePair<int, int> objeto, int id_usuario_logueado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", objeto.Key);
            parametros.Add("@id_funcionalidad", objeto.Value);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_ConcederFuncionalidadA", parametros);
        }

        protected override void QuitarDeLaBase(KeyValuePair<int, int> objeto, int id_usuario_logueado)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", objeto.Key);
            parametros.Add("@id_funcionalidad", objeto.Value);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_DenegarFuncionalidadA", parametros);
        }

        public void Refresh()
        {
            objetos = ObtenerDesdeLaBase();
        }


        public void ConcederBasicas(Usuario usuario)
        {
            this.repositorioDeFuncionalidades.TodasLasFuncionalidades().ForEach(f =>
            {
                if (!f.basica) return;
                if (f.SoloParaEmpleados && usuario.Owner.Legajo == null) return;
                if (f.SoloParaVerificados && !usuario.Verificado) return;

                this.ConcederFuncionalidadA(usuario.Id, f.Id, usuario.Id);
            });
        }

        public List<MAU_Perfil> GetPerfilesActuales(int id_usuario)
        {
            var perfiles = new List<MAU_Perfil>();

            MAU_Perfil unPerfil = new MAU_Perfil(1, "Responsable Control Asistencia");
            MAU_Perfil unPerfil1 = new MAU_Perfil(1, "Responsable Control Asistencia");
            MAU_Perfil unPerfil2 = new MAU_Perfil(2, "Reportes Dotacion Nivel 1");
            MAU_Perfil unPerfil3 = new MAU_Perfil(3, "Administrador de Medialunas");

            Area area1 = new Area(1, "Direccion General de Recursos Humanos");
            area1.IncluyeDependencias = 1;
            Area area2 = new Area(2, "Centro de Referencia Mendoza");
            area2.IncluyeDependencias = 0;
            Area area3 = new Area(3, "Programa Alimentario Mendoza");
            area3.IncluyeDependencias = 1;

            unPerfil.Areas.Add(area1);
            unPerfil1.Areas.Add(area2);
            unPerfil.Areas.Add(area3);
            unPerfil.Areas.Add(area2);

            unPerfil2.Areas.Add(area1);
            unPerfil3.Areas.Add(area3);

            perfiles.Add(unPerfil);
            perfiles.Add(unPerfil1);
            perfiles.Add(unPerfil2);
            perfiles.Add(unPerfil3);

            /*
           
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetPerfiles");
             * 
             * var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_usuario", id_usuario);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GET_FuncionalidadesPerfilesAreas", parametros);

            
            tablaDatos.Rows.ForEach(row =>
            {
                Perfil perfil;
                try
                {
                    perfil = new Perfil(row.GetInt("Id"), row.GetString("Nombre"));

                    perfiles.Add(perfil);
                }
                catch (Exception)
                {
                    throw;
                }
            });*/


            return perfiles;

            /*RepositorioDeUsuarios repositorioDeUsuarios = new RepositorioDeUsuarios(conexion, RepositorioDePersonas.NuevoRepositorioDePersonas(conexion));
            return this.Obtener().FindAll(p => p.Value == id_funcionalidad).Select(p => repositorioDeUsuarios.GetUsuarioPorId(p.Key)).ToList();*/
        }
    }
}
