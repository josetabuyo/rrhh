﻿using System;
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

        //public List<Area> GetTodasLasAreas()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetOrganigrama");
        //    List<Area> areas = new List<Area>();
        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo"), PresentaDDJJ = row.GetBoolean("Presenta_DDJJ") });
        //    });
        //    areas = areas.Distinct().ToList();
        //    //var aliases = ObtenerTodosLosAliasDeAreas();
        //    //aliases.ForEach(alias => areas.Find(area => area.Id == alias.IdArea).SetAlias(alias));
        //    return areas;
        //}

        //public Area GetAreaById(int id)
        //{
        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@Id_Area", id);
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.Web_GetAreaById", parametros);
        //    List<Area> areas = new List<Area>();
        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo") });
        //    });
        //    return areas.Distinct(new AreaEquals()).ToList()[0];
        //}

        //public List<Area> GetAreasAutorizadas(Area unArea)
        //{
        //    List<Area> areas = new List<Area>();            

        //    areas.Add(GetAreaSuperiorA(unArea));

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@Id_Area", unArea.Id);
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetSaltosPreferenciales");
        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo") });
        //    });

        //    return areas;
        //}

        //public Area GetAreaSuperiorA(Area unArea)
        //{
        //    List<Area> areas = new List<Area>();

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("@Id_Area", unArea.Id);
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetAreaSuperiorA");
        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo") });
        //    });
        //    return areas[0];
        //}

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


            //return null;

        }

         public List<Area> GetAreasParaProtocolo()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@FechaVigencia", DateTime.Today);
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_Get_AreasParaProtocolo", parametros);
            List<Area> areas_completas = GetTodasLasAreasCompletas();
            List<Area> areas = new List<Area>();
            //Area area_completa = new Area();

            if (tablaDatos.Rows.Count > 0)
            {

                tablaDatos.Rows.ForEach(row =>
                {
                    var id_area = row.GetSmallintAsInt("Id_area");
                    var area_completa = areas_completas.FindAll(ar => ar.Id == id_area);
                    var area_direccion = " ";
                    var area_datos = new List<DatoDeContacto>();
                    if (area_completa.Count > 0) 
                    {
                        area_direccion = area_completa.First().Direccion;
                        area_datos = area_completa.First().DatosDeContacto;
                    }

                    Responsable datos_responsable = new Responsable(row.GetString("Nombre"), row.GetString("Apellido").ToUpper(), "", "", "");

                    areas.Add(new Area
                    {
                        Id = id_area,
                        Nombre = row.GetString("Descripcion"),
                        Direccion = area_direccion,
                        DatosDeContacto = area_datos,     
                        datos_del_responsable = datos_responsable,
                        Asistentes = new List<Asistente>(),
                    });
                });
            }

            return areas;
         }


        public List<Area> GetTodasLasAreasCompletas()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetAreasCompletas_bel");
            List<Area> areas = new List<Area>();
            //tablaDatos.Rows.ForEach(row =>
            //{
            //    areas.Add(new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo") });
            //});
            //return areas.Distinct(new AreaEquals()).ToList();

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

                        Asistentes.Add(asistente);

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


                            area_existente.Asistentes.Add(asistente);
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

        //public List<Area> GetAreasFormales()
        //{
        //    var areas = GetTodasLasAreas();

        //    var areas_formales = areas.FindAll(a => a.PresentaDDJJ);
        //    return areas_formales;
        //}

    }
}
