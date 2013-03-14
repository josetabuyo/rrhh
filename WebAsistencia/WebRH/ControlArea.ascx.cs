using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSViaticos;
using WebRhUI;

public partial class ControlArea : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Usuario usuario = ((Usuario)Session["usuario"]);
        //MostrarTablaDeAreasDelUsuario(usuario); 

    }


    ////private void MostrarTablaDeAreasDelUsuario(Usuario un_usuario)
    ////{

    ////    RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new AreaToRowSerializer());
    ////    Area[] areas_del_usuario = un_usuario.Areas;
    ////    Session["AreasDeUsuarios"] = un_usuario.Areas;
    ////    //renderizador.AgregarCabeceras(new string[] {"", "", ""}, this.TablaAreas);
    ////    //renderizador.RenderTo(new List<Area>(areas_del_usuario), this.TablaAreas);

    ////    //TableCell tc; TableRow tr;

    ////    List<List<string>> ListaDeAreas = new List<List<string>>();
    ////    int i = 0;

    ////    foreach (Area UnArea in areas_del_usuario)
    ////    {

    ////        ListaDeAreas = ConstruirAreas(UnArea);

    ////        renderizador.RenderTo(ListaDeAreas, this.TablaAreas);
            

    ////        i++;
    ////        //    tc = new TableCell();
    ////        //    tr = new TableRow();
    ////        //    ControlArea wc = new ControlArea();
    ////        //    wc = (ControlArea)LoadControl("~\\ControlArea.ascx");
    ////        //    wc.CargarUnArea(UnArea);
    ////        //    tc.Controls.Add(wc);
    ////        //    tr.Cells.Add(tc);
    ////        //    this.TablaAreas.Rows.Add(tr);
    ////    }


    ////}



    public void MostrarTablaDeAreasDelUsuario(Area UnArea)
    {

        RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new AreaToRowSerializer());
        
        this.lblNombreArea.Text = UnArea.Nombre;
        this.lbDireccion.Text = "<i>Dirección</i>: " + "<label class= 'area01datosresaltados'>" + UnArea.Direccion + "</label>";
        this.lbTelefonoArea.Text = "<i>Teléfono</i>: " + "<label class= 'area01datosresaltados'>" + UnArea.Telefono + "</label>";
        this.lbMailArea.Text = "<i>Mail</i>: " + "<label class= 'area01datosresaltados'>" + UnArea.Mail + "</label>";
        this.lbResponsable.Text = "<i>Responsable</i>: " + "<label class= 'area01datosresaltados'>" + UnArea.datos_del_responsable.Apellido + ' ' + UnArea.datos_del_responsable.Nombre + "</label>";

        if (UnArea.Asistentes.First().Apellido != "")
        {
            foreach (Asistente asistente in UnArea.Asistentes)
            {

                this.lbAsistentes.Text += "<br/><i>" + asistente.Descripcion_Cargo + "</i>: "
                                         + "<label class= 'area01datosresaltados'>" + asistente.Apellido + ' ' + asistente.Nombre + "</label>" +
                                         " <i>Teléfono</i>: " + "<label class= 'area01datosresaltados'>" + asistente.Telefono + "</label>"
                                         + " <i>Mail</i>: " + "<label class= 'area01datosresaltados'>" + asistente.Mail + "</label>";

            }

        }
        else 
        {
            this.lbAsistentes.Text += "<br/>" + "Asistente: Teléfono: Mail: ";
        }

        this.lbAsistentes.Text += "<br/>"; //le agregro otro salto para separar los botones finales

        List<List<string>> ListaDeAreas = new List<List<string>>();

        //string telefonos = "";
        //string contactos = "";
        //foreach (ContactoArea contacto in UnArea.Contacto)
        //{
        //   // telefonos = telefonos + contacto.Telefonos.First().ToString();
                                
        //}


       
        //foreach (Persona responsable in UnArea.Responsables)
        //{
        //    contactos = contactos + responsable.Apellido + ", " + responsable.Nombre;

        //}aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa



        //Ver donde se están guardando todos los datos
       // this.lbResponsable.Text = UnArea.Contacto.First().Contacto;
        //this.lbSecretaria.Text = contactos;//UnArea.Responsables.First().Apellido;
        //this.lbTelefono.Text = telefonos.ToString();// UnArea.Contacto[0].Telefonos.First();
       // this.lbCorreoElectronico.Text = UnArea.Contacto[0].Mails.First();
        //this.lbDireccion.Text = UnArea.Direccion;

        //var linkbutton = new LinkButton();
        //linkbutton.PostBackUrl = "/WebRH/Principal&IdArea=" + UnArea.Id.ToString();

        //this.linkbAdministracion.PostBackUrl = "Principal.aspx?IdArea=" + UnArea.Id.ToString();
       // this.LinkbModificacion.PostBackUrl = "FormulariosDatosDeContacto/FModificacionDatosDeContacto.aspx?IdArea=" + UnArea.Id.ToString();
        //this.img1.OnClientClick = "IrAlArea(" + UnArea.Id.ToString() + ")";

        ControladorDeWebControls controlador = new ControladorDeWebControls();

        
        var tc = new TableCell();
        var tr = new TableRow();
        tc.Text = controlador.DibujarLinkConImagen(UnArea, "IrAlArea", "Imagenes/Botones/administrar_s2.png", "99", "13");
        tr.Cells.Add(tc);
        this.tablaBoton.Rows.Add(tr);

        tc = new TableCell();
        tc.Text = controlador.DibujarLinkConImagen(UnArea, "EditarElArea", "Imagenes/Botones/solicitar_modificacion_s2.png", "147", "12");
        tr.Cells.Add(tc);
        this.tablaBoton.Rows.Add(tr);


      

        //this.linkbAdministracion.OnClientClick = "IrAlArea(" + UnArea.Id.ToString() + ")";
        //this.linkbAdministracion.Click += IrAlArea(UnArea.Id.ToString());
        //this.Links.Controls.Add(linkbutton);

        //ListaDeAreas = ConstruirAreas(UnArea);

        //ListaDeAreas.ForEach(area => AgregarArea(area, thi));

        //    renderizador.RenderTo(ListaDeAreas, this.TablaAreasDetalle);

    }

    //-----------------------
    //public void MostrarTablaDeAreasDelUsuario(Area UnArea)
    //{

    //    RenderizadorDeTablas<List<string>> renderizador = new RenderizadorDeTablas<List<string>>(new AreaToRowSerializer());

    //    this.lblNombreArea.Text = UnArea.Nombre.ToString();

    //    List<List<string>> ListaDeAreas = new List<List<string>>();

    //    string telefonos = "";
    //    string contactos = "";
    //    foreach (ContactoArea contacto in UnArea.Contacto)
    //    {
    //        // telefonos = telefonos + contacto.Telefonos.First().ToString();

    //    }



    //    //foreach (Persona responsable in UnArea.Responsables)
    //    //{
    //    //    contactos = contactos + responsable.Apellido + ", " + responsable.Nombre;

    //    //}aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa



    //    //Ver donde se están guardando todos los datos
    //    // this.lbResponsable.Text = UnArea.Contacto.First().Contacto;
    //    this.lbSecretaria.Text = contactos;//UnArea.Responsables.First().Apellido;
    //    this.lbTelefono.Text = telefonos.ToString();// UnArea.Contacto[0].Telefonos.First();
    //    // this.lbCorreoElectronico.Text = UnArea.Contacto[0].Mails.First();
    //    this.lbDireccion.Text = UnArea.Direccion;

    //    //var linkbutton = new LinkButton();
    //    //linkbutton.PostBackUrl = "/WebRH/Principal&IdArea=" + UnArea.Id.ToString();

    //    //this.linkbAdministracion.PostBackUrl = "Principal.aspx?IdArea=" + UnArea.Id.ToString();
    //    // this.LinkbModificacion.PostBackUrl = "FormulariosDatosDeContacto/FModificacionDatosDeContacto.aspx?IdArea=" + UnArea.Id.ToString();
    //    //this.img1.OnClientClick = "IrAlArea(" + UnArea.Id.ToString() + ")";

    //    ControladorDeWebControls controlador = new ControladorDeWebControls();


    //    var tc = new TableCell();
    //    var tr = new TableRow();
    //    tc.Text = controlador.DibujarLinkConImagen(UnArea, "IrAlArea", "Imagenes/Botones/administrar_s2.png", "99", "13");
    //    tr.Cells.Add(tc);
    //    this.tablaBoton.Rows.Add(tr);

    //    tc = new TableCell();
    //    tc.Text = controlador.DibujarLinkConImagen(UnArea, "EditarElArea", "Imagenes/Botones/solicitar_modificacion_s2.png", "147", "12");
    //    tr.Cells.Add(tc);
    //    this.tablaBoton.Rows.Add(tr);




    //    //this.linkbAdministracion.OnClientClick = "IrAlArea(" + UnArea.Id.ToString() + ")";
    //    //this.linkbAdministracion.Click += IrAlArea(UnArea.Id.ToString());
    //    //this.Links.Controls.Add(linkbutton);

    //    //ListaDeAreas = ConstruirAreas(UnArea);

    //    //ListaDeAreas.ForEach(area => AgregarArea(area, thi));

    //    //    renderizador.RenderTo(ListaDeAreas, this.TablaAreasDetalle);

    //}
    //-----------------------





    private List<List<string>> ConstruirAreas(Area area)
    {

        List<List<string>> lista_de_areas = new List<List<string>>();

        
        //List<string> area_nombre = new List<string>();
        //area_nombre.Add("<b>Area:</b>");
        //area_nombre.Add(area.Nombre);
        //area_nombre.Add("");
        //area_nombre.Add("");


        if (area.Id == 939)
        {

            List<string> area_responsable = new List<string>();
            area_responsable.Add("<b>Responsable/s:</b> ");
            area_responsable.Add("Fabián Miranda");
            area_responsable.Add("");
            area_responsable.Add("");

            List<string> area_secretaria = new List<string>();
            area_secretaria.Add("<b>Secretaria/s:</b> ");
            area_secretaria.Add("Sin Secretaria");
            area_secretaria.Add("");
            area_secretaria.Add("");

            List<string> area_telefono = new List<string>();
            area_telefono.Add("<b>Teléfono/s:</b> ");
            area_telefono.Add("4768-5846");
            area_telefono.Add("");
            area_telefono.Add("");

            List<string> area_mail = new List<string>();
            area_mail.Add("<b>Mail:</b> ");
            area_mail.Add("fabian.miranda@ministeriodesarrollosocial.gob.ar");
            area_mail.Add("");
            area_mail.Add("");

            List<string> area_direccion = new List<string>();
            area_direccion.Add("<b>Dirección:</b> ");
            area_direccion.Add("9 de Julio - Edificio Evita");
            area_direccion.Add("");
            area_direccion.Add("");

            List<string> area_id = new List<string>();
            area_id.Add("");
            area_id.Add("");
            area_id.Add(area.Id.ToString());
            area_id.Add(area.Id.ToString());


            // lista_de_areas.Add(area_nombre);
            lista_de_areas.Add(area_responsable);
            lista_de_areas.Add(area_secretaria);
            lista_de_areas.Add(area_telefono);
            lista_de_areas.Add(area_mail);
            lista_de_areas.Add(area_direccion);
            lista_de_areas.Add(area_id);

            return lista_de_areas;
        }else
        {
            List<string> area_responsable = new List<string>();
            area_responsable.Add("<b>Responsable/s:</b> ");
            area_responsable.Add("Marta Novoa");
            area_responsable.Add("");
            area_responsable.Add("");

            List<string> area_secretaria = new List<string>();
            area_secretaria.Add("<b>Secretaria/s:</b> ");
            area_secretaria.Add("María Teresa Sotelo");
            area_secretaria.Add("");
            area_secretaria.Add("");

            List<string> area_telefono = new List<string>();
            area_telefono.Add("<b>Teléfono/s:</b> ");
            area_telefono.Add("4768-5800");
            area_telefono.Add("");
            area_telefono.Add("");

            List<string> area_mail = new List<string>();
            area_mail.Add("<b>Mail:</b> ");
            area_mail.Add("marta.novoa@ministerio.gob.ar");
            area_mail.Add("");
            area_mail.Add("");

            List<string> area_direccion = new List<string>();
            area_direccion.Add("<b>Dirección:</b> ");
            area_direccion.Add("Av. Corrientes 500");
            area_direccion.Add("");
            area_direccion.Add("");

            List<string> area_id = new List<string>();
            area_id.Add("");
            area_id.Add("");
            area_id.Add(area.Id.ToString());
            area_id.Add(area.Id.ToString());


            // lista_de_areas.Add(area_nombre);
            lista_de_areas.Add(area_responsable);
            lista_de_areas.Add(area_secretaria);
            lista_de_areas.Add(area_telefono);
            lista_de_areas.Add(area_mail);
            lista_de_areas.Add(area_direccion);
            lista_de_areas.Add(area_id);

            return lista_de_areas;
        }

    }



    //public void CargarUnArea(Area area)
    //{
    //    lblArea.Text = area.Nombre;
    //    lblResponsable.Text = "";
    //    lblSecretaria.Text = "";
    //    lblTelefono.Text = "";
    //    lblMail.Text = "";
    //    lblDireccion.Text = "";
    //}
}