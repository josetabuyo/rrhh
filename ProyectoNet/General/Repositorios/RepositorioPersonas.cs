using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using General;
using General.Repositorios;

namespace General
{
    public class RepositorioPersonas
    {
        #region IRepositorioPersonas Members

        public static List<Persona> personas { get; set; }

        public List<Persona> GetPersonasDelArea(Area unArea, int imprimeplanillafirma)
        {
            SqlDataReader dr;
            Inasistencia InasistenciaActual;
            PaseDeArea PasePendiente;

            ConexionDB cn = new ConexionDB("dbo.Web_GetAgentesDelArea");
            cn.AsignarParametro("@idArea", unArea.Id);
            cn.AsignarParametro("@imprimeplanillafirma", imprimeplanillafirma); 
            unArea.Personas = new List<Persona>();
            dr = cn.EjecutarConsulta();

            Persona persona;
            while (dr.Read())
            {
                InasistenciaActual = null;
                PasePendiente = null;

                if (dr.GetValue(dr.GetOrdinal("nro_articulo")) != DBNull.Value)
                {
                    InasistenciaActual = new Inasistencia { Descripcion = dr.GetString(dr.GetOrdinal("nro_articulo")) + dr.GetString(dr.GetOrdinal("concepto")), Aprobada = dr.GetInt32(dr.GetOrdinal("aprobada")) == 1 };
                    if (dr.GetValue(dr.GetOrdinal("desde")) != DBNull.Value)
                        InasistenciaActual.Desde = dr.GetDateTime(dr.GetOrdinal("desde"));
                    if (dr.GetValue(dr.GetOrdinal("hasta")) != DBNull.Value)
                        InasistenciaActual.Hasta = dr.GetDateTime(dr.GetOrdinal("hasta"));
                }   
                
                if (dr.GetValue(dr.GetOrdinal("idPasePendiente")) != DBNull.Value)
                    PasePendiente = new PaseDeArea { Id = dr.GetInt32(dr.GetOrdinal("idPasePendiente")) };

                
                persona = new Persona
                              {
                                  Documento = dr.GetInt32(dr.GetOrdinal("nro_documento")),
                                  Es1184 = dr.GetInt32(dr.GetOrdinal("Es1184")) == 1,
                                  Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                                  Apellido = dr.GetString(dr.GetOrdinal("apellido")),
                                  Legajo = dr.GetValue(dr.GetOrdinal("legajo")).ToString(),
                                  InasistenciaActual = InasistenciaActual,
                                  PasePendiente = PasePendiente,
                                  Nivel = dr.GetValue(dr.GetOrdinal("nivel")).ToString(),
                                  Grado = dr.GetValue(dr.GetOrdinal("grado")).ToString(),
                                  Telefono = dr.GetValue(dr.GetOrdinal("telefono")).ToString(),
                                  Cuit = dr.GetValue(dr.GetOrdinal("cuit")).ToString(),
                                  Id = dr.GetInt32(dr.GetOrdinal("idpersona")),
                                  Area = new Area() {Id = dr.GetInt32(dr.GetOrdinal("id_area"))},
                                  Categoria = ObtenerCategoria(dr),
                                  
                                   
                                  //Area = unArea,
                                  TipoDePlanta = new TipoDePlanta
                                                     {
                                                         Descripcion = dr.GetValue(dr.GetOrdinal("planta")).ToString()
                                                     }
                              };
                unArea.Personas.Add(persona);
            }
            cn.Desconestar();
            return unArea.Personas;
        }

        private string ObtenerCategoria(SqlDataReader dr)
        {
            if (dr.GetValue(dr.GetOrdinal("Grado")).ToString() == "-")
            {
                return dr.GetValue(dr.GetOrdinal("Nivel")).ToString() + '-' + dr.GetValue(dr.GetOrdinal("Grado")).ToString() + '#' + dr.GetString(dr.GetOrdinal("mod_contratacion"));
            }
            
            return dr.GetValue(dr.GetOrdinal("Nivel")).ToString() + '-' + int.Parse(dr.GetValue(dr.GetOrdinal("Grado")).ToString()).ToString("D2") + '#' + dr.GetString(dr.GetOrdinal("mod_contratacion"));
        }




        public List<Persona> GetPersonasDelAreaACargo(Area unArea)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.Web_GetAgentesDelAreaACargo");
            cn.AsignarParametro("@idArea", unArea.Id);
            unArea.Personas = new List<Persona>();
            dr = cn.EjecutarConsulta();

            Persona persona;
            while (dr.Read())
            {
                persona = new Persona
                {
                    Documento = dr.GetInt32(dr.GetOrdinal("nro_documento")),
                    Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                    Apellido = dr.GetString(dr.GetOrdinal("apellido")),
                    Legajo = dr.GetValue(dr.GetOrdinal("legajo")).ToString(),
                    Cuit = dr.GetValue(dr.GetOrdinal("cuit")).ToString()
                };
                unArea.Personas.Add(persona);
            }
            cn.Desconestar();
            return unArea.Personas;
        }


        public Area ArmarArea(SqlDataReader fila)
        {
            return new Area((int)fila.GetValue(fila.GetOrdinal("idAreaDependencia")), fila.GetString(fila.GetOrdinal("dependencia")).ToString());
        }

        public void EliminarInasistenciaActual(Persona unaPersona)
        {
            this.EliminarInasistenciaALaFecha(unaPersona, DateTime.Today);
        }

