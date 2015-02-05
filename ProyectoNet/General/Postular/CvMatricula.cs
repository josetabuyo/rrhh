using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using General.MAU;

namespace General
{
    public class CvMatricula : ItemCv
    {
        protected int _id;
        protected string _numero;
        protected string _expedidaPor;
        protected DateTime _fechaInscripcion;
        protected string _situacionActual;

        public int Id { get { return _id; } set { _id = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public string ExpedidaPor { get { return _expedidaPor; } set { _expedidaPor = value; } }
        public string SituacionActual { get { return _situacionActual; } set { _situacionActual = value; } }
        public DateTime FechaInscripcion { get { return _fechaInscripcion; } set { _fechaInscripcion = value; } }
        
        public CvMatricula(int id, string numero, string expedidaPor, string situacionActual, DateTime fechaInscripcion):base(id,numero,6)
        {
            this._id = id;
            this._numero = numero;
            this._expedidaPor = expedidaPor;
            this._situacionActual = situacionActual;
            this._fechaInscripcion = fechaInscripcion;
        }

        public CvMatricula()
        {
        }

        override public void validarDatos()
        {
            var validador_matricula = new Validador();

            validador_matricula.DeberianSerNoVacias(new string[] { "Numero", "ExpedidaPor", "SituacionActual" });
            validador_matricula.DeberianSerFechasNoVacias(new string[] { "FechaInscripcion" });

            if (!validador_matricula.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeMatricula(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPMatriculas();
        }
    }
}
