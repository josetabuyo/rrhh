using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class GraficoDotacion : Grafico
    {
        //public override List<Resumen> tabla_resumen;
        //public override List<Dotacion> tabla_detalle;


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
                

                tabla.Add(persona);
            });
            this.tabla_detalle = tabla;
        }

        public void GraficoPorNivel(List<string> listaNiveles)
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            Dictionary<string, int> niveles = new Dictionary<string, int>();
            foreach (var nivel in listaNiveles)
            {
                niveles.Add(nivel, 0);
            }

            tabla_personas.ForEach(p =>
            {
                niveles[p.Nivel] = niveles[p.Nivel] + 1;
            });
            int total = tabla_personas.Count;

            Dictionary<string, int> nivelesConDatos = new Dictionary<string, int>();
           
            foreach (var nivel in niveles)
            {
                if (nivel.Value != 0)
                    nivelesConDatos.Add(nivel.Key, nivel.Value);
                    
            }

            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));
            foreach (var nivel in nivelesConDatos)
            {
                tabla.Add(GenerarRegistroResumen("Nivel " + nivel.Key, "Nivel " + nivel.Key, nivel.Value, total));
            }

            this.tabla_resumen = tabla;
        }

        /*private Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }

        private Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }
        private Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total, int orden)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total), orden);
            return registro_resumen;
        }*/

        public void GraficoPorGenero()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int femenino = 0;
            int masculino = 0;
            tabla_personas.ForEach(p =>
            {
                switch (p.IdSexo)
                {
                    case 1:
                        masculino++;
                        break;
                    case 2:
                        femenino++;
                        break;
                }
            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));
            tabla.Add(GenerarRegistroResumen("Femenino", "Femenino", femenino, total));
            tabla.Add(GenerarRegistroResumen("Masculino", "Femenino", masculino, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        public void GraficoPorEstudio()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int NoEspecifica = 0;
            int Primario = 0;
            int Secundario = 0;
            int Terciario = 0;
            int Universitario = 0;
            int PostGrado = 0;
            int CicloBasico = 0;
            int Nopresentocertificado = 0;
            int Pregrado = 0;

            tabla_personas.ForEach(p =>
            {
                switch (p.NivelEstudio)
                {
                    case "NoEspecifica":
                        NoEspecifica++;
                        break;
                    case "Primario":
                        Primario++;
                        break;
                    case "Secundario":
                        Secundario++;
                        break;
                    case "Terciario":
                        Terciario++;
                        break;
                    case "Universitario":
                        Universitario++;
                        break;
                    case "PostGrado":
                        PostGrado++;
                        break;
                    case "CicloBasico":
                        CicloBasico++;
                        break;
                    case "Nopresentocertificado":
                        Nopresentocertificado++;
                        break;
                    case "Pregrado":
                        Pregrado++;
                        break;
                }
            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            if (NoEspecifica > 0) tabla.Add(GenerarRegistroResumen("No Especifica", NoEspecifica, total));
            if (Primario > 0) tabla.Add(GenerarRegistroResumen("Primario", Primario, total));
            if (Secundario > 0) tabla.Add(GenerarRegistroResumen("Secundario", Secundario, total));
            if (Terciario > 0) tabla.Add(GenerarRegistroResumen("Terciario", Terciario, total));
            if (Universitario > 0) tabla.Add(GenerarRegistroResumen("Universitario", Universitario, total));
            if (PostGrado > 0) tabla.Add(GenerarRegistroResumen("Post-Grado", PostGrado, total));
            if (CicloBasico > 0) tabla.Add(GenerarRegistroResumen("Ciclo Básico", CicloBasico, total));
            if (Nopresentocertificado > 0) tabla.Add(GenerarRegistroResumen("No presento certificado", Nopresentocertificado, total));
            if (Pregrado > 0) tabla.Add(GenerarRegistroResumen("Pregrado", Pregrado, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        public void GraficoPorPlanta(Dictionary<int, string> plantasDeBase)
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
          
            Dictionary<string, int> plantasTotalizadores = new Dictionary<string, int>();

            foreach (var plantaKey in plantasDeBase.Keys)
            {
                plantasTotalizadores.Add(plantasDeBase[plantaKey], 0);
            }

            tabla_personas.ForEach(p =>
            {
                plantasTotalizadores[p.Planta] = plantasTotalizadores[p.Planta] + 1;
            });

            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));

            foreach (var planta in plantasTotalizadores)
            {
                if (planta.Value != 0)
                    tabla.Add(GenerarRegistroResumen(planta.Key, planta.Value, total));
            }

           
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoPorAfiliacionGremial()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            int sin_datos = tabla_personas.Count;
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Sin Datos", sin_datos, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }

        internal void GraficoRangoEtareo(DateTime fecha)
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
        }

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
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.Personas.Count, total, registro.Orden));
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
