using System;
using System.Collections.Generic;

using System.Text;
using General;

namespace General
{
    public class Zona
    {
        private int _Id;
        private string _Nombre;
        private List<Provincia> _Provincias;

        public int Id { get { return _Id; } set { _Id = value;  } }
        
        public string Nombre { get { return _Nombre; } set { _Nombre = value;  } }

        public List<Provincia> Provincias { get { return _Provincias ;} set{ _Provincias = value;}}

        public Zona()
        {
            
        }

        public Zona(int id, string nombre)
        {
            this._Id = id;
            this._Nombre = nombre;
            this.Provincias = new List<Provincia>();
        }

    }
}
