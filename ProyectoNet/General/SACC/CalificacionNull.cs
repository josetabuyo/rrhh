﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CalificacionNull:Calificacion
    {
        public override int Nota { get; set; }
        public override string Descripcion { get; set; }

        public CalificacionNull(string nota)
        {
            this.Descripcion = nota;
        }
        public CalificacionNull()
        {
            this.Descripcion = "Sin Nota";
            this.Nota = 0;
        }
    }
}
