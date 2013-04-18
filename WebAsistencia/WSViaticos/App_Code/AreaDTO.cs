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
        descripcion = area.Alias;
    }

    public int id { get; set; }
    public string descripcion { get; set; }
}
