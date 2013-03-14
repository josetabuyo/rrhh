using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Organigrama
    {
        private List<Nodo> nodos;

        public Organigrama(List<Area> areas_del_organigrama, List<List<Area>> dependencias)
        {
            List<Area> areas_inn;
            this.nodos = new List<Nodo>();
            areas_inn = new List<Area>(areas_del_organigrama);
            dependencias = new List<List<Area>>(dependencias);

            List<Area> roots = areas_inn.FindAll(area => NoDependeDeNadieSegun(area, dependencias));

            if (roots.Count> 1)
            {
                throw new OrganigramaException("El Organigrama Posee más de un Área como Área Superior a Todas las Área y por lo tanto es inconsistente");
            }
            if (roots.Count.Equals(0))
            {
                throw new OrganigramaException("El Organigrama No Posee las Áreas y Relaciones entre Áreas Básicas y por lo tanto es inconsistente");
            }

            Area area_root = roots.First();
            CrearNodoRootPara(area_root);

            areas_inn.Remove(area_root);

            areas_inn.ForEach(area => CrearNodoPara(area));

            RelacionarNodosSegun(dependencias);

        }


        private void RelacionarNodosSegun(List<List<Area>> dependencias)
        {
            var nodos_no_root = NodosNoRoot();

            nodos_no_root.ForEach(nodo => nodo.DependesDe(NodoPadreDe(dependencias, nodo)));
        }

        private Nodo NodoPadreDe(List<List<Area>> dependencias, Nodo nodo)
        {
            return NodoDe(FindAreaPadreDe(nodo.Area(), dependencias));
        }

        private List<Nodo> NodosNoRoot()
        {
            return this.nodos.FindAll(nodo => !nodo.EsRoot());
        }

        private Nodo NodoDe(Area area)
        {
            return this.nodos.Find(nodo => nodo.Area().Equals(area));
            
        }

        private Area FindAreaPadreDe(Area area, List<List<Area>> dependencias)
        {
            List<List<Area>> dependencias_del_area = dependencias.FindAll(dep => dep.First().Equals(area));

            if (dependencias_del_area.Count > 1)
            {

                throw new OrganigramaException("El Organigrama Posee Áreas con más de un Área Superior Directa Asignada y por lo tanto es Incosistente");
            }
            return dependencias_del_area.First().Last();
        }

        private void CrearNodoPara(Area area)
        {
            var new_nodo = new Nodo(area);
            this.nodos.Add(new_nodo);
        }

        private void CrearNodoRootPara(Area root)
        {
            this.nodos.Add(new NodoRoot(root));
        }

        private bool NoDependeDeNadieSegun(Area area, List<List<Area>> dependencias)
        {
            return !dependencias.Any(dep => dep.First().Equals(area));
        }


        public Area AreaSuperiorDe(Area un_area)
        {

            try
            {
                var nodo = NodoDe(un_area);
                return nodo.AreaPadre();
            }
            catch (Exception)
            {
                throw new OrganigramaException("Se pidió el Area superior a " + un_area.Nombre + ", y esta no tiene");
            }

        }

        public List<Area> AreasSuperioresDe(Area un_area)
        {
            return NodoDe(un_area).AreasSuperiores();
        }

        private Nodo NodoRoot()
        {
            return this.nodos.Find(n => n.EsRoot());
        }

        public List<Area> ObtenerAreas(bool incluir_informales)
        {
            List<Area> areas = new List<Area>();
            this.nodos.ForEach(n => areas.Add(n.Area()));
            return areas.FindAll(a => a.PresentaDDJJ || incluir_informales);
        }

         public List<Area> GetAreasInferioresDelArea(Area area)
        {
            List<Area> areas = new List<Area>();
            areas.AddRange(this.AreasInferioresInmediatasDe(area));
            this.AreasInferioresInmediatasDe(area).ForEach(a => areas.AddRange(this.GetAreasInferioresDelArea(a)));
            return areas;
        }

        public List<Area> AreasInferioresInmediatasDe(Area area)
        {
            List<Area> areas = new List<Area>();

            this.nodos.ForEach(n => areas.AddRange(n.AreasInferioresInmediatasDe(area)));

            return areas;
        }

 

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Organigrama return false.
            Organigrama o = obj as Organigrama;
            if ((System.Object)o == null)
            {
                return false;
            }

            return this.nodos.Count == o.nodos.Count;
        }

        public override int GetHashCode()
        {
            return this.nodos.Count;
        }

    }
}
