using System;
using System.Collections.Generic;

using System.Text;
//using RRHH.Framework;

namespace General
{
    public class PaseDeArea
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime _Fecha;
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private Area _AreaOrigen;
        public Area AreaOrigen
        {
            get { return _AreaOrigen; }
            set { _AreaOrigen = value; }
        }

        private Area _AreaDestino;
        public Area AreaDestino
        {
            get { return _AreaDestino; }
            set { _AreaDestino = value; }
        }

        private Auditoria _Auditoria;
        public Auditoria Auditoria
        {
            get { return _Auditoria; }
            set { _Auditoria = value; }
        }

        private Persona _Persona;
        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

    }
}