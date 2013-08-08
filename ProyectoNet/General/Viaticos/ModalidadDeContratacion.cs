using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public abstract class ModalidadDeContratacion
    {
        private string _Descripcion;


        public abstract int Id { get; }
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value;  } }


        public abstract IEstrategiaDeCalculoDeViatico GetEstrategia(Persona unaPersona);

        public abstract IEstrategiaDeCalculoDeViatico GetEstrategia();

        public abstract ModalidadDeContratacion CrearModalidadDeContratacion(int idTipoViatico);



    }
}
