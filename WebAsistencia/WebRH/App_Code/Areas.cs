using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.MobileControls;
using WSViaticos;

/// <summary>
/// Descripción breve de Areas
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class Areas : System.Web.Services.WebService {

    public Areas () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    //TODO: Llamar al webservice en lugar de esto
    private List<Area> AreasFicticias()
    {
        var areas =  new List<Area>();
        for (int i  = 0; i  < 400;  i++)
        {
            var area = new Area();
            area.Nombre = "A" + i.ToString();
            area.Alias = "l" + i.ToString();
            areas.Add(area);
        }
        return areas;
    }

    private List<Area> Organigrama()
    {
        //Se persiste en la sesion para no llamar al backend otra vez.
        if (Session[ConstantesDeSesion.ORGANIGRAMA] == null)
            Session[ConstantesDeSesion.ORGANIGRAMA] = AreasFicticias(); //TODO: Llamar al webservice en lugar de esto

        var organigrama = (List<Area>)Session[ConstantesDeSesion.ORGANIGRAMA];
        return organigrama;
    }

    private List<Area> FiltrarArea(string filtro_nombre)
    {
        var resultado = Organigrama().Where(a => a.Alias.ToLower().Contains(filtro_nombre.ToLower())).ToList();
        return resultado;
    }
        
        
    [WebMethod]
    public List<Area> AreasFormales (string filtro_nombre)
    {

        //var areas_formales = FiltrarArea(filtro_nombre).Where(a => a.PresentaDDJJ);
        //var resultado = areas_formales.Take(12).ToList(); //No tiene sentido un combo con demasiadas opciones;

        //return resultado;
        return AreasFicticias().Take(12).ToList();
    }
    
}
