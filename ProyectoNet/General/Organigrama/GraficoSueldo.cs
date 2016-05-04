using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class GraficoSueldo : Grafico
    {
        //public List<Resumen> tabla_resumen;
        //public List<Dotacion> tabla_detalle;


        public override void CrearDatos(List<RowDeDatos> list)
        {

            List<Dotacion> tabla = new List<Dotacion>();

            list.ForEach(row =>
            {
                Dotacion persona =
                       new Dotacion(
                           row.GetInt("id_persona", 0),
                           row.GetInt("legajo", 0),
                          row.GetInt("nrodocumento", 0),
                           row.GetString("apellido", "Sin Dato"),
                           row.GetString("nombre", "Sin Dato"),
                           row.GetSmallintAsInt("id_sexo", 0),
                          row.GetString("descrip_sexo", "Sin Dato"),
                           row.GetString("nivel", "Sin Dato"),
                           row.GetString("grado", "Sin Dato"),
                           row.GetInt("id_area", 0),
                           row.GetString("area", "Sin Dato"),
                           row.GetString("area_descrip_corta", "Sin Dato"),
                           row.GetString("area_descrip_media", "Sin Dato"),
                           row.GetSmallintAsInt("id_planta", -1),
                           row.GetString("planta", "Sin Dato"),
                           row.GetInt("IdEstudio", -1),
                           row.GetString("Nivel_Estudios", "Sin Dato"),
                           row.GetString("Titulo_Obtenido", "Sin Dato"),
                           row.GetDateTime("FechaNacimiento", DateTime.Today),
                           row.GetInt("IdSecretaria", -1),
                            row.GetInt("IdSubSecretaria", -1),
                            row.GetString("area_descrip_secretaria", "S/Nombre"),
                            row.GetString("area_descrip_subsecretaria", "S/Nombre"),
                            row.GetString("area_descrip_secretaria_corta", "S/Nombre"),
                            row.GetString("area_descrip_subsecretaria_corta", "S/Nombre"),
                            row.GetInt("Orden", 999999)
                    );

                    persona.SueldoAnio = row.GetSmallintAsInt("SueldoAnio", 0);
                    persona.SueldoMes = row.GetSmallintAsInt("SueldoMes", 0);
                    persona.SueldoBruto = row.GetFloat("SueldoBruto", 0);
                    persona.SueldoNeto = row.GetFloat("SueldoNeto", 0);
                    persona.ExtrasAnio = row.GetSmallintAsInt("XtrasAnio", 0);
                    persona.ExtrasMes = row.GetSmallintAsInt("XtrasMes", 0);
                    persona.ExtrasBruto = row.GetFloat("XtrasBruto", 0);
                    persona.ExtrasNeto = row.GetFloat("XtrasNeto", 0);
                    persona.SACAnio = row.GetInt("SACAnio", 0);
                    persona.SACMes = row.GetInt("SACMes", 0);
                    persona.SACBruto = row.GetFloat("SACBruto", 0);
                    persona.SACNeto = row.GetFloat("SACNeto", 0);
                    persona.HsSimples = row.GetSmallintAsInt("HsSimples", 0);
                    persona.Hs50 = row.GetSmallintAsInt("Hs50", 0);
                    persona.Hs100 = row.GetSmallintAsInt("Hs100", 0);
                    persona.HsTotalesSimples(persona.HsSimples, persona.Hs50, persona.Hs100);
                    persona.Comidas = row.GetSmallintAsInt("Comidas", 0);
                    persona.UnidadRetributiva = row.GetSmallintAsInt("UR", 0);
               
                tabla.Add(persona);
            });
            this.tabla_detalle = tabla;
        }

        

        /*private override Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }

        private override Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }
        private override Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total, int orden)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total), orden);
            return registro_resumen;
        }*/


        /*internal void GraficoPorAfiliacionGremial()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            int sin_datos = tabla_personas.Count;
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Sin Datos", sin_datos, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }*/

        /*internal void GraficoRangoEtareo(DateTime fecha)
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int de_18_a_25 = 0;
            int de_26_a_35 = 0;
            int de_36_a_45 = 0;
            int de_46_a_55 = 0;
            int de_56_a_60 = 0;
            int de_61_a_65 = 0;
            int mas_de_65 = 0;
            tabla_personas.ForEach(p =>
            {
                if (p.Edad(fecha) >= 18 && p.Edad(fecha) <= 25)
                {
                    de_18_a_25++;
                }
                else if (p.Edad(fecha) >= 26 && p.Edad(fecha) <= 35)
                {
                    de_26_a_35++;
                }
                else if (p.Edad(fecha) >= 36 && p.Edad(fecha) <= 45)
                {
                    de_36_a_45++;
                }
                else if (p.Edad(fecha) >= 46 && p.Edad(fecha) <= 55)
                {
                    de_46_a_55++;
                }
                else if (p.Edad(fecha) >= 56 && p.Edad(fecha) <= 60)
                {
                    de_56_a_60++;
                }
                else if (p.Edad(fecha) >= 61 && p.Edad(fecha) <= 65)
                {
                    de_61_a_65++;
                }
                else if (p.Edad(fecha) > 65)
                {
                    mas_de_65++;
                }
            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("18-25", de_18_a_25, total));
            tabla.Add(GenerarRegistroResumen("26-35", de_26_a_35, total));
            tabla.Add(GenerarRegistroResumen("36-45", de_36_a_45, total));
            tabla.Add(GenerarRegistroResumen("46-55", de_46_a_55, total));
            tabla.Add(GenerarRegistroResumen("56-60", de_56_a_60, total));
            tabla.Add(GenerarRegistroResumen("61-65", de_61_a_65, total));
            tabla.Add(GenerarRegistroResumen(">65", mas_de_65, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }*/

        /*public override bool ContienePersonas()
        {
            if (this.tabla_detalle == null)
            {
                return false;
            }
            return true;
        }*/

        public override void GraficoPorArea()
        {

            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();

            tabla_personas.ForEach(p =>
            {
                if (contador.Count > 0)
                {
                    if (contador.Exists(area => area.Id == p.IdArea))
                    {
                        contador.Find(area => area.Id == p.IdArea).Personas.Add(p);
                    }
                    else
                    {
                        Contador nueva_area = new Contador(p.IdArea, p.Area, p.AreaDescripCorta);
                        nueva_area.Personas.Add(p);
                        nueva_area.Orden = p.OrdenArea;
                        contador.Add(nueva_area);

                    }
                }
                else
                {
                    Contador nueva_area = new Contador(p.IdArea, p.Area, p.AreaDescripCorta);
                    nueva_area.Personas.Add(p);
                    nueva_area.Orden = p.OrdenArea;
                    contador.Add(nueva_area);
                }

            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumenSueldoTotal(contador));
            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumenSueldo(registro, total));
            });

            this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();
        }


        public override void GraficoPorSecretarias()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();

            tabla_personas.ForEach(p =>
            {

                if (contador.Count > 0)
                {
                    if (contador.Exists(area => area.Id == p.IdSecretaria))
                    {
                        contador.Find(area => area.Id == p.IdSecretaria).Personas.Add(p);
                    }
                    else
                    {
                        Contador nueva_area = new Contador(p.IdSecretaria, p.NombreSecretaria, p.NombreSecretariaCorta);
                        nueva_area.Personas.Add(p);
                        nueva_area.Orden = p.OrdenArea;
                        contador.Add(nueva_area);
                    }
                }
                else
                {
                    Contador nueva_area = new Contador(p.IdSecretaria, p.NombreSecretaria, p.NombreSecretariaCorta);
                    nueva_area.Personas.Add(p);
                    nueva_area.Orden = p.OrdenArea;
                    contador.Add(nueva_area);
                }
            });

            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumenSueldoTotal(contador));
            contador.ForEach(registro =>
            {

                tabla.Add(GenerarRegistroResumenSueldo(registro, total));
            });

            this.tabla_resumen = tabla;
            this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();

        }

        public override void GraficoPorSubSecretarias()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();
            var nombre = "";
            tabla_personas.ForEach(p =>
            {
                if (contador.Count > 0)
                {
                    if (contador.Exists(area => area.Id == p.IdSubSecretaria))
                    {
                        contador.Find(area => area.Id == p.IdSubSecretaria).Personas.Add(p);
                    }
                    else
                    {
                        if (!tabla_personas.Exists(area => area.IdSecretaria == p.IdSubSecretaria))
                        {
                            nombre = "|||||" + p.NombresubSecretaria;
                        }
                        else
                        {
                            nombre = p.NombresubSecretaria;
                        }
                        Contador nueva_area = new Contador(p.IdSubSecretaria, nombre, p.NombresubSecretariaCorta);
                        nueva_area.Personas.Add(p);
                        nueva_area.Orden = p.OrdenArea;
                        contador.Add(nueva_area);
                    }
                }
                else
                {
                    if (!tabla_personas.Exists(area => area.IdSecretaria == p.IdSubSecretaria))
                    {
                        nombre = "|||||" + p.NombresubSecretaria;
                    }
                    else
                    {
                        nombre = p.NombresubSecretaria;
                    }
                    Contador nueva_area = new Contador(p.IdSubSecretaria, nombre, p.NombresubSecretariaCorta);
                    nueva_area.Personas.Add(p);
                    nueva_area.Orden = p.OrdenArea;
                    contador.Add(nueva_area);
                }
            });

            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumenSueldoTotal(contador));

            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumenSueldo(registro, total));
            });

            this.tabla_resumen = tabla;
            this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();

        }

        private Resumen GenerarRegistroResumenSueldo(Contador registro, int total)
        {
            Resumen resumen = GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.Personas.Count, total, registro.Orden);
            resumen.SumatoriaSueldo = registro.Personas.Sum(p => p.SueldoBruto);
            resumen.SumatoriaExtras = registro.Personas.Sum(p => p.hsTotalesSimples);
            if (registro.Personas.Count > 0)
            {
                resumen.PrimedioSueldo = resumen.SumatoriaSueldo / (float)registro.Personas.Count;
            }
            else
            {
                resumen.PrimedioSueldo = 0;
            }

            var personas_con_extras = registro.Personas.FindAll(p => p.HsSimples != 0 || p.Hs100 != 0 || p.Hs50 != 0);
            if (personas_con_extras.Count != 0)
            {
                resumen.PrimedioExtras = resumen.SumatoriaExtras / (float)personas_con_extras.Count;
            }
            var sueldos_ordenados = registro.Personas.OrderBy(p => p.SueldoBruto).ToList();
            resumen.MedianaSueldo = sueldos_ordenados.Skip(registro.Personas.Count / 2).Take(1).ToList().First().SueldoBruto;
            var extras_ordenados = personas_con_extras.OrderBy(p => p.hsTotalesSimples).ToList();
            if (extras_ordenados.Count > 0)
            {
                resumen.MedianaExtras = extras_ordenados.Skip(extras_ordenados.Count / 2).Take(1).ToList().First().hsTotalesSimples;
            }
            else
            {
                resumen.MedianaExtras = 0;
            }

            return resumen;
        }


        private Resumen GenerarRegistroResumenSueldoTotal(List<Contador> tabla_personas)
        {
            List<Dotacion> dotacion_total = new List<Dotacion>();
            Contador contador_total = new Contador();
            tabla_personas.ForEach(personas => dotacion_total.AddRange(personas.Personas));
            contador_total.Personas = dotacion_total;
            contador_total.Id = 0;
            contador_total.Orden = 0;
            contador_total.Descripcion = "Total";
            return GenerarRegistroResumenSueldo(contador_total, contador_total.Personas.Count);
        }

        
    }
}
