using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class EvaluacionNull:Evaluacion
    {
        private Calificacion _calificacion;

        //public override InstanciaDeEvaluacion instancia { get { return null; } set { ;} }
        //public override Alumno alumno { get { return null; } set { ;} }
        //public override Curso curso { get { return null; } set { ;} }
        public Calificacion Calificacion { get { return _calificacion; } set { ;} }
        //public override DateTime fecha { get { return null; } set { ;} }

        public EvaluacionNull()
        {
            this._calificacion = new CalificacionNull();
        }

        public override bool Aprobado() {
            return false;
        }

    }
}
