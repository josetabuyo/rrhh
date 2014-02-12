using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;


namespace General.MAU
{
    public class RepositorioDeFuncionalidades_EnMemoria:IRepositorioDeFuncionalidades
    {
        private Dictionary<Usuario, List<Funcionalidad>> diccionario_de_funcionalidades;

        public RepositorioDeFuncionalidades_EnMemoria(Dictionary<Usuario, List<Funcionalidad>> diccionario_de_funcionalidades)
        {
            this.diccionario_de_funcionalidades = diccionario_de_funcionalidades;
        }

        public List<Funcionalidad> FuncionalidadesPara(int id_usuario)
        {
            throw new NotImplementedException();
        }
        
        public List<Funcionalidad> TodasLasFuncionalidades()
        {
            return diccionario_de_funcionalidades.SelectMany(key => key.Value).Distinct().ToList();
        }

        public Funcionalidad GetFuncionalidadPorId(int p)
        {
            throw new NotImplementedException();
        }
    }
}
