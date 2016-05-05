using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public abstract class Grafico
    {
        //public List<Resumen> tabla_resumen;
        //public List<Dotacion> tabla_detalle;
        public List<Resumen> tabla_resumen;
        public List<Dotacion> tabla_detalle;

        public Grafico()
        {
        }


        public abstract void CrearDatos(List<RowDeDatos> list);

        //public abstract void GraficoPorNivel(List<string> listaNiveles);

        protected Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }

        protected Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }
        protected Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total, int orden)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total), orden);
            return registro_resumen;
        }

        //public abstract void GraficoPorGenero();
        /*{
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
        }*/

        //public abstract void GraficoPorEstudio();
        /*{
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
        }*/

        //public abstract void GraficoPorPlanta(Dictionary<int, string> plantasDeBase);
        /*{
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
        }*/

        //public abstract void GraficoPorAfiliacionGremial();
        /*{
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            int sin_datos = tabla_personas.Count;
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Sin Datos", sin_datos, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }*/

        //public abstract void GraficoRangoEtareo(DateTime fecha);
        /*{
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

        public bool ContienePersonas()
        {
            if (this.tabla_detalle.Count == 0)
            {
                return false;
            }
            return true;
        }

        public abstract void GraficoPorArea();
        /*{
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
        }*/

        public abstract void GraficoPorSecretarias();
        /*{
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

        }*/

        public abstract void GraficoPorSubSecretarias();
        /*{
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
        }*/

        //public abstract void GraficoDeSueldoPorSecretarias();
        /*{
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

        }*/

        /*public abstract Resumen GenerarRegistroResumenSueldo(Contador registro, int total)
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
        }*/

        /*internal void GraficoDeSueldoPorSubSecretarias()
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

        }*/

        /*internal void GraficoDeSueldoPorArea()
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
        }*/

        
    }
}
