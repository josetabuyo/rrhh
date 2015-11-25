using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvEstudios:ItemCv
    {
        protected string _titulo;
        protected int _id_titulo;
        protected int _anios;
        protected string _establecimiento;
        protected int _nivel;
        protected DateTime _fechaIngreso;
        protected DateTime _fechaEgreso;
        protected string _localidad;
        protected int _pais;
        protected string _especialidad;

        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public int IdTitulo { get { return _id_titulo; } set { _id_titulo = value; } }
        public int Anios { get { return _anios; } set { _anios = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public int Nivel { get { return _nivel; } set { _nivel = value; } }
        public string Especialidad { get { return _especialidad; } set { _especialidad = value; } }
        public DateTime FechaIngreso { get { return _fechaIngreso; } set { _fechaIngreso = value; } }
        public DateTime FechaEgreso { get { return _fechaEgreso; } set { _fechaEgreso = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        //public const int IdTabla = 1;// { get { return 1; } set { } }


		public CvEstudios() { }
        public CvEstudios(string titulo, int id_titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais):base(0,titulo,1)
        {
            SetearCampos(titulo, id_titulo, nivel, anios, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);
        }

        public CvEstudios(int id, string titulo, int id_titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais):base(id, titulo,1)
        {
            this.Id = id;
            SetearCampos(titulo, id_titulo, nivel, anios, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);

        }

        private void SetearCampos(string titulo, int id_titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais)
        {
            this._titulo = titulo;
            this._id_titulo = id_titulo;
            this._establecimiento = establecimiento;
            this._nivel = nivel;
            this._anios = anios;
            this._especialidad = especialidad;
            this._fechaIngreso = fechaIngeso;
            this._fechaEgreso = fechaEgreso;
            this._localidad = localidad;
            this._pais = pais;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((CvEstudios)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        override public void validarDatos()
        {
            var validador_estudios = new Validador();

            validador_estudios.DeberianSerNoVacias(new string[] { "Titulo", "Establecimiento", "Localidad" });
            validador_estudios.DeberianSerFechasNoVacias(new string[] { "FechaIngreso", "FechaEgreso" });
            validador_estudios.DeberianSerNaturalesOCero(new string[] { "Nivel", "Anios", "Pais" });
            //  validador_estudios.DeberianSerNaturales(new string[] {  "Pais" });

            if (!validador_estudios.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosEstudios(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SpEstudios();
        }
    }
}
