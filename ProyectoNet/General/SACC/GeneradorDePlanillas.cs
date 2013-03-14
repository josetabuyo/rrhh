using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class GeneradorDePlanillas
    {
        public GeneradorDePlanillas()
        { }


        public PlanillaMensual GenerarPlanillaMensualPara(Curso un_curso, DateTime fecha_desde, DateTime fecha_hasta)
        {
            return new PlanillaMensual(un_curso, fecha_desde, fecha_hasta);
        }

        public PlanillaMensual GenerarPlanillaMensualPara(Curso un_curso,DateTime fecha_desde, DateTime fecha_hasta, CalendarioDeCurso un_calendario)
        {
            return new PlanillaMensual(un_curso, fecha_desde, fecha_hasta, un_calendario);
        }
    }
}
