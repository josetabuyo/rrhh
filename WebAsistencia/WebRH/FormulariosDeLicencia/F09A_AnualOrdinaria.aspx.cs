#region

using System;
using System.Web.UI.WebControls;
using WSViaticos;
////using WSWebRH;

#endregion

public partial class FormulariosDeLicencia_Default : System.Web.UI.Page
{
    private ConceptoDeLicencia _Concepto;

    #region CargaContenidos
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Titulo();
        ((Label)this.Master.FindControl("LTitulo")).Text = Titulo();
        ((Label)this.Master.FindControl("LResumenNormativa")).Text = Normativa();
        ((Label)this.Master.FindControl("LProcedimiento")).Text = Procedimiento();
        ((Label)this.Master.FindControl("LAclaracion")).Text = Aclaracion();
        this.AceptarCancelar1.PuedeAceptar = false;
        this.AceptarCancelar1.Acepto += new EventHandler(AceptarCancelar1_Acepto);
        this.DesdeHasta1.CambioFecha += new EventHandler(DesdeHasta1_CambioFecha);
        this.DesdeHasta1.DesplegoCalendario += new EventHandler(DesdeHasta1_DesplegoCalendario);
        _Concepto = new ConceptoDeLicencia();
        _Concepto.Id = 1;
        this.SaldoOrdinaria1.Concepto = _Concepto;
    }

    private string Titulo()
    {
        return @"Solicitud de Licencia Anual Ordinaria (Decreto 3.413/79 - Anexo I - Cap. II - Art 9)";
    }

    private string Aclaracion()
    {
        return @"* La cantidad de dias disponibles está sujeta a modificación ante licencias solicitadas anteriormente y que se encuentran pendientes de recepción ó procesamiento en la Dirección General de Recursos Humanos y Organización.";
    }

    private string Procedimiento()
    {
        return @"<b>Procedimiento a seguir:</b><br>
1. Complete e imprima el formulario (desde el botón correspondiente)<br>
2. Con la firma del responsable directo (rango no inferior a Director) y la notificación del agente, remita el formulario a la Dirección de Administración. ";
    }

    private string Normativa()
    {
        return @"La <b>licencia anual ordinaria</b> se acordará por año vencido.<br>
El período de licencia se otorgará con goce íntegro de haberes.<br>
El término de esta licencia será fijado en relación con la antigüedad que registre el agente al 31 de diciembre del año al que corresponda el beneficio.<br>
A pedido del interesado y siempre que por razones de servicio lo permitan, esta licencia podrá fraccionarse en dos (2) períodos.<br>
Los períodos en que el agente no preste servicios por hallarse en uso de licencia por afecciones o lesiones de largo tratamiento, accidentes de trabajo o enfermedad profesional, y las sin goce de sueldo —excluida la licencia por maternidad— no generan derecho a licencia anual ordinaria.<br>
ESTA SOLICITUD DEBE SER RECIBIDA EN LA DIRECCION DE ADMINISTRACIÓN DE PERSONAL 15 DIAS ANTES DEL INICIO DEL PERIODO DE LICENCIA QUE SE AUTORICE. ";

    }

    #endregion

    #region LogicaDeEventos
    void AceptarCancelar1_Acepto(object sender, EventArgs e)
    {
        try
        {
            Licencia l = new Licencia();
            l.Desde = this.DesdeHasta1.Desde;
            l.Hasta = this.DesdeHasta1.Hasta;
            l.Concepto = _Concepto;
            l.Persona = (Persona)Session["persona"];
            l.Persona.Area = (Area)Session["areaActual"];
            l.Auditoria = new Auditoria();
            l.Auditoria.UsuarioDeCarga = (Usuario)Session["usuario"];

            WSViaticosSoapClient s = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos s = new WSViaticos.WSViaticos();
            string error = s.CargarLicencia(l);
            if (error == null)
            {
                Response.Redirect("~\\Principal.aspx");
            }
            else
            {
                ((Label)this.Master.FindControl("LError")).Text = error;
            }
        }
        catch (Exception exception)
        {
            ((Label)this.Master.FindControl("LError")).Text = exception.ToString();
            //Response.Redirect("~\\Principal.aspx");
        }
    }

    void DesdeHasta1_DesplegoCalendario(object sender, EventArgs e)
    {
        this.AceptarCancelar1.PuedeAceptar = false;
    }

    void DesdeHasta1_CambioFecha(object sender, EventArgs e)
    {
        this.ValidarDatos();
        this.SaldoOrdinaria1.DiasSolicitados = this.DesdeHasta1.DiasEntreFechas();
        this.SaldoOrdinaria1.BuscarSegmentos(this.DesdeHasta1.Desde);


    }

    protected void RBOtorgada_CheckedChanged(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    protected void RBDenegada_CheckedChanged(object sender, EventArgs e)
    {
        this.ValidarDatos();
    }

    private void ValidarDatos()
    {
        bool DatosValidos = true;
        if (!this.DesdeHasta1.ValidarFechas())
            DatosValidos = false;

        if (this.DesdeHasta1.DiasEntreFechas() > this.SaldoOrdinaria1.DiasDisponibles)
            DatosValidos = false;

        if (!this.RBOtorgada.Checked && !this.RBDenegada.Checked)
            DatosValidos = false;
       
        WSViaticosSoapClient s = new WSViaticosSoapClient();
        var usuario = (Usuario)Session["usuario"];
        this.SaldoOrdinaria1.BuscarSegmentos(this.DesdeHasta1.Desde);
        if (this.SaldoOrdinaria1.SegmentosDisponibles == 0 && !s.ElUsuarioTienePermisosParaFuncionalidadPorNombre(usuario.Id, "mas_de_dos_periodos"))
        {
            DatosValidos = false;
        }

        if (this.DesdeHasta1.Desde < DateTime.Today && !s.ElUsuarioTienePermisosParaFuncionalidadPorNombre(usuario.Id, "licencias_antiguas"))
        {
            DatosValidos = false;
        }

        this.AceptarCancelar1.PuedeAceptar = DatosValidos;
    }
    #endregion

}
