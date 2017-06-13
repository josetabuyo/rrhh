using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using General.Repositorios;

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

        public MoBi_Bien[] GetBienesDelArea( int IdArea, int IdTipoBien)
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


        public bool GuardarNuevoEventoBien( MoBi_Evento.enumTipoEvento tipoEvento, int IdBien, int IdArea, int IdPersona, string Observaciones, int IdUser)
        {
            string spEvento= string.Empty;
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


        public AccionesMobi[] GetAcciones(int id_bien, int id_estado_propiedad, int id_area)
        {
            
            List<AccionesMobi> listaAcciones = new List<AccionesMobi>();
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.MOBI_GET_Acciones");
            cn.AsignarParametro("@id_bien", id_bien);
            cn.AsignarParametro("@id_estado_propiedad", id_estado_propiedad);
            cn.AsignarParametro("@id_area_seleccionada", id_area);

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


        public bool Mobi_Alta_Vehiculo_Asignacion(int id_bien, int id_area, int id_responsable, int IdUser)
        {
            ConexionDB cn = new ConexionDB("dbo.MOBI_ADD_Vehiculo_Asignacion");
            cn.AsignarParametro("@id_bien", id_bien);
            cn.AsignarParametro("@id_usuario", IdUser);
            cn.AsignarParametro("@id_receptor_area", id_area);
            cn.AsignarParametro("@id_receptor_responsable", id_responsable);

            cn.EjecutarSinResultado();
            cn.Desconestar();
            return true;

        }


    }

}
