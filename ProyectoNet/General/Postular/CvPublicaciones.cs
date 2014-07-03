using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvPublicaciones
    {
        protected int _id;
        protected string _titulo;
        protected string _datosEditorial;
        protected string _cantidadHojas;
        protected bool _disponeCopia;
        protected DateTime _fechaPublicacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string DatosEditorial { get { return _datosEditorial; } set { _datosEditorial = value; } }
        public string CantidadHojas { get { return _cantidadHojas; } set { _cantidadHojas = value; } }
        public bool DisponeCopia { get { return _disponeCopia; } set { _disponeCopia = value; } }
        public DateTime FechaPublicacion { get { return _fechaPublicacion; } set { _fechaPublicacion = value; } }

        public CvPublicaciones(int id, string titulo, string datosEditorial, string cantidadHojas, bool disponeCopia, DateTime fechaPublicacion)
        {
            this._id = id;
            this._titulo = titulo;
            this._datosEditorial = datosEditorial;
            this._cantidadHojas = cantidadHojas;
            this._disponeCopia = disponeCopia;
            this._fechaPublicacion = fechaPublicacion;

        }

        public CvPublicaciones()
        {
        }

    }
}
