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

        public override void CrearDatos(List<RowDeDatos> list)
        {

            List<Dotacion> tabla = new List<Dotacion>();

            list.ForEach(row =>
            {
                Dotacion persona = crearPersonaDotacion(row);
                       
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