        public void EliminarInasistenciaALaFecha(Persona unaPersona, DateTime fecha)
        {
            ConexionDB cn = new ConexionDB("dbo.[Web_EliminarInasistenciaALaFecha]");
            cn.AsignarParametro("@nroDocumento", unaPersona.Documento);
            cn.AsignarParametro("@fecha", fecha.ToShortDateString());
            cn.EjecutarSinResultado();
            cn.Desconestar();
        }


        public List<Persona> GetPersonasDelAreaParaDDJJ104(int mes, int anio, Area unArea, int complementaria)
        {
            SqlDataReader dr;
            //Inasistencia InasistenciaActual;
            //PaseDeArea PasePendiente;

            ConexionDB cn = new ConexionDB("dbo.PLA_GET_Personas_Del_Area_Para_DDJJ104");
            cn.AsignarParametro("@idArea", unArea.Id);
            cn.AsignarParametro("@mes", mes);
            cn.AsignarParametro("@anio", anio);
            cn.AsignarParametro("@complementaria", complementaria); 
            

            unArea.Personas = new List<Persona>();
            dr = cn.EjecutarConsulta();

            Persona persona;
            while (dr.Read())
            {
                //InasistenciaActual = null;
                //PasePendiente = null;
                //if (dr.GetValue(dr.GetOrdinal("nro_articulo")) != DBNull.Value)
                //{
                //    InasistenciaActual = new Inasistencia { Descripcion = dr.GetString(dr.GetOrdinal("nro_articulo")) + dr.GetString(dr.GetOrdinal("concepto")), Aprobada = dr.GetInt32(dr.GetOrdinal("aprobada")) == 1 };
                //    if (dr.GetValue(dr.GetOrdinal("desde")) != DBNull.Value)
                //        InasistenciaActual.Desde = dr.GetDateTime(dr.GetOrdinal("desde"));
                //    if (dr.GetValue(dr.GetOrdinal("hasta")) != DBNull.Value)
                //        InasistenciaActual.Hasta = dr.GetDateTime(dr.GetOrdinal("hasta"));
                //}

                //if (dr.GetValue(dr.GetOrdinal("idPasePendiente")) != DBNull.Value)
                //    PasePendiente = new PaseDeArea { Id = dr.GetInt32(dr.GetOrdinal("idPasePendiente")) };


                persona = new Persona
                {
                    Documento = dr.GetInt32(dr.GetOrdinal("nro_documento")),
                    //Es1184 = dr.GetInt32(dr.GetOrdinal("Es1184")) == 1,
                    Nombre = dr.GetString(dr.GetOrdinal("nombre")),
                    Apellido = dr.GetString(dr.GetOrdinal("apellido")),
                    Legajo = dr.GetValue(dr.GetOrdinal("legajo")).ToString(),
                    //InasistenciaActual = InasistenciaActual,
                    //PasePendiente = PasePendiente,
                    Nivel = dr.GetValue(dr.GetOrdinal("nivel")).ToString(),
                    Grado = dr.GetValue(dr.GetOrdinal("grado")).ToString(),
                    //Telefono = dr.GetValue(dr.GetOrdinal("telefono")).ToString(),
                    Cuit = dr.GetValue(dr.GetOrdinal("cuit")).ToString(),
                    Id = dr.GetInt32(dr.GetOrdinal("idpersona")),
                    Area = new Area() { Id = dr.GetInt32(dr.GetOrdinal("id_area")) },
                    Categoria = ObtenerCategoria(dr),

                    Esta_Cargada = dr.GetInt32(dr.GetOrdinal("esta_cargado")),

                    //Area = unArea,
                    TipoDePlanta = new TipoDePlanta
                    {
                        Descripcion = dr.GetValue(dr.GetOrdinal("planta")).ToString()
                    },

                    EstaCertificadoEnLaDDJJ = (dr.GetValue(dr.GetOrdinal("Certificado")).ToString() == "S" ? true : false),
                    CertificaHoraDesdeDDJJ = dr.GetValue(dr.GetOrdinal("Hora_Desde")).ToString(),
                    CertificaHoraHastaDDJJ = dr.GetValue(dr.GetOrdinal("Hora_Hasta")).ToString(),

                };
                unArea.Personas.Add(persona);
            }
            cn.Desconestar();
            return unArea.Personas;
        }



        public List<Persona> GetPersonas()
        {
            Persona persona_fer = new Persona();
            persona_fer.Nombre = "Fernando";
            persona_fer.Apellido = "Caino";
            persona_fer.Documento = 31046911;
            persona_fer.Area = new Area(1, "Area de Faby");
            persona_fer.Id = 1;

            Persona persona_agus = new Persona();
            persona_agus.Nombre = "Belen";
            persona_agus.Apellido = "Cevey";
            persona_agus.Documento = 28753914;
            persona_agus.Area = new Area(1, "Area de Faby");
            persona_agus.Id = 2;

            Persona persona_jor = new Persona();
            persona_jor.Nombre = "Jorge";
            persona_jor.Apellido = "Castillo";
            persona_jor.Documento = 123456789;
            persona_jor.Area = new Area(1, "Area de Faby");
            persona_jor.Id = 3;

            Persona persona_zambri = new Persona();
            persona_zambri.Nombre = "Ariel";
            persona_zambri.Apellido = "Zambrano";
            persona_zambri.Documento = 987654321;
            persona_zambri.Area = new Area(1, "Area de Faby");
            persona_zambri.Id = 4;

             if (personas == null)
                {
                    personas = new List<Persona>() { persona_fer, persona_agus, persona_jor, persona_zambri };
                }

            return personas;
  
        }

        #endregion
    }
}
