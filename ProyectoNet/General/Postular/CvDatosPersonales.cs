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
        protected int _sexo;
        protected int _estadoCivil;
        protected string _cuil;
        protected string _lugarNacimiento;
        protected int _nacionalidad;
        protected string _fechaNacimiento;
        protected int _tipoDocumento;
        protected CvDomicilio _domicilioPersonal;
        protected CvDomicilio _domicilioLegal;
        protected string _legajo;
        protected string _telefono;
        protected string _telefono2;
        protected string _email;

        public int Dni { get { return _dni; } set { _dni = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public int Sexo { get { return _sexo; } set { _sexo = value; } }
        public int EstadoCivil { get { return _estadoCivil; } set { _estadoCivil = value; } }
        public string Cuil { get { return _cuil; } set { _cuil = value; } }
        public string LugarDeNacimiento { get { return _lugarNacimiento; } set { _lugarNacimiento = value; } }
        public int Nacionalidad { get { return _nacionalidad; } set { _nacionalidad = value; } }
        public string FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }
        public int TipoDocumento { get { return _tipoDocumento; } set { _tipoDocumento = value; } }
        public CvDomicilio DomicilioPersonal { get { return _domicilioPersonal; } set { _domicilioPersonal = value; } }
        public CvDomicilio DomicilioLegal { get { return _domicilioLegal; } set { _domicilioLegal = value; } }
        public string TieneLegajo { get { return _legajo; } set { _legajo = value; } }
        public string Telefono { get {return _telefono;} set { _telefono = value; } }
        public string Telefono2 { get {return _telefono2;} set { _telefono2 = value; } }
        public string Email { get { return _email; } set { _email = value; } }

        public CvDatosPersonales(int dni, string nombre, string apellido, int sexo, int estadoCivil, string cuil, string lugarNacimiento, int nacionalidad, string fechaNacimiento, int tipoDocumento, CvDomicilio domicilio_personal, CvDomicilio domicilio_legal, string tiene_legajo, string telefono, string telefono2, string email)
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

            this._legajo = tiene_legajo;
            this._telefono = telefono;
            this._telefono2 = telefono2;
            this._email = email;
        }

        public CvDatosPersonales()
        {
        }
    }
}