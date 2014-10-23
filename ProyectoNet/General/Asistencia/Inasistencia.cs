using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class Inasistencia
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        private string _PathFormularioWeb;
        public string PathFormularioWeb
        {
            get { return _PathFormularioWeb; }
            set { _PathFormularioWeb = value;  }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value;  }
        }

        private bool _Aprobada;
        public bool Aprobada
        {
            get { return _Aprobada; }
            set { _Aprobada = value;  }
        }

        private DateTime _Desde;
        public DateTime Desde
        {
            get { return _Desde; }
            set { _Desde = value;  }
        }

        private DateTime _Hasta;
        public DateTime Hasta
        {
            get { return _Hasta; }
            set { _Hasta = value;  }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
