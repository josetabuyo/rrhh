using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using System.Linq;
using Extensiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace General.Repositorios
{
    public class RepositorioDeVehiculos
    {
        private IConexionBD conexion_bd;

        public RepositorioDeVehiculos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public Vehiculo ObtenerVehiculoPorID(string id_vehiculo)
        {
            if (id_vehiculo == null)
            {
                id_vehiculo = "1";
            }
            var parametros = new Dictionary<string, object>();
            
            
            parametros.Add("@Id_Bien", id_vehiculo);



            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GetVehiculosPorIdBien", parametros);

            var unVehiculo = new Vehiculo();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];


                unVehiculo.NumeroVehiculo = row.GetString("NumeroVehiculo");
                unVehiculo.Dominio = row.GetString("Dominio");
                unVehiculo.Segmento = row.GetString("Segmento");
                unVehiculo.Marca = row.GetString("Marca");
                unVehiculo.Modelo = row.GetString("Modelo");
                unVehiculo.Motor = row.GetString("Motor");
                unVehiculo.Chasis = row.GetString("Chasis");
                unVehiculo.Anio = row.GetString("Anio");
                unVehiculo.Observacion = row.GetString("Observacion");
                unVehiculo.Area = row.GetString("Area");
                unVehiculo.Apellido = row.GetString("Apellido");
                unVehiculo.Nombre = row.GetString("Nombre"); 
            };

            return unVehiculo;
        }

        public Vehiculo ObtenerVehiculoPorIDVerificacion(string id_verificacion)
        {
            if (id_verificacion == null)
            {
                id_verificacion = "1";
            }
            var parametros = new Dictionary<string, object>();


            parametros.Add("@Id_Verificacion", id_verificacion);



            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GetVehiculosPorIdTarjeton2", parametros);

            var unVehiculo = new Vehiculo();

            tablaDatos.Rows.ForEach(r => {

                switch (r.GetString("Atributo"))
                {
                    case "NumeroVehiculo": unVehiculo.NumeroVehiculo = r.GetString("ValorAtributo", ""); break;
                    case "Dominio": unVehiculo.Dominio = r.GetString("ValorAtributo", ""); break;
                    case "Segmento": unVehiculo.Segmento = r.GetString("ValorAtributo", ""); break;
                    case "Marca": unVehiculo.Marca = r.GetString("ValorAtributo", ""); break;
                    case "Modelo": unVehiculo.Modelo = r.GetString("ValorAtributo", ""); break;
                    case "Motor": unVehiculo.Motor = r.GetString("ValorAtributo", ""); break;
                    case "Chasis": unVehiculo.Chasis = r.GetString("ValorAtributo", ""); break;
                    case "Año": unVehiculo.Anio = r.GetString("ValorAtributo", ""); break;
                    case "Observacion": unVehiculo.Observacion = r.GetString("ValorAtributo", ""); break;
                    case "Id Imagen": unVehiculo.imagenes.Add(r.GetInt("ValorAtributo"));  break;
                }
                    unVehiculo.Area = r.GetString("Area", "");
                    unVehiculo.Apellido = r.GetString("Apellido", "");
                    unVehiculo.Nombre = r.GetString("Nombre", "");
            });

            return unVehiculo;
        }
    }
}
