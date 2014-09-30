using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class Postulacion
    {
        protected int _id;
      /*  protected Puesto _puesto;*/
        protected Perfil _perfil;
        protected int _idPersona;
        protected DateTime _fechaPostulacion;
        protected string _motivo;
        protected string _observaciones;
        protected string _numero;
        protected List<EtapaPostulacion> _etapas;

        public virtual int Id { get { return _id; } set { _id = value; } }
        //public virtual Puesto Puesto { get { return _perfil; } set { _perfil = value; } }
        public virtual Perfil Puesto { get { return _perfil; } set { _perfil = value; } }
        public virtual int IdPersona { get { return _idPersona; } set { _idPersona = value; } }
        public virtual DateTime FechaPostulacion { get { return _fechaPostulacion; } set { _fechaPostulacion = value; } }
        public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual string Numero { get { return _numero; } set { _numero = value; } }
        public virtual List<EtapaPostulacion> Etapas { get { return _etapas; } set { _etapas = value;} }  

       
        public Postulacion(int id, Perfil perfil, int idPersona, DateTime fecha, string motivo, string observaciones, string numero, List<EtapaPostulacion> etapas)
        {
            _id = id;
            _perfil = perfil;
            _idPersona = idPersona;
            _fechaPostulacion = fecha;
            _motivo = motivo;
            _observaciones = observaciones;
            _numero = numero;
            _etapas = etapas;
        }

        public Postulacion() {
            this._etapas = new List<EtapaPostulacion>();
        }


        public EtapaPostulacion EtapaEn(DateTime fecha)
        {
            return this.Etapas.FindLast(e => e.Fecha <= fecha);
        }

        internal void AgregarPostulacion(EtapaPostulacion ep)
        {
            this._etapas.Add(ep);
        }
    }
}
