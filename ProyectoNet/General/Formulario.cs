using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Formulario
    {
        public int idFormulario  { get; set; }
        public int nroDocumento { get; set; }
        public List<Campo> campos { get; set; }
        public int idUsuario  { get; set; }

        public Formulario() {}

        public Formulario(int idForm, int documento, List<Campo> camp, int idUsu)
        {
            this.idFormulario = idForm;
            this.nroDocumento = documento;
            this.campos = camp;
            this.idUsuario = idUsu;
        }




    }
}
