#region

using System;
using System.Collections.Generic;
using WSViaticos;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web;
using System.IO;




#endregion

public partial class FCargaComisionDeServicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Sesion.VerificarSesion(this);
        //GetFotosDelDirectorio();
        Encriptador crypt = new Encriptador();
               
        //esta idtemporal es para ir agregando los id negativos a las estadias y pasajes nuevos durante el cargado
        if (Session["idtemporal"] == null)
        {
            Session["idtemporal"] = 0;
        }

        if (Session["personaViatico"] != null)
        {
            WSViaticosSoapClient service = new WSViaticosSoapClient();
            Persona personaViat = (Persona)Session["personaViatico"];
            personaViat = service.CompletarDatosDeContratacion(personaViat);
            Session[ConstantesDeSesion.PERSONA] = personaViat;
            string documentoEncriptado = crypt.getMd5Hash(personaViat.Documento + ".jpg");

            this.img_perfil.ImageUrl = "../Imagenes/fotosEncriptadas/" + documentoEncriptado + ".jpg";

         
        }

        /*AZA -Para control de fechas superpuestas contra la base. Ver si se deja.*/
        //if (Session["estadiasAnteriores"] == null)
        //{
        //    WSViaticosSoapClient service = new WSViaticosSoapClient();
        //    Persona personaViat = (Persona)Session["personaViatico"];
        //    lista_estadias_anteriores_persona = service.GetEstadiasPorPersona(personaViat.Documento);
        //    Session["estadiasAnteriores"] = lista_estadias_anteriores_persona;

        try
        {
            this.DatosDelAgente1.Agente = (Persona)Session[ConstantesDeSesion.PERSONA];
            this.DatosDelAgente1.Area = (Area)Session[ConstantesDeSesion.AREA_ACTUAL];
        }
        catch (Exception)
        {
            Response.Redirect("~\\Principal.aspx");
        }

        if (Session["zonas"] == null)
        {
            WSViaticosSoapClient service = new WSViaticosSoapClient();
            //WSViaticos.WSViaticos service =  new WSViaticos.WSViaticos();

            Session["zonas"] = service.ZonasDeViaticos();
            Session["mediosDeTransporte"] = service.MediosDeTransporte();
            Session["mediosDePagos"] = service.MediosDePago();

        }

        List<Provincia> provincias = new List<Provincia>();

        foreach (Zona unaZona in (Zona[])Session["zonas"])
        {
            foreach (Provincia unaProvincia in unaZona.Provincias)
            {
                provincias.Add(unaProvincia);
            }
        }

        Provincia[] vectorProvincias = new Provincia[provincias.Count];

        for (int i = 0; i < provincias.Count; i++)
        {
            vectorProvincias[i] = provincias[i];
        }



        if (!IsPostBack)
        {
            this.ControlEstadia.Provincias = vectorProvincias;
            this.ControlPasaje.Medios = (MedioDeTransporte[])Session["mediosDeTransporte"];
            this.ControlPasaje.Pagos = (MedioDePago[])Session["mediosDePagos"];
        }

        this.ControlPasaje.Provincias = vectorProvincias;

        this.ControlPasaje.Acepto += new EventHandler(CambioCombo);

        this.ControlGrillaEstadias.AgregarEncabezado();
        this.ControlGrillaPasajes.AgregarEncabezado();

        ComisionDeServicio comision = (ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        if ((bool)Session["VieneDeModificacion"])
        {
            if (comision.Id != 0)
            {
            //Completar la grilla para modificar
            this.ControlGrillaEstadias.MostrarTablaDeEstadias(comision);
            this.ControlGrillaPasajes.MostrarTablaDePasajes(comision);
            Session["VieneDeModificacion"] = false;
            }
        }
        

        //esto es para capturar el id que se envia por la url de la pantalla y poder quitar o no de las listas
        string id_estadia = Request.QueryString["EstadiaAQuitar"];
        string id_pasaje = Request.QueryString["PasajeAQuitar"];

        QuitarEstadia(id_estadia);
        QuitarPasaje(id_pasaje);
    }




    private void QuitarEstadia(string id)
    {
        List<string> id_estadias_quitadas = (List<string>)Session["EstadiasQuitadas"];

        if (id != null)
        {
            if (!id_estadias_quitadas.Contains(id))
            {
                QuitarEstadiaDelListado(int.Parse(id));
                id_estadias_quitadas.Add(id);
            }
        }
    }

    private void QuitarPasaje(string id)
    {
        List<string> id_pasajes_quitadas = (List<string>)Session["PasajesQuitadas"];

        if (id != null)
        {           
            if (!id_pasajes_quitadas.Contains(id))
            {
                QuitarPasajeDelListado(int.Parse(id));
                id_pasajes_quitadas.Add(id);
            }
        }
    }

    //PONGO ESTE METODO PARA QUE LO ESCUCHE PERO NO HAGO NADA
    void CambioCombo(object sender, EventArgs e)
    {

    }

    protected void btn_agregar_estadia_Click(object sender, EventArgs e)
    {

        if (!DatosEstadiaSonCorrectos())
        {
            return;
        }

        /*AZA Validación de fechas superpuestas en estadías*/
        if (ValidarFechasEstadiaSonSuperpuestas())
        {

            string mensaje = "Ya ingresó una estadía entre esas fechas.";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");



           // this.labelGuardado.Text = "Ya ingresó una estadía entre esas fechas.";
            this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
            this.ControlEstadia.LimpiarControles();
            // Session.Contents.Remove("");

            return;
        }



        Session["idtemporal"] = GenerarIdNegativo((int)Session["idtemporal"]);
        var persona = (Persona)Session[ConstantesDeSesion.PERSONA];

        WSViaticosSoapClient service = new WSViaticosSoapClient();
        
        Estadia estadia = new Estadia();
        estadia.Id = (int)Session["idtemporal"];
        estadia.Desde =  this.ControlEstadia.Desde;
        estadia.Hasta = this.ControlEstadia.Hasta;
        estadia.AdicionalParaPasajes = this.ControlEstadia.AdicionalParaPasajes;
        estadia.Eventuales = this.ControlEstadia.Eventuales;
        estadia.Motivo = this.ControlEstadia.Motivo;
        estadia.Provincia = this.ControlEstadia.ProvinciaElegida;
        estadia.Provincia.Zona = service.GetZonaDe(this.ControlEstadia.ProvinciaElegida);

        estadia.Persona = persona;
        //estadia.ComisionDeServicio = comision;

        /*AZA Validación de fechas superpuestas en estadías*/
        //if (ValidarFechasEstadiaSonSuperpuestas())
        //{
        //    this.labelGuardado.Text = "Ya ingresó una estadía entre esas fechas.";
        //    this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        //    Session.Contents.Remove("empresa");
        //    return;
        //}

        /*AZA Validación de fechas superpuestas en estadías contra la base de datos- VER SI SE DEJA*/
        //var estadias_anteriores = (Estadia[])Session["estadiasAnteriores"];
        //foreach (Estadia una_estadia in estadias_anteriores)
        //{
        //    if (ControlEstadia.Desde <= una_estadia.Hasta && ControlEstadia.Desde >= una_estadia.Desde)
        //    {
        //        this.labelGuardado.Text = "Ya se ha cargado en el sistema una estadía entre esas fechas.";
        //        this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        //        return;
        //    }               
        //}
        

        /*FIN AZA Validación de fechas superpuestas en estadías*/

        AddEstadia(estadia);

        this.ControlEstadia.LimpiarControles();
        
        this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        this.ControlGrillaPasajes.MostrarTablaDePasajes((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        this.labelGuardado.Text = "";
        DateTime fecha_servidor = DateTime.Today;
        bool menor_a_72_horas = ValidacionesEnComisionesDeServicios.Validar72Horas(fecha_servidor, estadia.Desde);

        if (menor_a_72_horas) {

            string mensaje = "Viático pedido con un lapso menor a 72 horas hábiles.";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");

        };


    }

    private int GenerarIdNegativo(int id_temp)
    {
        return id_temp - 1;
    }

    private bool DatosEstadiaSonCorrectos()
    {
        if (ControlEstadia.Desde.ToString().Length == 0)
        {
            return false;
        }

        if (ControlEstadia.Hasta.ToString().Length == 0)
        {
            return false;
        }

        if (ControlEstadia.Desde > ControlEstadia.Hasta)
        {
            return false;
        }
        return true;
    }


    private bool ValidarFechasEstadiaSonSuperpuestas()
    {
        DateTime fecha_desde;
        DateTime fecha_maxima;

        fecha_desde = this.ControlEstadia.Desde;
        fecha_maxima = ObtenerFechaMaximaEstadia();

        if (fecha_desde < fecha_maxima)
        {
            return true;
        }
        return false;
    }


    public DateTime ObtenerFechaMaximaEstadia()
    {
        ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];
        DateTime maxDate = DateTime.MinValue;
        foreach (Estadia estadia in viatico_en_edicion.Estadias)
        {
            if (maxDate < estadia.Hasta)
            {
                maxDate = estadia.Hasta;
            }
        }
        return maxDate;
    }

    private List<Pasaje> pasajes()
    {
        return new List<Pasaje>(((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]).Pasajes);
    }

    private List<Estadia> estadias()
    {
        return new List<Estadia>(((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]).Estadias);
    }

    private void AddPasaje(Pasaje pasaje)
    {
        ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        var nuevos_pasajes = pasajes();// new List<Pasaje>(viatico_en_edicion.Pasajes);
        nuevos_pasajes.Add(pasaje);

        viatico_en_edicion.Pasajes = nuevos_pasajes.ToArray();

    }

    private void AddEstadia(Estadia estadia)
    {
        ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        var nuevos_estadias = estadias();// new List<Estadia>(viatico_en_edicion.Estadias);
        nuevos_estadias.Add(estadia);

        viatico_en_edicion.Estadias = nuevos_estadias.ToArray();

    }


    protected void btn_agregar_pasaje_Click(object sender, EventArgs e)
    {
        Localidad localidad_origen = this.ControlPasaje.LocalidadOrigen;
        Localidad localidad_destino = this.ControlPasaje.LocalidadDestino;

        Session["idtemporal"] = GenerarIdNegativo((int)Session["idtemporal"]);
        var comision = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        Pasaje pasaje = new Pasaje();
        pasaje.Id = (int)Session["idtemporal"];
        pasaje.FechaDeViaje = this.ControlPasaje.FechaPasaje;
        pasaje.Origen = localidad_origen;
        pasaje.Destino = localidad_destino;
        pasaje.MedioDeTransporte = this.ControlPasaje.MediosDeTransporte;
        pasaje.MedioDePago = this.ControlPasaje.MediosDePago;
        pasaje.Precio = this.ControlPasaje.Precio;
        //pasaje.ComisionDeServicio = comision;

        AddPasaje(pasaje);

        this.ControlGrillaPasajes.MostrarTablaDePasajes((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        
        DateTime fecha_servidor = DateTime.Today;
        bool menor_a_72_horas = ValidacionesEnComisionesDeServicios.Validar72Horas(fecha_servidor, pasaje.FechaDeViaje);

        if (menor_a_72_horas)
        {

            string mensaje = "Viático pedido con un lapso menor a 72 horas hábiles.";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");

        };

        this.ControlPasaje.LimpiarControles();
    }

    

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        var comision = (ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION];
        if (estadias().Count == 0)
        {
            //this.labelGuardado.Text = "Debe especificar la estadía.";


            string mensaje = "Debe especificar la estadía.";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");


            return;



        }

        comision.AreaCreadora = (Area)Session[ConstantesDeSesion.AREA_ACTUAL];
        comision.Persona = (Persona)Session[ConstantesDeSesion.PERSONA];
        comision.AreaActual = (Area)Session[ConstantesDeSesion.AREA_ACTUAL];

        WSViaticosSoapClient ws = new WSViaticosSoapClient();

        
        if (((Usuario)Session[ConstantesDeSesion.USUARIO]).EsFirmante)
        {
            comision.AreaSuperior = ws.GetAreaSuperiorA(comision.AreaActual);
        } else {
            comision.AreaSuperior = comision.AreaActual;
        }

        comision = PonerEn0LosIdDeLasEstadiasYPasajesNuevas(comision);

        try
        {
            /*AZA Validación de fechas superpuestas en estadías contra la base de datos*/

            if (!ws.PuedeGuardarseComision(comision))
            {
                string mensaje = "Ya existen registradas estadías para esta persona en ese rango de fechas.";
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");

                this.ControlGrillaPasajes.MostrarTablaDePasajes((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
                this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
        

                return;

            }
            


            ws.AltaDeComisionDeServicio(comision);

            //limpio la comision de la sesion
            LimpiarComisionEnSession();

            //this.labelGuardado.Text = "Estadía guardada correctamente";


            string mensaje2 = "Estadía guardada correctamente";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje2 + "');</script>");


        }
        catch (Exception)
        {
            LimpiarComisionEnSession();
            //this.labelGuardado.Text = "No cargó ninguna estadía";

            string mensaje = "No cargó ninguna estadía";
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:mostrarMensaje('" + mensaje + "');</script>");


        }
    }



    private void LimpiarComisionEnSession()
    {   ComisionDeServicio comisionEnEdicion = new ComisionDeServicio();
        comisionEnEdicion.Estadias = new Estadia[0];
        comisionEnEdicion.Pasajes = new Pasaje[0];
        Session[ConstantesDeSesion.VIATICO_EN_EDICION] = comisionEnEdicion;
     

    }


    private ComisionDeServicio PonerEn0LosIdDeLasEstadiasYPasajesNuevas(ComisionDeServicio comision)
    {
        foreach (var estadia in comision.Estadias)
        {
            if (estadia.Id < 0)
            {
                estadia.Id = 0;
            }
        }

        foreach (var pasaje in comision.Pasajes)
        {
            if (pasaje.Id < 0)
            {
                pasaje.Id = 0;
            }
        }

        return comision;
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {


    }

    //[ScriptMethod, WebMethod]
    //public static string  QuitarEstadia(object id_estadia)
    //{
    //    ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION];
    //    List<Estadia> estadias_existentes = new List<Estadia>(viatico_en_edicion.Estadias);
    //    Estadia estadia_a_borrar = estadias_existentes.Find(e => e.Id == (int)id_estadia);
    //    estadias_existentes.Remove(estadia_a_borrar);
    //    viatico_en_edicion.Estadias = estadias_existentes.ToArray();
    //    //this.ControlGrillaEstadias.MostrarTablaDeEstadias((ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
    //    //this.ControlGrillaPasajes.MostrarTablaDePasajes((ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION]);
    //    return "FCargaComisionDeServicio.aspx";
    //}


    public void QuitarEstadiaDelListado(int id_estadia)
    {
        ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        List<Estadia> estadias_existentes = new List<Estadia>(viatico_en_edicion.Estadias);

        Estadia estadia_a_borrar = estadias_existentes.Find(e => e.Id == (int)id_estadia);

        estadias_existentes.Remove(estadia_a_borrar);

        viatico_en_edicion.Estadias = estadias_existentes.ToArray();

        this.ControlGrillaEstadias.MostrarTablaDeEstadias(viatico_en_edicion);
        this.ControlGrillaPasajes.MostrarTablaDePasajes(viatico_en_edicion);
    }

    public void QuitarPasajeDelListado(int id_pasaje)
    {
        ComisionDeServicio viatico_en_edicion = (ComisionDeServicio)HttpContext.Current.Session[ConstantesDeSesion.VIATICO_EN_EDICION];

        List<Pasaje> pasajes_existentes = new List<Pasaje>(viatico_en_edicion.Pasajes);

        Pasaje pasaje_a_borrar = pasajes_existentes.Find(p => p.Id == (int)id_pasaje);

        pasajes_existentes.Remove(pasaje_a_borrar);

        viatico_en_edicion.Pasajes = pasajes_existentes.ToArray();

        this.ControlGrillaEstadias.MostrarTablaDeEstadias(viatico_en_edicion);
        this.ControlGrillaPasajes.MostrarTablaDePasajes(viatico_en_edicion);
    }


   


   

}
