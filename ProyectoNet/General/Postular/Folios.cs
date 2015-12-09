using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class Folios
    {
        protected string _codigo;
        protected DateTime _fecha;
        protected int _ficha_inscripcion;
        protected int _foto_carnet;
        protected int _fotocopia_dni;
        protected int _fotocopia_titulo;
        protected int _Curri;
        protected int _Docum_respaldo;
        protected int _dni;
       

        public string codigo { get { return _codigo; } set { _codigo = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }
        public int ficha_inscripcion { get { return _ficha_inscripcion; } set { _ficha_inscripcion = value; } }
        public int foto_carnet { get { return _foto_carnet; } set { _foto_carnet = value; } }
        public int fotocopia_dni { get { return _fotocopia_dni; } set { _fotocopia_dni = value; } }
        public int fotocopia_titulo { get { return _fotocopia_titulo; } set { _fotocopia_titulo = value; } }
        public int Curri { get { return _Curri; } set { _Curri = value; } }
        public int Docum_respaldo { get { return _Docum_respaldo; } set { _Docum_respaldo = value; } }
        public int dni { get { return _dni; } set { _dni = value; } }

        public Folios()
        {
        }

        public Folios(string codigo, DateTime fecha, int ficha_inscripcion, int foto_carnet, int fotocopia_dni, int fotocopia_titulo, int Curri, int Docum_respaldo, int dni)
        {
            this._codigo = codigo;
            this._fecha = fecha;
            this._ficha_inscripcion = ficha_inscripcion;
            this._foto_carnet = foto_carnet;
            this._fotocopia_dni = fotocopia_dni;
            this._fotocopia_titulo = fotocopia_titulo;
            this._Curri = Curri;
            this._Docum_respaldo = Docum_respaldo;
            this._dni = dni;
        }

        public Folios(string nro_inscripcion, string dni_postulante, string fecha_postulacion)
        {
            // TODO: Complete member initialization
            this._codigo = nro_inscripcion;
            this._dni = Convert.ToInt32(dni_postulante);
            this._fecha = new DateTime(Convert.ToInt16(fecha_postulacion.Substring(6,4)), Convert.ToInt32(fecha_postulacion.Substring(3,2)), Convert.ToInt32(fecha_postulacion.Substring(0,2)));
        }

    }
}
