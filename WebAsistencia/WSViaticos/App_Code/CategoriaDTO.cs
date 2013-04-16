using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class CategoriaDTO
{
    public CategoriaDTO(CategoriaDeDocumentoSICOI categoria)
    {
        id = categoria.Id;
        descripcion = categoria.descripcion;
    }

    public int id { get; set; }
    public string descripcion { get; set; }
}
