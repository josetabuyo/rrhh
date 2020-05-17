namespace General
{
    public class MoBi_Vehiculo
    {
        protected int _id;
        protected int _numeroVehiculo;
        protected string _dominio;
        protected string _segmento;
        protected string _marca;
        protected string _modelo;
        protected string _motor;
        protected string _chasis;
        protected int _anio;
        protected string _observacion;

        public int Id { get { return _id; } set { _id = value; } }
        public int NumeroVehiculo { get { return _numeroVehiculo; } set { _numeroVehiculo = value; } }
        public string Dominio { get { return _dominio; } set { _dominio = value; } }
        public string Segmento { get { return _segmento; } set { _segmento = value; } }
        public string Marca { get { return _marca; } set { _marca = value; } }
        public string Modelo { get { return _modelo; } set { _modelo = value; } }
        public string Motor { get { return _motor; } set { _motor = value; } }
        public string Chasis { get { return _chasis; } set { _chasis = value; } }
        public int Anio { get { return _anio; } set { _anio = value; } }
        public string Observacion { get { return _observacion; } set { _observacion = value; } }

    }

}
