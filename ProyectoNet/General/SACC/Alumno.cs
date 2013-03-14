
namespace General
{
    public class Alumno
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _documento;
      //  private Area _area;
        private Modalidad _modalidad;
        private string _telefono;
        private string _mail;
        private string _direccion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public int Documento { get { return _documento; } set { _documento = value; } }
     //   public Area Area { get { return _area; } set { _area = value; } }
        public Modalidad Modalidad { get { return _modalidad; } set { _modalidad = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, int documento, string telefono, string mail, string direccion, Area area, Modalidad modalidad)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._documento = documento;
            this._telefono = telefono;
            this._mail = mail;
            this._direccion = direccion;
      //      this._area = area;
            this._modalidad = modalidad;
        }



        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((Alumno)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
