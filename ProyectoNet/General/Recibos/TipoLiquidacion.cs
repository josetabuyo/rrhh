using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class TipoLiquidacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Meses_Retraso { get; set; }

        public TipoLiquidacion(int id, string descripcion,int meses_retraso)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Meses_Retraso = meses_retraso;
        }

        public TipoLiquidacion()
        {
        }

    }
}

