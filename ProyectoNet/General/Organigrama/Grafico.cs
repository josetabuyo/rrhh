using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class Grafico
    {
        private List<object> tabla_resultado;
        private List<object> tabla_detalle;

        public Grafico()
        {


        }



        internal void CrearDatos(int tipo, List<RowDeDatos> list)
        {
            if (tipo == 1)
            {
                CrearDatosDeGenero(list);
            }
        }

        private void CrearDatosDeGenero(List<RowDeDatos> list)
        {
            list.ForEach(row =>
            {
                
            });
        }


    }
}
