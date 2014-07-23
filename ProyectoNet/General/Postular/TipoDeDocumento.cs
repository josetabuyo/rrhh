using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class TipoDeDocumento
    {
        public int Id;
        public string Descripcion;

        public TipoDeDocumento()
        {

        }

        public TipoDeDocumento(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
