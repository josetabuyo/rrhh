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

        //PARA IMPLEMENTAR PROXIMAMENTE
        public string GenerarInforme(int idArea, int idUsuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_area", idArea);
           
            //parametros.Add("@incluir_dependencias", incluir_dependencias);
            //var tablaDatos = conexion_bd.Ejecutar("dbo.CTR_ADD_Seleccion_Contratos_WEB", parametros);

            return "ok";
        }

        
    }
}
