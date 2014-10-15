using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvCertificadoDeCapacitacion : ItemCv
    {
        protected int _id;
        protected string _diplomaDeCertificacion;
        protected string _establecimiento;
        protected DateTime _fechaInicio;
        protected DateTime _fechaFinalizacion;
        protected string _duracion;
        protected string _especialidad;
        protected string _localidad;
        protected int _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string DiplomaDeCertificacion { get { return _diplomaDeCertificacion; } set { _diplomaDeCertificacion = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public string Especialidad { get { return _especialidad; } set { _especialidad = value; } }
        public string Duracion { get { return _duracion; } set { _duracion = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }

        public CvCertificadoDeCapacitacion(int id, string diplomaDeCertificacion, string establecimiento, string especialidad, string duracion, DateTime fechaInicio, DateTime fechaFinalizacion, string localidad, int pais):base(id,diplomaDeCertificacion)
        {
            this._id = id;
            this._diplomaDeCertificacion = diplomaDeCertificacion;
            this._establecimiento = establecimiento;
            this._especialidad = especialidad;
            this._fechaInicio = fechaInicio;
            this._fechaFinalizacion = fechaFinalizacion;
            this._duracion = duracion;
            this._localidad = localidad;
            this._pais = pais;
        }

        public CvCertificadoDeCapacitacion()
        {
        }
    }
}
