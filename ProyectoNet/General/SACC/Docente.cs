
namespace General
{
    public class Docente
    {
        private int _id;
        private int _dni;
        private string _nombre;
        private string _apellido;
        //por ahora agregue estos datos q no eran del docente para mostrarlo en la pantalla
        private string _telefono;
        private string _mail;
        private string _direccion;

        public virtual  string Telefono { get { return _telefono; } set { _telefono = value; } }
        public virtual string Mail { get { return _mail; } set { _mail = value; } }
        public virtual string Direccion { get { return _direccion; } set { _direccion = value; } }

        public Docente()
        {

        }
        public Docente(int id, int dni, string nombre, string apellido)
        {
            this._id = id;
            this._dni = dni;
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public virtual string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public virtual string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        internal int esMayorAlfabeticamenteQue(Docente otrodocente)
        {
            return this.Apellido.CompareTo(otrodocente.Apellido);
        }
    }
}
