using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class SueldoPersona
    {
        public int idPersona { get; set; }
        public int legajo { get; set; }
        public int nroDocumento { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int idArea { get; set; }
        public string area { get; set; }
        public string areaDescripCorta { get; set; }
        public string areaDescripMedia { get; set; }
        public int sueldoAnio { get; set; }
        public int sueldoMes { get; set; }
        public float sueldoBruto { get; set; }
        public float sueldoNeto { get; set; }
        public int xtrasAnio { get; set; }
        public int xtrasMes { get; set; }
        public float xtrasBruto { get; set; }
        public float xtrasNeto { get; set; }
        public int SACAnio { get; set; }
        public int SACMes { get; set; }
        public float SACBruto { get; set; }
        public float SACNeto { get; set; }
        public int hsSimples { get; set; }
        public int hs50 { get; set; }
        public int hs100 { get; set; }
        public int comidas { get; set; }
    }
}
