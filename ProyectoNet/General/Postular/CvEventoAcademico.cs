using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvEventoAcademico : ItemCv
    {
        protected string _denominacion;

        protected int _tipoEvento;
        protected int _caracterDeParticipacion;
        protected int _institucion;

        protected DateTime _fechaInicio;
        protected DateTime _fechaFinalizacion;
        protected string _duracion;
        protected string _localidad;
        protected int _pais;

        protected int _unidadTiempo;


        public string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public int TipoDeEvento { get { return _tipoEvento; } set { _tipoEvento = value; } }
        public int CaracterDeParticipacion { get { return _caracterDeParticipacion; } set { _caracterDeParticipacion = value; } }
        public int Institucion { get { return _institucion; } set { _institucion = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        public int UnidadTiempo { get { return _unidadTiempo; } set { _unidadTiempo = value; } }

        public CvEventoAcademico(int id, string denominacion, int tipoDeEvento, int caracterDeParticipacion, DateTime fechaInicio, DateTime fechaFinalizacion, string duracion, int institucion, string localidad, int pais, int unidadtiempo):base(id,denominacion,4)
        {
            this.Id = id;
            this._denominacion = denominacion;
            this._tipoEvento = tipoDeEvento;
            this._caracterDeParticipacion = caracterDeParticipacion;
            this._institucion = institucion;
            this._fechaInicio = fechaInicio;
            this._fechaFinalizacion = fechaFinalizacion;
            this._duracion = duracion;
            this._localidad = localidad;
            this._pais = pais;
            this._unidadTiempo = unidadtiempo;
        }

        public CvEventoAcademico()
        {
        }

        override public void validarDatos()
        {
            var validador_evento = new Validador();

            validador_evento.DeberianSerNoVacias(new string[] { "Denominacion", "Duracion", "Localidad" });
            validador_evento.DeberianSerFechasNoVacias(new string[] { "FechaInicio", "FechaFinalizacion" });
            validador_evento.DeberianSerNaturalesOCero(new string[] { "Pais", "CaracterDeParticipacion", "TipoDeEvento", "Institucion" });

            if (!validador_evento.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeEventosAcademicos(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPEventosAcademicos();
        }
    }

}

