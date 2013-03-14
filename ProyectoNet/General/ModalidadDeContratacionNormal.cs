using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class ModalidadDeContratacionNormal: ModalidadDeContratacion
    {
        public override int Id
        {
            get { return 1; }
        }

        //para que recibel a persona
        public override IEstrategiaDeCalculoDeViatico GetEstrategia(Persona unaPersona)
        {
            return new EstrategiaDeCalculoNormal();
        }

        public override IEstrategiaDeCalculoDeViatico GetEstrategia()
        {
            return new EstrategiaDeCalculoNormal();
        }

        public override ModalidadDeContratacion CrearModalidadDeContratacion(int idTipoViatico)
        {
            if (idTipoViatico != 1) return null;
            return new ModalidadDeContratacionNormal();
            
        }
    }
}
