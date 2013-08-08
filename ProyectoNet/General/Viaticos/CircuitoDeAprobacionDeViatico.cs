namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CircuitoDeAprobacionDeViatico
    {
        private Organigrama organigrama;
        private List<List<int>> saltos_preferenciales;
        private Area area_final;

        public CircuitoDeAprobacionDeViatico(Organigrama organigrama, List<List<int>> saltos_preferenciales, Area area)
        {
            // TODO: Complete member initialization
            this.organigrama = organigrama;
            this.saltos_preferenciales = saltos_preferenciales;
            this.area_final = area;
        }

        public Area SiguienteAreaDe(Area area)
        {

            if (this.saltos_preferenciales.Any(s => s.First().Equals(area.Id)))
            {
                var id_area_preferida = this.saltos_preferenciales.Find(s => s.First().Equals(area.Id)).Last();
                return organigrama.ObtenerAreas(true).Find(a => a.Id == id_area_preferida);
            }
            else
            {
                return organigrama.AreaSuperiorDe(area);
            }
        }
    }
}
