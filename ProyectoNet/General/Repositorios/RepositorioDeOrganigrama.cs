using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;

namespace General
{
    public class RepositorioDeOrganigrama : General.Repositorios.IRepositorioDeOrganigrama
    {
        private static RepositorioDeOrganigrama _instancia;
        private static DateTime _fecha_creacion;
        private Organigrama organigrama;
        private IConexionBD conexion_bd;
        //private InterpretadorDeCodigosDeArea interpretador_de_codigos;

        public RepositorioDeOrganigrama(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            //this.interpretador_de_codigos = new InterpretadorDeCodigosDeArea();
        }

        public static RepositorioDeOrganigrama NuevoRepositorioOrganigrama(IConexionBD conexion)
        {
           // if (_instancia == null || _fecha_creacion.AddMinutes(2) < DateTime.Now)
            if (_instancia == null || ExpiroTiempoDeOrganigrama())
            {
                _instancia = new RepositorioDeOrganigrama(conexion);
                _fecha_creacion = DateTime.Now;
            }
            return _instancia;
        }



        private static bool ExpiroTiempoDeOrganigrama()
        {
            if (FechaExpiracion() < DateTime.Now)
	        {
                return true;
	        }
            return false;
        }


        private static DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(2);

        }

        public Organigrama GetOrganigrama()
        {
            if (organigrama == null)
            {
                var areas = new List<Area>();
                var dependencias = new List<List<Area>>();

                TablaDeDatos estructura = conexion_bd.Ejecutar("dbo.VIA_GetOrganigrama", new Dictionary<string, object>());

                foreach (var row in estructura.Rows)
                {
                    var area_repetida = AreaRepetida(row, areas);
                    if (area_repetida == null)
                    {
                        AgregarAreaCreadaDesdeRow(row, areas);
                    }
                    //else
                    //    interpretador_de_codigos.PonerleCerosAlFinalDelCodigoDelArea(area_repetida);
                }

                areas.ForEach(a => AsignarPadreEn(a, dependencias, estructura, areas));


                var aliases = ObtenerTodosLosAliasDeAreas();
                aliases.ForEach((alias) =>
                {
                    var area_del_alias = areas.Find(area => area.Id == alias.IdArea);
                    if (area_del_alias != null) { area_del_alias.SetAlias(alias); }
                });

                organigrama = new Organigrama(areas, dependencias);
            }
            return organigrama;
        }


        public List<Alias> ObtenerTodosLosAliasDeAreas()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.Via_GetAlias");
            List<Alias> alias = new List<Alias>();
            tablaDatos.Rows.ForEach(row =>
            {
                alias.Add(new Alias(row.GetInt("Id"), row.GetInt("Id_Area"), row.GetString("Alias")));
            });
            return alias.Distinct().ToList();
            //return null;

        }

        private static void AgregarAreaCreadaDesdeRow(RowDeDatos row, List<Area> areas_del_organigrama)
        {
            if (!row.GetBoolean("Baja"))
                areas_del_organigrama.Add(new Area(row.GetInt("Id_Area"), row.GetString("Descripcion"), row.GetBoolean("Presenta_DDJJ")));
        }

        private static Area AreaRepetida(RowDeDatos row, List<Area> areas_del_organigrama)
        {
            return areas_del_organigrama.Find(a => a.Id.Equals(row.GetInt("Id_Area")));
        }

        private void AsignarPadreEn(Area area_hija, List<List<Area>> dependencias, TablaDeDatos estructura, List<Area> areas)
        {
            //var codigo_buscado = interpretador_de_codigos.CodigoDelAreaPadreDe(area_hija.Codigo, areas);
            var row_hija = estructura.Rows.Find(r => r.GetInt("Id_Area") == area_hija.Id);
            var id_madre = row_hija.GetInt("Id_Area_Madre");
            if (id_madre == area_hija.Id) return;
            dependencias.Add(new List<Area>() { area_hija, areas.Find(a => a.Id == id_madre) });
            
            //if (padres.Count > 1) throw new Exception("Un area tiene mas de un padre");
            //if (padres.Count.Equals(0)) return;
            //dependencias.Add(new List<Area>() { area_hija, padres[0] });
        }

        public List<List<int>> ExcepcionesDeCircuitoViaticos()
        {
            TablaDeDatos estructura = conexion_bd.Ejecutar("dbo.VIA_GetExcepcionesCircuito", new Dictionary<string, object>());
            List<List<int>> excepciones = new List<List<int>>();

            foreach (var row in estructura.Rows)
            {
                excepciones.Add(new List<int>() { row.GetInt("IdOrigen"), row.GetInt("IdDestino") });
            }

            return excepciones;
        }

        public Area GetAreaById(int id)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Area", id);
            var tablaDatos = conexion_bd.Ejecutar("dbo.Web_GetAreaById", parametros);
            List<Area> areas = new List<Area>();
            tablaDatos.Rows.ForEach(row =>
            {
                areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion") });
            });
            //Se puede mejorar creando un SP porque se traen todos los los Alias cuando sólo se está necesitando uno.
            var aliases = ObtenerTodosLosAliasDeAreas();
            aliases.ForEach((alias) =>
            {
                var area_del_alias = areas.Find(area => area.Id == alias.IdArea);
                if (area_del_alias != null) { area_del_alias.SetAlias(alias); }
            });

            return areas.Distinct(new AreaEquals()).ToList()[0];
        }


        public List<Area> GetAreaInferiorById(int id, bool presenta_ddjj)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_area", id);
            parametros.Add("@presenta_ddjj", presenta_ddjj);
            var tablaDatos = conexion_bd.Ejecutar("dbo.ESTR_GET_Areas_Dependencias_Activas", parametros);
            List<Area> areas = new List<Area>();
            tablaDatos.Rows.ForEach(row =>
            {
                areas.Add(new Area { 
                                Id = row.GetInt("id_area"), 
                                Nombre = row.GetString("descripcion"),
                                PresentaDDJJ = row.GetBoolean("presenta_DDJJ")
                                });
            });
            
            //var aliases = ObtenerTodosLosAliasDeAreas();
            //aliases.ForEach((alias) =>
            //{
            //    var area_del_alias = areas.Find(area => area.Id == alias.IdArea);
            //    if (area_del_alias != null) { area_del_alias.SetAlias(alias); }
            //});

            return areas; //areas.Distinct(new AreaEquals()).ToList()[0];
        }



        public List<Area> GetAreasQueDependientesDe(int id_area)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdArea", id_area);
            //var tablaDatos = conexion_bd.Ejecutar("dbo.PRUEBA_GER", parametros);
            var tablaDatos = conexion_bd.Ejecutar("dbo.ESTR_GET_Area_Y_Dependencias_Informales", parametros);
            List<Area> areas = new List<Area>();
            tablaDatos.Rows.ForEach(row =>
            {
                areas.Add(new Area
                {
                    Id = row.GetInt("id"),
                    Nombre = row.GetString("descripcion"),
                    PresentaDDJJ = row.GetBoolean("Presenta_DDJJ")
                });
            });

            return areas;

        }
            

    }
}
