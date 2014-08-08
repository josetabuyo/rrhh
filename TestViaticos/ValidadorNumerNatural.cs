using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos
{
    public class ValidadorNumerNatural
    {
        protected int objeto_a_validar;
        internal ValidadorNumerNatural SiEsValido(int objeto_a_validar)
        {
            if (objeto_a_validar > 0)
                return new ValidadorNumerNaturalValido(objeto_a_validar);
            else
                return new ValidadorNumerNaturalInvalido(objeto_a_validar);
        }

        public virtual ValidadorNumerNatural Entonces(Action<int> func) { throw new NotImplementedException(); }
        public virtual ValidadorNumerNatural SiNo(Action<int> func) { throw new NotImplementedException(); }
    }

    public class ValidadorNumerNaturalValido : ValidadorNumerNatural
    {
        public ValidadorNumerNaturalValido(int objeto_a_validar)
        {
            this.objeto_a_validar = objeto_a_validar;
        }

        public override ValidadorNumerNatural Entonces(Action<int> func)
        {
            func.Invoke(this.objeto_a_validar);
            return this;
        }

        public override ValidadorNumerNatural SiNo(Action<int> func)
        {
            return this;
        }
    }

    public class ValidadorNumerNaturalInvalido : ValidadorNumerNatural
    {
        public ValidadorNumerNaturalInvalido(int objeto_a_validar)
        {
            this.objeto_a_validar = objeto_a_validar;
        }

        public override ValidadorNumerNatural Entonces(Action<int> func)
        {
            return this;
        }

        public override ValidadorNumerNatural SiNo(Action<int> func)
        {
            func.Invoke(this.objeto_a_validar);
            return this;
        }
    }
}
