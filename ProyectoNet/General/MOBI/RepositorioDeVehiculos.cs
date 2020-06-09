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

        public Vehiculo ObtenerVehiculoPorID(int id_vehiculo)
        {
            if (id_vehiculo == null)
            {
                id_vehiculo = 0;
            }
            var parametros = new Dictionary<string, object>();
            
            parametros.Add("@IdBien", id_vehiculo);

            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GET_Vehiculos_Por_IdBien", parametros);

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

                unVehiculo.Conductor = new Persona();
                if (row.GetString("Nombre", String.Empty) == String.Empty)
                {
                    unVehiculo.Conductor.Nombre = "";
                    unVehiculo.Conductor.Apellido = "";
                    unVehiculo.Conductor.Documento = 0;
                }
                else
                {
                    unVehiculo.Conductor.Nombre = row.GetString("Nombre");
                    unVehiculo.Conductor.Apellido = row.GetString("Apellido");
                    unVehiculo.Conductor.Documento = row.GetInt("NroDocumento");
                }
                
            };

            return unVehiculo;
        }

        public Vehiculo ObtenerVehiculoPorCodigoWeb(string id_verificacion)
        {

            if (id_verificacion == null)
            {
                id_verificacion = "0";
            }
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Cod_Web", id_verificacion);

            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GetVehiculosPorCodigoWeb", parametros);
            
            var unVehiculo = new Vehiculo();

            unVehiculo.Conductor = new Persona();

            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];

                unVehiculo.NumeroVehiculo = row.GetString("NumeroVehiculo", "");
                unVehiculo.Dominio = row.GetString("Dominio", "-");
                unVehiculo.Segmento = row.GetString("Segmento", "");
                unVehiculo.Marca = row.GetString("Marca", "");
                unVehiculo.Modelo = row.GetString("Modelo", "");
                unVehiculo.Motor = row.GetString("Motor", "");
                unVehiculo.Chasis = row.GetString("Chasis", "");
                unVehiculo.Anio = row.GetString("Anio", "");
                unVehiculo.Observacion = row.GetString("Observacion", "");
                unVehiculo.Area = row.GetString("Area", "");
                //Imagenes del vehiculo
                tablaDatos.Rows.ForEach(r =>
                {
                    if (r.GetObject("id_imagen") is DBNull) return;
                    unVehiculo.imagenes.Add(r.GetInt("id_imagen"));
                unVehiculo.Conductor.Id = row.GetInt("Persona");
                
                //Si no tiene conductor asignado.
                if (unVehiculo.Conductor.Id != -1)
                {
                    unVehiculo.Conductor.Apellido = row.GetString("Apellido", "Sin Asignación");
                    unVehiculo.Conductor.Nombre = row.GetString("Nombre", "Sin Asignación");
                    unVehiculo.Conductor.Documento = row.GetInt("NroDocumento");
                    unVehiculo.Conductor.IdImagen = row.GetInt("Id_Imagen_Conductor");
                };

                });
            };

            return unVehiculo;
        }

        //solo obtengo los datos propios del vehiculo y no los relacionados con el,como conductor, area, etc.
        public Vehiculo ObtenerDatosVehiculoPorID(int id_vehiculo)
        {
            /*if (id_vehiculo == null)
            {
                id_vehiculo = 0;
            }*/
            var parametros = new Dictionary<string, object>();

            parametros.Add("@IdBien", id_vehiculo);

            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GET_Vehiculo_Por_IdBien", parametros);

            var unVehiculo = new Vehiculo();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];

                unVehiculo.NumeroVehiculo = row.GetString("NumeroVehiculo");
                unVehiculo.Dominio = row.GetString("Dominio");
                unVehiculo.Segmento = row.GetString("Segmento","");
                unVehiculo.Marca = row.GetString("Marca");
                unVehiculo.Modelo = row.GetString("Modelo");
                unVehiculo.Motor = row.GetString("Motor");
                unVehiculo.Chasis = row.GetString("Chasis");
                unVehiculo.Anio = row.GetString("Anio");
                unVehiculo.Observacion = row.GetString("Observacion");
                /*unVehiculo.Area = row.GetString("Area");

                unVehiculo.Conductor = new Persona();
                if (row.GetString("Nombre", String.Empty) == String.Empty)
                {
                    unVehiculo.Conductor.Nombre = "";
                    unVehiculo.Conductor.Apellido = "";
                    unVehiculo.Conductor.Documento = 0;
                }
                else
                {
                    unVehiculo.Conductor.Nombre = row.GetString("Nombre");
                    unVehiculo.Conductor.Apellido = row.GetString("Apellido");
                    unVehiculo.Conductor.Documento = row.GetInt("NroDocumento");
                }*/

            };

            return unVehiculo;
        }

        public int ObtenerIdVehiculoxDominio(string patente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@patente", patente);
            //retorna el id del objeto o un null si no lo encuentra
            var r = this.conexion_bd.EjecutarEscalar("dbo.MOBI_GetIdVehiculoxPatente", parametros);
            if (r is null) {
                return -1;
            } else return int.Parse(r.ToString());
              
            //return int.Parse(this.conexion_bd.EjecutarEscalar("dbo.MOBI_GetIdVehiculoxPatente", parametros).ToString());
            
        }

        public int AltaVehiculo(string dominio, string segmento, string marca, string modelo, string motor, string chasis, string anio, int usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Dominio", dominio);
            parametros.Add("@Segmento", segmento);
            parametros.Add("@Marca", marca);
            parametros.Add("@Modelo", modelo);
            parametros.Add("@Motor", motor);
            parametros.Add("@Chasis", chasis);
            parametros.Add("@Anio", anio);
            parametros.Add("@IdUser", usuario);

            return int.Parse(this.conexion_bd.EjecutarEscalar("dbo.MOBI_ADD_Vehiculo_NEW", parametros).ToString());


        }


    }
}
