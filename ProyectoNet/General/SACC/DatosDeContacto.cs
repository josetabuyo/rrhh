using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class DatoDeContacto
    {
        private int _id;
        private string _tipo_contacto;
        private string _dato;
        private int _orden;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _tipo_contacto; } set { _tipo_contacto = value; } }
        public string Dato { get { return _dato; } set { _dato = value; } }
        public int Orden { get { return _orden; } set { _orden = value; } }


        public DatoDeContacto( int id, string tipo_de_contacto, string dato, int orden)
        {
            _id = id;
            _tipo_contacto = tipo_de_contacto;
            _dato = dato;
            _orden = orden;
        }


        public DatoDeContacto()
        {
        }

        internal int esMayorQue(DatoDeContacto otrodato)
        {
            return this.Orden.CompareTo(otrodato.Orden);
        }
  
    }
}
