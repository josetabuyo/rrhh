using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;
using General.MAU;
namespace General.Repositorios
{
    public class RepositorioDeAreas : RepositorioLazySingleton<Area>
    {
        private static RepositorioDeAreas _instancia;
        int indice_auxiliar = 990000000;
        private RepositorioDeAreas(IConexionBD conexion)
            : base(conexion, 10)
        {
        }

        public static RepositorioDeAreas NuevoRepositorioDeAreas(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeAreas(conexion);
            return _instancia;
        }

        public void ReloadArea(Area unArea)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Area", unArea.Id);
            var tablaDatos = conexion.Ejecutar("dbo.Web_GetArea", parametros);
            var primeraFila = tablaDatos.Rows.First();
            unArea.Id = primeraFila.GetInt("id_area");
            unArea.Nombre = primeraFila.GetString("descripcion");
            unArea.Direccion = primeraFila.GetString("direccion_area");

            tablaDatos = conexion.Ejecutar("dbo.Web_GetContactoArea", parametros);
            var contacArea = new List<ContactoArea>();
            tablaDatos.Rows.ForEach(row =>
            {
                //contacArea.Add(new ContactoPersonalizado { Id_Area = row.GetInt("IdContactoArea"), TipoContacto = (byte)row.GetObject("idTipoContacto"), Nombre_Area = row.GetString("ContactoArea") });
            });
            unArea.Contacto = contacArea;
        }


