using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public interface IRepositorioDePersonas
    {
        List<Persona> TodasLasPersonas();
        Persona GetPersonaPorId(int id_persona);
    }
}
