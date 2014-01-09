using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.MAU
{
    public interface IRepositorioDeFuncionalidades
    {
        List<Funcionalidad> FuncionalidadesPara(Usuario usuario);
        void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad);
    }
}
