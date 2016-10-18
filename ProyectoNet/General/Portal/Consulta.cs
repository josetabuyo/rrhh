using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Consulta
    {
        public int Id;
        public Persona creador;
        public DateTime fechaCreacion;
        public int id_tipo_consulta;
        public string tipo_consulta;
        public string motivo;
        public int id_estado;
        public string estado;
        public Persona contestador;
        public DateTime fechaContestacion;
        public string respuesta;

        public Consulta()
        {

        }
    }
}
