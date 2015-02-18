using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AnexosDeEtapas
    {

        public int Id { get; set; }
        public Comite Comite { get; set; }
        public EtapaPostulacion EtapaPostualcion { get; set; }
        public List<Postulacion> Postulaciones { get; set; }
        public DateTime Fecha { get; set; }
       

        public AnexosDeEtapas() { }

        public AnexosDeEtapas(int id, Comite comite, List<Postulacion> postulaciones, EtapaConcurso etapa, DateTime fecha)
        {


        }

    }
}
