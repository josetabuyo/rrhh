using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;

using Extensiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace General.Repositorios
{
    public class RepositorioDePersonas : RepositorioLazySingleton<Persona>, IRepositorioDePersonas
    {
        private static RepositorioDePersonas _instancia;

        private RepositorioDePersonas(IConexionBD conexion)
            :base(conexion, 1)
        {
        }

        public static RepositorioDePersonas NuevoRepositorioDePersonas(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDePersonas(conexion);
            return _instancia;
        }

        public List<Persona> TodasLasPersonas()
        {
            return this.Obtener();
        }


        public List<Persona> BuscarPersonas(string criterio)
        {
            try
            {
                var criterio_deserializado = (JObject) JsonConvert.DeserializeObject(criterio);
                bool filtrar_por_documento = false;
                int documento = -1;
                bool filtrar_por_tiene_legajo = false;
                bool con_legajo = false;

                if (criterio_deserializado["Documento"]!= null) {
                    filtrar_por_documento = true;
                    documento = (int)((JValue)criterio_deserializado["Documento"]);
                }

                if (criterio_deserializado["ConLegajo"] != null) {
                    filtrar_por_tiene_legajo = true;
                    con_legajo = (bool)((JValue)criterio_deserializado["ConLegajo"]);
                }

                return TodasLasPersonas().FindAll(persona =>
                {
                    var pasan_todas_las_condiciones = true;
                    if (filtrar_por_documento)
                    {
                        if (persona.Documento != documento) pasan_todas_las_condiciones = false;
                    }
                    if (filtrar_por_tiene_legajo)
                    {
                        if (con_legajo)
                        {
                            if (persona.Legajo.Trim() == "") pasan_todas_las_condiciones = false;
                        }
                    }
                    return pasan_todas_las_condiciones;
                });

            }
            catch (Exception e)
            {
                var palabras_busqueda = criterio.Split(' ').Select(p => p.ToUpper().Trim());
                return TodasLasPersonas().FindAll(persona =>
                    palabras_busqueda.All(palabra =>
                            persona.Apellido.ToUpper().QuitarTildes().Contains(palabra.QuitarTildes()) ||
                            persona.Nombre.ToUpper().QuitarTildes().Contains(palabra.QuitarTildes()) ||
                            persona.Documento.ToString().Contains(palabra) ||
                            persona.Legajo.Contains(palabra)
                        )
                    );
            }            
        }

        public bool RecuperarUsuario(string criterio)
        {
            try
            {
                var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
                if (criterio_deserializado["Mail"] != null)
                {

                    string mail = (string)((JValue)criterio_deserializado["Mail"]);
                }

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public List<Persona> BuscarPersonasConLegajo(string criterio)
        {
            return this.BuscarPersonas(criterio).FindAll(p => p.Legajo.Trim() != "");
        }

        public Persona GetPersonaPorId(int id_persona)
        {
            return TodasLasPersonas().Find(persona => persona.Id == id_persona);
            //var parametros = new Dictionary<string, object>();
            //parametros.Add("@id_persona", id_persona);
            //var tablaDatos = conexion.Ejecutar("dbo.WEB_Get_Personas", parametros);
            //return GetPersonasDeTablaDeDatos(tablaDatos).First();
        }

        private static List<Persona> GetPersonasDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            var personas = new List<Persona>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    var legajo = "";
                    if (!(row.GetObject("Legajo") is DBNull))
                    {
                        legajo = row.GetInt("Legajo").ToString();
                    }
                    personas.Add(new Persona
                    {
                        Id = row.GetInt("Id"),
                        Nombre = row.GetString("Nombre"),
                        Apellido = row.GetString("Apellido"),
                        Legajo = legajo,
                        Documento = row.GetInt("Nro_Documento")
                    });
                });
            }

            return personas;
        }

        protected override List<Persona> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_Get_Personas");
            return GetPersonasDeTablaDeDatos(tablaDatos);
        }

        public void GuardarPersona(Persona persona)
        {
            this.Guardar(persona);
        }

        protected override void GuardarEnLaBase(Persona persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@tipoDocumento", 1);
            parametros.Add("@documento", persona.Documento);
            parametros.Add("@nombre", persona.Nombre);
            parametros.Add("@apellido", persona.Apellido);
            persona.Id = Convert.ToInt32(conexion.EjecutarEscalar("dbo.MAU_CrearPersona", parametros));
        }

        protected override void QuitarDeLaBase(Persona objeto)
        {
            throw new NotImplementedException();
        }


        public TipoDePlanta GetTipoDePlantaActualDe(Persona unaPersona)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("[dbo].[Web_GetTipoDePlantaDePersona]");
            cn.AsignarParametro("@Documento", unaPersona.Documento);
            dr = cn.EjecutarConsulta();


            TipoDePlanta planta = null;
            //FC: antes solo devolvia el tipo de planta comun con el id que trae del sp
            if (dr.Read())
            {
                //planta = new TipoDePlanta {Id = dr.GetInt16(dr.GetOrdinal("idPlanta"))};
                if (dr.GetInt16(dr.GetOrdinal("idPlanta")) == 22)
                {
                    planta = new TipoDePlantaContratado();
                }
                else { 
                    planta = new TipoDePlantaGeneral(dr.GetInt16(dr.GetOrdinal("idPlanta")),"Planta Permanente");
                }
            }
            return planta;
        }
    }
}
