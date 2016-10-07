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
        public string nombre_contestador;
        public DateTime fechaCreacion;
        public int tipo_id;
        public string tipo_descripcion;
        public string motivo;
        public int estado_id;
        public string estado_descripcion;
        public Persona contestador;
        public DateTime fechaContestacion;
        public string respuesta;

        public Consulta()
        {

        }


    }
}
