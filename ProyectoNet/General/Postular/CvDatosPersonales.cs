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
        protected int _estadoCivil;
        protected string _cuil;
        protected string _lugarNacimiento;
        protected int _nacionalidad;
        protected string _fechaNacimiento;
        protected int _tipoDocumento;
        protected CvDomicilio _domicilioPersonal;
        protected CvDomicilio _domicilioLegal;

        public int Dni { get { return _dni; } set { _dni = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Sexo { get { return _sexo; } set { _sexo = value; } }
        public int EstadoCivil { get { return _estadoCivil; } set { _estadoCivil = value; } }
        public string Cuil { get { return _cuil; } set { _cuil = value; } }
        public string LugarDeNacimiento { get { return _lugarNacimiento; } set { _lugarNacimiento = value; } }
        public int Nacionalidad { get { return _nacionalidad; } set { _nacionalidad = value; } }
        public string FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public int TipoDocumento { get { return _tipoDocumento; } set { _tipoDocumento = value; } }
        public CvDomicilio DomicilioPersonal { get { return _domicilioPersonal; } set { _domicilioPersonal = value; } }
        public CvDomicilio DomicilioLegal { get { return _domicilioLegal; } set { _domicilioLegal = value; } }

        public CvDatosPersonales(int dni, string nombre, string apellido, string sexo, int estadoCivil, string cuil, string lugarNacimiento, int nacionalidad, string fechaNacimiento, int tipoDocumento, CvDomicilio domicilio_personal, CvDomicilio domicilio_legal)
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

            this._domicilioPersonal = domicilio_personal;
            this._domicilioLegal = domicilio_legal;
        }

        public CvDatosPersonales()
        {
        }
    }
}