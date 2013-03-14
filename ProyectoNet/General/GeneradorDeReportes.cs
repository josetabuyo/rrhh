using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class GeneradorDeReportes
    {
       

        public GeneradorDeReportes()
        {
            // TODO: Complete member initialization

        }

        public List<ComisionDeServicio> TraerViaticosPorAreasCreadoras(List<ComisionDeServicio> total_comisiones,  List<Area> areas_creadoras)
        {

            return total_comisiones.FindAll(v => areas_creadoras.Any(a => a == v.AreaCreadora));// comisiones_filtradas;
        }

        public List<ComisionDeServicio> TraerViaticosPorAreasCreadorasYPorEstado(List<ComisionDeServicio> total_comisiones, List<Area> areas_creadoras, EstadosDeComision estadosDeComision)
        {
            return total_comisiones.FindAll(v => v.Estado == estadosDeComision && areas_creadoras.Any(a => a.Id == v.AreaCreadora.Id));// comisiones_filtradas;         
        }

        public List<List<string>> ViaticosPorAreasCreadorasYPorEstado(List<FiltroDeComisiones> filtros, List<ComisionDeServicio> comisiones)
        {
            var reporte = new List<List<string>>();
           
            filtros.ForEach(f => comisiones = f.Filtrar(comisiones));

            var areas = AreasEnComisiones(comisiones);
            areas.ForEach(a => GenerarFilaEn(reporte, ComisionesDelArea(a, comisiones)));
            return reporte;
        }

        public List<ComisionDeServicio> ComisionesDelArea(Area area, List<ComisionDeServicio> comisiones)
        {
            return comisiones.FindAll(c => c.AreaCreadora.Equals(area));
        }

        public List<ComisionDeServicio> ComisionesDelaPersona(Persona persona, List<ComisionDeServicio> comisiones)
        {
            return comisiones.FindAll(c => c.Persona.Equals(persona));
        }

        private List<Area> AreasEnComisiones(List<ComisionDeServicio> comisiones)
        {
            return comisiones.Select(c => c.AreaCreadora).Distinct().ToList();
        }

        private List<Persona> PersonasEnComisiones(List<ComisionDeServicio> comisiones)
        {
            return comisiones.Select(c => c.Persona).Distinct().ToList();
        }

        public bool HayAlgunaEstadiaEnElPeriodo(DateTime fechaDesde, DateTime fechaHasta, ComisionDeServicio v)
        {
            return v.Estadias.Any(e => e.Desde >= fechaDesde && e.Desde <= fechaHasta);
        }

        private List<string> GenerarFilaEn(List<List<string>> reporte, List<ComisionDeServicio> comisiones_por_areas)
        {
            List<string> fila = new List<string>();

            fila.Add(comisiones_por_areas[0].AreaCreadora.Nombre);
            fila.Add(comisiones_por_areas[0].Estado.ToString());
            fila.Add(comisiones_por_areas.Select(c => c.ImporteTotal()).Sum().ToString());
            
            fila.Add("20");

            reporte.Add(fila);
            
            return fila;
        }


        public List<List<string>> ViaticosPorProvincia(List<FiltroDeComisiones> filtros, List<ComisionDeServicio> comisiones, List<Provincia> provincias)
        {
            var reporte = new List<List<string>>();

            filtros.ForEach(f => comisiones = f.Filtrar(comisiones));

            // FC: tuve que comentar este metodo, xq me traia las provincias de todas las estadias, aunque no tengan las provincias seleccionadas
            // var provincias = ProvinciasEnEstadias(comisiones);

            provincias.ForEach(p => GenerarListadoPorProvincia(reporte, EstadiasDeLaProvincia(p, comisiones)));

            return reporte;
        }

        private List<string> GenerarListadoPorProvincia(List<List<string>> reporte, List<Estadia> estadias_por_provincia)
        {
            List<string> fila = new List<string>();

            if (estadias_por_provincia.Count > 0)
            {              
                fila.Add(estadias_por_provincia[0].Provincia.Nombre);
                fila.Add(estadias_por_provincia.Count.ToString());
                fila.Add("$1500.00");
                fila.Add("20");

                reporte.Add(fila);
            }

           

            return fila;
             
        }



        public List<List<string>> ViaticosDePersonaPorAreas(List<FiltroDeComisiones> filtros,  List<ComisionDeServicio> comisiones)
        {
            var reporte = new List<List<string>>();

            filtros.ForEach(f => comisiones = f.Filtrar(comisiones));

            //var areas = AreasEnComisiones(comisiones);

            GenerarListadoParaPersona(reporte, comisiones);
            return reporte;
            
            
            //List<List<string>> listado_para_mostrar = new List<List<string>>();

            //List<ComisionDeServicio> comisiones_filtradas = comisiones.FindAll(v => v.Persona.Documento == belen.Documento && lista_areas.Any(a => a.Id == v.AreaCreadora.Id) && v.Estadias.Any(e => e.Desde >= fechaDesde && e.Hasta <= fechaHasta));// comisiones_filtradas;

            //listado_para_mostrar.Add(GenerarListadoParaPersona(comisiones_filtradas));

            //return listado_para_mostrar;

            
    
        }

        private new List<string> GenerarListadoParaPersona(List<List<string>> reporte, List<ComisionDeServicio> total_comisiones)
        {
            List<string> fila = new List<string>();

            if (total_comisiones.Count > 0)
            {
                fila.Add(total_comisiones[0].Persona.Documento.ToString());
                fila.Add(total_comisiones[0].Persona.Apellido);
                fila.Add(total_comisiones[0].Persona.Area.Nombre);
                fila.Add(total_comisiones.Count.ToString());
                fila.Add("$1500.00");
                fila.Add("20");

                reporte.Add(fila);
            }


            return fila;
        }

        private List<Estadia> EstadiasDelAreaYProvincia(Area area, Provincia provincia, List<ComisionDeServicio> comisiones)
        {
            List<Estadia> lista_estadia = new List<Estadia>();

            comisiones.FindAll(c => c.AreaCreadora.Equals(area)).ForEach(c => lista_estadia.AddRange(c.Estadias.FindAll(e => e.Provincia.Equals(provincia))));

            //comisiones.ForEach(c => lista_estadia.AddRange(c.Estadias.FindAll(e => e.Provincia.Equals(provincia))));

            return lista_estadia.Distinct().ToList();
        }
        private List<string> GenerarListadoPorAreaYProvincia(List<List<string>> reporte, Area area, List<Estadia> estadias)
        {

            List<string> fila = new List<string>();

            if (estadias.Count > 0) {
                fila.Add(area.Nombre);
                fila.Add(estadias[0].Provincia.Nombre);
                fila.Add(estadias.Count().ToString());
                fila.Add("30");

                reporte.Add(fila);
            }

            
            return fila;
        }

        public List<List<string>> ViaticoPorAreasPorProvincia(List<FiltroDeComisiones> filtros, List<ComisionDeServicio> comisiones, List<Provincia> provincias)
        {
            var reporte = new List<List<string>>();

            filtros.ForEach(f => comisiones = f.Filtrar(comisiones));
            
            var areas = AreasEnComisiones(comisiones);
            // var provincias = ProvinciasEnEstadias(comisiones);

            areas.ForEach(a => provincias.ForEach(p => GenerarListadoPorAreaYProvincia(reporte, a, EstadiasDelAreaYProvincia(a, p, comisiones))));

            return reporte;
        }

        private List<Provincia> ProvinciasEnEstadias(List<ComisionDeServicio> comisiones)
        {
            return (from comision in comisiones from estadia in comision.Estadias select estadia.Provincia).Distinct().ToList();
        }

        public List<Estadia> EstadiasDeLaProvincia(Provincia provincia, List<ComisionDeServicio> comisiones)
        {
            List<Estadia> lista_estadia = new List<Estadia>();

            comisiones.ForEach(c => lista_estadia.AddRange(c.Estadias.FindAll(e => e.Provincia.Equals(provincia))));

            return lista_estadia.Distinct().ToList();
        }

        private List<string> GenerarListadoParaReporteAreaProvinciaFecha(Area area, Estadia estadia)
        {
            List<string> fila = new List<string>();

            fila.Add(area.Nombre);
            fila.Add(estadia.Provincia.Nombre);
            fila.Add("50");
            fila.Add("30");

            return fila;
        }

        private List<ComisionDeServicio> GetComisionesFiltradas(List<ComisionDeServicio> total_comisiones, List<Area> lista_areas, DateTime fechaDesde, DateTime fechaHasta)
        {
            return total_comisiones.FindAll(
                            v => lista_areas.Any(a => a.Id == v.AreaCreadora.Id)
                                && v.Estadias.Any(e => e.Desde >= fechaDesde
                                    && e.Hasta <= fechaHasta));
        }

        public List<List<string>> PersonasQueMasSolicitaronViaticos(List<FiltroDeComisiones> filtros, List<ComisionDeServicio> comisiones)
        {
            var reporte = new List<List<string>>();

            filtros.ForEach(f => comisiones = f.Filtrar(comisiones));

            comisiones.Sort(
               (viatico1, viatico2) => viatico1.esMayorAlfabeticamenteQue(viatico2));

            var personas = PersonasEnComisiones(comisiones);
            personas.ForEach(p => GenerarListadoParaRanking(reporte, ComisionesDelaPersona(p, comisiones)));

            return reporte;
            
            
            //List<ComisionDeServicio> viaticos = GetComisionesFiltradas(lista_comisiones, lista_areas, fechaDesde, fechaHasta);
           

            //Dictionary<Persona, List<ComisionDeServicio>> personas_con_comisiones = new Dictionary<Persona, List<ComisionDeServicio>>();

            //foreach (var comision in viaticos)
            //{
            //    if (!personas_con_comisiones.ContainsKey(comision.Persona))
            //    {
            //        personas_con_comisiones.Add(comision.Persona, new List<ComisionDeServicio>());
            //    }

            //    personas_con_comisiones[comision.Persona].Add(comision);
                
            //}

            //List<List<string>> listado_para_mostrar = new List<List<string>>();

            
            //foreach (List<ComisionDeServicio> comisiones_por_persona in personas_con_comisiones.Values)
            //{

            //    listado_para_mostrar.Add(GenerarListadoParaRanking(comisiones_por_persona));
              
            //}

            //return listado_para_mostrar;

        }

        private List<string> GenerarListadoParaRanking(List<List<string>> reporte, List<ComisionDeServicio> comisiones_por_persona)
        {
            List<string> fila = new List<string>();

            fila.Add(comisiones_por_persona[0].Persona.Documento.ToString());
            fila.Add(comisiones_por_persona[0].Persona.Apellido);
            fila.Add(comisiones_por_persona[0].AreaCreadora.Nombre);
            fila.Add(comisiones_por_persona.Count.ToString());
            fila.Add("20");
            fila.Add("40");

            reporte.Add(fila);
            
            return fila;
        }
    }
}
