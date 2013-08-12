namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AliasNull : Alias
    {
        public AliasNull()
        {

        }

        public override string ConcatenarCon(string nombre_area)
        {
            return nombre_area;
        }

        public override string Descripcion
        {
            get { return ""; }
        }
    }
}
