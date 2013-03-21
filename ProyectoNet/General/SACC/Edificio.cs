
namespace General
{
    public class Edificio
    {
        private int _id;
        private string _descripcion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public Edificio() 
        {
        }

        public Edificio(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }
    }
}
