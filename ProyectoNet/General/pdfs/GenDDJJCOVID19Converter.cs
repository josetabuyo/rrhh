using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class GenDDJJCOVID19Converter: ModeloToPdfConverter
{
    public GenDDJJCOVID19Converter()
    {
    }

    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {        
        
//        mapa.Add("texto0", p.Documento.ToString());
        mapa.Add("Fecha", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
        mapa.Add("Agente", (String)modelo[8]);
        mapa.Add("A1", (String)modelo[0]);
        mapa.Add("A2", (String)modelo[1]);
        mapa.Add("A2A", (String)modelo[2]);
        mapa.Add("A2B", (String)modelo[3]);
        mapa.Add("A2C", (String)modelo[4]);
        mapa.Add("A2D", (String)modelo[5]);
        mapa.Add("B1", (String)modelo[6]);
        mapa.Add("B2", (String)modelo[7]);

        mapa.Add("B211", (String)modelo[9]);
        mapa.Add("B212", (String)modelo[10]);
        mapa.Add("B213", (String)modelo[11]);
        mapa.Add("B221", (String)modelo[12]);
        mapa.Add("B222", (String)modelo[13]);
        mapa.Add("B223", (String)modelo[14]);
        mapa.Add("B231", (String)modelo[15]);
        mapa.Add("B232", (String)modelo[16]);
        mapa.Add("B233", (String)modelo[17]);
        mapa.Add("B241", (String)modelo[18]);
        mapa.Add("B242", (String)modelo[19]);
        mapa.Add("B243", (String)modelo[20]);
        mapa.Add("B251", (String)modelo[21]);
        mapa.Add("B252", (String)modelo[22]);
        mapa.Add("B253", (String)modelo[23]);
        mapa.Add("id_ddjj", (String)modelo[24]);
                                    

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

