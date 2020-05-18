using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using General.Repositorios;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Data;

namespace General.Repositorios
{
    public class RepositorioMoBi
    {
        private IConexionBD conexion_bd;

        public RepositorioMoBi(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public MoBi_Area[] GetAreasUsuario(int IdUsuario)
        {
            List<MoBi_Area> lau = new List<MoBi_Area>();
            MoBi_Area area;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetAreasDelUsuario");
            cn.AsignarParametro("@IdUsuario", IdUsuario);
            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                area = new MoBi_Area();
                area.Id = dr.GetInt32(dr.GetOrdinal("id"));
                area.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                lau.Add(area);
            }
            cn.Desconestar();
            return lau.ToArray();
        }


        public MoBi_Area[] GetAreasUsuarioCBO(int IdUsuario, int IdTipoBien, bool MostrarSoloAreasConBienes)
        {
            List<MoBi_Area> lau = new List<MoBi_Area>();
            MoBi_Area area;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetAreasDelUsuarioCBO");
            cn.AsignarParametro("@IdUsuario", IdUsuario);
            cn.AsignarParametro("@Id_TipoBien", IdTipoBien);
            cn.AsignarParametro("@MostrarSoloAreasConBienes", MostrarSoloAreasConBienes);
            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                area = new MoBi_Area();
                area.Id = dr.GetInt32(dr.GetOrdinal("id"));
                area.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                lau.Add(area);
            }
            cn.Desconestar();
            return lau.ToArray();
        }

        public MoBi_Area[] GetAreasDelUsuarioBienesDisponibles(int IdUsuario, int IdTipoBien, bool Incluir_Dependencias, bool Mostrar_Todas_Areas)
        {
            List<MoBi_Area> lau = new List<MoBi_Area>();
            MoBi_Area area;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetAreasDelUsuarioBienesDisponibles");
            cn.AsignarParametro("@IdUsuario", IdUsuario);
            cn.AsignarParametro("@Id_TipoBien", IdTipoBien);
            cn.AsignarParametro("@Incluir_Dependencias", Incluir_Dependencias);
            cn.AsignarParametro("@Mostrar_Todas_Areas", Mostrar_Todas_Areas);
            dr = cn.EjecutarConsulta();
            while (dr.Read())
            {
                area = new MoBi_Area();
                area.Id = dr.GetInt32(dr.GetOrdinal("id"));
                area.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                lau.Add(area);
            }
            dr.Close(); dr.Dispose(); dr = null;
            cn.Desconestar();
            return lau.ToArray();
        }


