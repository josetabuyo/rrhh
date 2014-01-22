using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeFuncionalidades:IRepositorioDeFuncionalidades
    {
        protected IConexionBD conexion;

        public RepositorioDeFuncionalidades(IConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public List<Funcionalidad> TodasLasFuncionalidades()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetFuncionalidades");
            return GetFuncionalidadesDeTablaDeDatos(tablaDatos);
        }

        public List<Funcionalidad> FuncionalidadesPara(Usuario usuario)
        {
            return this.FuncionalidadesPara(usuario.Id);
        }

        public List<Funcionalidad> FuncionalidadesPara(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario", id_usuario);
            var tablaDatos = conexion.Ejecutar("dbo.MAU_GetFuncionalidades", parametros);

            return GetFuncionalidadesDeTablaDeDatos(tablaDatos);
        }

        private static List<Funcionalidad> GetFuncionalidadesDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            var funcionalidades = new List<Funcionalidad>();
            tablaDatos.Rows.ForEach(row =>
            {
                var func = new Funcionalidad(row.GetInt("Id"), row.GetString("Nombre"));
                funcionalidades.Add(func);
            });
            return funcionalidades;
        }

        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad)
        {
            throw new NotImplementedException();
        }
    }
}
