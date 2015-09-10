using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Pantalla1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var  usuario = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);
        if (!IsPostBack)
        {
            CurriculumVitae cv;

            try
            {
                cv = Servicio().GetCurriculum(usuario.Owner.Id);
            }
            catch (Exception excepcion)
            {
                
                throw new Exception("No se pudo traer el curriculum. Mensaje: " + excepcion.Message);
            }
            

            var curriculum = JsonConvert.SerializeObject(cv);

            this.curriculum.Value = curriculum;
        }
    }


    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }

}

