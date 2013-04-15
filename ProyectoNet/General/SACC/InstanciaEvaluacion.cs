using System;

namespace General
{
    public class InstanciaEvaluacion
    {
        private int _id;
        private  DateTime _fecha;
        private int _baja;
        private string _nota;
        private int _idAlumno;
        private int _idCurso;

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public int Baja { get { return _baja; } set { _baja = value; } }
        public string Nota { get { return _nota; } set { _nota = value; } }
        public int Alumno { get { return _idAlumno; } set { _idAlumno = value; } }
        public int Curso { get { return _idCurso; } set { _idCurso = value; } }

        public InstanciaEvaluacion() { }

         public InstanciaEvaluacion(int id, DateTime fecha, int alumno, int curso, string nota)
        {
            this._id = id;
            this._fecha = fecha;
            this._nota = nota;
            this._idAlumno = alumno;
            this._idCurso = curso;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((Alumno)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

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
