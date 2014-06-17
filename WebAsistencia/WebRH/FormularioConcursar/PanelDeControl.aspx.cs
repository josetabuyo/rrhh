using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;

public partial class FormularioConcursar_PanelDeControl : System.Web.UI.Page
{
  
    public string apellido;
    public string nombre;
    private WSViaticos.Usuario usuarioLogueado;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            this.usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
            var dni = Servicio().GetDniPorAlias(usuarioLogueado.Alias);

            var cv = Servicio().GetCurriculum(dni);

            //var curriculum = JsonConvert.SerializeObject(cv);
            apellido = cv.DatosPersonales.Apellido;
            nombre = cv.DatosPersonales.Nombre;
            
        }
        }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

    } 
