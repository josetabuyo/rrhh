using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class GenReciboToPdfConverter : ModeloToPdfConverter
{
    public GenReciboToPdfConverter()
    {
    }

    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {        
        Recibo r = (Recibo) modelo[0];
        //////////////////////////
///        //Usuario,fecha de generacion, identificador gedo
///        string telefono = "";

/*        var dato_de_contacto = area.DatosDeContacto.OrderBy(c=> c.Orden).ToList().Find(c => c.Id == 1);
        if (dato_de_contacto != null)
        {
            telefono = dato_de_contacto.Dato;
        }
*/

//        mapa.Add("texto0", p.Documento.ToString());
        mapa.Add("texto1", r.cabecera.Area);
        mapa.Add("texto2", Convert.ToString(r.cabecera.Legajo));
        mapa.Add("texto3", r.cabecera.Agente);
        mapa.Add("texto4", r.cabecera.CUIL);
        mapa.Add("texto5", Convert.ToString(r.cabecera.Oficina));
        mapa.Add("texto6", Convert.ToString(r.cabecera.Orden));
        mapa.Add("c1", telefono);
        mapa.Add("des1", domicilioNuevo.Calle);
        mapa.Add("h1", domicilioNuevo.Numero.ToString());
        mapa.Add("d1", domicilioNuevo.Depto);
        mapa.Add("c2", telefono);
        mapa.Add("des2", domicilioNuevo.Calle);
        mapa.Add("h2", domicilioNuevo.Numero.ToString());
        mapa.Add("d2", domicilioNuevo.Depto);
        mapa.Add("c3", telefono);
        mapa.Add("des3", domicilioNuevo.Calle);
        mapa.Add("h3", domicilioNuevo.Numero.ToString());
        mapa.Add("d3", domicilioNuevo.Depto);
        mapa.Add("c4", telefono);
        mapa.Add("des4", domicilioNuevo.Calle);
        mapa.Add("h4", domicilioNuevo.Numero.ToString());
        mapa.Add("d4", domicilioNuevo.Depto);
        mapa.Add("c5", telefono);
        mapa.Add("des5", domicilioNuevo.Calle);
        mapa.Add("h5", domicilioNuevo.Numero.ToString());
        mapa.Add("d5", domicilioNuevo.Depto);
        mapa.Add("c6", telefono);
        mapa.Add("des6", domicilioNuevo.Calle);
        mapa.Add("h6", domicilioNuevo.Numero.ToString());
        mapa.Add("d6", domicilioNuevo.Depto);
        



        mapa.Add("totalH", r.cabecera.Bruto );
        mapa.Add("totalD", domicilioNuevo.Casa);
        mapa.Add("neto", domicilioNuevo.Manzana);
        mapa.Add("categoria", domicilioNuevo.Barrio);
        mapa.Add("opcion", domicilioNuevo.Cp.ToString());
        mapa.Add("fechaLiquidacion", domicilioNuevo.NombreLocalidad);
        mapa.Add("tipoLiquidacion", domicilioNuevo.NombreProvincia);
        mapa.Add("dni", domicilioNuevo.Torre);
        mapa.Add("domicilio", domicilioNuevo.Uf);
        mapa.Add("fechaFirmaEmpleado", domicilioNuevo.Telefono2);
        mapa.Add("descripcionTipoLiquidacion", domicilioNuevo.Telefono);

//        mapa.Add("Nombre_usu", usr.Owner.Apellido + ", " + usr.Owner.Nombre + " (" + usr.Owner.Documento.ToString() + ")");
//        mapa.Add("Fecha_hora", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));

/*        if (domicilioNuevo.DocumentoGDE != null)
        {
            mapa.Add("Identif_Formulario", domicilioNuevo.DocumentoGDE.idDocumentoGDE.ToString());
        }
        else
        { //siempre va a haber un numero de gde, pero lo dejo porque puede cambiar al atributo numero interno de gde
            mapa.Add("Identif_Formulario", "----");
        }
*/
        

        return mapa;
    }

}

