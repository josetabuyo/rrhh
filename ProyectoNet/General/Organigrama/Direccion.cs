using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Direccion
    {
        private int _idEdificio;
        private string _edificio;
        private string _calle;
        private int _numero;
        private Localidad _localidad;
        private int _idOficina;
        private string _piso;
        private string _dto;
        private string _uf;
        private string _descripcion;
        private int _codigoPostal;

        

        public string CP { get; set; }
        public string Provincia { get; set; }
        public int IdEdificio { get { return _idEdificio; } set { _idEdificio = value; } }
        public string Edificio { get { return _edificio; } set { _edificio = value; } }
        public string Calle { get { return _calle; } set { _calle = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }
        public Localidad Localidad { get { return _localidad; } set { _localidad = value; } }
        public int IdOficina { get { return _idOficina; } set { _idOficina = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Dto { get { return _dto; } set { _dto = value; } }
        public string UF { get { return _uf; } set { _uf = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public int CodigoPostal { get { return _codigoPostal; } set { _codigoPostal = value; } }
       

        public Direccion()
        {
                
        }

        public Direccion(string calle, string cp, Localidad localidad, string provincia)
        {
            this.Calle = calle;
            this.CP = cp;
            this.Localidad = localidad;
            this.Provincia = provincia;
        }

        public Direccion(int id_edificio, string edificio, string calle, int numero, Localidad localidad, int id_oficina, string piso, string dto, string uf, string descripcion, int codigo_postal)
        {
            this._idEdificio = id_edificio;
            this._edificio = edificio;
            this._calle = calle;
            this._numero = numero;
            this._localidad = localidad;
            this._idOficina = id_oficina;
            this._piso = piso;
            this._dto = dto;
            this._uf = uf;
            this._descripcion = descripcion;
            this._codigoPostal = codigo_postal;
        }
    }
}
