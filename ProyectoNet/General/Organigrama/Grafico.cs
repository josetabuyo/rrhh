using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Grafico
    {
        public List<Resumen> tabla_resumen;
        public List<Dotacion> tabla_detalle;

        public Grafico()
        {
        }




        internal void CrearDatos(List<RowDeDatos> list)
        {

            List<Dotacion> tabla = new List<Dotacion>();

            list.ForEach(row =>
            {
                Dotacion persona =
                       new Dotacion(
                           row.GetInt("id_persona"),
                           row.GetInt("legajo"),
                          row.GetInt("nrodocumento"),
                           row.GetString("apellido"),
                           row.GetString("nombre"),
                           row.GetSmallintAsInt("id_sexo"),
                          row.GetString("descrip_sexo"),
                           row.GetString("nivel"),
                           row.GetSmallintAsInt("grado"),
                           row.GetInt("id_area"),
                           row.GetString("area"),
                           row.GetSmallintAsInt("id_planta"),
                           row.GetString("planta"),
                           row.GetInt("IdEstudio"),
                           row.GetString("Nivel_Estudios"),
                           row.GetString("Titulo_Obtenido")
                );
                tabla.Add(persona);
            });
            this.tabla_detalle = tabla;
        }

        internal void GraficoPorNivel()
        {
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();
            int nivel_a = 0;
            int nivel_b = 0;
            int nivel_c = 0;
            int nivel_d = 0;
            int nivel_e = 0;
            int nivel_f = 0;
            tabla_personas.ForEach(p =>
            {
                switch (p.Nivel)
                {
                    case "A":
                        nivel_a++;
                        break;
                    case "B":
                        nivel_b++;
                        break;
                    case "C":
                        nivel_c++;
                        break;
                    case "D":
                        nivel_d++;
                        break;
                    case "E":
                        nivel_e++;
                        break;
                    case "F":
                        nivel_f++;
                        break;
                }

            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Nivel A", nivel_a, total));
            tabla.Add(GenerarRegistroResumen("Nivel B", nivel_b, total));
            tabla.Add(GenerarRegistroResumen("Nivel C", nivel_c, total));
            tabla.Add(GenerarRegistroResumen("Nivel D", nivel_d, total));
            tabla.Add(GenerarRegistroResumen("Nivel E", nivel_e, total));
            tabla.Add(GenerarRegistroResumen("Nivel F", nivel_f, total));
            this.tabla_resumen = tabla;
        }

        private Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, float.Parse(String.Format("{0:0.##}", cantidad * 100 / total)));
            return registro_resumen;
        }

        internal void GraficoPorGenero()
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
                        femenino++;
                        break;
                    case 2:
                        masculino++;
                        break;
                }
            });
            int total = tabla_personas.Count;

            tabla.Add(GenerarRegistroResumen("Femenino", femenino, total));
            tabla.Add(GenerarRegistroResumen("Masculino", masculino, total));
            this.tabla_resumen = tabla;
        }

        internal void GraficoPorEstudio()
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

            tabla.Add(GenerarRegistroResumen("No Especifica", NoEspecifica, total));
            tabla.Add(GenerarRegistroResumen("Primario", Primario, total));
            tabla.Add(GenerarRegistroResumen("Secundario", Secundario, total));
            tabla.Add(GenerarRegistroResumen("Terciario", Terciario, total));
            tabla.Add(GenerarRegistroResumen("Universitario", Universitario, total));
            tabla.Add(GenerarRegistroResumen("Post-Grado", PostGrado, total));
            tabla.Add(GenerarRegistroResumen("Ciclo Básico", CicloBasico, total));
            tabla.Add(GenerarRegistroResumen("No presento certificado", Nopresentocertificado, total));
            tabla.Add(GenerarRegistroResumen("Pregrado", Pregrado, total));

            this.tabla_resumen = tabla;
        }

        internal void GraficoPorPlanta()
        {
            throw new NotImplementedException();
        }

        internal void GraficoPorAfiliacionGremial()
        {
            throw new NotImplementedException();
        }
    }
}
