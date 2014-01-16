using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Inserta las referencias de javascript y css en las páginas
/// </summary>
public class Referencias
{
    public static string Css(string ruta_origen){
        var refs = @"    
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Scripts/bootstrap/css/bootstrap.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Scripts/bootstrap/css/bootstrap-responsive.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/css/smoothness/jquery-ui-1.10.2.custom.min.css"" />
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/Estilos.css"" type=""text/css""/>";
        refs = refs.Replace("__RUTA_ORIGEN__", ruta_origen);
        return refs;
    }

    public static string Javascript(string ruta_origen){
        var refs = @"    
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/FuncionesDreamWeaver.js""></script>   
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Grilla.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/InputAutocompletable.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/placeholder_ie.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/InputSoloNumeros.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/linq.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/list.js""></script>";
        refs = refs.Replace("__RUTA_ORIGEN__", ruta_origen);
        return refs;
    }
}