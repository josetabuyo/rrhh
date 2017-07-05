using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Esta es la super clase del los objetos que se usan para convertir
/// un modelo (grafo de objetos) en el diccionario para aplicar los valores
/// a los campos (placeholder) del pdf.
/// </summary>
public abstract class ModeloToPdfConverter
{
    protected Dictionary<string, string> mapa;
    public abstract Dictionary<string, string> CrearMapa(List<Object> modelo);

    public ModeloToPdfConverter()
    {
        mapa = new Dictionary<string, string>();
    }
}