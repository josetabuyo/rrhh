using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestViaticos.TestSACC
{
    public abstract class Acumulador
    {
        protected object valor;
        protected int horas_maximas;

        public abstract int HorasNoAsistidas();
        public abstract int HorasAsistidas();
        public abstract int AcumularHorasNoAsistidas(int valor_acumulado);
        public abstract int AcumularHorasAsistidas(int valor_acumulado);
    }
    public class AcumuladorHorasDiaCursado:Acumulador
    {
        protected int valor;

        public AcumuladorHorasDiaCursado(int valor, int horas_maximas)
        {
            this.valor = valor;
            this.horas_maximas = horas_maximas;
        }
        public override int HorasNoAsistidas()
        {
            return this.horas_maximas - this.valor;
        }

        public override int AcumularHorasNoAsistidas(int valor_acumulado)
        {
            return valor_acumulado + this.HorasNoAsistidas();
        }



        public override int HorasAsistidas()
        {
            throw new NotImplementedException();
        }

        public override int AcumularHorasAsistidas(int valor_acumulado)
        {
            throw new NotImplementedException();
        }
    }
    public class AcumuladorHorasDiaNoCursado : Acumulador
    {
        protected string valor;
        public AcumuladorHorasDiaNoCursado(string valor, int horas_maximas)
        {
            this.valor = valor;
        }

        public override int HorasNoAsistidas()
        {
            return 0;
        }

        public override int HorasAsistidas()
        {
            return 0;
        }

        public override int AcumularHorasNoAsistidas(int valor_acumulado)
        {
            return valor_acumulado;
        }

        public override int AcumularHorasAsistidas(int valor_acumulado)
        {
            return valor_acumulado;
        }
    }
}
