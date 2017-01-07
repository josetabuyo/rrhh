using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class Consulta
    {
        public long Id;
        public Persona creador;
        public DateTime fechaCreacion;
        public DateTime fechaCierre;
        public int id_tipo_consulta;
        public string tipo_consulta;
        public int id_estado;
        public string estado;
        public int calificacion;
        public bool leida;
        public List<Respuesta> respuestas;

        public Consulta() { }

        public Consulta(long id, Persona creador, DateTime fecha_creacion, DateTime fecha_cierre, int id_tipo_consulta, string tipo_consulta, int id_estado, string estado, int calificacion, bool leida, List<Respuesta> respuestas)
        {
            this.Id = id;
            this.creador = creador;
            this.fechaCreacion = fecha_creacion;
            this.fechaCierre = fecha_cierre;
            this.id_tipo_consulta = id_tipo_consulta;
            this.tipo_consulta = tipo_consulta;
            this.id_estado = id_estado;
            this.estado = estado;
            this.calificacion = calificacion;
            this.leida = leida;
            this.respuestas = respuestas;

        }


    }
}
