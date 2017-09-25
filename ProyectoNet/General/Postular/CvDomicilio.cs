using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvDomicilio
    {
        protected string _calle;
        protected int _numero;
        protected string _piso;
        protected string _depto;
        protected int _localidad;
        protected int _cp;
        protected int _provincia;


        public int Id { get; set; }
        public string Calle { get { return _calle; } set { _calle = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Depto { get { return _depto; } set { _depto = value; } }
        public int Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Cp { get { return _cp; } set { _cp = value; } }
        public int Provincia { get { return _provincia; } set { _provincia = value; } }
        public string Manzana { get; set; }
        public string Barrio { get; set; }
        public string Casa { get; set; }
        public string Torre { get; set; }
        public string Uf { get; set; }
        public int Partido { get; set; }
        public string NombreLocalidad { get; set; }
        public string NombreProvincia { get; set; }
          
        public int IdDocumentoGDE { get; set; }

        public string NombrePartido { get; set; }
        public string Telefono { get; set; }
        public string MailParticular { get; set; }

        public CvDomicilio(int id, string calle, int numero, string piso, string depto, int localidad, int cp, int provincia)
        {
            this._calle = calle;
            this._numero = numero;
            this._piso = piso;
            this._depto = depto;
            this._localidad = localidad;
            this._cp = cp;
            this._provincia = provincia;
            this.Id = id;

        }

        public CvDomicilio(int id, string calle, int numero, string piso, string depto, Localidad localidad, int cp, Provincia provincia, string manzana, string casa, string barrio, string torre, string uf, int idDocumentoGDE)
        {
            this._calle = calle;
            this._numero = numero;
            this._piso = piso;
            this._depto = depto;
            this.NombreLocalidad = localidad.Nombre;
            this.Localidad = localidad.Id;
            this._cp = cp;
            this.NombreProvincia = provincia.Nombre;
            this.Provincia = provincia.Id;
            this.Id = id;

            this.Manzana = manzana;
            this.Torre = torre;
            this.Uf = uf;
            this.Casa = casa;
            this.Barrio = barrio;
            this.IdDocumentoGDE = idDocumentoGDE;

        }

        public CvDomicilio(int id, string calle, int numero, string piso, string depto, Localidad localidad, int cp, Provincia provincia, string manzana, string casa, string barrio, string torre, string uf, int idDocumentoGDE, string nombrePartido, string telefono, string mailParticular)
        {
            this._calle = calle;
            this._numero = numero;
            this._piso = piso;
            this._depto = depto;
            this.NombreLocalidad = localidad.Nombre;
            this.Localidad = localidad.Id;
            this._cp = cp;
            this.NombreProvincia = provincia.Nombre;
            this.Provincia = provincia.Id;
            this.Id = id;

            this.Manzana = manzana;
            this.Torre = torre;
            this.Uf = uf;
            this.Casa = casa;
            this.Barrio = barrio;
            this.IdDocumentoGDE = idDocumentoGDE;

            this.NombrePartido = nombrePartido;
            this.Telefono = telefono;
            this.MailParticular = mailParticular;

        }


        public CvDomicilio()
        {
        }
    }
}
