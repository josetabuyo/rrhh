using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public class Resumen
    {
        public string Id { get; set; }
        public string DescripcionGrafico { get; set; }
        public int Cantidad { get; set; }
        public float Porcentaje { get; set; }
        public int Orden { get; set; }
        public float SumatoriaSueldo { get; set; }
        public float PrimedioSueldo { get; set; }
        public float MedianaSueldo { get; set; }
        public float SumatoriaExtras { get; set; }
        public float PrimedioExtras { get; set; }
        public float MedianaExtras { get; set; }

        public Resumen() { }

        public Resumen(string id, string descripcionGrafico, int cantidad, float porcentaje)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Porcentaje = porcentaje;
            this.DescripcionGrafico = descripcionGrafico;
        }
        public Resumen(string id, int cantidad, float porcentaje)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Porcentaje = porcentaje;
        }
        public Resumen(string id, string descripcionGrafico, int cantidad, float porcentaje, int orden)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Porcentaje = porcentaje;
            this.Orden = orden;
            this.DescripcionGrafico = descripcionGrafico;
        }
    }
}
