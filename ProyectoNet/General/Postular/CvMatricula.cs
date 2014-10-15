using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvMatricula : ItemCv
    {
        protected int _id;
        protected string _numero;
        protected string _expedidaPor;
        protected DateTime _fechaInscripcion;
        protected string _situacionActual;

        public int Id { get { return _id; } set { _id = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public string ExpedidaPor { get { return _expedidaPor; } set { _expedidaPor = value; } }
        public string SituacionActual { get { return _situacionActual; } set { _situacionActual = value; } }
        public DateTime FechaInscripcion { get { return _fechaInscripcion; } set { _fechaInscripcion = value; } }
        
        public CvMatricula(int id, string numero, string expedidaPor, string situacionActual, DateTime fechaInscripcion):base(id,numero)
        {
            this._id = id;
            this._numero = numero;
            this._expedidaPor = expedidaPor;
            this._situacionActual = situacionActual;
            this._fechaInscripcion = fechaInscripcion;
        }

        public CvMatricula()
        {
        }
    }
}
