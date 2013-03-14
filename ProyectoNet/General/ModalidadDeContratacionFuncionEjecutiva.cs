using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class ModalidadDeContratacionFuncionEjecutiva: ModalidadDeContratacion
    {

        public override int Id
        {
            get { return 2; }
        }

        public override IEstrategiaDeCalculoDeViatico GetEstrategia(Persona unaPersona)
        {
            return new EstrategiaDeCalculoDeViaticoFuncionEjecutiva();
        }

        public override IEstrategiaDeCalculoDeViatico GetEstrategia()
        {
            return new EstrategiaDeCalculoDeViaticoFuncionEjecutiva();
        }

        public override ModalidadDeContratacion CrearModalidadDeContratacion(int idTipoViatico)
        {
            if (idTipoViatico != 2) return null;
            return new ModalidadDeContratacionFuncionEjecutiva();
           
        }
    }
}
