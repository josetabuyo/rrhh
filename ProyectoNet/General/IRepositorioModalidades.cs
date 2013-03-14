using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public interface IRepositorioModalidades
    {
        string GetModalidadDeContratacionDe(Persona unaPersona);
        string GetNivelGradoDeContratacionDe(Persona unaPersona);
    }
}
