using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Formulario
    {
        public int idFormulario  { get; set; }
        public int idPersona { get; set; }
        public List<Campo> campos { get; set; }
        public int idUsuario  { get; set; }

        public Formulario() {}

        public Formulario(int idForm, int id_persona, List<Campo> camp, int idUsu)
        {
            this.idFormulario = idForm;
            this.idPersona = id_persona;
            this.campos = camp;
            this.idUsuario = idUsu;
        }




    }
}
