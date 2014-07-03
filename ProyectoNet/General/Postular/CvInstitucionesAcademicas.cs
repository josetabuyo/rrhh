using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvInstitucionesAcademicas
    {
        protected int _id;
        protected string _institucion;
        protected string _caracterEntidad;
        protected string _cargosDesempeniados;
        protected int _numeroAfiliado;
        protected string _categoriaActual;
        protected DateTime _fechaDeAfiliacion;
        protected DateTime _fecha;
        protected DateTime _fechaInicio;
        protected DateTime _fechaFin;
        protected string _localidad;
        protected string _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string Institucion { get { return _institucion; } set { _institucion = value; } }
        public string CaracterEntidad { get { return _caracterEntidad; } set { _caracterEntidad = value; } }
        public string CargosDesempeniados { get { return _cargosDesempeniados; } set { _cargosDesempeniados = value; } }
        public int NumeroAfiliado { get { return _numeroAfiliado; } set { _numeroAfiliado = value; } }
        public string CategoriaActual { get { return _categoriaActual; } set { _categoriaActual = value; } }
        public DateTime FechaDeAfiliacion { get { return _fechaDeAfiliacion; } set { _fechaDeAfiliacion = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public string Pais { get { return _pais; } set { _pais = value; } }



        public CvInstitucionesAcademicas(int id, string institucion, string caracterEntidad, string cargosDesempeniados, int numeroAfiliado, string categoriaActual, DateTime fechaAfiliacion, DateTime fecha, DateTime fechaInicio, DateTime fechaFin, string localidad, string pais  )
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
    }
}
