using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvIdiomas
    {
        protected string _diploma;
        protected string _establecimiento;
        protected string _idioma;
        protected string _lectura;
        protected string _escritura;
        protected string _oral;
        protected DateTime _fechaObtencion;
        protected DateTime _fechaFin;
        protected string _localidad;
        protected string _pais;


        public string Diploma { get { return _diploma; } set { _diploma = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Idioma { get { return _idioma; } set { _idioma = value; } }
        public string Lectura { get { return _lectura; } set { _lectura = value; } }
        public string Escritura { get { return _escritura; } set { _escritura = value; } }
        public string Oral { get { return _oral; } set { _oral = value; } }
        public DateTime FechaObtencion { get { return _fechaObtencion; } set { _fechaObtencion = value; } }
        public DateTime FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }


        public CvIdiomas(string diploma, string establecimiento, string idioma, string lectura, string escritura, string oral, DateTime fechaObtencion, DateTime fechaFin, string localidad, string pais)
        {
            this._diploma = diploma;
            this._establecimiento = establecimiento;
            this._idioma = idioma;
            this._lectura = lectura;
            this._escritura = escritura;
            this._oral = oral;
            this._fechaObtencion = fechaObtencion;
            this._fechaFin = fechaFin;
            this._localidad = localidad;
            this._pais = pais;
        }

        public CvIdiomas()
        {
        }

    }
}