        public Alias ObtenerAliasDeAreaByIdDeArea(Area area)
        {
            var tablaDatos = conexion.Ejecutar("dbo.Via_GetAliasByIdDeArea");

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
            var tablaDatos = conexion.Ejecutar("dbo.VIA_Get_AreasParaProtocolo", parametros);
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

        public List<Area> BuscarAreas(string criterio)
        {
            var palabras_busqueda = criterio.Split(' ').Select(p => p.ToUpper().Trim());
            return GetTodasLasAreasCompletas().FindAll(area =>
                palabras_busqueda.All(palabra => area.Nombre.ToUpper().Contains(palabra.ToUpper())));
        }

        public List<Area> GetAreasParaLugaresDeTrabajo()
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@FechaVigencia", DateTime.Today);
            var tablaDatos = this.conexion.Ejecutar("dbo.VIA_Get_AreasParaLugaresDeTrabajo", parametros);
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
            return this.Obtener();
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
                            PresentaDDJJ = row.GetBoolean("presenta_DDJJ"),
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

        public Area GetAreaPorId(int id_area)
        {
            return this.GetTodasLasAreasCompletas().Find(a => a.Id == id_area);
        }

        public Area GetAreaCompletaPorId(int id_area)
        {
            Area area = new Area();
            area.Id = id_area;
            List<DatoDeContacto> datos_de_contacto = new List<DatoDeContacto>();
            List<Asistente> asistentes = new List<Asistente>();
            area.DatosDeContacto = datos_de_contacto;
            area.Asistentes = asistentes;
            var parametros = new Dictionary<string, object>();

            //BUSCO LOS DATOS DEL RESPONSABLE
            parametros.Add("@Operacion", 'S');
            parametros.Add("@Id", null);
            parametros.Add("@Area", id_area);
            var tablaDatos = conexion.Ejecutar("dbo.GABM_Tabla_Firmantes", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                var responsable_base = tablaDatos.Rows.First();
                Responsable responsable = new Responsable();
                responsable.NombreApellido = responsable_base.GetString("Apellido");
                string[] nombre_y_apellido = responsable.NombreApellido.Split(',');
                if (nombre_y_apellido.Length > 0)
                {
                    responsable.Apellido = nombre_y_apellido[0];
                    if (nombre_y_apellido.Length > 1)
                    {
                        responsable.Nombre = nombre_y_apellido[1];
                    }
                }
                responsable.Documento = responsable_base.GetInt("Documento");
                responsable.IdInterna = responsable_base.GetInt("Id_Interna");
                responsable.TratamientoPersona = new Combo(responsable_base.GetSmallintAsInt("Id_Tratamiento"), responsable_base.GetString("Tratamiento"));
                responsable.TratamientoTitulo = new Combo(responsable_base.GetSmallintAsInt("Id_Titulo"), responsable_base.GetString("Titulo"));
                responsable.CargoFuncion = new Combo(responsable_base.GetSmallintAsInt("id_cargo"), responsable_base.GetString("Cargo"));
                responsable.ActoAdministrativo = responsable_base.GetString("FirmaActosAdm");
                responsable.Contratos = responsable_base.GetString("FirmaContratos");
                responsable.Facturas = responsable_base.GetString("FirmaFacturas");
                responsable.DDJJRecibos = responsable_base.GetString("FirmaddjjRecibo");

                area.Responsable = responsable;
            }
            else
            {
                area.Responsable = new Responsable();
            }

            //BUSCO LOS DATOS DE DIRECCIÓN DEL ÁREA
            parametros.Clear();
            tablaDatos.Clear();
            parametros.Add("@Id_Edificio", 0);
            parametros.Add("@id_area", id_area);
            tablaDatos = conexion.Ejecutar("dbo.ESTR_GET_Area_Por_Id", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                var direccion_base = tablaDatos.Rows.First();
                Localidad localidad = new Localidad(direccion_base.GetInt("Localidad"), direccion_base.GetString("nombrelocalidad"));
                area.DireccionCompleta = new Direccion(direccion_base.GetInt("Id_Edificio"), direccion_base.GetString("Edificio"), direccion_base.GetString("Calle"), direccion_base.GetInt("Numero"), localidad, direccion_base.GetInt("Id_Oficina"), direccion_base.GetString("Piso"), direccion_base.GetString("Dpto"), direccion_base.GetString("UF"), direccion_base.GetString("descripcion"), direccion_base.GetInt("codigopostal"));

                //BUSCO LOCALIDAD
                parametros.Clear();
                tablaDatos.Clear();
                parametros.Add("@localidad", localidad.Id);
                tablaDatos = conexion.Ejecutar("dbo.GetLocalidad", parametros);
                if (tablaDatos.Rows.Count > 0)
                {
                    var localidad_base = tablaDatos.Rows.First();
                    localidad.CodigoPostal = localidad_base.GetInt("codigopostal");
                    localidad.IdProvincia = localidad_base.GetInt("Id_Provincia");
                    localidad.NombreProvincia = localidad_base.GetString("nombreProvincia");
                    localidad.IdPartido = localidad_base.GetSmallintAsInt("partido");
                    localidad.NombrePartido = localidad_base.GetString("DescPartido");
                }

            }
            else
            {
                area.DireccionCompleta = new Direccion();
            }


            //BUSCO LOS DATOS DE CONTACTO DEL ÁREA (n)
            parametros.Clear();
            tablaDatos.Clear();
            parametros.Add("@IdArea", id_area);
            tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Tabla_Areas_DatosContacto", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    var orden = 99;
                    if (!(row.GetObject("Orden") is DBNull))
                    {
                        orden = row.GetSmallintAsInt("Orden");
                    }
                    DatoDeContacto nuevo_dato = new DatoDeContacto(row.GetSmallintAsInt("Id"),
                                                                                      row.GetString("Descrip_Tipo_Dato"),
                                                                                      row.GetString("Dato"),
                                                                                      orden);
                    nuevo_dato.IdContacto = row.GetSmallintAsInt("Tipo_Dato");
                    area.DatosDeContacto.Add(nuevo_dato);
                });
            }

            //BUSCO LOS DATOS DE ASISTENTES DEL ÁREA (n)
            parametros.Clear();
            tablaDatos.Clear();
            parametros.Add("@IdArea", id_area);
            tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Tabla_Areas_Asistentes ", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    var telefono = "";
                    if (!(row.GetObject("Telefono") is DBNull)) telefono = row.GetString("Telefono");
                    var fax = "";
                    if (!(row.GetObject("Fax") is DBNull)) fax = row.GetString("Fax");

                    Asistente asistente = new Asistente(row.GetString("nombre"),
                                                               row.GetString("apellido"),
                                                               row.GetString("Descripcargo"),
                                                               row.GetSmallintAsInt("Nro_Orden"),
                                                               telefono,
                                                               fax,
                                                               row.GetString("Mail"));
                    asistente.Id = row.GetInt("Id");
                    asistente.Documento = row.GetInt("DNI");
                    asistente.IdCargo = row.GetInt("Indicador_Cargo");
                    area.Asistentes.Add(asistente);
                });
            }

            return area;

        }

        private FiltroDeAreas DeterminarFiltro(int idCombo, string dato_ingresado_en_filtro)
        {
            switch (idCombo)
            {
                case 1:
                    return new FiltroDeAreas(FiltroDeAreas.PredicadoPorDireccion, dato_ingresado_en_filtro);
                default:
                    return null;
            }
        }

        protected override List<Area> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.VIA_GetAreasCompletas");
            List<Area> areas = GetAreasDeTablaDeDatos(tablaDatos);
            return areas;
        }

        protected override void GuardarEnLaBase(Area objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Area objeto)
        {
            throw new NotImplementedException();
        }

        public List<Combo> ObtenerTratamientoPersonas()
        {
            List<Combo> combo = new List<Combo>();
            var tablaDatos = conexion.Ejecutar("dbo.VIA_GetTratamientosPersonas");
            tablaDatos.Rows.ForEach(row =>
                {
                    Combo opcion = new Combo(row.GetSmallintAsInt("id"), row.GetString("descripcion"));
                    combo.Add(opcion);
                });
            return combo;
        }

        public List<Combo> ObtenerTratamientoTitulos()
        {
            List<Combo> combo = new List<Combo>();
            var tablaDatos = conexion.Ejecutar("dbo.VIA_GetTratamientosTitulos");
            tablaDatos.Rows.ForEach(row =>
            {
                Combo opcion = new Combo(row.GetSmallintAsInt("id"), row.GetString("Descripcion"));
                combo.Add(opcion);
            });
            return combo;
        }

        public List<Combo> ObtenerCargosFunciones()
        {
            List<Combo> combo = new List<Combo>();
            var tablaDatos = conexion.Ejecutar("dbo.VIA_GetCargosFunciones");
            tablaDatos.Rows.ForEach(row =>
            {
                Combo opcion = new Combo(row.GetSmallintAsInt("id"), row.GetString("descripcion"));
                combo.Add(opcion);
            });
            return combo;
        }

        public void ModificarResponsable(Area area, int id_usuario)
        {
            throw new NotImplementedException();
        }

        public List<Combo> ObtenerEdificiosPorLocalidad(int id_localidad, int id_provincia, Usuario usuario)
        {
            List<Combo> combo = new List<Combo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Localidad", id_localidad);
            var tablaDatos = conexion.Ejecutar("dbo.ESTR_GET_Edificios_Por_Localidad", parametros);
            tablaDatos.Rows.ForEach(row =>
            {
                Combo opcion = new Combo(row.GetSmallintAsInt("id"), row.GetString("descripcion"));
                combo.Add(opcion);
            });
            parametros.Add("@id_usuario", usuario.Id);
            var tablaDatos_aux = conexion.Ejecutar("dbo.ESTR_Get_Edificios_AUX", parametros);
            tablaDatos_aux.Rows.ForEach(row =>
            {
                Combo opcion = new Combo(indice_auxiliar + row.GetSmallintAsInt("id"), row.GetString("calle") + " " + row.GetInt("numero"));
                combo.Add(opcion);
            });
            return combo;
        }

        public List<Combo> ObtenerOficinaPorEdificio(int id_edificio, int id_area)
        {
            List<Combo> combo = new List<Combo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_Edificio", id_edificio);
             parametros.Add("@id_area", id_area);
            var tablaDatos = conexion.Ejecutar("dbo.ESTR_GET_Oficinas", parametros);
            tablaDatos.Rows.ForEach(row =>
            {
                Combo opcion = new Combo(row.GetSmallintAsInt("Id_Oficina"), row.GetString("Oficina"));
                combo.Add(opcion);
            });
            //var tablaDatos_aux = conexion.Ejecutar("dbo.", parametros);
            //tablaDatos_aux.Rows.ForEach(row =>
            //{
            //    Combo opcion = new Combo(indice_auxiliar + row.GetSmallintAsInt("Id_Oficina"), row.GetString("Oficina"));
            //    combo.Add(opcion);
            //});
            return combo;
        }

        public Edificio ObtenerEdificioPorId(int id_edificio)
        {
            Edificio edificio = new Edificio();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_Edificio", id_edificio);

            var tablaDatos = conexion.Ejecutar("dbo.ESTR_GET_Edificios_Por_Id", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var edificio_bd = tablaDatos.Rows.First();
                Localidad localidad = new Localidad();
                edificio.Id = edificio_bd.GetSmallintAsInt("id_Edificio");
                edificio.Numero = edificio_bd.GetInt("Numero");
                edificio.Calle = edificio_bd.GetString("Calle");
                edificio.Nombre = edificio_bd.GetString("Edificio");
                localidad.Id = edificio_bd.GetInt("Localidad");

                parametros.Clear();
                tablaDatos.Clear();
                parametros.Add("@localidad", localidad.Id);
                tablaDatos = conexion.Ejecutar("dbo.GetLocalidad", parametros);
                if (tablaDatos.Rows.Count > 0)
                {
                    var localidad_base = tablaDatos.Rows.First();
                    localidad.CodigoPostal = localidad_base.GetInt("codigopostal");
                    localidad.IdProvincia = localidad_base.GetInt("Id_Provincia");
                    localidad.NombreProvincia = localidad_base.GetString("nombreProvincia");
                    localidad.IdPartido = localidad_base.GetSmallintAsInt("partido");
                    localidad.NombrePartido = localidad_base.GetString("DescPartido");
                    localidad.Nombre = localidad_base.GetString("nombrelocalidad");
                }

                edificio.Localidad = localidad;
            }
            return edificio;  
        }

        public Oficina ObtenerOficinaPorId(int id_oficina)
        {
            Oficina oficina = new Oficina();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@oficina", id_oficina);

            var tablaDatos = conexion.Ejecutar("dbo.ESTR_GET_Oficinas", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var oficina_bd = tablaDatos.Rows.First();
                oficina.Id = oficina_bd.GetSmallintAsInt("Id_Oficina");
                oficina.Nombre = oficina_bd.GetString("Oficina");
                oficina.Dto = oficina_bd.GetString("Dpto");
                oficina.Piso = oficina_bd.GetString("Piso");
                oficina.UF = oficina_bd.GetString("UF"); 
            }
            return oficina;  
        }

        public int GuardarEdificioPendienteDeAptobacion(int id_provincia, string nombre_provincia, int id_localidad, string nombre_localidad, int codigo_postal, string calle, string numero, Usuario usuario)
        {
            int id = indice_auxiliar;
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_provincia", id_provincia);
            parametros.Add("@nombre_provincia", nombre_provincia);
            parametros.Add("@id_localidad", id_localidad);
            parametros.Add("@nombre_localidad", nombre_localidad);
            parametros.Add("@codigo_postal", codigo_postal);
            parametros.Add("@calle", calle);
            parametros.Add("@numero", numero);
            parametros.Add("@id_usuario", usuario.Id);

            var tablaDatos = conexion.Ejecutar("dbo.ESTR_Ins_Edificio_AUX", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                id = id + tablaDatos.Rows.First().GetSmallintAsInt("id");
            }
            else {
                id = 0;
            }
            return id;
        }

        public int WS_GuardarOficinaPendienteDeAptobacion(int id_edificio, string piso, string oficina, string UF, Usuario usuario)
        {
            int id = indice_auxiliar;
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id_edificio", id_edificio);
            parametros.Add("@piso", piso);
            parametros.Add("@oficina", oficina);
            parametros.Add("@UF", UF);
            parametros.Add("@id_usuario", usuario.Id);

            var tablaDatos = conexion.Ejecutar("dbo.ESTR_Ins_Oficina_AUX", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                id = id + tablaDatos.Rows.First().GetInt("id");
            }
            else {
                id = 0;
            }
            return id;
        }

        public Localidad CargarDatosDeCodigoPostal(int codigo_postal)
        {
            Localidad localidad = new Localidad();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@cpos", codigo_postal);

            var tablaDatos = conexion.Ejecutar("dbo.GetLocalidadesPorCP", parametros);
            if (tablaDatos.Rows.Count > 0)
            {
                var id_codigo_postal = tablaDatos.Rows.First().GetInt("IdLocalidad"); ;
                parametros.Clear();
                tablaDatos.Clear();
                parametros.Add("@localidad", id_codigo_postal);
                tablaDatos = conexion.Ejecutar("dbo.GetLocalidad", parametros);
                if (tablaDatos.Rows.Count > 0)
                {
                    var localidad_base = tablaDatos.Rows.First();
                    localidad.CodigoPostal = localidad_base.GetInt("codigopostal");
                    localidad.IdProvincia = localidad_base.GetInt("Id_Provincia");
                    localidad.NombreProvincia = localidad_base.GetString("nombreProvincia");
                    localidad.IdPartido = localidad_base.GetSmallintAsInt("partido");
                    localidad.NombrePartido = localidad_base.GetString("DescPartido");
                    localidad.Nombre = localidad_base.GetString("nombrelocalidad");
                }
            }

            return localidad;
        }
    }
}
