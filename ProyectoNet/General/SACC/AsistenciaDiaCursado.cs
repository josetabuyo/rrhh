using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaDiaCursado:AcumuladorAsistencia
    {
        protected int valor;
        private DateTime fecha;
        private int id_alumno;
        private int id_curso;

        public AsistenciaDiaCursado(string valor, int horas_maximas)
        {
            this.Valor = valor;
            this.valor = int.Parse(valor);
            this.horas_maximas = horas_maximas;
        }

        public AsistenciaDiaCursado(int id, string valor, int horas_maximas, DateTime fecha, int id_alumno, int id_curso)
        {
            this.Valor = valor;
            this.valor = int.Parse(valor);
            this.horas_maximas = horas_maximas;
            this.Fecha = fecha;
            this.IdAlumno = id_alumno;
            this.IdCurso = id_curso;
            this.Id = id;
        }
        public override int HorasNoAsistidas()
        {
            return this.horas_maximas - this.valor;
        }

        public override int AcumularHorasNoAsistidas(int valor_acumulado)
        {
            return valor_acumulado + this.HorasNoAsistidas();
        }

        public override int HorasAsistidas()
        {
            return int.Parse(this.Valor);
        }

        public override int AcumularHorasAsistidas(int valor_acumulado)
        {
            return valor_acumulado + this.HorasAsistidas();
        }
    }
    
}
