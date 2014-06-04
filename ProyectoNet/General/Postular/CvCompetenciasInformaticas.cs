using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvCompetenciasInformaticas
    {
        protected string _diploma;
        protected DateTime _fechaObtencion;
        protected string _establecimiento;
        protected string _tipoInformatica;
        protected string _conocimiento;
        protected string _nivel;
        protected string _localidad;
        protected string _pais;

        public string Diploma { get { return _diploma; } set { _diploma = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string TipoInformatica { get { return _tipoInformatica; } set { _tipoInformatica = value; } }
        public string Conocimiento { get { return _conocimiento; } set { _conocimiento = value; } }
        public string Nivel { get { return _nivel; } set { _nivel = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }
        public DateTime FechaObtencion { get { return _fechaObtencion; } set { _fechaObtencion = value; } }

        public CvCompetenciasInformaticas(string diploma, string establecimiento, string tipoInformatica, string conocimiento, string nivel, string localidad, string pais, DateTime fechaObtencion)
        {
            this._diploma = diploma;
            this._establecimiento = establecimiento;
            this._tipoInformatica = tipoInformatica;
            this._conocimiento = conocimiento;
            this._nivel = nivel;
            this._localidad = localidad;
            this._pais = pais;
            this._fechaObtencion = fechaObtencion;
        }

        public CvCompetenciasInformaticas()
        {
        }
    }
}
