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

        public void GuardarCovid19(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, int idPersona, string fi1, string fh1, string n1, string fi2, string fh2, string n2, string fi3, string fh3, string n3, string fi4, string fh4, string n4, string fi5, string fh5, string n5, int idFormulario, string contenido,string fecha)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", idFormulario);
            parametros.Add("@idPersona", idPersona);
            parametros.Add("@fecha_generacion", fecha);
            parametros.Add("@Rta1_NO", v1);
            parametros.Add("@Rta1_SI", v2);
            parametros.Add("@Rta1a", v3);
            parametros.Add("@Rta1b", v4);
            parametros.Add("@Rta1c", v5);
            parametros.Add("@Rta1d", v6);
            parametros.Add("@Rta2NO", v7);
            parametros.Add("@Rta2SI", v8);
            parametros.Add("@Fecha_Desde_Tramo1", fi1);
            parametros.Add("@Fecha_Hasta_Tramo1", fh1);
            parametros.Add("@Pais_Tramo1", n1);
            parametros.Add("@Fecha_Desde_Tramo2", fi2);
            parametros.Add("@Fecha_Hasta_Tramo2", fh2);
            parametros.Add("@Pais_Tramo2", n2);
            parametros.Add("@Fecha_Desde_Tramo3", fi3);
            parametros.Add("@Fecha_Hasta_Tramo3", fh3);
            parametros.Add("@Pais_Tramo3", n3);
            parametros.Add("@Fecha_Desde_Tramo4", fi4);
            parametros.Add("@Fecha_Hasta_Tramo4", fh4);
            parametros.Add("@Pais_Tramo4", n4);
            parametros.Add("@Fecha_Desde_Tramo5", fi5);
            parametros.Add("@Fecha_Hasta_Tramo5", fh5);
            parametros.Add("@Pais_Tramo5", n5);
            parametros.Add("@bytes_file", contenido);

            try
            {
                this.conexion.Ejecutar("dbo.DDJJCOVID19_ADD_DDJJ", parametros);
            }
            catch (Exception e)
            {
                //
                var x ="v";
            }
            

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
