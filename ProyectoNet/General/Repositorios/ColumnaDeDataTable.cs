using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class ColumnaDeDataTable
    {
        public string NombreColumna { get; set; }
        public Type TipoColumna { get; set; }

        public ColumnaDeDataTable(string nombre_columna, Type tipo_columna)
        {
            this.NombreColumna = nombre_columna;
            this.TipoColumna = tipo_columna;
        }
    }
}