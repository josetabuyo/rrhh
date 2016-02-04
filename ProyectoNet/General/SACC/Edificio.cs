
namespace General
{
    public class Edificio
    {
        private int _id;
        private string _nombre;
        private string _direccion;
        private Area _area;
        string _calle;
        int _numero;
        Localidad _localidad;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public Area Area { get { return _area; } set { _area = value; } }
        public string Calle { get { return _calle; } set { _calle = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }
        public Localidad Localidad { get { return _localidad; } set { _localidad = value; } }

        public Edificio() 
        {
        }

        public Edificio(int id, string nombre, string direccion, Area area)
        {
            this._area = new Area();
            this._id = id;
            this._nombre = nombre;
            this._direccion = direccion;
            this._area = area;

        }

        internal int esMayorAlfabeticamenteQue(Edificio otroedificio)
        {
            return this.Nombre.CompareTo(otroedificio.Nombre);
        }
    }
}
