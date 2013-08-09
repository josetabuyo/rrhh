using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public class ModalidadDeContratacionNivelPolitico: ModalidadDeContratacion
    {
        private string _Nivel;
        private int _Grado;

        public override int Id
        {
            get { return 3; }
        }

        public string Nivel {get { return _Nivel; } set { _Nivel = value;  }}

        public int Grado { get { return _Grado; } set { _Grado = value;  }}

        public override IEstrategiaDeCalculoDeViatico GetEstrategia(Persona unaPersona)
        {
            return new EstrategiaDeCalculoDeViaticoPorNivelPolitico();
        }

        public override IEstrategiaDeCalculoDeViatico GetEstrategia()
        {
            return new EstrategiaDeCalculoDeViaticoPorNivelPolitico();
        }

        public override ModalidadDeContratacion CrearModalidadDeContratacion(int idTipoViatico)
        {
            if (idTipoViatico != 3) return null;
            return new ModalidadDeContratacionNivelPolitico();

        }
    }
}
