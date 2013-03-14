namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using General;

    public class EstrategiaDeCalculoDeViaticoPorNivelPolitico : IEstrategiaDeCalculoDeViatico
    {
        #region IEstrategiaDeCalculoDeViatico Members

        public float CalcularViatico(Zona unaZona, Persona unaPersona)
        {
            switch (((ModalidadDeContratacionNivelPolitico)unaPersona.ModalidadDeContratacion).Grado)
            {
                case 1:
                    switch (unaZona.Nombre)
                    {
                        case "NOA":
                            return 304;
                        case "NEA":
                            return 213;
                        case "CUYO":
                            return 304;
                        case "CENTRO":
                            return 253;
                        case "SUR":
                            return 371;
                        case "METROPOLITANA":
                            return 213;
                        default:
                            return 0;
                    }
                case 2:
                    switch (unaZona.Nombre)
                    {
                        case "NOA":
                            return 282;
                        case "NEA":
                            return 198;
                        case "CUYO":
                            return 282;
                        case "CENTRO":
                            return 235;
                        case "SUR":
                            return 344;
                        case "METROPOLITANA":
                            return 198;
                        default:
                            return 0;
                    }
                case 3:
                    switch (unaZona.Nombre)
                    {
                        case "NOA":
                            return 260;
                        case "NEA":
                            return 182;
                        case "CUYO":
                            return 260;
                        case "CENTRO":
                            return 217;
                        case "SUR":
                            return 318;
                        case "METROPOLITANA":
                            return 182;
                        default:
                            return 0;
                    }
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
