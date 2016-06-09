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
              
                /*var NumeroVehiculo = row.GetString("NumeroVehiculo", "Prueba NroVehiculo");
                var Dominio = row.GetString("Dominio", "Prueba Dominio");
                var Segmento = row.GetString("Segmento", "Prueba Segmento");
                var Marca = row.GetString("Marca", "Prueba Marca");
                var Modelo = row.GetString("Modelo", "Prueba Modelo");
                var Motor = row.GetString("Motor", "Prueba Motor");
                var Chasis = row.GetString("Chasis", "Prueba Chasis");
                var Anio = row.GetString("Anio", "Prueba Anio");
                var Observacion = row.GetString("Observacion", "Prueba Observacion");
                var Area = row.GetString("Area", "Prueba Area");
                var Apellido = row.GetString("Apellido", "Sin asignación");
                var Nombre = row.GetString("Nombre", "Sin asignación");*/


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
    }
}
