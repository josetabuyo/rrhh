using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class CvCompetenciasInformaticas
    {
        protected int _id;
        protected string _diploma;
        protected DateTime _fechaObtencion;
        protected string _establecimiento;
        protected int _tipoInformatica;
        protected string _conocimiento;
        protected string _nivel;
     
        protected string _localidad;
        protected int _pais;
        protected string _detalle;

        public int Id { get { return _id; } set { _id = value; } }
        public string Diploma { get { return _diploma; } set { _diploma = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public int TipoInformatica { get { return _tipoInformatica; } set { _tipoInformatica = value; } }
        public string Conocimiento { get { return _conocimiento; } set { _conocimiento = value; } }
        public string Nivel { get { return _nivel; } set { _nivel = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        public DateTime FechaObtencion { get { return _fechaObtencion; } set { _fechaObtencion = value; } }
        public string Detalle { get { return _detalle; } set { _detalle = value; } }

        public CvCompetenciasInformaticas(int id, string diploma, string establecimiento, int tipoInformatica, string conocimiento, string nivel, string localidad, int pais, DateTime fechaObtencion, string detalle)
        {
            this._id = id;
            this._diploma = diploma;
            this._establecimiento = establecimiento;
            this._tipoInformatica = tipoInformatica;
            this._conocimiento = conocimiento;
            this._nivel = nivel;
            this._localidad = localidad;
            this._pais = pais;
            this._fechaObtencion = fechaObtencion;
            this._detalle = detalle;
        }

        public CvCompetenciasInformaticas()
        {
        }
    }
}
