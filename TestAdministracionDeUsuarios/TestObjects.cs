using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace TestAdministracionDeUsuarios
{
    public class TestObjects
    {
        public static AutorizadorFuncionalidades Autorizador()
        {
            return new AutorizadorFuncionalidades(PermisosJuanLeeLegajos());
        }

        protected static Dictionary<string, List<Permiso>> PermisosJuanLeeLegajos()
        {
            var permisos = new Dictionary<string, List<Permiso>>();
            permisos.Add(Juan(), new List<Permiso> { Permiso.Conceder(FuncionalidadLecturaLegajos()) });
            return permisos;
        }

        public static string Juan()
        {
            return "Juan";
        }

        protected static List<Funcionalidad> SoloFuncionalidadLecturaLegajos()
        {
            return new List<Funcionalidad> { FuncionalidadLecturaLegajos() };
        }

        public static Funcionalidad FuncionalidadLecturaLegajos()
        {
            return new Funcionalidad("lectura legajos");
        }

        public static Funcionalidad FuncionalidadEsctrituraLegajos()
        {
            return new Funcionalidad("escritura legajos");
        }

        public static Funcionalidad RescindirContrato()
        {
            return new Funcionalidad("Rescindir contrato");
        }

        public static Funcionalidad FuncionalidadContratos()
        {
            var funcionalidad_contratos = new Funcionalidad("Acceso a contratos");
            funcionalidad_contratos.AgregarFuncionalidad(RescindirContrato());
            return funcionalidad_contratos;
        }
    }
}
