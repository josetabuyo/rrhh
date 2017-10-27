using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Partido
    {
        private int _Id;
        private string _Nombre;
        private int _idProvincia;


        public int Id { get { return _Id; } set { _Id = value;  } }               
        public string Nombre {get { return _Nombre; } set { _Nombre = value;  }}
        public int IdProvincia { get { return _idProvincia; } set { _idProvincia = value; } }


        public Partido() {

        }


        public Partido(int Id, string Nombre, int idProvincia)
        {

            this.Id = Id;
            this.Nombre = Nombre;
            this.IdProvincia = idProvincia;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Partido)obj).Id;

        }

        public override int GetHashCode()
        {
                return Id;
        }

    }
}
