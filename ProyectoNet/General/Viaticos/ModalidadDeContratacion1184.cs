using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class ModalidadDeContratacion1184: ModalidadDeContratacion
    {
        public override int Id
        {
            get { return 4; }
        }

        private float _Retribucion;
        public float Retribucion
        {
            get { return _Retribucion; }
            set { _Retribucion = value;  }
        }

        //este metodo creo que no serviria mas
        public override IEstrategiaDeCalculoDeViatico GetEstrategia(Persona unaPersona)
        {
            return new EstrategiaDeCalculoDeViatico1184();
        }

        public override IEstrategiaDeCalculoDeViatico GetEstrategia()
        {
            return new EstrategiaDeCalculoDeViatico1184();
        }

        public override ModalidadDeContratacion CrearModalidadDeContratacion(int idTipoViatico)
        {
            if (idTipoViatico != 4) return null;
            return new ModalidadDeContratacion1184();
            
        }
    }
}
