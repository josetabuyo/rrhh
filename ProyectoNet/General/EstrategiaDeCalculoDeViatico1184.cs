namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using General;

    public class EstrategiaDeCalculoDeViatico1184 : IEstrategiaDeCalculoDeViatico
    {
        #region IEstrategia Members

        // no hace nada con la zona
        public float CalcularViatico(Zona unaZona, Persona unaPersona)
        {
            if (((ModalidadDeContratacion1184)unaPersona.ModalidadDeContratacion).Retribucion <= 1920)
            {
                return 84;
            }
            if (((ModalidadDeContratacion1184)unaPersona.ModalidadDeContratacion).Retribucion <= 2919)
            {
                return 105;
            }
            return 126;
        }

        // lo puse para que no rompiera, pero la implementacion es cualquiera, pero esta bien que reciba una comision
        public float CalcularViatico(ComisionDeServicio comision)
        {
            if (((ModalidadDeContratacion1184)comision.Persona.ModalidadDeContratacion).Retribucion <= 1920)
            {
                return 84;
            }
            if (((ModalidadDeContratacion1184)comision.Persona.ModalidadDeContratacion).Retribucion <= 2919)
            {
                return 105;
            }
            return 126;
        }

        public float CalcularViatico(Estadia estadia)
        {
            return 0;
        }

        #endregion
    }
}
