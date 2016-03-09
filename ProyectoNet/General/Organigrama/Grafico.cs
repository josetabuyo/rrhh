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
        public Resumen[] tabla_resumen;
        public Dotacion[] tabla_detalle;

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
                           row.GetString("descripcion"),
                           row.GetSmallintAsInt("id_planta"),
                           row.GetString("planta")
                       );
                tabla.Add(persona);
            });
            this.tabla_detalle = tabla.ToArray();
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

                if ("A".Equals(p))
                {
                    nivel_a = nivel_a + 1;
                }
                else if ("B".Equals(p))
                {
                    nivel_b = nivel_b + 1;
                }
                else if ("C".Equals(p))
                {
                    nivel_c = nivel_c + 1;
                }
                else if ("D".Equals(p))
                {
                    nivel_d = nivel_d + 1;
                }
                else if ("E".Equals(p))
                {
                    nivel_e = nivel_e + 1;
                }
                else if ("F".Equals(p))
                {
                    nivel_f = nivel_f + 1;
                }

            });
            int total = tabla_personas.Count;
           
            tabla.Add(GenerarRegistroResumen("A", nivel_a, total));
            tabla.Add(GenerarRegistroResumen("B", nivel_b, total));
            tabla.Add(GenerarRegistroResumen("C", nivel_c, total));
            tabla.Add(GenerarRegistroResumen("D", nivel_d, total));
            tabla.Add(GenerarRegistroResumen("E", nivel_e, total));
            tabla.Add(GenerarRegistroResumen("F", nivel_f, total));
            this.tabla_resumen = tabla.ToArray();
        }

        private Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, cantidad * 100 / total);
            return registro_resumen;
        }
    }
}
