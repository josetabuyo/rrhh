using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General;
using General.Repositorios;


public class ActualizacionDomicilioToPdfConverter : ModeloToPdfConverter
{
    public ActualizacionDomicilioToPdfConverter()
    {
    }

    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {
        Persona p = (Persona)modelo[1];
        Usuario usr = (Usuario)modelo[0];
        CvDomicilio domicilioNuevo = (CvDomicilio)modelo[2];
        Area area = (Area)modelo[3];
        Area area_sup = (Area)modelo[4];

        //Usuario,fecha de generacion, identificador gedo
        string telefono = "";

        var dato_de_contacto = area.DatosDeContacto.OrderBy(c=> c.Orden).ToList().Find(c => c.Id == 1);
        if (dato_de_contacto != null)
        {
            telefono = dato_de_contacto.Dato;
        }


        mapa.Add("texto0", p.Documento.ToString());
        mapa.Add("texto1", p.Cuit);
        mapa.Add("texto2", p.Legajo);
        mapa.Add("texto3", p.Apellido + ", " + p.Nombre);
        mapa.Add("texto4", area.Nombre);
        mapa.Add("texto5", area_sup.Nombre);
        mapa.Add("texto6", area.Direccion);
        mapa.Add("texto7", telefono);
        mapa.Add("texto8", domicilioNuevo.Calle);
        mapa.Add("texto9", domicilioNuevo.Numero.ToString());
        mapa.Add("texto10", domicilioNuevo.Depto);
        mapa.Add("texto11", domicilioNuevo.Piso);
        mapa.Add("texto12", domicilioNuevo.Casa);
        mapa.Add("texto13", domicilioNuevo.Manzana);
        mapa.Add("texto14", domicilioNuevo.Barrio);
        mapa.Add("texto15", domicilioNuevo.Cp.ToString());
        mapa.Add("texto16", domicilioNuevo.NombreLocalidad);
        //mapa.Add("texto17", domicilioNuevo.NombrePartido);
        mapa.Add("texto18", domicilioNuevo.NombreProvincia);
        mapa.Add("texto19", domicilioNuevo.Torre);
        mapa.Add("texto20", domicilioNuevo.Uf);
        mapa.Add("texto21", domicilioNuevo.Telefono2);
        mapa.Add("texto22", domicilioNuevo.Telefono);

        mapa.Add("Nombre_usu", usr.Owner.Apellido + ", " + usr.Owner.Nombre + " (" + usr.Owner.Documento.ToString() + ")");
        mapa.Add("Fecha_hora", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
        mapa.Add("Identif_Formulario", domicilioNuevo.DocumentoGDE.ToString());

        return mapa;
    }




}

