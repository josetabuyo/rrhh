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
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/Estilos.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__SACC/Estilos/EstilosSACC.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/alertify.core.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/alertify.default.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Scripts/opentip/opentip.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/animate.css"" type=""text/css""/>";
        refs = refs.Replace("__RUTA_ORIGEN__", ruta_origen);
        return refs;
    }



    public static string Javascript(string ruta_origen){
        var refs = @"
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-latest.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/underscore-min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/bootstrap/js/jquery.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/alertify.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery-ui-1.10.2.custom/development-bundle/ui/i18n/jquery.ui.datepicker-es.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/FuncionesDreamWeaver.js""></script>   
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Grilla.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/InputAutocompletable.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/placeholder_ie.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/InputSoloNumeros.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/bootstrap/js/bootstrap-dropdown.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/linq.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/list.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/jquery.leanModal.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/bootstrap/js/bootstrap-collapse.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/bootstrap/js/bootstrap-transition.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/ProveedorAjax.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Extensiones/Validaciones.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Extensiones/Colecciones.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Extensiones/PolyfillsIE.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Extensiones/Combos.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/opentip/opentip-jquery-excanvas.min.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Promesa.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Backend.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Repositorio.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__MAU/HabilitadorDeControles.js""></script>
            <script type=""text/javascript"" src=""__RUTA_ORIGEN__Scripts/Spin.js""></script>";
        refs = refs.Replace("__RUTA_ORIGEN__", ruta_origen);
        return refs;
    }

    public static string Css2(string ruta_origen)
    {
        var v1 = Css(ruta_origen);
        var prefijo = "\r\n            <link rel=\"stylesheet\" href=\"" + ruta_origen;

        //cambio la referencia de bootstrap.css a la carpeta de bootstrap4
        var v2 = v1.Replace("bootstrap/css/bootstrap.css", "bootstrap4/css/bootstrap.min.css");

        //borro la linea de bootstra-presponsive porque la verseion 4 no lo usa
        v2 = Remover(v2, prefijo + @"Scripts/bootstrap/css/bootstrap-responsive.css"" type=""text/css""/>");

        return v2;
    }

    public static string Javascript2(string ruta_origen)
    {
        var v1 = Javascript(ruta_origen);
        var prefijo = "\r\n            <script type=\"text/javascript\" src=\"" + ruta_origen;

        var v2 = Remover(v1, prefijo + "Scripts/bootstrap/js/bootstrap-transition.js\"></script>");
        v2 = Remover(v2, prefijo + "Scripts/bootstrap/js/bootstrap-collapse.js\"></script>");
        v2 = Remover(v2, prefijo + "Scripts/bootstrap/js/bootstrap-dropdown.js\"></script>");
        v2 = Remover(v2, prefijo + "Scripts/jquery-ui-1.10.2.custom/js/jquery-1.9.1.js\"></script>");
        v2 = Remover(v2, prefijo + "Scripts/bootstrap/js/jquery.js\"></script>");
        

        v2 = v2.Replace("Scripts/jquery-latest.min.js\"", "Scripts/jquery3.3.1/jquery-3.3.1.min.js\"");
        
        return v2;
    }


    protected static string Remover(string original, string str_a_remover)
    {
        return original.Replace(str_a_remover, "");
    }
}