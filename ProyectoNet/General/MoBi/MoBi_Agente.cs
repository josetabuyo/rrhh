using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MoBi_Agente
    {
        private int _Id;
        private string _Apellido;
        private string _Nombre;
        private int _Documento;
        private string _Descipcion;

        public string Descripcion
        {
            get { return _Descipcion; }
            set { _Descipcion = value; }
        }

        public int Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        
    }

}
