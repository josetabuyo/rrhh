using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class InterpretadorDeCodigosDeArea
    {
        private Dictionary<int, string> ceros;

        public InterpretadorDeCodigosDeArea()
        {
            ConstruirCeros(24);
        }


        public string ParteDerechaDelCodigo(string codigo)
        {
            for (int i = codigo.Length; i > 0; i--)
            {
                if (codigo.Contains(StringConCeros(i))) return StringConCeros(i);
            }
            return "";
        }

        public string CodigoDelAreaPadreDe(string codigo_de_la_hija)
        {
            var parte_izquierda = ParteIzquierdaDelCodigo(codigo_de_la_hija);
            var parte_izquierda_del_padre = parte_izquierda.Substring(0, parte_izquierda.Length - CantidadDeCerosEnElNivel(NivelDelArea(codigo_de_la_hija)));
            var parte_derecha_del_padre = StringConCeros(24 - parte_izquierda_del_padre.Length);
            return parte_izquierda_del_padre + parte_derecha_del_padre;
        }

        private int NivelDelArea(string codigo)
        {
            if (ParteIzquierdaDelCodigo(codigo).Equals(""))
                return 7;
            return 1;
        }



        private void ConstruirCeros(int largo_del_codigo)
        {
            ceros = new Dictionary<int, string>();
            for (int i = 1; i <= largo_del_codigo; i++)
            {
                ceros.Add(i, StringConCeros(i));
            }
        }

        private string StringConCeros(int cantidad_de_ceros)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < cantidad_de_ceros; i++)
            {
                builder.Append("0");
            }
            return builder.ToString();
        }


        private int CantidadDeCerosEnElNivel(int nivel)
        {
            if (nivel == 7)
                return 5;
            return 2;
        }

        private string ParteIzquierdaDelPadre(string codigo)
        {
            var parte_izquierda_del_codigo = ParteIzquierdaDelCodigo(codigo);
            return parte_izquierda_del_codigo.Substring(0, parte_izquierda_del_codigo.Length - CantidadDeCerosEnElNivel(1));
        }


        private string ParteIzquierdaDelCodigo(string codigo)
        {
            for (int i = codigo.Length; i > 0; i--)
            {
                if (Right(codigo, i).Equals(StringConCeros(i)))
                {
                    //FC:le tuve que agregar esta condicion porque si el codigo viene 0110 el right toma solo hasta el 011 y rompe
                    if (i.Equals(21)) {
                        return codigo.Substring(0, codigo.Length - 20);
                    }
                    return codigo.Substring(0, codigo.Length - i);
                }

            }
            return codigo;
        }

        private string Right(string codigo, int i)
        {
            return codigo.Substring(codigo.Length - i, i);
        }


        public string CodigoDelAreaPadreDe(string codigo, List<Area> areas)
        {
            if (codigo.Equals("00" + ceros[22])) return ceros[24];
            var codigo_padre = CodigoDelAreaPadreDe(codigo);
            if (areas.Any(a => a.Codigo.Equals(codigo_padre)))
                return codigo_padre;
            else
                return CodigoDelAreaPadreDe(codigo_padre, areas);
        }

        public string PonerleCerosAlFinalDelCodigoDelArea(Area area)
        {
            return area.Codigo = area.Codigo.Substring(0, 19) + "00000";
        }
    }
}