        public MoBi_TipoBien[] GetTipoDeBienes()
        {
            List<MoBi_TipoBien> ltb = new List<MoBi_TipoBien>();
            MoBi_TipoBien tipoBien;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetTiposDeBien");
            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                tipoBien = new MoBi_TipoBien();
                tipoBien.Id = dr.GetInt32(dr.GetOrdinal("id"));
                tipoBien.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                ltb.Add(tipoBien);
            }
            cn.Desconestar();
            return ltb.ToArray();
        }

        public MoBi_Bien[] GetBienesDelArea(int IdArea, int IdTipoBien)
        {
            List<MoBi_Bien> lb = new List<MoBi_Bien>();
            MoBi_Bien bien;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetBienesDelArea");
            cn.AsignarParametro("@IdArea", IdArea);
            cn.AsignarParametro("@IdTipoBien", IdTipoBien);
            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                bien = new MoBi_Bien();
                bien.Id = dr.GetInt32(dr.GetOrdinal("id"));
                bien.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                bien.Estado = dr.GetString(dr.GetOrdinal("estado"));
                bien.FechaUltMov = dr.GetDateTime(dr.GetOrdinal("ultMovimiento"));
                //bien.Remitente = dr.GetString(dr.GetOrdinal("remitente"));
                //bien.Asignacion = dr.GetString(dr.GetOrdinal("asignacion"));
                lb.Add(bien);
            }
            cn.Desconestar();
            return lb.ToArray();
        }

        public MoBi_Bien[] GetBienesDisponibles(int IdArea, int IdTipoBien, int IdUsuario)
        {
            List<MoBi_Bien> lb = new List<MoBi_Bien>();
            MoBi_Bien bien;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetBienesDisponibles");
            cn.AsignarParametro("@IdArea", IdArea);
            cn.AsignarParametro("@IdTipoBien", IdTipoBien);
            cn.AsignarParametro("@IdUsuario", IdUsuario);

            dr = cn.EjecutarConsulta();
            while (dr.Read())
            {
                bien = new MoBi_Bien();
                bien.Id = dr.GetInt32(dr.GetOrdinal("id"));
                bien.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                bien.Ubicacion = dr.GetString(dr.GetOrdinal("ubicacion"));
                bien.Verificacion = dr.GetString(dr.GetOrdinal("verificacion"));
                bien.Estado = dr.GetString(dr.GetOrdinal("estado"));
                lb.Add(bien);
            }
            dr.Close(); dr.Dispose(); dr = null;
            cn.Desconestar();
            return lb.ToArray();
        }


        public MoBi_Bien[] GetBienesDelAreaRecepcion(int IdArea, int IdTipoBien)
        {
            List<MoBi_Bien> lb = new List<MoBi_Bien>();
            MoBi_Bien bien;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetBienesDelAreaRecepcion");
            cn.AsignarParametro("@IdArea", IdArea);
            cn.AsignarParametro("@IdTipoBien", IdTipoBien);
            dr = cn.EjecutarConsulta();

            while (dr.Read())
            {
                bien = new MoBi_Bien();
                bien.Id = dr.GetInt32(dr.GetOrdinal("id"));
                bien.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                bien.Estado = dr.GetString(dr.GetOrdinal("estado"));
                bien.FechaUltMov = dr.GetDateTime(dr.GetOrdinal("ultMovimiento"));
                //bien.Remitente = dr.GetString(dr.GetOrdinal("remitente"));
                //bien.Asignacion = dr.GetString(dr.GetOrdinal("asignacion"));
                lb.Add(bien);
            }
            cn.Desconestar();
            return lb.ToArray();
        }


        public MoBi_Evento[] GetEventosBien(int IdBien)
        {
            List<MoBi_Evento> le = new List<MoBi_Evento>();
            MoBi_Evento evento;
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetMovimientos");
            cn.AsignarParametro("@Id_Bien", IdBien);
            dr = cn.EjecutarConsulta();
            while (dr.Read())
            {
                evento = new MoBi_Evento();
                evento.Id = dr.GetInt32(dr.GetOrdinal("Id_Evento"));
                evento.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                evento.TipoEvento = dr.GetString(dr.GetOrdinal("TipoEvento"));
                evento.Observaciones = dr.GetString(dr.GetOrdinal("Observaciones"));
                evento.Area = dr.GetString(dr.GetOrdinal("Area"));
                evento.Responsable = dr.GetString(dr.GetOrdinal("Responsable"));
                evento.Operador = dr.GetString(dr.GetOrdinal("Operador"));
                le.Add(evento);
            }
            cn.Desconestar();
            return le.ToArray();
        }


        public MoBi_Agente[] GetAgentes(int IdArea)
        {
            List<MoBi_Agente> la = new List<MoBi_Agente>();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GetAgentesDelArea");
            cn.AsignarParametro("@Id_Area", IdArea);
            dr = cn.EjecutarConsulta();
            MoBi_Agente agente;
            while (dr.Read())
            {
                agente = new MoBi_Agente();
                agente.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                agente.Apellido = dr.GetString(dr.GetOrdinal("Apellido"));
                agente.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                agente.Documento = dr.GetInt32(dr.GetOrdinal("NroDocumento"));
                agente.Descripcion = dr.GetString(dr.GetOrdinal("Agente"));
                la.Add(agente);
            }
            cn.Desconestar();
            return la.ToArray();
        }


        public bool GuardarNuevoEventoBien(MoBi_Evento.enumTipoEvento tipoEvento, int IdBien, int IdArea, int IdPersona, string Observaciones, int IdUser)
        {
            string spEvento = string.Empty;
            switch (tipoEvento)
            {
                case MoBi_Evento.enumTipoEvento.ALTA_PROVISORIA:
                    break;
                case MoBi_Evento.enumTipoEvento.ALTA_DEFINITIVA:
                    break;
                case MoBi_Evento.enumTipoEvento.ASIGNACION_FORMAL_TRANSITO:
                    break;
                case MoBi_Evento.enumTipoEvento.ASIGNACION_FORMAL_RECEPCION:
                    break;
                case MoBi_Evento.enumTipoEvento.ASIGNACION_OPERATIVA_TRANSITO:
                    spEvento = "MOBI_AsignacionOperativaTransito";
                    break;
                case MoBi_Evento.enumTipoEvento.ASIGNACION_OPERATIVA_RECEPCION:
                    spEvento = "MOBI_AsignacionOperativaRecepcion";
                    break;
                case MoBi_Evento.enumTipoEvento.ASIGNACION_OPERATIVA_RECHAZO:
                    spEvento = "MOBI_AsignacionOperativaRechazar";
                    break;
                case MoBi_Evento.enumTipoEvento.SOLICITUD_REPARACION:
                    break;
                case MoBi_Evento.enumTipoEvento.EN_REPARACION:
                    break;
                case MoBi_Evento.enumTipoEvento.BAJA:
                    break;
                default:
                    break;
            }
            ConexionDB cn = new ConexionDB(spEvento);
            cn.AsignarParametro("@Id_Bien", IdBien);
            cn.AsignarParametro("@Id_Area", IdArea);
            cn.AsignarParametro("@Id_Persona", IdPersona);
            cn.AsignarParametro("@Observaciones", Observaciones);
            cn.AsignarParametro("@IdUser", IdUser);
            cn.EjecutarSinResultado();
            return true;
        }


        public MoBi_Bien GetImagenesBienPorId(int id_bien)
        {

            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdBien", id_bien);

            var tablaDatos = this.conexion_bd.Ejecutar("dbo.MOBI_GET_Imagenes_Bien_Por_Id", parametros);


            var bien = new MoBi_Bien();
            if (tablaDatos.Rows.Count > 0)
            {
                var row = tablaDatos.Rows[0];

                bien.Id = row.GetInt("Id");
                bien.Descripcion = row.GetString("descripcion");

                tablaDatos.Rows.ForEach(r =>
                {
                    if (r.GetObject("id_imagen") is DBNull) return;
                    bien.Imagenes.Add(r.GetInt("id_imagen"));
                });
            };

            return bien;
        }


        public bool AsignarImagenABien(int id_bien, int id_imagen)
        {
            var parametros_asignar_imagen = new Dictionary<string, object>();
            parametros_asignar_imagen.Add("@idBien", id_bien);
            parametros_asignar_imagen.Add("@idImagen", id_imagen);
            this.conexion_bd.Ejecutar("dbo.MOBI_AsignarImagenABien", parametros_asignar_imagen);
            return true;
        }


        public bool DesAsignarImagenABien(int id_bien, int id_imagen)
        {
            var parametros_desasignar_imagen = new Dictionary<string, object>();
            parametros_desasignar_imagen.Add("@idBien", id_bien);
            parametros_desasignar_imagen.Add("@idImagen", id_imagen);
            this.conexion_bd.Ejecutar("dbo.MOBI_DesAsignarImagenABien", parametros_desasignar_imagen);
            return true;
        }


        public AccionesMobi[] GetAcciones(int id_bien, int id_estado_propiedad, int id_area, int id_area_receptora, int id_area_propietaria)
        {
            List<AccionesMobi> listaAcciones = new List<AccionesMobi>();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GET_Acciones");
            cn.AsignarParametro("@id_bien", id_bien);
            cn.AsignarParametro("@id_estado_propiedad", id_estado_propiedad);
            cn.AsignarParametro("@id_area_seleccionada", id_area);
            if (id_estado_propiedad == 3)
            {
                cn.AsignarParametro("@id_area_propietaria", id_area_receptora);
            }
            else
            {
                cn.AsignarParametro("@id_area_propietaria", id_area_propietaria);
            }


            dr = cn.EjecutarConsulta();
            AccionesMobi acciones;
            while (dr.Read())
            {
                acciones = new AccionesMobi();
                acciones.IdAccion = dr.GetString(dr.GetOrdinal("Acciones"));
                acciones.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
                listaAcciones.Add(acciones);
            }
            cn.Desconestar();
            return listaAcciones.ToArray();

        }


        public bool Mobi_Alta_Vehiculo_Evento(int id_bien, int id_tipoevento, string observaciones, int id_user, int id_receptor_area, int id_receptor_Persona)
        {
            ConexionDB cn = new ConexionDB("dbo.MOBI_ADD_NuevoEventoBien");
            cn.AsignarParametro("@Id_Bien", id_bien);
            cn.AsignarParametro("@Id_TipoEvento", id_tipoevento);
            cn.AsignarParametro("@Observaciones", observaciones);
            cn.AsignarParametro("@IdUser", id_user);
            cn.AsignarParametro("@Id_Receptor", id_receptor_area);

            cn.BeginTransaction();

            try
            {
                //GUARDO EL AREA
                cn.EjecutarSinResultado();

                //Si mando 0 es porque no se agrega el evento de la persona
                if (id_receptor_Persona != 0)
                {
                    cn.CrearComandoConTransaccionIniciada("dbo.MOBI_ADD_NuevoEventoBien");
                    cn.AsignarParametro("@Id_Bien", id_bien);
                    cn.AsignarParametro("@Id_TipoEvento", 3);
                    cn.AsignarParametro("@Observaciones", observaciones);
                    cn.AsignarParametro("@IdUser", id_user);
                    cn.AsignarParametro("@Id_Receptor", id_receptor_Persona);

                    //GUARDO LA PERSONA
                    cn.EjecutarSinResultado();
                }

            }
            catch (Exception)
            {
                cn.RollbackTransaction();
                throw;
            }

            cn.CommitTransaction();
            cn.Desconestar();
            return true;

        }


        public bool Mobi_Alta_Vehiculo_Evento_Persona(int id_bien, int id_tipoevento, string observaciones, int id_user, int id_receptor_Persona)
        {

            ConexionDB cn = new ConexionDB("dbo.MOBI_ADD_NuevoEventoBien");
            cn.AsignarParametro("@Id_Bien", id_bien);
            cn.AsignarParametro("@Id_TipoEvento", id_tipoevento);
            cn.AsignarParametro("@Observaciones", observaciones);
            cn.AsignarParametro("@IdUser", id_user);
            cn.AsignarParametro("@Id_Receptor", id_receptor_Persona);

            try
            {

                cn.EjecutarSinResultado();

            }
            catch (Exception)
            {
                throw;
            }


            cn.Desconestar();
            return true;

        }

        public MoBi_Evento[] Mobi_GetMovimientos(int id_bien)
        {

            List<MoBi_Evento> listaEventos = new List<MoBi_Evento>();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GET_Eventos_por_IdBien");
            cn.AsignarParametro("@id_bien", id_bien);

            dr = cn.EjecutarConsulta();
            MoBi_Evento evento;
            while (dr.Read())
            {
                evento = new MoBi_Evento();
                evento.Id = dr.GetInt32(dr.GetOrdinal("Id_Evento"));
                evento.TipoEvento = dr.GetString(dr.GetOrdinal("Tipo_Evento"));
                evento.Observaciones = dr.GetString(dr.GetOrdinal("Observaciones"));
                evento.Receptor = dr.GetString(dr.GetOrdinal("Descripcion_Receptor"));
                evento.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"));
                listaEventos.Add(evento);
            }
            cn.Desconestar();
            return listaEventos.ToArray();

        }


        public string ImportarArchivoExcel(string nombreArchivo, string detalleExcel, int id_user)
        {
            _Application exlApp;
            Workbook exlWbook;
            Worksheet exlWsheet;
            string path = "";
            string sErrorApellidoNombre = "";

            try
            {

                byte[] bytes = Convert.FromBase64String(detalleExcel);

                path = System.Web.HttpContext.Current.Server.MapPath("") + "\\" + nombreArchivo;

                File.WriteAllBytes(path, bytes);

                exlApp = new Microsoft.Office.Interop.Excel.Application();

                //Asignamos el libro que sera abierot
                exlWbook = exlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                exlWsheet = exlWbook.Worksheets.get_Item(1);

                Range exlRange;
                string sValor;
                string sDetalle = "";

                //Definimos el rango de celdas que seran leidas
                exlRange = exlWsheet.UsedRange;

                //Recorremos el archivo excel como si fuera una matriz
                for (int i = 1; i <= exlRange.Rows.Count; i++)
                {
                    sValor = "";
                    for (int j = 1; j <= exlRange.Columns.Count; j++)
                    {
                        sValor += " " + (exlRange.Cells[i, j] as Range).Value + "|";
                    }

                    //Controlo que el campo de Apellido, Nombre y DNI
                    String[] sCampos = sValor.Split('|');
                    String[] Conductor = sCampos[4].ToString().Split(';');

                    if (Conductor.Count() > 3 && Conductor[3].ToString() != "")
                    {
                        sErrorApellidoNombre = "Hay un error en la fila " + i + " del archivo en el campo Conductor |";
                        sErrorApellidoNombre += "No cumple con el formato aducuado. APELLIDO;NOMBRE;DNI |";
                        sErrorApellidoNombre += "Campo= " + sCampos[4].ToString();

                        exlWbook.Close();
                        exlApp.Quit();
                        File.Delete(path);

                        return sErrorApellidoNombre;
                    }

                    sDetalle = sDetalle + "*" + sValor;
                }

                //cerramos el libro y la aplicacion
                exlWbook.Close();
                exlApp.Quit();
                File.Delete(path);


                return GuardarArchivoExcel(nombreArchivo, sDetalle, id_user);

            }
            catch (Exception)
            {
                sErrorApellidoNombre = "Hubo un error al querer importar el archivo |";
                sErrorApellidoNombre += "Pruebe en abrir el archivo y guardarlo como 'Libro Excel 97-2003 (*.xls)' e intente nuevamente.";

                File.Delete(path);

                return sErrorApellidoNombre;
            }
            

        }


        public string GuardarArchivoExcel(string nombreArchivo, string detalleExcel, int id_user)
        {

            Char delimiter;
            var iContador = 0;

            delimiter = '*';
            String[] sFila = detalleExcel.Split(delimiter);


            ConexionDB cn = new ConexionDB("dbo.MOBI_ADD_TransaccionesYPF_Cabecera");
            cn.AsignarParametro("@NombreArchivo", nombreArchivo);
            cn.AsignarParametro("@Usuario", id_user);


            cn.BeginTransaction();

            try
            {
                //GUARDO EL AREA
                var idtransaccion = cn.EjecutarEscalar();

                //VALIDO QUE EL ARCHIVO EXISTA.
                if (Convert.ToInt32(idtransaccion) == 0)
                {
                    cn.RollbackTransaction();
                    return "El archivo " + nombreArchivo + " ya fue importado";
                }

                foreach (var unaFila in sFila)
                {
                    if (iContador > 2)
                    {
                        delimiter = '|';
                        String[] sCampos = unaFila.Split(delimiter);

                        cn.CrearComandoConTransaccionIniciada("dbo.MOBI_ADD_TransaccionesYPF_Detalle");
                        cn.AsignarParametro("@Id_Cabecera", Convert.ToInt32(idtransaccion));
                        //cn.AsignarParametro("@Contrato", sCampos[0].ToString());
                        //cn.AsignarParametro("@Centro_Costo", sCampos[1].ToString());
                        cn.AsignarParametro("@Tarjeta", sCampos[2].ToString());
                        cn.AsignarParametro("@Patente", sCampos[3].ToString());

                        String[] Conductor = sCampos[4].ToString().Split(';');
                        cn.AsignarParametro("@Apellido", Conductor[0].ToString());
                        cn.AsignarParametro("@Nombre", Conductor[1].ToString());
                        cn.AsignarParametro("@NroDocumento", Conductor[2].ToString());

                        cn.AsignarParametro("@Fecha_Transacción", sCampos[5].ToString());
                        cn.AsignarParametro("@Numero_Establecimiento", Convert.ToInt32(sCampos[6].ToString()));
                        cn.AsignarParametro("@Establecimiento", sCampos[7].ToString());
                        cn.AsignarParametro("@Direccion", sCampos[8].ToString());
                        cn.AsignarParametro("@Localidad", sCampos[9].ToString());
                        cn.AsignarParametro("@Provincia", sCampos[10].ToString());
                        cn.AsignarParametro("@Producto", sCampos[11].ToString());
                        cn.AsignarParametro("@Centro_Emisor", Convert.ToInt32(sCampos[12].ToString()));
                        cn.AsignarParametro("@Remito", Convert.ToInt32(sCampos[13].ToString()));
                        cn.AsignarParametro("@Cantidad_Lts", Convert.ToDecimal(sCampos[14].ToString()));
                        cn.AsignarParametro("@KM", Convert.ToInt32(sCampos[15].ToString()));
                        cn.AsignarParametro("@Precio_Aplicado", Convert.ToDecimal(sCampos[16].ToString()));
                        cn.AsignarParametro("@IVA", Convert.ToDecimal(sCampos[17].ToString()));
                        cn.AsignarParametro("@ITC", Convert.ToDecimal(sCampos[18].ToString()));
                        cn.AsignarParametro("@Tasa_Hidrica", Convert.ToDecimal(sCampos[19].ToString()));
                        cn.AsignarParametro("@TGO", Convert.ToDecimal(sCampos[20].ToString()));
                        cn.AsignarParametro("@Nro_Extracto", sCampos[21].ToString());
                        cn.AsignarParametro("@Importe", Convert.ToDecimal(sCampos[22].ToString()));
                        cn.AsignarParametro("@Moneda", sCampos[23].ToString());
                        cn.AsignarParametro("@Nro_Factura", sCampos[24].ToString());


                        cn.EjecutarSinResultado();
                    }

                    iContador++;
                }

            }
            catch (Exception ex)
            {
                cn.RollbackTransaction();
                return "Error al Exportar el archivo, Fila " + iContador;
            }

            cn.CommitTransaction();
            cn.Desconestar();
            return "Datos importados correctamente";
        }



        public string MOBI_GET_EventosxTipoBienxClaveAtributoBienxValor(int Id_ClaveAtributoBien, string valor, int Id_TipoBien, int tipoConsulta)
        {
           
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id_ClaveAtributoBien", Id_ClaveAtributoBien);
            parametros.Add("@valor", valor);
            parametros.Add("@Id_TipoBien", Id_TipoBien);
            parametros.Add("@tipoConsulta", tipoConsulta);

            var resultado = new object();
            var lista = new List<object>();

            var tablaDatos = conexion_bd.Ejecutar("dbo.MOBI_GET_EventosxTipoBienxClaveAtributoBienxValor", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {/*Tambien se puede crear un objeto contenedor de cada fila, esto me sirve para  retornar una 
                  * lista en lugar de un objeto string json
                  * 
                    Persona persona = new Persona(row.GetInt("id_usuario"), row.GetInt("NroDocumento"), row.GetString("nombre"), row.GetString("apellido"), area);
                    Respuesta respuesta = new Respuesta(
                        row.GetInt("id_orden"),
                        persona,
                        row.GetDateTime("fecha_creacion"),
                        row.GetString("texto"));
                    */
                 /* NOTA: para procesar las columnas dinamicamente segun su longitud e ir imprimiendo el nombre la columna y su valor se debe rehacer el
                  * conexion_db_Ejecutar o dar una alternativa para que use los contenedores default y no los renombrados sino no se puede
                  * sacar esos metadatos o indexar y recuperar las columnas dinamicamente
                  * foreach (DataColumn column in tablaDatos.Columns)
                  {
                      Console.WriteLine(row[column]);
                  }*/                    

                    resultado = new
                    {
                        //Id_Recibo = row.GetInt("Id_Recibo"),
                        //id = int.Parse(row.GetObject("id").ToString())
                        //anio = int.Parse(row.GetObject("anio").ToString()),//smallint
                        idEvento = row.GetInt("idEvento"),
                        idVehiculoAsociado = row.GetInt("idVehiculoAsociado"),
                        idTipoEvento = row.GetSmallintAsInt("idTipoEvento"),
                        observacion = row.GetString("observacion", ""),
                        idTarjeton = row.GetInt("idTarjeton"),
                        fechaCreacion = row.GetDateTime("fechaCreacion").ToString("yyyy'-'MM'-'dd"),
                        descripcionTipoEvento = row.GetString("descripcionTipoEvento", ""),
                        vigencia = row.GetString("Vigencia", ""),
                        codigoWeb = row.GetString("codigoWeb", "")

                    };
                    lista.Add(resultado);
                });

            }

            return JsonConvert.SerializeObject(lista);
        }



}

}
