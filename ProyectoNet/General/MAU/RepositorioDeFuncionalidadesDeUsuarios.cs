using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using Newtonsoft.Json.Linq;

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
            cache_por_usuario = new Dictionary<Usuario, List<Funcionalidad>>();
        }

        public static RepositorioDeFuncionalidadesDeUsuarios NuevoRepositorioDeFuncionalidadesDeUsuarios(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeFuncionalidadesDeUsuarios(conexion, repo_funcionalidades);
            return _instancia;
        }

        protected Dictionary<Usuario, List<Funcionalidad>> cache_por_usuario;

        public List<Funcionalidad> FuncionalidadesPara(Usuario usuario)
        {
            if (!cache_por_usuario.ContainsKey(usuario))
            {
                var funcionalidades = this.Obtener().FindAll(p => p.Key == usuario.Id)
                .Select(p => this.repositorioDeFuncionalidades.GetFuncionalidadPorId(p.Value))
                .Where(f => !f.NoPodriaUsarlaElUsuario(usuario))
                .ToList();
                if (funcionalidades.Any(f => f == null)) throw new Exception("El usuario tiene permisos para funcionalidades que no existen");
                //return funcionalidades;
                cache_por_usuario.Add(usuario, funcionalidades);
            }
            return cache_por_usuario[usuario];
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
            parametros.Add("@Id_usuario_logueado", id_usuario_logueado); 
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
            
            try
            {
                var perfiles = new List<MAU_Perfil>();
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario", id_usuario);
                var tablaDatos = conexion.Ejecutar("dbo.MAU_GET_PerfilesDeUnUsuario", parametros);


                tablaDatos.Rows.ForEach(row =>
                {
                    MAU_Perfil perfil;
                    perfil = new MAU_Perfil(row.GetInt("IdPerfil", 0), row.GetString("descripcionPerfil", ""));
                    Area area = new Area(row.GetInt("IdArea", 0), row.GetString("descripcion", "Sin Area"));
                    area.IncluyeDependencias = row.GetBoolean("incluyeDependencias", false) ? 1 : 0;
                    perfil.Areas.Add(area);
                    perfiles.Add(perfil);

                });

                return perfiles;

            }
            catch (Exception e)
            {
                throw;
            }

          
        }

        public List<Funcionalidad> GetFuncionalidadesActuales(int id_usuario)
        {

            try
            {
                var funcionalidades = new List<Funcionalidad>();
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario", id_usuario);
                var tablaDatos = conexion.Ejecutar("dbo.MAU_GET_FuncionalidadesDeUnUsuario", parametros);

            
                tablaDatos.Rows.ForEach(row =>
                {
                    Funcionalidad funcionalidad;              
                    funcionalidad = new Funcionalidad(row.GetInt("id_funcionalidad"), row.GetString("Nombre"), "", false, false, false);
                    Area area = new Area(row.GetInt("IdArea",0), row.GetString("descripcion", "Sin Area"));
                    area.IncluyeDependencias =  row.GetBoolean("incluyeDependencias",false) ? 1 : 0; 
                    funcionalidad.Areas.Add(area);
                    funcionalidades.Add(funcionalidad);
                
                });

                return funcionalidades;

            } catch (Exception e)
             {
                 throw;
             }

           
        }

        public string AsignarPerfilesAUsuario(List<int> perfiles, List<Area> areas, int idUsuario, int id_usuario_alta)
        {

            try
            {
                //traigo los perfiles actuales para verificar que ya no los tenga
                List<MAU_Perfil> perfilesActuales = this.GetPerfilesActuales(idUsuario);

                 //Si pusieron areas al perfil
                if (areas.Count > 0)
                {
                    
                    perfiles.ForEach(idPerfil => areas.ForEach(area =>
                    {
                        //Valido que no tenga el perfil ya
                        if (!perfilesActuales.Exists(p => p.Id == idPerfil))
                            {
                            var parametros = new Dictionary<string, object>();
                            parametros.Add("@id_area", area.Id);
                            parametros.Add("@id_usuario", idUsuario);
                            parametros.Add("@id_perfil", idPerfil);
                            parametros.Add("@incluye_dependencia", area.IncluyeDependencias);
                            parametros.Add("@id_usuario_alta", id_usuario_alta);
                            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarPerfilFuncionalidadAUsuario", parametros);
                            }

                    })
                        );
                }
                else //Si no tiene areas
                {
                    
                    perfiles.ForEach(idPerfil => 
                    {
                        //Valido que no tenga el perfil ya
                        if (!perfilesActuales.Exists(p => p.Id == idPerfil))
                        {
                            var parametros = new Dictionary<string, object>();
                            parametros.Add("@id_usuario", idUsuario);
                            parametros.Add("@id_perfil", idPerfil);
                            parametros.Add("@id_usuario_alta", id_usuario_alta);
                            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarPerfilFuncionalidadAUsuario", parametros);
                        }
                    });
                }
                

                return "ok";
            }
            catch (Exception e) {
                return e.Message;
            }  
        }

        public string AsignarFuncionalidadesAUsuario(List<int> funcionalidades, List<Area> areas, int idUsuario, int id_usuario_alta)
        {

            try
            {
                //traigo los perfiles actuales para verificar que ya no los tenga
                List<Funcionalidad> funcionalidadesActuales = this.GetFuncionalidadesActuales(idUsuario);

                 //Si pusieron areas a la funcionalidad
                if (areas.Count > 0)
                {
                    
                    funcionalidades.ForEach(idFuncionalidad => areas.ForEach(area =>
                    {
                        //Valido que no tenga el perfil ya
                        //if (!funcionalidadesActuales.Exists(f => f.Id == idFuncionalidad))
                        if (this.tieneMismaFuncionalidadEnMismaArea(funcionalidadesActuales, idFuncionalidad, area.Id))
                        {
                            var parametros = new Dictionary<string, object>();
                            parametros.Add("@id_area", area.Id);
                            parametros.Add("@id_usuario", idUsuario);
                            parametros.Add("@id_funcionalidad", idFuncionalidad);
                            parametros.Add("@incluye_dependencia", area.IncluyeDependencias);
                            parametros.Add("@id_usuario_alta", id_usuario_alta);
                            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarPerfilFuncionalidadAUsuario", parametros);
                        }
                    })
                        );

                }
                else //Si no tiene areas
                {
                    
                    funcionalidades.ForEach(idFuncionalidad =>
                    {
                        //Valido que no tenga el perfil ya
                        if (!funcionalidadesActuales.Exists(f => f.Id == idFuncionalidad))
                        {
                            var parametros = new Dictionary<string, object>();
                            parametros.Add("@id_usuario", idUsuario);
                            parametros.Add("@id_funcionalidad", idFuncionalidad);
                            parametros.Add("@id_usuario_alta", id_usuario_alta);
                            var tablaDatos = conexion.Ejecutar("dbo.MAU_AsignarPerfilFuncionalidadAUsuario", parametros);
                        }
                    });
                }

                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool tieneMismaFuncionalidadEnMismaArea(List<Funcionalidad> funcionalidadesActuales, int idFuncionalidad, int idArea)
        {
            var rto = true;
            funcionalidadesActuales.ForEach(funcionalidad => funcionalidad.Areas.ForEach(area =>
                {
                    if (funcionalidad.Id == idFuncionalidad && area.Id == idArea)
                    {
                        rto = false;
                    }
                }
                )
            );

            return rto;
        }

        public List<Funcionalidad> GetFuncionalidadesPerfilesAreas(int id_usuario)
        {

            try
            {
                var funcionalidades = new List<Funcionalidad>();
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario", id_usuario);
                var tablaDatos = conexion.Ejecutar("dbo.MAU_GET_FuncionalidadesPerfilesAreas", parametros);


                tablaDatos.Rows.ForEach(row =>
                {
                    Funcionalidad funcionalidad;
                    funcionalidad = new Funcionalidad(row.GetInt("IdFuncionalidad"), row.GetString("Nombre"), "", false, false, false);
                    Area area = new Area(row.GetInt("IdArea", 0), row.GetString("descripcion", "Sin Area"));
                    area.IncluyeDependencias = row.GetBoolean("incluyeDependencias", false) ? 1 : 0;
                    funcionalidad.Areas.Add(area);
                    funcionalidades.Add(funcionalidad);

                });

                List<Funcionalidad> funcionalidadesOrdenadas = funcionalidades.OrderBy(o => o.Id).ToList();

                return funcionalidadesOrdenadas;

            }
            catch (Exception e)
            {
                throw;
            }


        }

        public string DesAsignarPerfilDeUsuario(int idPerfil, int idArea, int idUsuario, int id_usuario_alta)
        {

            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario", idUsuario);
                parametros.Add("@id_perfil", idPerfil);
                parametros.Add("@id_usuario_alta", id_usuario_alta);
                if (idArea != 0)
                    parametros.Add("@id_area", idArea);

                var tablaDatos = conexion.Ejecutar("dbo.MAU_DesAsignarPerfilFuncionalidadAUsuario", parametros);
            
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DesAsignarFuncionalidadDeUsuario(int idFuncionalidad, int idArea, int idUsuario, int id_usuario_alta)
        {

            try
            {


                var parametros = new Dictionary<string, object>();
                parametros.Add("@id_usuario", idUsuario);
                parametros.Add("@id_funcionalidad", idFuncionalidad);
                parametros.Add("@id_usuario_alta", id_usuario_alta);
                if (idArea != 0)
                    parametros.Add("@id_area", idArea);

                var tablaDatos = conexion.Ejecutar("dbo.MAU_DesAsignarPerfilFuncionalidadAUsuario", parametros);

                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


    }
}
