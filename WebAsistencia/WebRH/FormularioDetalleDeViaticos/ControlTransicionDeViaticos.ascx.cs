using System;
using System.Collections.Generic;
using System.Linq;
using WSViaticos;
using Newtonsoft.Json;

public partial class FormularioDetalleDeViaticos_WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        var area = ws.SiguientePasoDelCircuitoDelArea(((ComisionDeServicio)Session["comisionActual"]).AreaActual);
        this.Btn_AccesoDirectoAprobar.Text = "Aprobar y enviar a " + area.Nombre;
        this.Btn_AccesoDirectoSolicitarModificacion.Text = "Solicitar modificación a";
        //var area_final = ws.AreaFinalDelCircuitoDeViaticos();
        //Btn_AccesoDirectoAprobar.Text = area.Contacto

        // Esto se harcodea hasta tener una definición de cómo obtener el área FIN:

        var viaticoActual = ((ComisionDeServicio)Session["comisionActual"]);

        if ((viaticoActual.AreaActual.Id).Equals(1073))
        {
            //this.controlTransiciones.Visible = false;
        }
        else
        {
            List<Area> areas = ws.GetAreas().ToList();
            var dataSourceAreas = new List<Object>();

            areas.ForEach(delegate(Area a)
                {
                    dataSourceAreas.Add(new {label = a.Nombre, value = a.Id.ToString() });
                });
            this.ListaAreas.Value = JsonConvert.SerializeObject(dataSourceAreas);

            ws.GetAccionesDeTransicionParaUnViaticoEnCirculacion().ToList().ForEach(a => this.cmbAccion.Items.Add(new System.Web.UI.WebControls.ListItem(a.Descripcion, a.Id.ToString())));

            AgregarAreasAnterioresAlComboDeSolicitarModificacion(viaticoActual);

            this.AlertaTransicionInvalida.Visible = false;
        }
            
    }

    private void AgregarAreasAnterioresAlComboDeSolicitarModificacion(ComisionDeServicio viaticoActual)
    {
        foreach (var t in viaticoActual.TransicionesRealizadas)
        {
            var a = t.AreaOrigen;
            //Agrego las areas distintas entre si y distintas al area actual
            if (this.cmbAreasTransicionesAnteriores.Items.FindByValue(a.Id.ToString()) == null)
            {
                if (a.Id != viaticoActual.AreaActual.Id)
                {
                    this.cmbAreasTransicionesAnteriores.Items.Add(new System.Web.UI.WebControls.ListItem(a.Nombre, a.Id.ToString()));
                }
            }
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
        try
        {
            Int32 id_area = Int32.Parse(this.AreaSeleccionada.Value);
            ws.ReasignarComision(una_comision, id_area, Int32.Parse(this.cmbAccion.SelectedValue), this.txtComentarios.Text);
            Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
        }
        catch (FormatException)
        {
            this.AlertaTransicionInvalida.InnerText = "Debe seleccionar un área destino para enviar el viático";
            this.AlertaTransicionInvalida.Visible = true;
        }

     }

    //protected void btnAprobarYEnviarA_Click(object sender, EventArgs e)
    //{
    //    WSViaticosSoapClient ws = new WSViaticosSoapClient();
    //    ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
    //    ws.ReasignarComision(una_comision, ws.GetAreaSuperiorA(((ComisionDeServicio)Session["comisionActual"]).AreaActual).Id, 1, "");
    //    Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    //}

    //protected void btnRechazarYNotificarA_Click(object sender, EventArgs e)
    //{

    //}
    
    //protected void btnSolicitarModificacionA_Click(object sender, EventArgs e)
    //{
    //    WSViaticosSoapClient ws = new WSViaticosSoapClient();
    //    ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
    //    ws.ReasignarComision(una_comision, ws.GetAreaPreviaDe(((ComisionDeServicio)Session["comisionActual"])).Id , 2, "");
    //    Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    //}

    protected void Btn_AccesoDirectoAprobar_Click(object sender, EventArgs e)
    {
        /**/

        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];
        ws.ReasignarComision(una_comision, ws.GetAreaSuperiorA(((ComisionDeServicio)Session["comisionActual"]).AreaActual).Id, 1, "");
        Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);


    }
    protected void Btn_AccesoDirectoSolicitarModificacion_Click(object sender, EventArgs e)
    {
        WSViaticosSoapClient ws = new WSViaticosSoapClient();
        ComisionDeServicio una_comision = (ComisionDeServicio)Session["comisionActual"];

        ws.ReasignarComision(una_comision, Int32.Parse(this.cmbAreasTransicionesAnteriores.SelectedValue), 2, "");
        Response.Redirect("~/FormularioDeViaticosAprobacion/FControlDeAprobacion.aspx", true);
    }
    
}