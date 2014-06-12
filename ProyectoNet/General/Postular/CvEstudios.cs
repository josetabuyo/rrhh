using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvEstudios
    {
        protected int _id;
        protected string _titulo;
        protected string _establecimiento;
        protected string _fechaIngreso;
        protected string _fechaEgreso;
        protected string _localidad;
        protected string _pais;
        protected string _especialidad;

        public int Id { get { return _id; } set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Especialidad { get { return _especialidad; } set { _especialidad = value; } }
        public string FechaIngreso { get { return _fechaIngreso; } set { _fechaIngreso = value; } }
        public string FechaEgreso { get { return _fechaEgreso; } set { _fechaEgreso = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }
        

        public CvEstudios(string titulo, string establecimiento, string especialidad, string fechaIngeso, string fechaEgreso, string localidad, string pais)
        {
            SetearCampos(titulo, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);
        }

        public CvEstudios(int id, string titulo, string establecimiento, string especialidad, string fechaIngeso, string fechaEgreso, string localidad, string pais)
        {
            this._id = id;
            SetearCampos(titulo, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);

        }

        private void SetearCampos(string titulo, string establecimiento, string especialidad, string fechaIngeso, string fechaEgreso, string localidad, string pais)
        {
            this._titulo = titulo;
            this._establecimiento = establecimiento;
            this._especialidad = especialidad;
            this._fechaIngreso = fechaIngeso;
            this._fechaEgreso = fechaEgreso;
            this._localidad = localidad;
            this._pais = pais;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((CvEstudios)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public CvEstudios()
        {
        }
    }
}
