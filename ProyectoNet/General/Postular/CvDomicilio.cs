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
        protected string _localidad;
        protected int _cp;
        protected string _provincia;

        public string Calle { get { return _calle; } set { _calle = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Depto { get { return _depto; } set { _depto = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Cp { get { return _cp; } set { _cp = value; } }
        public string Provincia { get { return _provincia; } set { _provincia = value; } }


        public CvDomicilio(string calle, int numero, string piso, string depto, string localidad, int cp, string provincia)
        {
            this._calle = calle;
            this._numero = numero;
            this._piso = piso;
            this._depto = depto;
            this._localidad = localidad;
            this._cp = cp;
            this._provincia = provincia;

        }

        public CvDomicilio()
        {
        }
    }
}
