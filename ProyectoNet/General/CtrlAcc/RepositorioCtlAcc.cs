using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;


namespace General.CtrlAcc
{
    public class RepositorioCtlAcc
    {

        public string Grabar_Lote_Control_Acceso( string jsonLote  )
        {
            var jsonRes = string.Empty;
            try
            {
                ConexionDB cn = new ConexionDB("dbo.WS_CTL_ACC_Grabar_Lote");
                cn.AsignarParametro("@json", jsonLote);
                var dr = cn.EjecutarConsulta();
                if (dr.Read())
                {
                    jsonRes = dr[0].ToString();
                    dr.Close();
                    dr.Dispose();
                }
                dr = null;
            }
            catch( Exception ex )
            {
                jsonRes = "{'resultado':'No fue posible guardar el Lote.','detalle':'" + ex.Message + "'}";
            }
            return jsonRes;
        }

        public string Get_Dotacion_Control_Acceso()
        {
            var jsonRes = string.Empty;
            StringBuilder sb = new StringBuilder(string.Empty);
            try
            {
                sb.Append("{\"Estado\":\"OK\",\"Personas\":[");
                ConexionDB cn = new ConexionDB("dbo.WS_CTL_ACC_Get_Dotacion");
                var dr = cn.EjecutarConsulta();                   
                while (dr.Read()) 
                    sb.Append(dr[0].ToString());
                dr.Close(); dr.Dispose(); dr = null;
                if (sb.Length > 0) 
                        sb.Remove(sb.Length - 1, 1);
                sb.Append("]}");
                jsonRes = sb.ToString();
            }
            catch (Exception ex)
            {
                jsonRes = "{\"Estado\":\"" + ex.Message + "\",\"Personas\":[]}";
            }
            return jsonRes;
        }


        public string Get_Personas_Buscador(string param_busc)
        {
            var jsonRes = string.Empty;
            try
            {
                var sb = new StringBuilder(string.Empty);
                sb.Append("{\"results\": [");
                ConexionDB cn = new ConexionDB("dbo.WS_CTL_ACC_Get_Personas_Buscador");
                cn.AsignarParametro("@param_busqueda", param_busc);
                var dr = cn.EjecutarConsulta();
                while (dr.Read()) 
                    sb.Append(dr[0].ToString());
                dr.Close(); dr.Dispose(); dr = null;
                sb.Append("]}");
                jsonRes = sb.ToString().Replace("},]}", "}]}");
            }
            catch
            {
                jsonRes = "{\"results\":[]}";
            }
            return jsonRes;        
        }

    }
}
