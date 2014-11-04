using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class CvDocencia : ItemCv
    {
        protected int _id;
        protected string _asignatura;
        protected int _nivelEducativo;
        protected string _tipoActividad;
        protected string _categoriaDocente;
        protected string _caracterDesignacion;
        protected string _dedicacionDocente;
        protected string _cargaHoraria;
        protected DateTime _fechaInicio;
        protected DateTime _fechaFinalizacion;
        protected string _establecimiento;
        protected string _localidad;
        protected int _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string Asignatura { get { return _asignatura; } set { _asignatura = value; } }
        public int NivelEducativo { get { return _nivelEducativo; } set { _nivelEducativo = value; } }
        public string TipoActividad { get { return _tipoActividad; } set { _tipoActividad = value; } }
        public string CategoriaDocente { get { return _categoriaDocente; } set { _categoriaDocente = value; } }
        public string CaracterDesignacion { get { return _caracterDesignacion; } set { _caracterDesignacion = value; } }
        public string DedicacionDocente { get { return _dedicacionDocente; } set { _dedicacionDocente = value; } }
        public string CargaHoraria { get { return _cargaHoraria; } set { _cargaHoraria = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }


        public CvDocencia(string asignatura, int nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, DateTime fechaInicio, DateTime fechaFinalizacion, string establecimiento, string localidad, int pais):base(0, asignatura,3)
        {
            SetearCampos(asignatura, nivelEducativo, tipoActividad, categoriaDocente, caracterDesignacion, dedicacionDocente, cargaHoraria, fechaInicio, fechaFinalizacion, establecimiento, localidad, pais);
        }

        public CvDocencia(int id, string asignatura, int nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, DateTime fechaInicio, DateTime fechaFinalizacion, string establecimiento, string localidad, int pais):base(id, asignatura,3)
           
        {
            this._id = id;
            SetearCampos(asignatura, nivelEducativo, tipoActividad, categoriaDocente, caracterDesignacion, dedicacionDocente, cargaHoraria, fechaInicio, fechaFinalizacion, establecimiento, localidad, pais);
        }



        private void SetearCampos(string asignatura, int nivelEducativo, string tipoActividad, string categoriaDocente, string caracterDesignacion, string dedicacionDocente, string cargaHoraria, DateTime fechaInicio, DateTime fechaFinalizacion, string establecimiento, string localidad, int pais)
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
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
