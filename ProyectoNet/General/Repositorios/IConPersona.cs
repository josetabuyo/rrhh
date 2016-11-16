using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public interface IConPersona
    {
        Persona Persona { get; }
        DateTime Desde();
    }
}
