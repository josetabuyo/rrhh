using System;
using System.Collections.Generic;
using System.Data;

namespace General.Repositorios
{
    public class GeneradorDeDataTables
    {
        public TablaDeDatos CreateDT(List<Object> entidades, List<ColumnaDeDataTable> columnas, Func<Object, List<Object>> metodo_constructor_de_fila)
        {
            var tabla_de_datos = new TablaDeDatos();
            //agrego titulos    
            columnas.ForEach(c => { tabla_de_datos.Columns.Add(c.NombreColumna, c.TipoColumna); });
            //agrego elementos adadasddad
            entidades.ForEach(e =>
            {
                tabla_de_datos.LoadDataRow(metodo_constructor_de_fila.Invoke(e).ToArray(), true);
            });

            return tabla_de_datos;
            //  return tabla_de_datos;
        }
    }
}