
namespace General
{
    public class Edificio
    {
        private int _id;
        private string _nombre;
        private string _direccion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }


        public Edificio() 
        {
        }

        public Edificio(int id, string nombre, string direccion)
        {
            this._id = id;
            this._nombre = nombre;
            this._direccion = direccion;

        }

        internal int esMayorAlfabeticamenteQue(Edificio otroedificio)
        {
            return this.Nombre.CompareTo(otroedificio.Nombre);
        }
    }
}
