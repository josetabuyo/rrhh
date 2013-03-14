using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace General
{

    public class GrupoConceptosDeLicencia
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value;  }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value;  }
        }

        private string _Detalle;
        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value;  }
        }
        public List<ConceptoDeLicencia> Conceptos { get; set; }
    }
}
