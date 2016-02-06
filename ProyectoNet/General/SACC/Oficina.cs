
namespace General
{
    public class Oficina
    {
        private int _id;
        private string _nombre;
        private string _piso;
        private string _dto;
        private string _uf;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Dto { get { return _dto; } set { _dto = value; } }
        public string UF { get { return _uf; } set { _uf = value; } }
      
        public Oficina() 
        {
        }

        public Oficina(int id, string nombre, string piso, string dto, string uf)
        {
            this._id = id;
            this._nombre = nombre;
            this._piso = piso;
            this._dto = dto;
            this._uf = uf;

        }      
    }
}
