using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class Comite
    {
        protected int _id;
        protected List<IntegranteComite> _integrantes;
        /*protected Puesto _puesto;*/
        protected Perfil _perfil;
        protected int _numero;
       


        public int Id { get { return _id; } set { _id = value; } }
        public List<IntegranteComite> Integrantes { get { return _integrantes; } set { _integrantes = value; } }
        public Perfil Puesto { get { return _perfil; } set { _perfil = value; } }
        public int Numero { get { return _numero; } set { _numero = value; } }


        public Comite(int id, int numero, List<IntegranteComite> integrantes)
        {
            this._id = id;
            this._integrantes = integrantes;
            this._numero = numero;
        }

        public Comite() {
            this.Integrantes = new List<IntegranteComite>();
        }

    }
}
