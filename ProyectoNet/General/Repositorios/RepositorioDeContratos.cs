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
using Newtonsoft.Json;

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

        public string GetInformesGenerados(int id_area, int id_estado, bool incluir_dependencias)
        {
            var parametros = new Dictionary<string, object>();
            var list_de_informes = new List<Object> { };

            parametros.Add("@id_area", id_area);
            parametros.Add("@estado", id_estado);
            parametros.Add("@incluir_dependencias", incluir_dependencias);

            var tablaDatos = conexion_bd.Ejecutar("dbo.CTR_GET_Seleccion_Informe", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    //if (!(list_de_informes.Any(i => i.Informe == row.GetInt("nroinforme", 0))))
                   // {
                        list_de_informes.Add(new
                        {
                            Informe = row.GetInt("nroinforme", 0),
                            Fecha = row.GetDateTime("fecha_alta"),
                            Usuario = row.GetString("Usuario", "Sin información")
                        });
                    //}
                    
                });

            }

            return JsonConvert.SerializeObject(list_de_informes);
        }

        
    }
}
