using System;
using System.Collections.Generic;
using General;

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
        private EstadoDeAlumno _estado_de_alumno;
        private Ciclo _ciclo_cursado;
        private string _telefono;
        private string _mail;
        private string _direccion;
        private string _lugar_de_trabajo;
        private Organismo _organismo;
        private DateTime _fecha_de_nacimiento;
        private DateTime _fecha_de_ingreso;
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
        public string LugarDeTrabajo{ get { return _lugar_de_trabajo; } set { _lugar_de_trabajo = value; } }
        public Organismo Organismo { get { return _organismo; } set { _organismo = value; } }
        public DateTime FechaDeNacimiento { get { return _fecha_de_nacimiento; } set { _fecha_de_nacimiento = value; } }
        public EstadoDeAlumno EstadoDeAlumno { get { return _estado_de_alumno; } set { _estado_de_alumno = value; } }
        public Ciclo CicloCursado { get { return _ciclo_cursado; } set { _ciclo_cursado = value; } }
        public DateTime FechaDeIngreso { get { return _fecha_de_ingreso; } set { _fecha_de_ingreso = value; } }
        public int Baja { get { return _baja; } set { _baja = value; } }

        public Alumno() { }
    
       

        public Alumno(int id, string nombre, string apellido, int documento, string telefono, string mail, string direccion, List<Area> areas, Modalidad modalidad, string lugar_de_trabajo, DateTime fecha_de_nacimiento, string estado_de_cursada, Ciclo ciclo_en_curso, DateTime fecha_de_ingreso, Organismo organismo)
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
            this._lugar_de_trabajo = lugar_de_trabajo;
            this._fecha_de_nacimiento = fecha_de_nacimiento;
            //this._estado_cursada = estado_de_cursada;
            this._ciclo_cursado = ciclo_en_curso;
            this._fecha_de_ingreso = fecha_de_ingreso;
            this._organismo = organismo;
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
