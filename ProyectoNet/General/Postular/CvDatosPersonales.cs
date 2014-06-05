using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvDatosPersonales
    {
        protected int _dni;
        protected string _nombre;
        protected string _apellido;
        protected string _sexo;
        protected string _estadoCivil;
        protected string _cuil;
        protected string _lugarNacimiento;
        protected string _nacionalidad;
        protected DateTime _fechaNacimiento;
        protected string _tipoDocumento;
        protected CvDomicilio _domicilio;

        public int Dni { get { return _dni; } set { _dni = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Sexo { get { return _sexo; } set { _sexo = value; } }
        public string EstadoCivil { get { return _estadoCivil; } set { _estadoCivil = value; } }
        public string Cuil { get { return _cuil; } set { _cuil = value; } }
        public string LugarDeNacimiento { get { return _lugarNacimiento; } set { _lugarNacimiento = value; } }
        public string Nacionalidad { get { return _nacionalidad; } set { _nacionalidad = value; } }
        public DateTime FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public string TipoDocumento { get { return _tipoDocumento; } set { _tipoDocumento = value; } }
        public CvDomicilio Domicilio { get { return _domicilio; } set { _domicilio = value; } }

        public CvDatosPersonales(int dni, string nombre, string apellido, string sexo, string estadoCivil, string cuil, string lugarNacimiento, string nacionalidad, DateTime fechaNacimiento, string tipoDocumento, CvDomicilio domicilio)
        {
            this._dni = dni;
            this._nombre = nombre;
            this._apellido = apellido;
            this._sexo = sexo;
            this._estadoCivil = estadoCivil;
            this._cuil = cuil;
            this._lugarNacimiento = lugarNacimiento;
            this._nacionalidad = nacionalidad;
            this._fechaNacimiento = fechaNacimiento;
            this._tipoDocumento = tipoDocumento;
            
            this._domicilio = domicilio;
        }

        public CvDatosPersonales()
        {
        }
    }
}
