using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;
namespace General.Repositorios
{
    public class RepositorioDeAreas
    {

        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeAreas(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public void ReloadArea(Area unArea)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Area", unArea.Id);
            var tablaDatos = conexion_bd.Ejecutar("dbo.Web_GetArea", parametros);            
            var primeraFila = tablaDatos.Rows[0];
            unArea.Id = primeraFila.GetInt("id_area");
            unArea.Nombre = primeraFila.GetString("descripcion");
            unArea.Direccion = primeraFila.GetString("direccion_area");

            tablaDatos = conexion_bd.Ejecutar("dbo.Web_GetContactoArea", parametros);      
            var contacArea = new List<ContactoArea>();
            tablaDatos.Rows.ForEach(row =>
            {
                //contacArea.Add(new ContactoPersonalizado { Id_Area = row.GetInt("IdContactoArea"), TipoContacto = (byte)row.GetObject("idTipoContacto"), Nombre_Area = row.GetString("ContactoArea") });
            });
            unArea.Contacto = contacArea;
        }


        public Alias ObtenerAliasDeAreaByIdDeArea(Area area)
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.Via_GetAliasByIdDeArea");

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Area", area.Id);
            
            List<Alias> alias = new List<Alias>();
            tablaDatos.Rows.ForEach(row =>
            {
                alias.Add(new Alias { Id = row.GetInt("Id"), Descripcion = row.GetString("Alias") });
            });
            return alias.Distinct(new AliasEquals()).Single();

        }

         public List<Area> GetAreasParaProtocolo()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@FechaVigencia", DateTime.Today);
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_Get_AreasParaProtocolo", parametros);
            List<Area> areas_completas = GetTodasLasAreasCompletas();
            List<Area> areas = new List<Area>();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    var id_area = row.GetSmallintAsInt("Id_area");
                    var area_completa = areas_completas.Find(ar => ar.Id == id_area);

                    areas.Add(new Area
                    {
                        Id = id_area,
                        Nombre = row.GetString("Descripcion"),
                        Direccion = area_completa.Direccion,
                        DatosDeContacto = area_completa.DatosDeContacto,     
                        datos_del_responsable = new Responsable(row.GetString("Nombre"), row.GetString("Apellido").ToUpper(), "", "", ""),
                        Asistentes = area_completa.Asistentes
                    });
                });
            }

            return areas;
         }


        public List<Area> GetTodasLasAreasCompletas()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetAreasCompletas");
            List<Area> areas = GetAreasDeTablaDeDatos(tablaDatos);

            return areas;
        }

        public static List<Area> GetAreasDeTablaDeDatos(TablaDeDatos tablaDatos)
        {
            List<Area> areas = new List<Area>();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    var Asistentes = new List<Asistente>();
                    if (areas.FindAll(a => a.Id == row.GetSmallintAsInt("Id_Area")).Count == 0) //refactorizar, poner un contains
                    {
                        List<DatoDeContacto> DatosDeContacto = new List<DatoDeContacto>();

                        Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                            row.GetString("Apellido_Asistente"),
                                                            row.GetString("Cargo"),
                                                            row.GetSmallintAsInt("Prioridad_Asistente"),
                                                            row.GetString("Telefono_Asistente"),
                                                            row.GetString("Telefono_Asistente"),//Falta cambiar por Fax!!!
                                                            row.GetString("Mail_Asistente"));
                        if (asistente.Descripcion_Cargo.Trim() != "" && asistente.Apellido.Trim() != "") Asistentes.Add(asistente);

                        Responsable datos_responsable = new Responsable(row.GetString("Nombre_Responsable"),
                                                                        row.GetString("Apellido_Responsable"),
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente"), //Falta cambiar!!!
                                                                        row.GetString("Nombre_Asistente")); //Falta cambiar!!!

                        DatoDeContacto dato_de_contacto = new DatoDeContacto(row.GetSmallintAsInt("Id_Dato_Area"), row.GetString("Descripcion_Dato_Area"), row.GetString("Dato_Area"), row.GetSmallintAsInt("Orden"));
                        DatosDeContacto.Add(dato_de_contacto);

                        areas.Add(new Area
                        {
                            Id = row.GetSmallintAsInt("Id_Area"),
                            Nombre = row.GetString("descripcion"),
                            Direccion = row.GetString("direccion"),
                            datos_del_responsable = datos_responsable,
                            Asistentes = Asistentes,
                            DatosDeContacto = DatosDeContacto,
                        });
                    }
                    else
                    {
                        var area_existente = areas.Find(a => a.Id == row.GetSmallintAsInt("Id_Area"));
                        if (!area_existente.Asistentes.Any(a => a.Apellido == row.GetString("Apellido_Asistente") && a.Descripcion_Cargo == row.GetString("Cargo")))
                        {
                            Asistente asistente = new Asistente(row.GetString("Nombre_Asistente"),
                                                               row.GetString("Apellido_Asistente"),
                                                               row.GetString("Cargo"),
                                                               row.GetSmallintAsInt("Prioridad_Asistente"),
                                                               row.GetString("Telefono_Asistente"),
                                                               row.GetString("Telefono_Asistente"),//Falta cambiar por Fax!!!
                                                               row.GetString("Mail_Asistente"));
                            if (asistente.Descripcion_Cargo.Trim() != "" && asistente.Apellido.Trim() != "") area_existente.Asistentes.Add(asistente);
                        }

                        if (!area_existente.DatosDeContacto.Any(d => d.Id == row.GetSmallintAsInt("Id_Dato_Area") && d.Orden == row.GetSmallintAsInt("Orden")))
                        {
                            DatoDeContacto nuevo_dato = new DatoDeContacto(row.GetSmallintAsInt("Id_Dato_Area"),
                                                                               row.GetString("Descripcion_Dato_Area"),
                                                                               row.GetString("Dato_Area"),
                                                                               row.GetSmallintAsInt("Orden"));
                            area_existente.DatosDeContacto.Add(nuevo_dato);
                        }
                    }

                });

            }

            foreach (Area area in areas)
            {
                area.DatosDeContacto.Sort((dato1, dato2) => dato1.esMayorQue(dato2));
            }
            return areas;
        }

        private FiltroDeAreas DeterminarFiltro(int idCombo, string dato_ingresado_en_filtro)
        {
            switch (idCombo )
            {
                case 1:
                    return new FiltroDeAreas(FiltroDeAreas.PredicadoPorDireccion, dato_ingresado_en_filtro);
                default:
                    return null;
            }
        }
    }
}
