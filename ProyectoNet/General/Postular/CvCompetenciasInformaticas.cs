using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvCompetenciasInformaticas : ItemCv
    {
        protected string _diploma;
        protected DateTime _fechaObtencion;
        protected string _establecimiento;
        protected int _tipoInformatica;
        protected int _conocimiento;
        protected int _nivel;
     
        protected string _localidad;
        protected int _pais;
        protected string _detalle;

        public string Diploma { get { return _diploma; } set { _diploma = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public int TipoInformatica { get { return _tipoInformatica; } set { _tipoInformatica = value; } }
        public int Conocimiento { get { return _conocimiento; } set { _conocimiento = value; } }
        public int Nivel { get { return _nivel; } set { _nivel = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        public DateTime FechaObtencion { get { return _fechaObtencion; } set { _fechaObtencion = value; } }
        public string Detalle { get { return _detalle; } set { _detalle = value; } }

        public CvCompetenciasInformaticas(int id, string diploma, string establecimiento, int tipoInformatica, int conocimiento, int nivel, string localidad, int pais, DateTime fechaObtencion, string detalle):base(id,diploma,10)
        {
            this.Id = id;
            this._diploma = diploma;
            this._establecimiento = establecimiento;
            this._tipoInformatica = tipoInformatica;
            this._conocimiento = conocimiento;
            this._nivel = nivel;
            this._localidad = localidad;
            this._pais = pais;
            this._fechaObtencion = fechaObtencion;
            this._detalle = detalle;
        }

        public CvCompetenciasInformaticas()
        {
        }

        override public void validarDatos()
        {
            var validador_competencia = new Validador();

            validador_competencia.DeberianSerNoVacias(new string[] { "Diploma", "Detalle", "Establecimiento", "Localidad" });
            validador_competencia.DeberianSerFechasNoVacias(new string[] { "FechaObtencion" });
            validador_competencia.DeberianSerNaturalesOCero(new string[] { "TipoInformatica", "Conocimiento", "Nivel", "Pais" });

            if (!validador_competencia.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeCompetenciasInformaticas(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPCompetenciasInformaticas();
        }
    }
}
