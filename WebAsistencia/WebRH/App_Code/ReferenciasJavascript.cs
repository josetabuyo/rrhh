using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ReferenciasJavascript
/// </summary>
public class ReferenciasJavascript
{
	public ReferenciasJavascript()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static string Referencias()
    {
        var str = @"    
            <script type=""text/javascript"" src=""../Scripts/Grilla.js""></script>
            <script type=""text/javascript"" src=""../Scripts/linq.min.js""></script>
            <script type=""text/javascript"" src=""../bootstrap/js/jquery.js""> </script>
            <script type=""text/javascript"" src=""../Scripts/jquery-ui.js""></script>
            <script type=""text/javascript"" src=""../Scripts/jquery.printElement.min.js""></script>
            <script type=""text/javascript"" src=""../bootstrap/js/bootstrap-dropdown.js""></script>
            <script type=""text/javascript"" src=""../bootstrap/js/bootstrap-tooltip.js""></script>
            <script type=""text/javascript"" src=""../Scripts/jquery-ui-1.10.2.custom/development-bundle/ui/minified/i18n/jquery.ui.datepicker-es.min.js""></script>
            <script type=""text/javascript"" src=""planilla_ingreso.js""></script>
            <script type=""text/javascript"" src=""../Scripts/alertify.js""></script>";
        return str;
    }
}