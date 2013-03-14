using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioZonas
    {
        #region IRepositorioZonas Members

       public IConexionBD conexion_bd { get; set; }

       public RepositorioZonas(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }


        public List<Zona> GetTodasLasZonas()
        {
            List<Zona> zonas = new List<Zona>();
           
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetZonas");

            Zona zona = new Zona();
            Provincia provincia = new Provincia();

            tablaDatos.Rows.ForEach(row =>
            {
                if (row.GetSmallintAsInt("IdZona") != zona.Id)
                {
                    zona = new Zona(row.GetSmallintAsInt("IdZona"), row.GetString("NombreZona"));
                    zonas.Add(zona);
                }


                if (row.GetSmallintAsInt("IdProvincia") != provincia.Id)
                {
                    provincia = new Provincia(row.GetSmallintAsInt("IdProvincia"), row.GetString("NombreProvincia"));
                    
                    zona.Provincias.Add(provincia); 
                }

                Localidad localidad = new Localidad(row.GetSmallintAsInt("IdLocalidad"), row.GetString("NombreLocalidad"));
              
                provincia.Localidades.Add(localidad);
                
                
               
            });

           
            return zonas;
        }

        public Zona GetZonaFromProvincia(Provincia provincia)
        {
            //Zona zona;// = new Zona();
            RepositorioDeProvincias repositorio = new RepositorioDeProvincias();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idProvincia", provincia.Id);
            
            //ConexionDB cn = new ConexionDB("[dbo].[VIA_GetZonaDeLaProvincia]");
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetZonaDeLaProvincia", parametros);
            

            //SqlDataReader dr = cn.EjecutarConsulta();

            if (tablaDatos.Rows.Count > 0)
            {
                var zona = new Zona { Id = tablaDatos.Rows[0].GetSmallintAsInt("Id"), Nombre = tablaDatos.Rows[0].GetString("NombreZona") };
                zona.Provincias = repositorio.GetProvinciasDeLaZona(zona);
                return zona;
            }

            return new Zona();

           
        }

        #endregion
    }
}
