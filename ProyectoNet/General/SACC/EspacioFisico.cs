using System;
using System.Collections.Generic;

namespace General
{
    public class EspacioFisico
    {
        

        private int _id;
        private string _aula;
        private int _capacidad;
        private Edificio _edificio;

        public virtual int Id { get { return _id; } set { _id = value; } }
        public virtual string Aula { get { return _aula; } set { _aula = value; } }
        public virtual int Capacidad { get { return _capacidad; } set { _capacidad = value; } }
        public virtual Edificio Edificio { get { return _edificio; } set { _edificio = value; } }



        public EspacioFisico()
        {

        }

        internal int esMayorAlfabeticamenteQue(EspacioFisico otroespaciofisico)
        {
             return this.Edificio.Nombre.CompareTo(otroespaciofisico.Edificio.Nombre);
        }
    }
}
