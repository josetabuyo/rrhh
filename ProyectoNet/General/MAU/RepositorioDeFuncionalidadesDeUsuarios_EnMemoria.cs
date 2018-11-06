using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace General.MAU
{
    public class RepositorioDeFuncionalidadesDeUsuarios_EnMemoria : IRepositorioDeFuncionalidadesDeUsuarios
    {
        private Dictionary<Usuario, List<Funcionalidad>> diccionario_de_funcionalidades;

        public RepositorioDeFuncionalidadesDeUsuarios_EnMemoria(Dictionary<Usuario, List<Funcionalidad>> diccionario_de_funcionalidades)
        {
            this.diccionario_de_funcionalidades = diccionario_de_funcionalidades;
        }

        public List<Funcionalidad> FuncionalidadesPara(Usuario usuario)
        {
            return diccionario_de_funcionalidades.GetValueOrDefault(usuario, new List<Funcionalidad>());
        }

        //public List<Funcionalidad> FuncionalidadesPara(int id_usuario)
        //{
        //    throw new NotImplementedException();
        //}


        public void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad, int id_usuario_logueado)
        {
            if (diccionario_de_funcionalidades.ContainsKey(usuario))
            {
                if (!diccionario_de_funcionalidades[usuario].Contains(funcionalidad))
                {
                    diccionario_de_funcionalidades[usuario].Add(funcionalidad);
                }
            }
            else
            {
                var funcionalidades = new List<Funcionalidad>() { funcionalidad };
                diccionario_de_funcionalidades.Add(usuario, funcionalidades);
            }

        }

        public void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }


        public void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {

        }


        public void ConcederBasicas(int id_usuario)
        {
            throw new NotImplementedException();
        }


        public void ConcederBasicas(Usuario usuario)
        {
            throw new NotImplementedException();
        }


        public List<Usuario> UsuariosConLaFuncionalidad(int id_funcionalidad)
        {
            throw new NotImplementedException();
        }


        public List<Funcionalidad> FuncionalidadesOtorgadasA(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<MAU_Perfil> GetPerfilesActuales(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public List<Funcionalidad> GetFuncionalidadesActuales(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public string AsignarPerfilesAUsuario(List<int> perfiles, JArray areas, int idUsuario, int id_usuario_alta)
        {
            throw new NotImplementedException();
        }
    }
}
