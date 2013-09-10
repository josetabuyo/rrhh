using System;

namespace General
{
    public class DiaDeCursada
    {
        private DateTime _Dia;
        private bool _esFeriado;

        public DiaDeCursada(DateTime unDia, bool esFeriado)
        {
            this._Dia = unDia;
            this._esFeriado = esFeriado;
        }

        public bool EsFeriado()
        {
            return _esFeriado;
        }

        public bool Contiene(DateTime otroDia)
        {
            return _Dia.Equals(otroDia);
        }

        public DateTime Dia()
        {
            return _Dia;
        }

    }
}
