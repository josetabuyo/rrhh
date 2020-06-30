using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.PotenciarTrabajo
{
    public class PT_Justificacion
    {
        public int Id_Registro { get; set; }
        public int Id_Persona_Rol { get; set; }
        public int Id_Motivo { get; set; }
        public int Anio_Desde { get; set; }
        public int Mes_Desde { get; set; }
        public int Semana_Desde { get; set; }
        public int Anio_Hasta { get; set; }
        public int Mes_Hasta { get; set; }
        public int Semana_Hasta { get; set; }
        public string Justificacion { get; set; }
        public int Id_Usuario_Carga { get; set; }
        public DateTime Fecha_Carga { get; set; }

    }
}
