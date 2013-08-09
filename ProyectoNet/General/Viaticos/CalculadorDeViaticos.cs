namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using General;

    // FC: en principio esta clase no se esta usando. El RepoCalculadorDeViaticos trae el viatico segun la el tipo de viatico (de la persona) y la zona (de la estadia)
    public class CalculadorDeViaticos
    {
        public float CalculaleLosViaticosA(Persona unaPersona, Zona unaZona)
        {
            IEstrategiaDeCalculoDeViatico estrategia = unaPersona.ModalidadDeContratacion.GetEstrategia(unaPersona);
            return estrategia.CalcularViatico(unaZona, unaPersona);
        }

        public void CalculaleLosViaticosA(Persona unaPersona)
        {
            throw new NotImplementedException();
        }

        public float CalculaleLosViaticosA(ComisionDeServicio comision)
        {
            return comision.Persona.ModalidadDeContratacion.GetEstrategia().CalcularViatico(comision);
        }
    }
}
