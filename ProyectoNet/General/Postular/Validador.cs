using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class Validador
    {
        protected Dictionary<string, Validador> validaciones;
        public static Validador NumeroNatural { get { return new ValidadorNumeroNatural(); } }
        public static Validador NoVacio { get { return new ValidadorNoVacio(); } }
        public static Validador NoNull { get { return new ValidadorNoNull(); } }
        public static Validador NumeroNaturalOCero { get { return new ValidadorNumeroNaturalOCero(); } }
        public static Validador FechaNoVacia { get { return new ValidadorFechaNoVacia(); } }
        public static Validador Mail { get { return new ValidadorMail(); } }

        public Validador () {
            this.validaciones = new Dictionary<string,Validador>();
        }

        public Validador DeberiaSer(string atributo, Validador validador)
        {
            this.validaciones.Add(atributo, validador);
            return this;
        }

        public virtual bool EsValido(object una_docencia)
        {
            return this.validaciones.Keys.ToList().All((key) => {
                var atributo_a_validar = key;
                var validador_a_usar = validaciones[key];
                return validador_a_usar.EsValido(una_docencia.GetType().GetProperty(atributo_a_validar).GetValue(una_docencia, null));
            });
        }

        public void ValidaSi(Dictionary<string, Validador> reglas)
        {
            reglas.Keys.ToList().ForEach(key => this.DeberiaSer(key, reglas[key]));
        }

        public void DeberianSerNaturales(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.NumeroNatural));
        }

        public void DeberianSerNoVacias(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.NoVacio));
        }

        public void DeberianSerFechasNoVacias(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.FechaNoVacia));
        }

        public void DeberianSerNaturalesOCero(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.NumeroNaturalOCero));
        }

        public void DeberianSerNoNulls(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.NoNull));
        }

        public void DeberiaSerMail(string[] atributos)
        {
            atributos.ToList().ForEach(attr => this.DeberiaSer(attr, Validador.Mail));
        }
    }

    public class ValidadorNumeroNatural:Validador
    {
        override public bool EsValido(object un_natural)
        {
            return (int)un_natural > 0;
        }
    }

    public class ValidadorNoVacio : Validador
    {
        override public bool EsValido(object un_srting)
        {
            return (string)un_srting != "";
        }
    }

    public class ValidadorFechaNoVacia : Validador
    {
        override public bool EsValido(object una_fecha)
        {
            return una_fecha.ToString() != "";
        }
    }

    public class ValidadorMail : Validador
    {
        override public bool EsValido(object una_fecha)
        {
            return una_fecha.ToString() != "";
        }
    }

    public class ValidadorNoNull : Validador
    {
        override public bool EsValido(object un_objeto)
        {
            return un_objeto != null;
        }
    }

    public class ValidadorNumeroNaturalOCero : Validador
    {
        override public bool EsValido(object un_natural)
        {
            return (int)un_natural >= 0;
        }
    }
}
