﻿using System;
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
        public string estado;
        public DateTime fecha_estado;
        public string codigo_Holograma;
        public int id_Bien_Tarjeton;
        public Tarjeton() { }
    }

    public class RepositorioTarjetones
    {
        private IConexionBD conexion_bd;

        public RepositorioTarjetones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public Tarjeton NuevoTarjeton(int id_Bien_Tarjeton, string codigo_Holograma, int IdUser)
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

                parametros.Add("@Vehiculo_Id_Bien", id_Bien_Tarjeton);
                parametros.Add("@Codigo_Holograma", codigo_Holograma);
                parametros.Add("@IdUser", IdUser);
                parametros.Add("@Cod_Web", strAlfanumericos.ToUpper());
                

                
                //MOBI_ADD_Tarjeton
                todo_bien_vieja = (bool)conexion_bd.EjecutarEscalar("dbo.MOBI_NuevoIDVerificacion", parametros);
            }

            var UnNuevoTarjeton = new Tarjeton();
            UnNuevoTarjeton.id_Bien_Tarjeton = id_Bien_Tarjeton;
            UnNuevoTarjeton.codigo_Holograma = codigo_Holograma;
            UnNuevoTarjeton.id_Verificacion = strAlfanumericos.ToUpper();

            return UnNuevoTarjeton;
        }


    }

}
