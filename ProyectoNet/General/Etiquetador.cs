using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Etiquetador
    {
        protected string codigo_actual;

        public Etiquetador(string codigo_inicial)
        {
            this.codigo_actual = codigo_inicial;
        }

        public string Siguiente()
        {
            return SiguienteDe(codigo_actual);
        }

        private string SiguienteDe(string un_codigo)
        {
            var caracter_de_la_derecha = CaracterDeLaDerechaDe(un_codigo);
            var caracteres_de_la_izquierda = CaracteresDeLaIzquierdaDe(un_codigo);
            var siguiente_ascii = SiguienteAsciiDe(caracter_de_la_derecha);
            var siguiente_caracter_de_la_derecha = PasarALetra(siguiente_ascii);

            AcarrearLetraEn(ref caracteres_de_la_izquierda, ref siguiente_caracter_de_la_derecha);

            AcarrearNumero(ref caracteres_de_la_izquierda, ref siguiente_caracter_de_la_derecha);

            return caracteres_de_la_izquierda + siguiente_caracter_de_la_derecha;
        }

        private void Acarrear(ref string caracteres_de_la_izquierda, ref string siguiente_caracter_de_la_derecha, string origen, string destino)
        {
            if (siguiente_caracter_de_la_derecha.Equals(origen))
            {
                siguiente_caracter_de_la_derecha = destino;
                caracteres_de_la_izquierda = SiguienteDe(caracteres_de_la_izquierda);
            }
        }

        private void AcarrearNumero(ref string caracteres_de_la_izquierda, ref string siguiente_caracter_de_la_derecha)
        {
            Acarrear(ref  caracteres_de_la_izquierda, ref  siguiente_caracter_de_la_derecha, ":", "0");

        }

        private void AcarrearLetraEn(ref string caracteres_de_la_izquierda, ref string siguiente_caracter_de_la_derecha)
        {
            Acarrear(ref  caracteres_de_la_izquierda, ref  siguiente_caracter_de_la_derecha, "[", "A");
        }


        private string CaracteresDeLaIzquierdaDe(string un_codigo)
        {
            return un_codigo.Substring(0, un_codigo.Length - 1);
        }

        private string CaracterDeLaDerechaDe(string un_codigo)
        {
            try
            {
                return un_codigo.Substring(un_codigo.Length - 1, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new CodigoDeTareaAgotadoException("No se puede generar un código mas grande que " + codigo_actual);

            }

        }

        private string PasarALetra(int siguiente_ascii)
        {
            return Convert.ToChar(siguiente_ascii).ToString();
        }

        private int SiguienteAsciiDe(string codigo_actual)
        {
            return Encoding.ASCII.GetBytes(codigo_actual)[0] + 1;
        }
    }

}
