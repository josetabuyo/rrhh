using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public abstract class AcumuladorAsistencia
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
        protected int horas_maximas;

        public abstract int HorasNoAsistidas();
        public abstract int HorasAsistidas();
        public abstract int AcumularHorasNoAsistidas(int valor_acumulado);
        public abstract int AcumularHorasAsistidas(int valor_acumulado);

        public override bool Equals(object obj)
        {
            AcumuladorAsistencia a = (AcumuladorAsistencia)obj;
            return this.Id == a.Id;
        }
    }
}
