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
        protected string _numero;
        protected string _estado;

        public virtual int Id { get { return _id; } set { _id = value; } }
        public virtual Puesto Puesto { get { return _puesto; } set { _puesto = value; } }
        public virtual int IdPersona { get { return _idPersona; } set { _idPersona = value; } }
        public virtual DateTime FechaPostulacion { get { return _fechaPostulacion; } set { _fechaPostulacion = value; } }
        public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual string Numero { get { return _numero; } set { _numero = value; } }
        public virtual string Estado { get { return _estado; } set { _estado = value; } }

        public Postulacion(int id, Puesto puesto, int idPersona, DateTime fecha, string motivo, string observaciones, string numero, string estado) {
            _id = id;
            _puesto = puesto;
            _idPersona = idPersona;
            _fechaPostulacion = fecha;
            _motivo = motivo;
            _observaciones = observaciones;
            _numero = numero;
        }

        public Postulacion() { }

    }
}
