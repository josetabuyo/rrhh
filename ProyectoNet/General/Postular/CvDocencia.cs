using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvDocencia
    {

        protected string _asignatura;
        protected string _nivelEducativo;
        protected string _tipoActividad;
        protected string _categoriaDocente;
        protected string _caracterDesignacion;
        protected string _dedicacionDocente;
        protected string _cargaHoraria;
        protected DateTime _fechaInicio;
        protected DateTime _fechaFinalizacion;
        protected string _establecimiento;
        protected string _localidad;
        protected string _pais;

        public string Asignatura { get { return _asignatura; } set { _asignatura = value; } }
        public string NivelEducativo { get { return _nivelEducativo; } set { _nivelEducativo = value; } }
        public string TipoActividad { get { return _tipoActividad; } set { _tipoActividad = value; } }
        public string CategoriaDocente { get { return _categoriaDocente; } set { _categoriaDocente = value; } }
        public string CaracterDesignacion { get { return _caracterDesignacion; } set { _caracterDesignacion = value; } }
        public string DedicacionDocente { get { return _dedicacionDocente; } set { _dedicacionDocente = value; } }
        public string CargaHoraria { get { return _cargaHoraria; } set { _cargaHoraria = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }


        public CvDocencia(string asignatura, string nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, DateTime fechaInicio, DateTime fechaFinalizacion, string establecimiento, string localidad, string pais)
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

    }
}
