using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using General;

namespace General
{
    public class ConstantesConcursar
    {
        public static EtapaConcurso EtapaPreinscripcionWeb = new EtapaConcurso(1, "Preinscripción web");
        public static EtapaConcurso EtapaPreinscripcionDocumental = new EtapaConcurso(2, "Preinscripción documental");
        public static EtapaConcurso EtapaInscripcionDocumental = new EtapaConcurso(3, "Inscripción documental");


        public ConstantesConcursar()
        {

        }
    }
}