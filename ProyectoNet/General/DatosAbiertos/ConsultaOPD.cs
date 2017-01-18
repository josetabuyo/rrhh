using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.DatosAbiertos;

namespace General.DatosAbiertos
{
    public class ConsultaOPD
    {
        public int Id;
        public string Nombre;
        public string Descripcion;
        public string SP;
        public int Funcionalidad;

        public List<ParametroConsultaOPD> Parametros;
        public ConsultaOPD()
        {
            Parametros = new List<ParametroConsultaOPD>();
        }

    }
}
