namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;

    public class EstrategiaDeCalculoNormal : IEstrategiaDeCalculoDeViatico
    {
        #region IEstrategiaDeCalculoDeViatico Members

        public float CalcularViatico(General.Zona unaZona, Persona unaPersona)
        {
            switch (unaZona.Nombre)
            {
                case "NOA":
                    return 234;
                case "NEA":
                    return 164;
                case "CUYO":
                    return 234;
                case "CENTRO":
                    return 195;
                case "SUR":
                    return 287;
                case "METROPOLITANA":
                    return 164;
                default:
                    return 0;

            }
        }

        #endregion


        public float CalcularViatico(ComisionDeServicio comision)
        {
            // cambiar para que evalue la zona de cada provincia de la estadia y que sea el correspondiente a los dias solicitados
            foreach (Estadia estadia in comision.Estadias)
            {
                switch (estadia.Provincia.Id)
                {
                    case 10:
                        return 234;
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

    }
}
