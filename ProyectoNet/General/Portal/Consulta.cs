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
        public DateTime fechaRespuesta;
        public Persona responsable;
        public int id_tipo_consulta;
        public string tipo_consulta;
        public string resumen;
        public int id_estado;
        public string estado;
        public int calificacion;
        public bool leida;
        public List<Respuesta> respuestas;

        public Consulta() { }

        public Consulta(long id, Persona creador, DateTime fecha_creacion, DateTime fecha_respuesta, Persona responsable, int id_tipo_consulta, string tipo_consulta, string resumen, int id_estado, string estado, int calificacion, bool leida, List<Respuesta> respuestas)
        {
            this.Id = id;
            this.creador = creador;
            this.fechaCreacion = fecha_creacion;
            this.fechaRespuesta = fecha_respuesta;
            this.responsable = responsable;
            this.id_tipo_consulta = id_tipo_consulta;
            this.tipo_consulta = tipo_consulta;
            this.resumen = resumen;
            this.id_estado = id_estado;
            this.estado = estado;
            this.calificacion = calificacion;
            this.leida = leida;
            this.respuestas = respuestas;

        }


    }
}
