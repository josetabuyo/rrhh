using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ManagerDeCalendarios
    {
        private CalendarioDeFeriados _calendarioDeFeriados;
        private Dictionary<Curso, CalendarioDeCurso> _calendariosPorCurso = new Dictionary<Curso, CalendarioDeCurso>(); 


        public ManagerDeCalendarios(CalendarioDeFeriados calendarioDeFeriados)
        {
            this._calendarioDeFeriados = calendarioDeFeriados;
        }

        public void AgregarCalendarioPara(Curso unCurso)
        {
            CalendarioDeCurso calendarioDeCurso = new CalendarioDeCurso(unCurso.diasDeCursada(),_calendarioDeFeriados);
            _calendariosPorCurso.Add(unCurso, calendarioDeCurso);
        }

        public CalendarioDeCurso CalendarioPara(Curso unCurso)
        {
            return _calendariosPorCurso[unCurso];
        }
    }
}
