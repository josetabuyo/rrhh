using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebRhUI;
using WSViaticos;
using Newtonsoft.Json.Linq;

public partial class AltaDeDocumento : System.Web.UI.Page
{
    private Usuario usuarioLogueado;
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        usuarioLogueado = ((Usuario)Session[ConstantesDeSesion.USUARIO]);
        
        Sesion.VerificarSesion(this);

        if (!usuarioLogueado.TienePermisosParaSiCoI)//mesa de entrada
        {      
            Response.Redirect("~/SeleccionDeArea.aspx");
        }
            
        var servicio = new WSViaticos.WSViaticosSoapClient();
        
        string areas_origen_destino;

        areas_origen_destino = servicio.AreasFormalesConInformales_JSON();

        this.ListaAreas.Value = areas_origen_destino;
        this.TiposDeDocumento.Value = JsonConvert.SerializeObject(servicio.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion));
        CompletarCombosDeTipoDeDocumentos();
        CompletarCombosDeCategoria();
        var areaDelUsuarioDTO = new {   id = usuarioLogueado.Areas[0].Id, 
                                        descripcion =  usuarioLogueado.Areas[0].Nombre};
        divAreaDelUsuario.Value = JsonConvert.SerializeObject(areaDelUsuarioDTO);
    }

    private void CompletarCombosDeTipoDeDocumentos()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var tiposDeDocumento = servicio.TiposDeDocumentosSICOI().OrderBy(td => td.descripcion);

        foreach (TipoDeDocumentoSICOI td in tiposDeDocumento)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = td.Id.ToString();
            unListItem.Text = td.descripcion;
            this.cmbFiltroPorTipoDeDocumento.Items.Add(unListItem);
        }
    }

    private void CompletarCombosDeCategoria()
    {
        var servicio = new WSViaticos.WSViaticosSoapClient();
        var categoriasDeDocumento = servicio.CategoriasDocumentosSICOI().OrderBy(cd => cd.descripcion);

        foreach (CategoriaDeDocumentoSICOI cd in categoriasDeDocumento)
        {
            ListItem unListItem = new ListItem();
            unListItem.Value = cd.Id.ToString();
            unListItem.Text = cd.descripcion;
            this.cmbCategoria.Items.Add(unListItem);
            this.cmbFiltroPorCategoria.Items.Add(unListItem);
        }
    }
}
