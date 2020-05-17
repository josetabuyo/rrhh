using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class GenTarjetonToPdfConverter : ModeloToPdfConverter
{
    public GenTarjetonToPdfConverter()
    {
    }

    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {
        Vehiculo r = (Vehiculo) modelo[0];
        String codigoTarjeton = (String) modelo[1];
        String vigencia = (String) modelo[2];

        mapa.Add("texto1", vigencia);
        mapa.Add("texto2", r.Dominio);
        mapa.Add("texto3", r.Marca+" - "+ r.Modelo);
        mapa.Add("texto4", "Motor: "+r.Motor);
        mapa.Add("texto5", "Chasis: "+r.Chasis);
        mapa.Add("texto6", codigoTarjeton);
        mapa.Add("texto7", r.Marca + " - " + r.Modelo+" - Motor: " + r.Motor + " - Chasis: " + r.Chasis);
        //mapa.Add("texto6", Convert.ToString(r.cabecera.Orden));


        return mapa;
    }

}

