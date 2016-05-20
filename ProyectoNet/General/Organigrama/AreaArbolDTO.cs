using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

namespace General
{
    public class AreaArbolDTO
    {
        public AreaArbolDTO()
        {

        }

        public AreaArbolDTO(Area area)
        {
            id = area.Id;
            nombre = area.Nombre;
            alias = area.Alias;
            areasDependientes = new List<AreaArbolDTO>();
            jerarquia = area.Jerarquia;
            orden = area.Orden;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string alias { get; set; }
        public List<AreaArbolDTO> areasDependientes { get; set; }
        public int jerarquia { get; set; }
        public int orden { get; set; }
    }
}