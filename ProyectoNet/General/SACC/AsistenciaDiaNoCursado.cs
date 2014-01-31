using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AsistenciaDiaNoCursado : AcumuladorAsistencia
    {
        protected string valor;
        protected DateTime fecha;
        protected int id_alumno;
        protected int id_curso;

        public AsistenciaDiaNoCursado(string valor, int horas_maximas)
        {
            this.valor = valor;
        }

        public AsistenciaDiaNoCursado(int id, string valor, int horas_maximas, DateTime fecha, int id_alumno, int id_curso)
        {
            this.Valor = valor;
            this.horas_maximas = horas_maximas;
            this.Fecha = fecha;
            this.IdAlumno = id_alumno;
            this.IdCurso = id_curso;
            this.Id = id;
        }

        public override int HorasNoAsistidas()
        {
            return 0;
        }

        public override int HorasAsistidas()
        {
            return 0;
        }

        public override int AcumularHorasNoAsistidas(int valor_acumulado)
        {
            return valor_acumulado;
        }

        public override int AcumularHorasAsistidas(int valor_acumulado)
        {
            return valor_acumulado;
        }
    }
    
}
