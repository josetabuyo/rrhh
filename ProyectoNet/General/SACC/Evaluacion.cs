using System;

namespace General
{
    public class Evaluacion
    {
        private  InstanciasDeEvaluacion _idInstanciaEvaluacion;
        private int _idAlumno;
        private int _idCurso;
        private string _calificacion;
        private DateTime _fecha;


        public InstanciasDeEvaluacion InstanciaEvaluacion { get { return _idInstanciaEvaluacion; } set { _idInstanciaEvaluacion = value; } }
        public string Calificacion { get { return _calificacion; } set { _calificacion = value; } }
        public int IdAlumno { get { return _idAlumno; } set { _idAlumno = value; } }
        public int IdCurso { get { return _idCurso; } set { _idCurso = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        public Evaluacion() { }

         public Evaluacion(InstanciasDeEvaluacion instancia_evaluacion, int alumno, int curso, string calificacion, DateTime fecha)
        {
            this._idInstanciaEvaluacion = instancia_evaluacion;
            this._calificacion = calificacion;
            this._idAlumno = alumno;
            this._idCurso = curso;
            this._fecha = fecha;
        }

         //public override bool Equals(object obj)
         //{
         //    if (base.Equals(obj)) { return true; }
         //    if (((Alumno)obj).Id == this.Id) { return true; }
         //    return false;
         //}

        //public override int GetHashCode()
        //{
        //    return this._id.GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return this.Nombre; 
        //}

        //internal int esMayorAlfabeticamenteQue(InstanciaEvaluacion otranota)
        //{
        //    return this.Nota.CompareTo(otranota.Nota); ;
        //}
    }
}
