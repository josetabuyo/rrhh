using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.PotenciarTrabajo
{
    public class PT_Resumen_Inicial
    {
      
        public int Id_Entidad { get; set; }
        public string Nombre_Entidad { get; set; }
        public int Activos { get; set; }
        public int Activos_Parcial { get; set; }
        public int Suspendidos { get; set; }
        public int Inactivos { get; set; }
        public int Sin_Carga { get; set; }
        public int En_Proceso { get; set; }
        public int Con_Informe { get; set; }
        

    }
}
