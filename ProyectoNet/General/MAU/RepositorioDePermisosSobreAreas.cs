using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General.MAU
{
    public class RepositorioDePermisosSobreAreas: IRepositorioDePermisosSobreAreas
    {
        protected IConexionBD conexion;

        public RepositorioDePermisosSobreAreas(IConexionBD conexion)
        {
            this.conexion = conexion;
        }

        List<Area> IRepositorioDePermisosSobreAreas.AreasAdministradasPor(Usuario usuario)
        {
            return AreasAdministradasPor(usuario.Id);
        }

        public List<Area> AreasAdministradasPor(int id_usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_usuario_administrador", id_usuario);
            var tablaDatos = conexion.Ejecutar("dbo.VIA_GetAreasCompletas", parametros);
            return RepositorioDeAreas.GetAreasDeTablaDeDatos(tablaDatos);
        }

        Area IRepositorioDePermisosSobreAreas.AsignarAreaAUnUsuario(Usuario usuario, Area area)
        {
            throw new NotImplementedException();
        }
    }
}
