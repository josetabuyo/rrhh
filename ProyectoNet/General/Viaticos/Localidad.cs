using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Localidad
    {
        private int _Id;
        private string _Nombre;
        public int IdProvincia { get; set; }
        public int IdPartido { get; set; }

        public int Id
        {
            get { return _Id; }
            set { _Id = value;  }
        }

        
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value;  }
        }

       

        public Localidad()
        {
              
        }

        public Localidad( int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }

        public Localidad(int Id, string Nombre, int id_provincia)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.IdProvincia = id_provincia;
        }

        public Localidad(int Id, string Nombre, int id_provincia, int idPartido)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.IdProvincia = id_provincia;
            this.IdPartido = idPartido;
        }
    }
}
