using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeFuncionalidadesDeUsuarios: IRepositorioDeFuncionalidadesDeUsuarios
    {
        protected IConexionBD conexion;
        protected IRepositorioDeFuncionalidades repositorioDeFuncionalidades;
        protected List<KeyValuePair<int, int>> funcionalidades_de_usuarios;

        private static RepositorioDeFuncionalidadesDeUsuarios _instancia;
        private static DateTime _fecha_creacion;

        private RepositorioDeFuncionalidadesDeUsuarios(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            this.conexion = conexion;
            repositorioDeFuncionalidades = repo_funcionalidades;
            funcionalidades_de_usuarios = ObtenerTodasLasFuncionalidadesDeUsuariosDesdeLaBase();
        }

        public List<KeyValuePair<int, int>> ObtenerTodasLasFuncionalidadesDeUsuariosDesdeLaBase()
        {
            return conexion.Ejecutar("dbo.MAU_GetFuncionalidadesDeUsuarios")
                .Rows.Select(row => new KeyValuePair<int, int>(row.GetInt("id_usuario"), row.GetInt("id_funcionalidad")))
                .ToList();
        }

        public static RepositorioDeFuncionalidadesDeUsuarios NuevoRepositorioDeFuncionalidadesDeUsuarios(IConexionBD conexion, IRepositorioDeFuncionalidades repo_funcionalidades)
        {
            if (_instancia == null || ExpiroTiempoDelRepositorio())
            {
                _instancia = new RepositorioDeFuncionalidadesDeUsuarios(conexion, repo_funcionalidades);
                _fecha_creacion = DateTime.Now;
            }
            return _instancia;
        }

        private static bool ExpiroTiempoDelRepositorio()
        {
            if (FechaExpiracion() < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private static DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(1);

        }

        public List<Funcionalidad> FuncionalidadesPara(Usuario usuario)
        {
            return this.FuncionalidadesPara(usuario.Id);
        }

        public List<Funcionalidad> FuncionalidadesPara(int id_usuario)
        {
            return funcionalidades_de_usuarios.FindAll(p => p.Key == id_usuario).Select(p => this.repositorioDeFuncionalidades.GetFuncionalidadPorId(p.Value)).ToList();
        }

        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad)
        {
            this.ConcederFuncionalidadA(usuario.Id, funcionalidad.Id);
        }

        public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_funcionalidad", id_funcionalidad);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_ConcederFuncionalidadA", parametros);
            funcionalidades_de_usuarios.Add(new KeyValuePair<int, int>(id_usuario, id_funcionalidad));
        }


        public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            parametros.Add("@id_funcionalidad", id_funcionalidad);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_DenegarFuncionalidadA", parametros);
            funcionalidades_de_usuarios.Remove(funcionalidades_de_usuarios.Find(f=> f.Key == id_usuario && f.Value==id_funcionalidad));
        }
    }
}
