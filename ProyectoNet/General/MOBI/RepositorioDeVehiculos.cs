using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using System.Linq;
using Extensiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.IEnumerable;

namespace General.Repositorios
{
    public class RepositorioDeVehiculos : RepositorioLazySingleton<Vehiculo>
    {
        private static RepositorioDeVehiculos _instancia;

        private RepositorioDeVehiculos(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeVehiculos Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeVehiculos(conexion);
            return _instancia;
        }

        public List<Vehiculo> All()
        {
            return this.Obtener();
        }

        public Vehiculo ObtenerVehiculoPorID(Vehiculo, unVehiculo)
        {
            var parametros = new List<Vehiculo>();
            parametros.Add("@Id_Bien", unVehiculo.NumeroVehiculo);

            var tablaDatos = this.conexion.Ejecutar("dbo.MOBI_GetVehiculosPorIdBien", parametros);

            return unVehiculo(tablaDatos);

        }

        protected override List<Vehiculo> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.MOBI_GetVehiculosPorIdBien");
            var vehiculos = new List<Vehiculo>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    vehiculos.Add(new Vehiculo{row.GetInt("NumeroVehiculo"), 
                                                row.GetString("Dominio"),
                                                row.GetString("Segmento"),
                                                row.GetString("Marca"),
                                                row.GetString("Modelo"),
                                                row.GetString("Motor"),
                                                row.GetString("Chasis"),
                                                row.GetInt("Anio"),
                                                row.GetInt("Observacion"),
                    });
            
            });

         
                };
            return vehiculos;
            }

            
        }

        
    }
