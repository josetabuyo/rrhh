using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeArchivos
    {
        IConexionBD conexion;

        public RepositorioDeArchivos(IConexionBD una_conexion)
        {
            this.conexion = una_conexion; 
        }

        public int GuardarArchivo(string bytes_archivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@bytes", bytes_archivo);
            return int.Parse(this.conexion.EjecutarEscalar("dbo.FS_SubirArchivo", parametros).ToString());
        }

        internal string GetArchivo(int id_archivo)
        {
            
        }
    }
}
