using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FuncionarioVisita : PersonaVisita
    {
        private string _Tratamiento;
        public string Tratamiento
        {
            set { this._Tratamiento = value; }
            get { return this._Tratamiento; }
        }

        private string _LugarTrabajo;
        public string LugarTrabajo
        {
            set { this._LugarTrabajo = value; }
            get { return this._LugarTrabajo; }
        }
    }
}
