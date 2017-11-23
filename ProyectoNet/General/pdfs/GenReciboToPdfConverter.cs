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

        //recorro cada fila de la descripcion
       /* for (int i = 0; i<r.detalles.Count;i++ )
        {
        }*/
        int i = 0;
        foreach (Detalle d in r.detalles)
        {
            mapa.Add("c"+i, d.Concepto);
            mapa.Add("des"+i, d.Descripcion);
            if (d.Aporte != 0) { mapa.Add("h" + i, Convert.ToString(d.Aporte));
            }else{
                mapa.Add("d" + i, Convert.ToString(d.Descuento));
            }
            
        }

        mapa.Add("totalH", r.cabecera.Bruto );
        mapa.Add("totalD", r.cabecera.Descuentos);
        mapa.Add("neto", r.cabecera.Neto);
        mapa.Add("categoria", r.cabecera.NivelGrado);
        mapa.Add("opcion", r.cabecera.OpcionJubilatoria);
        mapa.Add("fechaLiquidacion", r.cabecera.FechaLiquidacion);
        mapa.Add("tipoLiquidacion", r.cabecera.TipoLiquidacion);
        mapa.Add("dni", r.cabecera.Nro_Documento);
        mapa.Add("domicilio", r.cabecera.Domicilio);
        mapa.Add("fechaFirmaEmpleado", DateTime.Now.ToString("dd/MM/yyyy"));// tomo la fecha actual del server como fecha de firma del empleado
        mapa.Add("fechaDeposito", r.cabecera.Fecha_deposito.ToString("dd/MM/yyyy"));
        mapa.Add("descripcionTipoLiquidacionYMas", r.cabecera.DescripcionTipoLiquidacionYMas);

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

