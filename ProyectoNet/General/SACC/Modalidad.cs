
namespace General
{
    public class Modalidad
    {
        private int _id;
        private string _descripcion;
        private EstructuraDeEvaluacion _estructuraDeEvaluacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public EstructuraDeEvaluacion EstructuraDeEvaluacion { get { return _estructuraDeEvaluacion; } set { _estructuraDeEvaluacion = value; } }

        public Modalidad()
        {
        }

        public Modalidad(int id, string descripcion)
        {
            this._id = id;
            this._descripcion = descripcion;
        }

        public Modalidad(int id, string descripcion, EstructuraDeEvaluacion estructura)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._estructuraDeEvaluacion = estructura;
        }
    }
}
