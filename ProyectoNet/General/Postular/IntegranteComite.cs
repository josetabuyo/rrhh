using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
    public class IntegranteComite
    {

        protected int _id;
        protected string _nombre;
        protected string _apellido;
        protected string _tipoDocumento;
        protected int _nroDocumento;
        protected bool _titular;

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string TipoDocumento { get { return _tipoDocumento; } set { _tipoDocumento = value; } }
        public int NroDocumento { get { return _nroDocumento; } set { _nroDocumento = value; } }
        public bool EsTitular { get { return _titular; } set { _titular = value; } }

        public IntegranteComite()
        {

        }
    }
}
