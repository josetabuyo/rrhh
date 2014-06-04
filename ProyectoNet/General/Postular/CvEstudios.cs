using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvEstudios
    {
        protected string _titulo;
        protected string _establecimiento;
        protected DateTime _fechaIngreso;
        protected DateTime _fechaEgreso;
        protected string _localidad;
        protected string _pais;
        protected string _especialidad;

        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Especialidad { get { return _especialidad; } set { _especialidad = value; } }
        public DateTime FechaIngreso { get { return _fechaIngreso; } set { _fechaIngreso = value; } }
        public DateTime FechaEgreso { get { return _fechaEgreso; } set { _fechaEgreso = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }
        

        public CvEstudios(string titulo, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, string pais)
        {
            this._titulo = titulo;
            this._establecimiento = establecimiento;
            this._especialidad = especialidad;
            this._fechaIngreso = fechaIngeso;
            this._fechaEgreso = fechaEgreso;
            this._localidad = localidad;
            this._pais = pais;

        }

        public CvEstudios()
        {
        }
    }
}
