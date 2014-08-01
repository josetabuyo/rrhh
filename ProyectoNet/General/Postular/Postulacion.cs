using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Postulacion
    {
        protected int _id;
        protected Puesto _puesto;
        protected int _idPersona;
        protected DateTime _fechaPostulacion;
        protected string _motivo;
        protected string _observaciones;

        public virtual int Id { get { return _id; } set { _id = value; } }
        public virtual Puesto Puesto { get { return _puesto; } set { _puesto = value; } }
        public virtual int IdPersona { get { return _idPersona; } set { _idPersona = value; } }
        public virtual DateTime FechaPostulacion { get { return _fechaPostulacion; } set { _fechaPostulacion = value; } }
        public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }

        public Postulacion(int id, Puesto puesto, int idPersona, DateTime fecha, string motivo, string observaciones) {
            _id = id;
            _puesto = puesto;
            _idPersona = idPersona;
            _fechaPostulacion = fecha;
            _motivo = motivo;
            _observaciones = observaciones;

        }

        public Postulacion() { }


    }
}
