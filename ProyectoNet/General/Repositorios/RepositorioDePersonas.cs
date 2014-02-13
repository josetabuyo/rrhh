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
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDePersonas(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            this.cache = new CacheNoCargada<List<Persona>>();
        }

        public List<Persona> GetPersonas()
        {
            return cache.Ejecutar(ObtenerPersonasDesdeLaBase, this);
        }

        public List<Persona> BuscarPersonas(string criterio)
        {
            var palabras_busqueda = criterio.Split(' ').Select(p => p.ToUpper().Trim());

            return GetPersonas().FindAll(persona => 
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

        public List<Persona> ObtenerPersonasDesdeLaBase()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.WEB_Get_Personas");
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
