using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeCovid19
    {
        IConexionBD conexion;

        public RepositorioDeCovid19(IConexionBD una_conexion)
        {
            this.conexion = una_conexion; 
        }

        /*****/
        public int GetMaxIdCovid()
        {
            /*var parametros = new Dictionary<string, object>();
            parametros.Add("@bytes", bytes_archivo);*/
            var r = int.Parse(this.conexion.EjecutarEscalar("dbo.DDJJCOVID19_GET_NuevoId").ToString());
            return r;
        }

       /* public string GetArchivo(int id_archivo)
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
        }*/

        public string GetArchivoAsync(int id_archivo)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idArchivo", id_archivo);
            var tabla_resultado = this.conexion.Ejecutar("dbo.FS_ObtenerArchivoFirmado", parametros);
            if (tabla_resultado.Rows.Count == 0) throw new Exception("no existe el archivo buscado");

            return tabla_resultado.Rows[0].GetString("bytes_file", "no existe los datos del archivo buscado");
        }
    }
}
