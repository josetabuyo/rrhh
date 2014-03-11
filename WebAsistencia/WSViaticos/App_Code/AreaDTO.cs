using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class AreaDTO
{
    public AreaDTO()
    {

    }

    public AreaDTO(Area area)
    {
        id = area.Id;
        nombre = area.Nombre;
        alias = area.Alias;
    }

    public int id { get; set; }
    public string nombre { get; set; }
    public string alias { get; set; }
}
