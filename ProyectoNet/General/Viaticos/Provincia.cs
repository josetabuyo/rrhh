using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Provincia
    {
        private int _Id;
        private string _Nombre;
        private int _CodigoAFIP;
        private Zona _zona;

        public int Id { get { return _Id; } set { _Id = value;  } }               
        public string Nombre {get { return _Nombre; } set { _Nombre = value;  }}
        public int CodigoAFIP {get { return _CodigoAFIP; } set { _CodigoAFIP = value;  }}
        public List<Localidad> Localidades { get; set; }
        public Zona Zona { get { return _zona; } set { _zona = value; } }

        public Provincia() {

            this.Localidades = new List<Localidad>();
        }


        public Provincia( int Id, string Nombre)
        {

            this.Localidades = new List<Localidad>();
            this.Id = Id;
            this.Nombre = Nombre;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Provincia)obj).Id;

        }

        public override int GetHashCode()
        {
           
                return Id;
                //result = (result * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                //result = (result * 397) ^ Type.GetHashCode();
                //result = (result * 397) ^ (MainColumn != null ? MainColumn.GetHashCode() : 0);
                //result = (result * 397) ^ (childColumns != null ? childColumns.GetHashCode() : 0);
                //return result;
           
        }

    }
}
