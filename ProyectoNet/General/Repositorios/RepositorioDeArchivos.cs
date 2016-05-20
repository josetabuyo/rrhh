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

        public string GetArchivo(int id_archivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", id_archivo);
            var tabla_resultado = this.conexion.Ejecutar("dbo.FS_IniciarPedidoArchivo", parametros);
            if (tabla_resultado.Rows.Count == 0) throw new Exception("no existe el archivo buscado");
            if (tabla_resultado.Rows[0].GetObject("bytes_file") is DBNull)
            {
                int contador_repeticiones = 0;
                while (tabla_resultado.Rows[0].GetObject("bytes_file") is DBNull)
                {
                    System.Threading.Thread.Sleep(500);
                    tabla_resultado = this.conexion.Ejecutar("dbo.FS_ObtenerArchivoPedido", parametros);
                    contador_repeticiones++;
                    if (contador_repeticiones >= 10) throw new Exception("error al obtener el archivo con id=" + id_archivo);
                }
                return tabla_resultado.Rows[0].GetString("bytes_file");
            }
            else
            {
                return tabla_resultado.Rows[0].GetString("bytes_file");
            }            
        }
    }
}
