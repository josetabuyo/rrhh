using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesAprobadas
    {
        private Persona _persona;
        private Periodo _periodo;
        private int _dias;
        private int _concepto;
        private General.Persona juan;
        private General.Periodo primero_de_enero;
        private int cinco_de_enero;

        public int Dias { get { return _dias; } set { _dias = value; } }
        public Persona Persona { get { return _persona; } }
        public Periodo Periodo { get { return _periodo; } }
        public int Concepto { get { return _concepto; } }

        public VacacionesAprobadas(Persona persona, Periodo periodo, int dias, int concepto) 
        {
            this._persona = persona;
            this._periodo = periodo;
            this._dias = dias;
            this._concepto = concepto;
        }

        public VacacionesAprobadas(General.Persona juan, General.Periodo primero_de_enero, int cinco_de_enero)
        {
            // TODO: Complete member initialization
            this.juan = juan;
            this.primero_de_enero = primero_de_enero;
            this.cinco_de_enero = cinco_de_enero;
        }



    }
}
