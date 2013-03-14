using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeComisionesDeServicio
    {
        private IConexionBD conexion_bd;
        public RepositorioDeComisionesDeServicio(IConexionBD conexion)
        {
            this.conexion_bd = conexion;

        }
        #region IRepositorioComisionesDeServicio Members

        public void GuardarComisionesDeServicio(List<ComisionDeServicio> ComisionesDeServicio)
        {
            foreach (ComisionDeServicio unaComision in ComisionesDeServicio)
            {
                this.GuardarComisionDeServicio(unaComision);
            }
        }

        public void GuardarComisionDeServicio(ComisionDeServicio una_comision)
        {
            if (una_comision.Estadias.Count < 1) throw new Exception("No se puede guardar una comisión sin estadias.");

            if (una_comision.Id == 0 )
            {
                AltaDeComisionDeServicio(una_comision);
            }
            else
            {
                ModificacionDeComisionDeServicio(una_comision);
            }
        }

        private void ModificacionDeComisionDeServicio(ComisionDeServicio una_comision)
        {
            var comision_anterior = ObtenerViaticoPorId(una_comision.Id);

            foreach (Estadia unaEstadia in una_comision.Estadias)
            {
                unaEstadia.ComisionDeServicio = una_comision;
            }

            foreach (Pasaje unPasaje in una_comision.Pasajes)
            {
                unPasaje.ComisionDeServicio = una_comision;
            }

            var repoEstadias = new RepositorioDeEstadias(conexion_bd);
            var estadias_quitadas = comision_anterior.Estadias.FindAll(e => !una_comision.Estadias.Contains(e));
            repoEstadias.BajaDeEstadias(estadias_quitadas);
            var estadias_nuevas = una_comision.Estadias.FindAll(e => e.Id == 0);
            repoEstadias.AltaDeEstadias(estadias_nuevas);

            var repoPasajes = new RepositorioDePasajes(conexion_bd);
            var pasajes_quitados = comision_anterior.Pasajes.FindAll(p => !una_comision.Pasajes.Contains(p));
            repoPasajes.BajaDePasajes(pasajes_quitados);
            var pasajes_nuevos = una_comision.Pasajes.FindAll(p => p.Id == 0);
            repoPasajes.AltaDePasajes(pasajes_nuevos);

            var repoAcciones = new RepositorioDeAccionesDeTransicion();
            this.ReasignarComision(una_comision, una_comision.AreaSuperior, repoAcciones.GetAccionSolicitar().Id, "");
        }

        private void AltaDeComisionDeServicio(ComisionDeServicio una_comision)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@idAreaCreadora", una_comision.AreaCreadora.Id);
            parametros.Add("@documentoAgente", una_comision.Persona.Documento);
            parametros.Add("@estado", Enum.GetNames(typeof(EstadosDeComision))[(int)una_comision.Estado]);
            parametros.Add("@baja", una_comision.Baja);
            parametros.Add("@usuario", 1);
            var id = conexion_bd.EjecutarEscalar("dbo.VIA_AltaComisionDeServicio", parametros);

            una_comision.Id = int.Parse(id.ToString());

            foreach (Estadia unaEstadia in una_comision.Estadias)
            {
                unaEstadia.ComisionDeServicio = una_comision;
            }

            foreach (Pasaje unPasaje in una_comision.Pasajes)
            {
                unPasaje.ComisionDeServicio = una_comision;
            }

            var repoEstadias = new RepositorioDeEstadias(conexion_bd);
            repoEstadias.AltaDeEstadias(una_comision.Estadias);

            var repoPasajes = new RepositorioDePasajes(conexion_bd);
            repoPasajes.AltaDePasajes(una_comision.Pasajes);

            var repoAcciones = new RepositorioDeAccionesDeTransicion();

            //unaComision.AreaActual = unaComision.AreaCreadora;
            this.ReasignarComision(una_comision, una_comision.AreaSuperior, repoAcciones.GetAccionSolicitar().Id, "");
        }

        //public List<ComisionDeServicio> ObtenerViaticosPorAreaCreadora(List<Area> areas)
        //{
        //    List<ComisionDeServicio> viaticos = ObtenerTodosLosViaticos();

        //    return viaticos.FindAll(v => v.AreaCreadora.Id == unArea.Id);

        //}

        //public List<ComisionDeServicio> ObtenerViaticosPorAreaCreadoraYEstado(Area unArea, EstadosDeComision estado)
        //{
        //    List<ComisionDeServicio> viaticos = ObtenerTodosLosViaticos();

        //    return viaticos.FindAll(v => v.Estado == estado && v.AreaCreadora.Id == unArea.Id);
        //}

        public List<ComisionDeServicio> ObtenerViaticosPorArea(Area unArea)
        {
            List<ComisionDeServicio> viaticos = ObtenerTodosLosViaticos();

            return viaticos.FindAll(v => v.AreaActual.Id == unArea.Id);
        }

        public ComisionDeServicio ObtenerViaticoPorId(int id_viatico)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_Viatico", id_viatico);
            var tablaViaticos = conexion_bd.Ejecutar("dbo.VIA_GetViaticoPorId", parametros);
            return GetViaticosFromTabla(tablaViaticos)[0];
        }

        public List<ComisionDeServicio> ObtenerTodosLosViaticos()
        {
            var tablaViaticos = conexion_bd.Ejecutar("dbo.VIA_GetViaticos");

            return GetViaticosFromTabla(tablaViaticos);
        }

        private List<ComisionDeServicio> GetViaticosFromTabla(TablaDeDatos tablaViaticos)
        {
            List<ComisionDeServicio> viaticos = new List<ComisionDeServicio>();

            if (tablaViaticos.Rows.Count > 0)
            {
                var un_viatico = new ComisionDeServicio();
                var un_pasaje = new Pasaje();
                var una_estadia = new Estadia();
                var una_transicion = new TransicionDeViatico();
                var una_zona = new Zona();
                tablaViaticos.Rows.ForEach(row =>
                {
                    if (viaticos.FindAll(t => t.Id == row.GetInt("Id")).Count == 0)
                    {
                        un_viatico = new ComisionDeServicio();
                        un_viatico.Id = row.GetInt("Id");
                        un_viatico.Baja = row.GetBoolean("Baja");
                        un_viatico.FechaCreacion = row.GetDateTime("fecha");
                        un_viatico.AreaCreadora = new Area();
                        un_viatico.AreaCreadora.Id = row.GetInt("IdAreaCreadora");
                        un_viatico.AreaCreadora.Nombre = row.GetString("DescripcionAreaCreadora");
                        un_viatico.AreaSuperior = new Area();
                        un_viatico.AreaSuperior.Id = row.GetInt("IdAreaCreadora");
                        un_viatico.AreaSuperior.Nombre = row.GetString("DescripcionAreaCreadora");
                        un_viatico.Persona = new Persona();
                        un_viatico.Persona.Nombre = row.GetString("Persona_Nombre");
                        un_viatico.Persona.Apellido = row.GetString("Persona_Apellido");
                        un_viatico.Persona.Documento = row.GetInt("Persona_Documento");
                        un_viatico.Persona.Area = new Area();
                        un_viatico.Persona.Area.Id = row.GetInt("Persona_Area_Id");
                        un_viatico.Persona.Area.Nombre = row.GetString("Persona_Area_Descripcion");

                        un_viatico.Persona.Cuit = row.GetString("Cuil_Persona");
                        un_viatico.Persona.Legajo = row.GetInt("Legajo_Persona").ToString();
                        un_viatico.Persona.Telefono = row.GetString("Telefono_Area");
                        un_viatico.Persona.Categoria = row.GetString("Categoria_Persona");
                        un_viatico.Persona.Nivel = row.GetString("Nivel_Funcion");
                        un_viatico.Persona.Grado = row.GetString("Grado_Rango");

                        //FC:agrego el estado mockeado por ahora para poder filtrar               
                       
                        //

                        viaticos.Add(un_viatico);
                        un_pasaje = new Pasaje();
                        una_estadia = new Estadia();
                        una_transicion = new TransicionDeViatico();
                    }
                    if (!(row.GetObject("Estadia_Id") is DBNull))
                    {
                        if (un_viatico.Estadias.FindAll(t => t.Id == row.GetInt("Estadia_Id")).Count == 0)
                        {
                            una_estadia = new Estadia();
                            una_zona = new Zona(row.GetSmallintAsInt("Id_Zona"), row.GetString("Nombre_Zona"));
                            una_estadia.Id = row.GetInt("Estadia_Id");
                            una_estadia.Desde = row.GetDateTime("Estadia_Desde");
                            una_estadia.Hasta = row.GetDateTime("Estadia_Hasta");
                            una_estadia.Provincia = new Provincia();
                            una_estadia.Provincia.Id = row.GetSmallintAsInt("Estadia_Provincia_Id");
                            una_estadia.Provincia.Nombre = row.GetString("Estadia_Provincia_Nombre");
                            una_estadia.Provincia.Zona = una_zona;
                            una_estadia.Eventuales = Decimal.Parse(row.GetObject("Estadia_Eventuales").ToString());// GetObject("Estadia_Eventuales");
                            una_estadia.AdicionalParaPasajes = Decimal.Parse(row.GetObject("Estadia_AdicionalParaPasajes").ToString());//GetObject("Estadia_AdicionalParaPasajes");
                            una_estadia.CalculadoPorCategoria = Decimal.Parse(row.GetObject("Estadia_CalculadoPorCategoria").ToString()); //GetObject("Estadia_CalculadoPorCategoria");
                            una_estadia.Motivo = row.GetString("Estadia_Motivo");
                            una_estadia.Persona = un_viatico.Persona;

                            un_viatico.Estadias.Add(una_estadia);
                        }
                    }

                    if (!(row.GetObject("Pasaje_Id") is DBNull))
                    {
                        if (un_viatico.Pasajes.FindAll(t => t.Id == row.GetInt("Pasaje_Id")).Count == 0)
                        {
                            un_pasaje = new Pasaje();
                            un_pasaje.Id = row.GetInt("Pasaje_Id");
                            un_pasaje.Origen = new Localidad();
                            un_pasaje.Origen.Id = row.GetInt("Pasaje_LocalidadOrigen_Id");
                            un_pasaje.Origen.Nombre = row.GetString("Pasaje_LocalidadOrigen_Nombre");
                            un_pasaje.Destino = new Localidad();
                            un_pasaje.Destino.Id = row.GetInt("Pasaje_LocalidadDestino_Id");
                            un_pasaje.Destino.Nombre = row.GetString("Pasaje_LocalidadDestino_Nombre");
                            un_pasaje.FechaDeViaje = row.GetDateTime("Pasaje_FechaDeViaje");
                            un_pasaje.MedioDeTransporte = new MedioDeTransporte();
                            un_pasaje.MedioDeTransporte.Id = row.GetSmallintAsInt("Pasaje_MedioDeTransporte_Id");
                            un_pasaje.MedioDeTransporte.Nombre = row.GetString("Pasaje_MedioDeTransporte_Nombre");
                            un_pasaje.MedioDePago = new MedioDePago();
                            un_pasaje.MedioDePago.Id = row.GetSmallintAsInt("Pasaje_MedioDePago_Id");
                            un_pasaje.MedioDePago.Nombre = row.GetString("Pasaje_MedioDePago_Nombre");
                            un_pasaje.Precio = Decimal.Parse(row.GetObject("Pasaje_Precio").ToString());//.GetObject("Pasaje_Precio");

                            un_viatico.Pasajes.Add(un_pasaje);
                        }
                    }

                    if (!(row.GetObject("Transicion_Id") is DBNull))
                    {
                        if (un_viatico.TransicionesRealizadas.FindAll(t => t.Id == row.GetInt("Transicion_Id")).Count == 0)
                        {

                            var id_transicion = row.GetInt("Transicion_Id");

                            var id_area_origen = row.GetInt("Transicion_AreaOrigen_Id");
                            var nombre_area_origen = row.GetString("Transicion_AreaOrigen_Descripcion");
                            var area_origen = new Area(id_area_origen, nombre_area_origen);

                            var responsableAreaOrigen = new Persona();
                            responsableAreaOrigen.Nombre = row.GetString("Transicion_AreaOrigen_Responsable_Nombre");
                            responsableAreaOrigen.Apellido = row.GetString("Transicion_AreaOrigen_Responsable_Apellido");
                            responsableAreaOrigen.Documento = row.GetInt("Transicion_AreaOrigen_Responsable_Documento");
                            area_origen.Responsables = new List<Persona>();
                            area_origen.Responsables.Add(responsableAreaOrigen);

                            var id_area_destino = row.GetInt("Transicion_AreaDestino_Id");
                            var nombre_area_destino = row.GetString("Transicion_AreaDestino_Descripcion");
                            var area_destino = new Area(id_area_destino, nombre_area_destino);

                            var responsableAreaDestino = new Persona();
                            responsableAreaDestino.Nombre = row.GetString("Transicion_AreaDestino_Responsable_Nombre");
                            responsableAreaDestino.Apellido = row.GetString("Transicion_AreaDestino_Responsable_Apellido");
                            responsableAreaDestino.Documento = row.GetInt("Transicion_AreaDestino_Responsable_Documento");

                            area_destino.Responsables = new List<Persona>();
                            area_destino.Responsables.Add(responsableAreaDestino);

                            var repositorioAcciones = new RepositorioDeAccionesDeTransicion();
                            var accion = repositorioAcciones.GetAccionDeTransicionById(row.GetInt("Transicion_Id_Accion"));
                            var fecha = row.GetDateTime("Transicion_Fecha");
                            var comentario = row.GetString("Transicion_Comentario");
                            if (comentario == null)
                            {
                                comentario = "";
                            }
                            una_transicion = new TransicionDeViatico(id_transicion, area_origen, area_destino, accion, fecha, comentario);
                            un_viatico.TransicionesRealizadas.Add(una_transicion);
                        }
                    }
                });
            }
            return viaticos;
        }


        public void CompletarDatosDelCalculoDeViaticosDe(Persona unaPersona)
        {

            var parametros = new Dictionary<string, object>();

            parametros.Add("@nroDocumento", unaPersona.Documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.Web_GetDatosParaCalculoViaticosDelAgente", parametros);

            if (tablaDatos.Rows.Count>0)
            {
                var row = tablaDatos.Rows[0];
                unaPersona.Nivel = row.GetString("nivel");
                unaPersona.Grado = row.GetString("grado");
                unaPersona.TipoDePlanta = new TipoDePlanta { Descripcion = row.GetString("planta")};
                unaPersona.Es1184 = row.GetInt("Es1184") == 1;
            }
        }

        public void ReasignarComision(ComisionDeServicio una_comision, Area area_destino, int id_accion, String comentario)
        {
            Area area_actual;
            if (una_comision.TransicionesRealizadas.Count > 0)
            {
                area_actual = una_comision.AreaActual;
            }
            else
            {
                area_actual = una_comision.AreaCreadora;
            }

            var repo_acciones = new RepositorioDeAccionesDeTransicion();
            var accion = repo_acciones.GetAccionDeTransicionById(id_accion);

            var fecha_transicion = DateTime.Now;

            var parametros = new Dictionary<string, object>();

            parametros.Add("@Id_Comision", una_comision.Id);
            parametros.Add("@Id_Area_Origen", area_actual.Id);
            parametros.Add("@Id_Area_Destino", area_destino.Id);
            parametros.Add("@Id_Accion", id_accion);
            parametros.Add("@Fecha", fecha_transicion);
            parametros.Add("@Comentario", comentario);
            var id_transicion = conexion_bd.EjecutarEscalar("dbo.VIA_GuardarTransicionDeViatico", parametros);

            var transicion = new TransicionDeViatico((int)((Decimal)id_transicion), area_actual, area_destino, accion, fecha_transicion, comentario);
            una_comision.TransicionesRealizadas.Add(transicion);
        }

        public Area GetAreaPreviaDe(ComisionDeServicio una_comision)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Id_Viatico", una_comision.Id);
            var tablaDatos = conexion_bd.Ejecutar("dbo.VIA_GetAreaPreviaDe", parametros);

            if (tablaDatos.Rows.Count>0)
            {
                var row = tablaDatos.Rows[0];
                return new Area { Id = row.GetInt("id_area"), Nombre = row.GetString("descripcion"), Codigo = row.GetString("codigo") };
            }            
            return null;
        }
        #endregion


    }
}