using System;
using System.Collections.Generic;

namespace General
{
    public class Alumno
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _documento;
        private List<Area> _areas;
        private Modalidad _modalidad;
        private string _telefono;
        private string _mail;
        private string _direccion;
        private int _baja;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public int Documento { get { return _documento; } set { _documento = value; } }
        public List<Area> Areas { get { return _areas; } set { _areas = value; } }
        public Modalidad Modalidad { get { return _modalidad; } set { _modalidad = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public int Baja { get { return _baja; } set { _baja = value; } }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, int documento, string telefono, string mail, string direccion, List<Area> areas, Modalidad modalidad)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._documento = documento;
            this._telefono = telefono;
            this._mail = mail;
            this._direccion = direccion;
            this._areas = areas;
            this._modalidad = modalidad;
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

        public override string ToString()
        {
            return this.Nombre;
        }

        internal int esMayorAlfabeticamenteQue(Alumno otroalumno)
        {
            {
                //return this.Apellido.CompareTo(otroalumno.Apellido);
                if (this.Modalidad.Descripcion.CompareTo(otroalumno.Modalidad.Descripcion) == -1) return -1;

                else if (this.Modalidad.Descripcion.CompareTo(otroalumno.Modalidad.Descripcion) == +1) return +1;

                else if (this.Apellido.CompareTo(otroalumno.Apellido) == -1) return -1;

                else if (this.Apellido.CompareTo(otroalumno.Apellido) == +1) return +1;

                else if (this.Nombre.CompareTo(otroalumno.Nombre) == -1) return -1;

                else if (this.Nombre.CompareTo(otroalumno.Nombre) == +1) return +1;

                else return 0;
            }
        }
    }
}
