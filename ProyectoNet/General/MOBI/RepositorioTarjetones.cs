using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using System.Linq;
using Extensiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace General.Repositorios
{
    public class Tarjeton
    {
        public string codigo_Web;
        public int id_Bien;
        public string codigo_Holograma;
        public Tarjeton() { }
    }

    public class RepositorioTarjetones
    {
        private IConexionBD conexion_bd;

        public RepositorioTarjetones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

       
        public bool BajaTarjeton(string codigo_Web, int id_tipoevento)
        {
           

            var parametros = new Dictionary<string, object>();

            parametros.Add("@Codigo_Web", codigo_Web);

            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_Baja_Tarjeton", parametros);

            return true;
        }

    
        public Tarjeton NuevoTarjeton(int id_Bien, string codigo_Holograma )
        {
            System.Random rnd = new Random(DateTime.Now.Millisecond);

            char[] Letras ={'0','1','2','3','4','5','6','7','8','9', 
                    'A','B','C','D','E','F','G','H','I','J','K','L','M','N', 
                    'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            string strAlfanumericos = "";

            bool todo_bien_vieja = true;
            while (todo_bien_vieja)
            {
                strAlfanumericos = "";

                for (int i = 0; i < 8; i++)
                {
                    strAlfanumericos += Letras[rnd.Next(0, Letras.Length - 1)].ToString();
                }

                var parametros = new Dictionary<string, object>();

                parametros.Add("@Codigo_Web", strAlfanumericos.ToUpper());
                parametros.Add("@codigo_Holograma", codigo_Holograma);
                parametros.Add("@Id_Bien", id_Bien);

                todo_bien_vieja = (bool)conexion_bd.EjecutarEscalar("dbo.MOBI_Crear_Tarjeton", parametros);
            }

            var UnNuevoTarjeton = new Tarjeton();
            UnNuevoTarjeton.id_Bien = id_Bien;
            UnNuevoTarjeton.codigo_Web = strAlfanumericos.ToUpper();
            UnNuevoTarjeton.codigo_Holograma = codigo_Holograma;

            return UnNuevoTarjeton;
        }


    }

}
