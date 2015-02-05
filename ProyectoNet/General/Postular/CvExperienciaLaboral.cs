using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using General.Postular;
using General.MAU;

namespace General
{
    public class CvExperienciaLaboral : ItemCv
    {
        protected int _id;
        protected string _puestoOcupado;
        protected string _motivoDesvinculacion;
        protected string _nombreEmpleador;     
        protected DateTime _fechaInicio;
        protected DateTime _fechaFin;
        protected string _localidad;
        protected int _pais;
        protected int _personasACargo;
        protected string _tipoEmpresa;
        protected string _actividad;
        protected string _sector;
        protected int _ambitoLaboral;

        public int Id { get { return _id; } set { _id = value; } }
        public string PuestoOcupado { get { return _puestoOcupado; } set { _puestoOcupado = value; } }
        public string MotivoDesvinculacion { get { return _motivoDesvinculacion; } set { _motivoDesvinculacion = value; } }
        public string NombreEmpleador { get { return _nombreEmpleador; } set { _nombreEmpleador = value; } }
        public int PersonasACargo { get { return _personasACargo; } set { _personasACargo = value; } }
        public string TipoEmpresa { get { return _tipoEmpresa; } set { _tipoEmpresa = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        public string Actividad { get { return _actividad; } set { _actividad = value; } }
        public string Sector { get { return _sector; } set { _sector = value; } }
        public int AmbitoLaboral { get { return _ambitoLaboral; } set { _ambitoLaboral = value; } }

        public CvExperienciaLaboral()
        {
        }

        public CvExperienciaLaboral(int id, string puestoOcupado, string motivoDesvinculacion, string nombreEmpleador, int personasACargo, string tipoEmpresa, string actividad, DateTime fechaInicio, DateTime fechaFin, string localidad, int pais, string sector, int AmbitoLaboral):base(id, puestoOcupado,8)
        {
            this._id = id;
            this._puestoOcupado = puestoOcupado;
            this._motivoDesvinculacion = motivoDesvinculacion;
            this._nombreEmpleador = nombreEmpleador;
            this._personasACargo = personasACargo;
            this._tipoEmpresa = tipoEmpresa;
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
            this._localidad = localidad;
            this._pais = pais;
            this._actividad = actividad;
            this._sector = sector;
            this._ambitoLaboral = AmbitoLaboral;
        }

        override public void validarDatos()
        {
            var validador_experiencia = new Validador();

            validador_experiencia.DeberianSerNoVacias(new string[] { "PuestoOcupado", "Actividad", "NombreEmpleador", "TipoEmpresa", "Sector", "Localidad" });
            validador_experiencia.DeberianSerFechasNoVacias(new string[] { "FechaInicio", "FechaFin" });
            validador_experiencia.DeberianSerNaturalesOCero(new string[] { "Pais" });
            validador_experiencia.DeberianSerNaturalesOCero(new string[] { "PersonasACargo" });

            if (!validador_experiencia.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeExperiencias(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPExperienciasLaborales();
        }
    }
}
