using System;
using System.Collections.Generic;

using System.Text;
using General.MAU;
using General;

namespace General
{
    public class Justificacion
    {

        public int Id {get; set; }
        public DateTime Desde {get; set; }
        public DateTime Hasta {get; set; }
        public string Motivo {get; set; }
        public Usuario Usuario {get; set; }
        public Inasistencia Inasistencia {get; set; }
        public int idAusencia {get; set; }
        public DateTime FechaCarga { get; set; }

        public Justificacion()
        {
        }

        public Justificacion(int id, int idAusencia, string motivo, DateTime desde, DateTime hasta, Usuario usuario)
        {
            this.Id = id;
            this.idAusencia = idAusencia;
            this.Motivo = motivo;
            this.Desde = desde;
            this.Hasta = hasta;
            this.Usuario = usuario;

        }

    }
}
