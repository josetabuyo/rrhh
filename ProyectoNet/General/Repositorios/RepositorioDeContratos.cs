using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace General.Repositorios
{
    public class RepositorioDeContratos
    {
        private IConexionBD conexion_bd;


        public RepositorioDeContratos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public string AgregaAccionAPersona(int idArea, int documento, string estado, int idUsuario) {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_area", idArea);
            parametros.Add("@documento", documento);
            parametros.Add("@usuario_alta", idUsuario);
            parametros.Add("@estado", estado);
            //parametros.Add("@incluir_dependencias", incluir_dependencias);
            var tablaDatos = conexion_bd.Ejecutar("dbo.CTR_ADD_Seleccion_Contratos_WEB", parametros);
           
            return "ok";
        }

        public string GenerarInforme(int id_area, int id_estado, bool incluir_dependencias, int id_usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_area", id_area);
            parametros.Add("@estado", id_estado);
            parametros.Add("@usuario", id_usuario);           
            parametros.Add("@incluir_dependencias", incluir_dependencias);

            var tablaDatos = conexion_bd.Ejecutar("dbo.CTR_ADD_seleccion_contratos_WEB_inf", parametros);

            return "ok";
        }

        
    }
}
