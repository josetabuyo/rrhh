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
        public List<Resumen> tabla_resumen;
        public List<Dotacion> tabla_detalle;

        public Grafico()
        {
        }


        public abstract void CrearDatos(List<RowDeDatos> list);


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

        public bool ContienePersonas()
        {
            if (this.tabla_detalle.Count == 0)
            {
                return false;
            }
            return true;
        }

        public abstract void GraficoPorArea();
        public abstract void GraficoPorSecretarias();
        public abstract void GraficoPorSubSecretarias();

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

        
    }
}
