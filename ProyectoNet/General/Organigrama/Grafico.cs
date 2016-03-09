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
        public List<object> tabla_resumen;
        public List<object> tabla_detalle;

        public Grafico()
        {
        }


        internal void CrearDatos(List<RowDeDatos> list)
        {

            List<object> tabla = new List<object>();

            list.ForEach(row =>
            {
                var registro_detalle =
                       new
                       {
                           id_persona = row.GetInt("id_persona"),
                           legajo = row.GetInt("legajo"),
                           nrodocumento = row.GetInt("nrodocumento"),
                           apellido = row.GetString("apellido"),
                           nombre = row.GetString("nombre"),
                           id_sexo = row.GetSmallintAsInt("id_sexo"),
                           descrip_sexo = row.GetString("descrip_sexo"),
                           nivel = row.GetString("nivel"),
                           grado = row.GetSmallintAsInt("grado"),
                           id_area = row.GetInt("id_area"),
                           descripcion = row.GetString("descripcion"),
                           id_planta = row.GetSmallintAsInt("id_planta"),
                           planta = row.GetString("planta")
                       };
                tabla.Add(registro_detalle);
            });
            this.tabla_detalle = tabla;

        }


        internal void GraficoPorNivel()
        {
            int nivel_a = 0;
            int nivel_b = 0;
            int nivel_c = 0;
            int nivel_d = 0;
            int nivel_e = 0;
            int nivel_f = 0;
            this.tabla_detalle.ForEach(o =>
            {
                Type t = o.GetType();
                PropertyInfo p = t.GetProperty("nivel");
                object v = p.GetValue(o, null);

                if ("A".Equals(v))
                {
                    nivel_a = nivel_a + 1;
                }
                else if ("B".Equals(v))
                {
                    nivel_b = nivel_b + 1;
                }
                else if ("C".Equals(v))
                {
                    nivel_c = nivel_c + 1;
                }
                else if ("D".Equals(v))
                {
                    nivel_d = nivel_d + 1;
                }
                else if ("E".Equals(v))
                {
                    nivel_e = nivel_e + 1;
                }
                else if ("F".Equals(v))
                {
                    nivel_f = nivel_f + 1;
                }

            });
            int total = this.tabla_detalle.Count;
            this.tabla_resumen = new List<object>();
            this.tabla_resumen.Add(GenerarRegistroResumen("A", nivel_a, total));
            this.tabla_resumen.Add(GenerarRegistroResumen("B", nivel_b, total));
            this.tabla_resumen.Add(GenerarRegistroResumen("C", nivel_c, total));
            this.tabla_resumen.Add(GenerarRegistroResumen("D", nivel_d, total));
            this.tabla_resumen.Add(GenerarRegistroResumen("E", nivel_e, total));
            this.tabla_resumen.Add(GenerarRegistroResumen("F", nivel_f, total));
        }

        private object GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            var registro_resumen =
                       new
                       {
                           nivel = nivel,
                           cantidad = cantidad,
                           porcentaje = cantidad * 100 / total

                       };
            return registro_resumen;
        }
    }
}
