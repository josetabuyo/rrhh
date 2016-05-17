using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class GraficoRangoEtario : Grafico
    {
        //public override List<Resumen> tabla_resumen;
        //public override List<Dotacion> tabla_detalle;

        public override void CrearDatos(List<RowDeDatos> list)
        {
            throw new Exception();
        }

        public void CrearDatos(List<RowDeDatos> list, DateTime fecha_reporte)
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
                persona.Edad(fecha_reporte);


                tabla.Add(persona);
            });
            this.tabla_detalle = tabla;
        }


        public void GraficoPorRangoEtario(DateTime fecha)
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

        }


        public override void GraficoPorArea()
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
            int de_18_a_25_f = 0;
            int de_26_a_35_f = 0;
            int de_36_a_45_f = 0;
            int de_46_a_55_f = 0;
            int de_56_a_60_f = 0;
            int de_61_a_65_f = 0;
            int mas_de_65_f = 0;
            int de_18_a_25_m = 0;
            int de_26_a_35_m = 0;
            int de_36_a_45_m = 0;
            int de_46_a_55_m = 0;
            int de_56_a_60_m = 0;
            int de_61_a_65_m = 0;
            int mas_de_65_m = 0;

            tabla_personas.ForEach(p =>
            {
                if (p.EdadPersona >= 18 && p.EdadPersona <= 25)
                {
                    de_18_a_25++;
                    if (p.IdSexo == 1)
                    {
                        de_18_a_25_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_18_a_25_f++;
                    }
                }
                else if (p.EdadPersona >= 26 && p.EdadPersona <= 35)
                {
                    de_26_a_35++;
                    if (p.IdSexo == 1)
                    {
                        de_26_a_35_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_26_a_35_f++;
                    }
                }
                else if (p.EdadPersona >= 36 && p.EdadPersona <= 45)
                {
                    de_36_a_45++;
                    if (p.IdSexo == 1)
                    {
                        de_36_a_45_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_36_a_45_f++;
                    }
                }
                else if (p.EdadPersona >= 46 && p.EdadPersona <= 55)
                {
                    de_46_a_55++;
                    if (p.IdSexo == 1)
                    {
                        de_46_a_55_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_46_a_55_f++;
                    }
                }
                else if (p.EdadPersona >= 56 && p.EdadPersona <= 60)
                {
                    de_56_a_60++;
                    if (p.IdSexo == 1)
                    {
                        de_56_a_60_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_56_a_60_f++;
                    }
                }
                else if (p.EdadPersona >= 61 && p.EdadPersona <= 65)
                {
                    de_61_a_65++;
                    if (p.IdSexo == 1)
                    {
                        de_61_a_65_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        de_61_a_65_f++;
                    }
                }
                else if (p.EdadPersona > 65)
                {
                    mas_de_65++;
                    if (p.IdSexo == 1)
                    {
                        mas_de_65_m++;
                    }
                    if (p.IdSexo == 2)
                    {
                        mas_de_65_f++;
                    }
                }
            });
            int total = tabla_personas.Count;
            int total_m = tabla_personas.FindAll(p => p.IdSexo == 1).Count;
            int total_f = tabla_personas.FindAll(p => p.IdSexo == 2).Count;

            tabla.Add(GenerarRegistroResumen("Total", total, total_m, total_f, total));
            tabla.Add(GenerarRegistroResumen("18-25", de_18_a_25, de_18_a_25_m, de_18_a_25_f, total));
            tabla.Add(GenerarRegistroResumen("26-35", de_26_a_35, de_26_a_35_m, de_26_a_35_f, total));
            tabla.Add(GenerarRegistroResumen("36-45", de_36_a_45, de_36_a_45_m, de_36_a_45_f, total));
            tabla.Add(GenerarRegistroResumen("46-55", de_46_a_55, de_46_a_55_m, de_46_a_55_f, total));
            tabla.Add(GenerarRegistroResumen("56-60", de_56_a_60, de_56_a_60_m, de_56_a_60_f, total));
            tabla.Add(GenerarRegistroResumen("61-65", de_61_a_65, de_61_a_65_m, de_61_a_65_f, total));
            tabla.Add(GenerarRegistroResumen(">65", mas_de_65, mas_de_65_m, mas_de_65_f, total));
            this.tabla_resumen = tabla;
        }

        private Resumen GenerarRegistroResumen(string titulo, int subtotal, int subtotal_masculino, int subtotal_femenino, int total)
        {
            var resumen = new Resumen();
            resumen = GenerarRegistroResumen(titulo, subtotal, total);
            if (subtotal != 0)
            {
                resumen.PorcentajeHombres = (float)subtotal_masculino * (float)100 / (float)subtotal;
                resumen.PorcentajeMujeres = (float)subtotal_femenino * (float)100 / (float)subtotal;
            }
            else {
                resumen.PorcentajeHombres = 0;
                resumen.PorcentajeMujeres = 0;
            }
           
            return resumen;
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
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.ForEach(registro =>
            {

                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.Personas.Count, total, registro.Orden));
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
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.Personas.Count, total, registro.Orden));
            });

            this.tabla_resumen = tabla;
            this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();
        }




    }
}
