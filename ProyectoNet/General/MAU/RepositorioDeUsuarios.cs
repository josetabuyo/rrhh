using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDeUsuarios:IRepositorioDeUsuarios
    {
        private IConexionBD conexion;

        public RepositorioDeUsuarios(IConexionBD conexion)
        {
            this.conexion = conexion;
        }

        Usuario IRepositorioDeUsuarios.GetUsuarioPorAlias(string alias)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@alias", alias);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetUsuarioPorAlias", parametros);

            if (tablaDatos.Rows.Count == 0) return new UsuarioNulo();
            if (tablaDatos.Rows.Count > 1) throw new Exception("hay mas de un usuario con el mismo alias: " + alias);
            var row = tablaDatos.Rows.First();
            return new Usuario(row.GetSmallintAsInt("Id"), row.GetString("Alias"), row.GetString("Clave_Encriptada"));                                    
        }
    }
}
