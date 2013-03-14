namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeComisiones
    {
        private Func<List<ComisionDeServicio>, List<ComisionDeServicio>> metodo;

        public FiltroDeComisiones()
        { }

        public FiltroDeComisiones(Func<List<ComisionDeServicio>, List<ComisionDeServicio>> metodo)
        {
            this.metodo = metodo;
        }

        public List<ComisionDeServicio> Filtrar(List<ComisionDeServicio> lista)
        {
            return metodo.Invoke(lista);
        }




    }
}
