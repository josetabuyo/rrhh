namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EstrategiaDeCalculoDeViaticoFuncionEjecutiva : IEstrategiaDeCalculoDeViatico
    {

        #region IEstrategiaDeCalculoDeViatico Members

        public float CalcularViatico(General.Zona unaZona, Persona unaPersona)
        {
            switch (unaZona.Nombre)
            {
                case "NOA":
                    return 269.1f;
                case "NEA":
                    return 188.6f;
                case "CUYO":
                    return 304f;
                case "CENTRO":
                    return 224.25f;
                case "SUR":
                    return 330.05f;
                case "METROPOLITANA":
                    return 188.6F;
                default:
                    return 0;

            }
        }

        // lo puse para que no rompiera, pero la implementacion es cualquiera
        public float CalcularViatico(ComisionDeServicio comision)
        {
            foreach (Estadia estadia in comision.Estadias)
            {
                switch (estadia.Provincia.Id)
                {
                    case 10:
                        return 0.5F;
                    case 12:
                        return 164;
                    default:
                        return 0;
                }
            }
            return 0;
        }

        public float CalcularViatico(Estadia estadia)
        {
            return 0;
        }

        #endregion
    }
}
