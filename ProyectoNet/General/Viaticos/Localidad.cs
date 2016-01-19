using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Localidad
    {
        private int _Id;
        private string _Nombre;


        public int Id { get { return _Id; } set { _Id = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public int CodigoPostal { get; set; }
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public int IdPartido { get; set; }
        public string NombrePartido { get; set; }


        public Localidad()
        {

        }

        public Localidad(int Id, string Nombre)
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
    }
}
