#region

using System;
using WSViaticos;

#endregion

//using WSWebRH;

public partial class Impresiones_AnticipoViaticosPasajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ComisionDeServicio Comision = new ComisionDeServicio();
        Persona Persona = new Persona();

        Comision = (ComisionDeServicio)Session["ComisionDeServicio"];
        Persona = ((Persona)Session["persona"]);

        lblAgente.Text = Persona.Apellido.ToString();
        lblDependencia.Text = Persona.Area.Dependencias[0].Nombre.ToString();
        lblTelefono.Text = "";
        lblCategoria.Text = "";
        lblLegajo.Text = "";
        lblCUIT.Text = "";
        //lblComision.Text = Comision.Estadias[0].Provincia[0].Nombre.ToString();
        lblFechaInicio.Text = Comision.Estadias[0].Desde.ToString();
        lblFechaFin.Text = Comision.Estadias[0].Hasta.Date.ToString();
        lblHoraInicio.Text = Comision.Estadias[0].Desde.ToString();
        lblHoraFin.Text = Comision.Estadias[0].Hasta.ToString();
        lblDias.Text = ""; //calculo Marcelo
        lblPesosDiario.Text = ""; //calculo agustin
        lblTotalPesos.Text = ""; // Comision.Estadias[0].AdicionalParaPasajes + Comision.Estadias[0].Eventuales;
        lblPasajesPesos.Text = Comision.Estadias[0].AdicionalParaPasajes.ToString();
        lblEventualesPesos.Text = Comision.Estadias[0].Eventuales.ToString();
        lblProgramaNro.Text = "";
        lblActividadNro.Text = "";

        lblDiasDPEP.Text = "";
        lblPesosDiarioDPEP.Text = "";
        lblTotalPesosDPEP.Text = ""; //Comision.Estadias[0].AdicionalParaPasajes + Comision.Estadias[0].Eventuales;
        lblPasajesPesosDPEP.Text = Comision.Estadias[0].AdicionalParaPasajes.ToString();
        lblEventualesPesosDPEP.Text = Comision.Estadias[0].Eventuales.ToString();

        lblRecibiPesosLetra.Text = "";
        lblRecibiPesosNro.Text = "";
        lblDiasRebici.Text = "";
        lblPesosDiarioRebici.Text = "";
        lblTotalPesosRebici.Text = ""; //Comision.Estadias[0].AdicionalParaPasajes + Comision.Estadias[0].Eventuales;
        lblPasajesPesosRebici.Text = Comision.Estadias[0].AdicionalParaPasajes.ToString();
        lblEventualesPesosRebici.Text = Comision.Estadias[0].Eventuales.ToString();

        lblApellidoNombrePersona.Text = Persona.Apellido.ToString() + ", " + Persona.Nombre.ToString();
    }
}
