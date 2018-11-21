using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace General.MAU
{
    public interface IRepositorioDeFuncionalidadesDeUsuarios
    {
        List<Funcionalidad> FuncionalidadesPara(Usuario usuario);
        List<MAU_Perfil> GetPerfilesActuales(int id_usuario);
        List<Funcionalidad> GetFuncionalidadesActuales(int id_usuario);
        string AsignarPerfilesAUsuario(List<int> perfiles, List<Area> areas, int idUsuario, int id_usuario_alta);
        string AsignarFuncionalidadesAUsuario(List<int> funcionalidades, List<Area> areas, int idUsuario, int id_usuario_alta);
        string DesAsignarPerfilDeUsuario(int idPerfil, int idUsuario, int id_usuario_alta);
        string DesAsignarFuncionalidadDeUsuario(int idFuncionalidad, int idUsuario, int id_usuario_alta);
        //List<Funcionalidad> FuncionalidadesPara(int id_usuario);
        List<Usuario> UsuariosConLaFuncionalidad(int id_funcionalidad);
        void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad, int id_usuario_logueado);
        void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado);
        void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad, int id_usuario_logueado);
        void Refresh();
        void ConcederBasicas(Usuario usuario);

        List<Funcionalidad> FuncionalidadesOtorgadasA(Usuario usuario);
    }
}
