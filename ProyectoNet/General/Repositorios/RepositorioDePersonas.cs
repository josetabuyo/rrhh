using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;

using Extensiones;

namespace General.Repositorios
{
    public class RepositorioDePersonas : RepositorioLazy<List<Persona>>, IRepositorioDePersonas
    {
        public RepositorioDePersonas(IConexionBD conexion)
            :base(conexion)
        {
        }

        public List<Persona> TodasLasPersonas()
        {
            return cache.Ejecutar(ObtenerPersonasDesdeLaBase, this);
        }

        public List<Persona> BuscarPersonas(string criterio)
        {
            var palabras_busqueda = criterio.Split(' ').Select(p => p.ToUpper().Trim());

            return TodasLasPersonas().FindAll(persona => 
                palabras_busqueda.All(palabra =>
                        persona.Apellido.ToUpper().QuitarTildes().Contains(palabra.QuitarTildes()) ||
                        persona.Nombre.ToUpper().QuitarTildes().Contains(palabra.QuitarTildes()) ||
                        persona.Documento.ToString().Contains(palabra)||
                        persona.Legajo.Contains(palabra)
                    )
                );
        }


        public List<Persona> BuscarPersonasConLegajo(string criterio)
        {
            return this.BuscarPersonas(criterio).FindAll(p => p.Legajo.Trim() != "");
        }

        protected List<Persona> ObtenerPersonasDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_Get_Personas");
            return GetPersonasDeTablaDeDatos(tablaDatos);
        }

        public Persona GetPersonaPorId(int id_persona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_persona", id_persona);
            var tablaDatos = conexion.Ejecutar("dbo.WEB_Get_Personas", parametros);
            return GetPersonasDeTablaDeDatos(tablaDatos).First();
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
    }
}
