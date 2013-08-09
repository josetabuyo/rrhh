namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExcepcionDeValidacion : Exception
    {
        public ExcepcionDeValidacion(string message)
            : base(message)
        {
        }
    }
}
