using System;
using System.Collections.Generic;

namespace General
{
    public class Materia
    {
        private int _id;
        private string _nombre;
        private Modalidad _modalidad;
        private Ciclo _ciclo;

        public int Id { get { return _id; } set { _id = value; }}

        public string Nombre { get { return _nombre; } set { _nombre = value; }}

        public Modalidad Modalidad { get { return _modalidad; } set { _modalidad = value; }}

        public Ciclo Ciclo { get { return _ciclo; } set { _ciclo = value; }}

        public Materia()
        {

        }
        public Materia(int id, string nombre, Modalidad modalidad)
        {
            this._id = id;
            this._nombre = nombre;
            this._modalidad = modalidad;
        }

        public Materia(int id, string nombre, Modalidad modalidad, Ciclo ciclo)
        {
            this._id = id;
            this._nombre = nombre;
            this._modalidad = modalidad;
            this._ciclo = ciclo;
        }

        internal int esMayorAlfabeticamenteQue(Materia otramateria)
        {
            return this.Nombre.CompareTo(otramateria.Nombre);
        }
    }
}
