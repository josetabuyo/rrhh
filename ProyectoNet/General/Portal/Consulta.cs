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

        public Consulta() { }

        public Consulta(int id, Persona creador, DateTime fecha_creacion, string tipo_consulta, string motivo, string estado, Persona contestador, DateTime fecha_contestacion, string respuesta)
        {
            this.contestador = new Persona();
            this.Id = id;
            this.fechaCreacion = fecha_creacion;
            this.tipo_consulta = tipo_consulta;
            this.motivo = motivo;
            this.estado = estado;
            this.contestador = contestador;
            this.fechaContestacion = fecha_contestacion;
            this.respuesta = respuesta;
            this.creador = creador;
        }


    }
}
