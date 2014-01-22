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
        List<Funcionalidad> FuncionalidadesPara(int id_usuario);
        void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad);
        List<Funcionalidad> TodasLasFuncionalidades();
    }
}
