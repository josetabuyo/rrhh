namespace Dominio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CodigoDeTareaAgotadoException : Exception
    {
        public CodigoDeTareaAgotadoException(string message)
            : base(message)
        {

        }
    }
}
