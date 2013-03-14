
namespace General
{
    public class Docente
    {
        private int _id;
        private int _dni;
        private string _nombre;
        private string _apellido;

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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        
    }
}
