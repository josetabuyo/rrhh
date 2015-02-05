using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvInstitucionesAcademicas : ItemCv
    {
        protected int _id;
        protected string _institucion;
        protected string _caracterEntidad;
        protected string _cargosDesempeniados;
        protected string _numeroAfiliado;
        protected string _categoriaActual;
        protected DateTime _fechaDeAfiliacion;
        protected DateTime _fecha;
        protected DateTime _fechaInicio;
        protected DateTime _fechaFin;
        protected string _localidad;
        protected int _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string Institucion { get { return _institucion; } set { _institucion = value; } }
        public string CaracterEntidad { get { return _caracterEntidad; } set { _caracterEntidad = value; } }
        public string CargosDesempeniados { get { return _cargosDesempeniados; } set { _cargosDesempeniados = value; } }
        public string NumeroAfiliado { get { return _numeroAfiliado; } set { _numeroAfiliado = value; } }
        public string CategoriaActual { get { return _categoriaActual; } set { _categoriaActual = value; } }
        public DateTime FechaDeAfiliacion { get { return _fechaDeAfiliacion; } set { _fechaDeAfiliacion = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }



        public CvInstitucionesAcademicas(int id, string institucion, string caracterEntidad, string cargosDesempeniados, string numeroAfiliado, string categoriaActual, DateTime fechaAfiliacion, DateTime fecha, DateTime fechaInicio, DateTime fechaFin, string localidad, int pais  ):base(id,institucion,7)
        {
            this._id = id;
            this._institucion = institucion;
            this._caracterEntidad = caracterEntidad;
            this._cargosDesempeniados = cargosDesempeniados;
            this._numeroAfiliado = numeroAfiliado;
            this._categoriaActual = categoriaActual;
            this._fechaDeAfiliacion = fechaAfiliacion;
            this._fecha = fecha;
            this._fechaInicio = fechaInicio;
            this._fechaFin = fechaFin;
            this._localidad = localidad;
            this._pais = pais;
        }

        public CvInstitucionesAcademicas()
        {
        }

        override public void validarDatos()
        {
            var validador_institucion = new Validador();

            validador_institucion.DeberianSerNoVacias(new string[] { "Institucion", "CaracterEntidad", "CargosDesempeniados", "NumeroAfiliado", "CategoriaActual", "Localidad" });
            validador_institucion.DeberianSerFechasNoVacias(new string[] { "FechaInicio", "FechaFin", "FechaDeAfiliacion", "Fecha" });
            validador_institucion.DeberianSerNaturalesOCero(new string[] { "Pais" });

            if (!validador_institucion.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeInstituciones(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPInstituciones();
        }
    }
}
