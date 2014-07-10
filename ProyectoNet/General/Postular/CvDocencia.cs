using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvDocencia
    {
        protected int _id;
        protected string _asignatura;
        protected string _nivelEducativo;
        protected string _tipoActividad;
        protected string _categoriaDocente;
        protected string _caracterDesignacion;
        protected string _dedicacionDocente;
        protected string _cargaHoraria;
        protected string _fechaInicio;
        protected string _fechaFinalizacion;
        protected string _establecimiento;
        protected string _localidad;
        protected string _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string Asignatura { get { return _asignatura; } set { _asignatura = value; } }
        public string NivelEducativo { get { return _nivelEducativo; } set { _nivelEducativo = value; } }
        public string TipoActividad { get { return _tipoActividad; } set { _tipoActividad = value; } }
        public string CategoriaDocente { get { return _categoriaDocente; } set { _categoriaDocente = value; } }
        public string CaracterDesignacion { get { return _caracterDesignacion; } set { _caracterDesignacion = value; } }
        public string DedicacionDocente { get { return _dedicacionDocente; } set { _dedicacionDocente = value; } }
        public string CargaHoraria { get { return _cargaHoraria; } set { _cargaHoraria = value; } }
        public string FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public string FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }


        public CvDocencia(string asignatura, string nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, string fechaInicio, string fechaFinalizacion, string establecimiento, string localidad, string pais)
        {
            SetearCampos(asignatura, nivelEducativo, tipoActividad, categoriaDocente, caracterDesignacion, dedicacionDocente, cargaHoraria, fechaInicio, fechaFinalizacion, establecimiento, localidad, pais);
        }

        public CvDocencia(int id, string asignatura, string nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, string fechaInicio, string fechaFinalizacion, string establecimiento, string localidad, string pais)
        {
            this._id = id;
            SetearCampos(asignatura, nivelEducativo, tipoActividad, categoriaDocente, caracterDesignacion, dedicacionDocente, cargaHoraria, fechaInicio, fechaFinalizacion, establecimiento, localidad, pais);
        }



        private void SetearCampos(string asignatura, string nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, string fechaInicio, string fechaFinalizacion, string establecimiento, string localidad, string pais)
        {
            this._asignatura = asignatura;
            this._nivelEducativo = nivelEducativo;
            this._tipoActividad = tipoActividad;
            this._categoriaDocente = categoriaDocente;
            this._caracterDesignacion = caracterDesignacion;
            this._dedicacionDocente = dedicacionDocente;
            this._cargaHoraria = cargaHoraria;
            this._fechaInicio = fechaInicio;
            this._fechaFinalizacion = fechaFinalizacion;
            this._establecimiento = establecimiento;
            this._localidad = localidad;
            this._pais = pais;
        }

        public CvDocencia()
        {
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((CvDocencia)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

    }
}
