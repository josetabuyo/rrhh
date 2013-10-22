using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MotivoVisita
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private string _Motivo;
        public string Motivo
        {
            set { this._Motivo = value; }
            get { return this._Motivo; }
        }
    }
}
