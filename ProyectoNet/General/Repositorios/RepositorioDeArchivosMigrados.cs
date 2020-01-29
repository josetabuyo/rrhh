using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeArchivosMigrados
    {
        IConexionBD conexion;

        public RepositorioDeArchivosMigrados(IConexionBD una_conexion)
        {
            this.conexion = una_conexion; 
        }

       /* public int GuardarArchivo(string bytes_archivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@bytes", bytes_archivo);
            return int.Parse(this.conexion.EjecutarEscalar("dbo.FS_SubirArchivo", parametros).ToString());
        }*/

        public Boolean GetArchivoMigrado(string nombreArchivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Archivo", nombreArchivo);
            var tabla_resultado = this.conexion.Ejecutar("dbo.PLA_GET_Archivos_Importados", parametros);
            if (tabla_resultado.Rows.Count == 0) return false;
            else{
                return true;
            }            
        }

        public int GET_Recibos_Migrados_MaxLiq()
        {
            var parametros = new Dictionary<string, object>();
            return int.Parse(this.conexion.EjecutarEscalar("dbo.PLA_GET_Recibos_Migrados_MaxLiq", parametros).ToString());
        }

    }
}
