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
        public string id_Verificacion;
        public int id_Bien;
        public Tarjeton() { }
    }

   public class RepositorioTarjetones
   {
       private IConexionBD conexion_bd;

       public RepositorioTarjetones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


       public Tarjeton NuevoTarjeton(int id_Bien)
       {
           System.Random rnd = new Random(DateTime.Now.Millisecond);

           char[] Letras ={'0','1','2','3','4','5','6','7','8','9', 
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n', 
            'o','p','q','r','s','t','u','v','w','x','y','z', 
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

               parametros.Add("@Id_Bien", id_Bien);

               parametros.Add("@Id_Verificacion", strAlfanumericos);

               todo_bien_vieja = (bool)conexion_bd.EjecutarEscalar("dbo.MOBI_NuevoIDVerificacion", parametros);

               

              
           }
                var UnNuevoTarjeton = new Tarjeton();
                UnNuevoTarjeton.id_Bien = id_Bien;
                UnNuevoTarjeton.id_Verificacion = strAlfanumericos;

               return UnNuevoTarjeton;
       }

       public void AgregarTarjetonTODOSlosVehiculos()
       {
           for (int id_Bien = 1; id_Bien < 3; id_Bien++)
           {
               NuevoTarjeton(id_Bien);   
               
           }
       
       }
    
   }

}
