using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PersonaVisita
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private string _Nombre;
        public string Nombre
        {
            set { this._Nombre = value; }
            get { return this._Nombre; }
        }

        private string _Apellido;
        public string Apellido
        {
            set { this._Apellido = value; }
            get { return this._Apellido; }
        }

        private int _Documento;
        public int Documento
        {
            set { this._Documento = value; }
            get { return this._Documento; }
        }

        private int _Telefono;
        public int Telefono
        {
            set { this._Telefono = value; }
            get { return this._Telefono; }
        }
    }

}
