using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MoBi_Area
    {
        protected int _Id;
        protected string _Nombre;
        protected string _Path;

	    public int Id
	    {
		    get { return _Id;}
		    set { _Id = value;}
	    }

	    public string Nombre
	    {
		    get { return _Nombre;}
		    set { _Nombre = value;}
	    }

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }


    }
}
