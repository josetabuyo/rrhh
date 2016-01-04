using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class FormularioConcursar_Postulaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            CurriculumVitae cv;
            Postulacion[] postulaciones;
            Perfil[] perfiles;

            var usuarioLogueado = ((WSViaticos.Usuario)Session[ConstantesDeSesion.USUARIO]);

            try
            {
                cv = Servicio().GetCurriculum(usuarioLogueado.Owner.Id);
                postulaciones = Servicio().GetPostulaciones(usuarioLogueado);
                perfiles = Servicio().GetCvPerfiles();
            }
            catch (Exception excepcion)
            {
                throw new Exception("Error de carga. Mensaje: " + excepcion.Message);
            }


            //var postulaciones = Servicio().GetPostulaciones(usuarioLogueado);
          
            //var perfiles = Servicio().GetCvPerfiles();

            var curriculum = JsonConvert.SerializeObject(cv);
            var perfilSerialize = JsonConvert.SerializeObject(perfiles);
            var postulacionSerialize = JsonConvert.SerializeObject(postulaciones);
           
            this.perfiles.Value = perfilSerialize;
            this.postulaciones.Value = postulacionSerialize;
            this.curriculum.Value = curriculum;
        }
        
    }

    private WSViaticosSoapClient Servicio()
    {
        return new WSViaticosSoapClient();
    }
}