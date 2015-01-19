using System;
namespace General
{
    public class EtapaPostulacion
    {
        public DateTime Fecha{ get; set; }
        public EtapaConcurso Etapa { get; set; }
        public int IdUsuario { get; set; }

        public EtapaPostulacion()
        {

        }
    }
}
