using General.Contrato;
using General.MAU;
using General.MED;
using General.PotenciarTrabajo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace General.Repositorios
{
    public class RepositorioPotenciarTrabajo
    {
     
        public List<GeneralCombos> PT_Get_Cargar_Combo(string nombre_combo, Usuario usuario)
        {
            SqlDataReader dr = null;
            ConexionDB cn = null;

            switch (nombre_combo)
            {
                case "GrupoTrabajo":
                    cn = new ConexionDB("dbo.PRGSOC_GET_Entidades");
                    break;

                case "MotivoJustificacion":
                    cn = new ConexionDB("dbo.PRGSOC_GET_Tabla_Motivos_Justificacion");
                    break;
                    

                default:
                    break;
            }

            dr = cn.EjecutarConsulta();

            GeneralCombos combo;
            List<GeneralCombos> lista = new List<GeneralCombos>();

            while (dr.Read())
            {
                combo = new GeneralCombos();
                combo.id = dr.GetInt32(dr.GetOrdinal("Id"));
                combo.descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));

                lista.Add(combo);
            }

            cn.Desconestar();
            return lista;
        }


        public List<PT_Periodo> PT_Get_Periodos()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_Periodos");
            
            dr = cn.EjecutarConsulta();

            PT_Periodo combo;
            List<PT_Periodo> lista = new List<PT_Periodo>();

            while (dr.Read())
            {
                combo = new PT_Periodo();
                combo.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                combo.Mes = dr.GetString(dr.GetOrdinal("Mes"));
                combo.Anio = dr.GetInt32(dr.GetOrdinal("Anio"));
                combo.Cant_Semanas = dr.GetInt32(dr.GetOrdinal("Cantidad_Semannas"));

                lista.Add(combo);
            }

            cn.Desconestar();
            return lista;
        }

        
        public List<PT_Participacion_Dato> PT_Get_Participaciones_Dato()
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_Tabla_Datos_Participacion");

            dr = cn.EjecutarConsulta();

            PT_Participacion_Dato combo;
            List<PT_Participacion_Dato> lista = new List<PT_Participacion_Dato>();

            while (dr.Read())
            {
                combo = new PT_Participacion_Dato();
                combo.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                combo.Dato_Participacion = dr.GetString(dr.GetOrdinal("Dato_Participacion"));
                combo.Permite_Observaciones = dr.GetInt32(dr.GetOrdinal("PermiteObservaciones"));
               
                lista.Add(combo);
            }

            cn.Desconestar();
            return lista;
        }
        

        public List<PT_Participacion> PT_Get_Add_Participacion_por_Entidad_Periodo(int id_entidad, int mes, int anio, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_ADD_Participacion_Por_Entidad_Periodo");
            cn.AsignarParametro("@Id_Entidad", id_entidad);
            cn.AsignarParametro("@Mes", mes);
            cn.AsignarParametro("@Anio", anio);
            cn.AsignarParametro("@Usuario", usuario.Id);

            dr = cn.EjecutarConsulta();

            PT_Participacion part;
            List<PT_Participacion> lista = new List<PT_Participacion>();

            while (dr.Read())
            {
                part = new PT_Participacion();
                part.Persona = new PT_Personas();
                part.Persona.Id_Rol = dr.GetInt32(dr.GetOrdinal("Id_Persona_Rol"));
                part.Persona.CUIL = dr.GetString(dr.GetOrdinal("CUIL"));
                part.Persona.Nombre_Apellido = dr.GetString(dr.GetOrdinal("Apellido_Nombre"));
                part.Persona.Id_Estado = dr.GetInt32(dr.GetOrdinal("Id_Estado_Persona"));
                part.Persona.Nombre_Estado = dr.GetString(dr.GetOrdinal("Nombre_Estado"));
                part.Part_Semana1 = dr.GetInt32(dr.GetOrdinal("Part_Semana1"));
                part.Justif_Semana1 = dr.GetInt32(dr.GetOrdinal("Justif_Semana1"));
                part.Part_Semana2 = dr.GetInt32(dr.GetOrdinal("Part_Semana2"));
                part.Justif_Semana2 = dr.GetInt32(dr.GetOrdinal("Justif_Semana2"));
                part.Part_Semana3 = dr.GetInt32(dr.GetOrdinal("Part_Semana3"));
                part.Justif_Semana3 = dr.GetInt32(dr.GetOrdinal("Justif_Semana3"));
                part.Part_Semana4 = dr.GetInt32(dr.GetOrdinal("Part_Semana4"));
                part.Justif_Semana4 = dr.GetInt32(dr.GetOrdinal("Justif_Semana4"));
                part.Part_Semana5 = dr.GetInt32(dr.GetOrdinal("Part_Semana5"));
                part.Justif_Semana5 = dr.GetInt32(dr.GetOrdinal("Justif_Semana5"));
                if (!dr.IsDBNull(dr.GetOrdinal("Observacion"))) {
                    part.Observacion = dr.GetString(dr.GetOrdinal("Observacion"));
                };

                lista.Add(part);
            }

            cn.Desconestar();
            return lista;
        }

        public void PT_Upd_Participacion_por_Entidad_Periodo(int id_entidad, int mes, int anio, int semana, int id_persona_rol, int id_dato_participacion, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_UPD_Participacion_Por_Entidad_Periodo");
            cn.AsignarParametro("@Id_Entidad", id_entidad);
            cn.AsignarParametro("@Mes", mes);
            cn.AsignarParametro("@Anio", anio);
            cn.AsignarParametro("@Semana", semana);
            cn.AsignarParametro("@Id_Persona_Rol", id_persona_rol);
            cn.AsignarParametro("@Id_Dato_Participacion", id_dato_participacion);
            cn.AsignarParametro("@Usuario", usuario.Id);
            
           cn.EjecutarSinResultado();
        }


        public void PT_UPD_Participacion_Observacion(int id_entidad, int mes, int anio, int id_persona_rol, string observacion, Usuario usuario)
        {            
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_UPD_Participacion_Observacion");
            cn.AsignarParametro("@Id_Entidad", id_entidad);
            cn.AsignarParametro("@Mes", mes);
            cn.AsignarParametro("@Anio", anio);
            cn.AsignarParametro("@Id_Persona_Rol", id_persona_rol);
            cn.AsignarParametro("@Observacion", observacion);
            cn.AsignarParametro("@Usuario", usuario.Id);

            cn.EjecutarSinResultado();
        }
        

        public void PT_Add_Justificacion(int id_persona_rol, int id_motivo, int anio_desde, int mes_desde, int semana_desde, int anio_hasta, int mes_hasta, int semana_hasta, string justificacion, int id_entidad, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_ADD_PRGSOC_Participacion_Justificacion");
            cn.AsignarParametro("@Id_Persona_Rol", id_persona_rol);
            cn.AsignarParametro("@Id_Motivo", id_motivo);
            cn.AsignarParametro("@Anio_Desde", anio_desde);
            cn.AsignarParametro("@Mes_Desde", mes_desde);
            cn.AsignarParametro("@Semana_Desde", semana_desde);
            cn.AsignarParametro("@Anio_Hasta", anio_hasta);
            cn.AsignarParametro("@Mes_Hasta", mes_hasta);
            cn.AsignarParametro("@Semana_Hasta", semana_hasta);
            cn.AsignarParametro("@Justificacion", justificacion);
            cn.AsignarParametro("@Id_Usuario_Carga", usuario.Id);
            cn.AsignarParametro("@Id_Entidad", id_entidad);


            cn.EjecutarSinResultado();
        }
        
        public void PT_Upd_Justificacion(int id_registro_justif, int anio_hasta, int mes_hasta, int semana_hasta, string justificacion, int id_entidad, Usuario usuario)
        {
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_UPD_PRGSOC_Participacion_Justificacion");
            cn.AsignarParametro("@Id_Registro", id_registro_justif);
            cn.AsignarParametro("@Anio_Hasta", anio_hasta);
            cn.AsignarParametro("@Mes_Hasta", mes_hasta);
            cn.AsignarParametro("@Semana_Hasta", semana_hasta);
            cn.AsignarParametro("@Justificacion", justificacion);
            cn.AsignarParametro("@Id_Usuario_Carga", usuario.Id);
            cn.AsignarParametro("@Id_Entidad", id_entidad);


            cn.EjecutarSinResultado();
        }

        public List<PT_Justificacion> PT_Get_Justificacion(int id_registro)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_Carga_Participacion_Justificacion");
            cn.AsignarParametro("@Id_Registro", id_registro);
            
            dr = cn.EjecutarConsulta();

            PT_Justificacion just;
            List<PT_Justificacion> lista = new List<PT_Justificacion>();

            while (dr.Read())
            {
                just = new PT_Justificacion();
                just.Id_Registro = dr.GetInt32(dr.GetOrdinal("Id_Registro"));
                just.Id_Persona_Rol = dr.GetInt32(dr.GetOrdinal("Id_Persona_Rol"));
                just.Id_Motivo = dr.GetInt32(dr.GetOrdinal("Id_Motivo"));
                just.Anio_Desde = dr.GetInt32(dr.GetOrdinal("Anio_Desde"));
                just.Mes_Desde = dr.GetInt32(dr.GetOrdinal("Mes_Desde"));
                just.Semana_Desde = dr.GetInt32(dr.GetOrdinal("Semana_Desde"));
                just.Anio_Hasta = dr.GetInt32(dr.GetOrdinal("Anio_Hasta"));
                just.Mes_Hasta = dr.GetInt32(dr.GetOrdinal("Mes_Hasta"));
                just.Semana_Hasta = dr.GetInt32(dr.GetOrdinal("Semana_Hasta"));
                just.Justificacion = dr.GetString(dr.GetOrdinal("Justificacion"));
                just.Id_Usuario_Carga = dr.GetInt32(dr.GetOrdinal("Id_Usuario_Carga"));
                just.Fecha_Carga = dr.GetDateTime(dr.GetOrdinal("Fecha_Carga"));
                

                lista.Add(just);
            }

            cn.Desconestar();
            return lista;
        }

        public List<PT_Resumen_Inicial> PT_Get_Estado_Carga_Participacion_Por_Periodo(int anio, int mes, Usuario usuario)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.PRGSOC_GET_Estado_Carga_Participacion_Por_Periodo");
            cn.AsignarParametro("@anio", anio);
            cn.AsignarParametro("@mes", mes);
            cn.AsignarParametro("@Id_usuario", usuario.Id);

            dr = cn.EjecutarConsulta();

            PT_Resumen_Inicial res;
            List<PT_Resumen_Inicial> lista = new List<PT_Resumen_Inicial>();

            while (dr.Read())
            {
                res = new PT_Resumen_Inicial();
                res.Id_Entidad = dr.GetInt32(dr.GetOrdinal("Id_Entidad"));
                res.Nombre_Entidad = dr.GetString(dr.GetOrdinal("Nombre_Entidad"));
                res.Activos = dr.GetInt32(dr.GetOrdinal("Activos"));
                res.Activos_Parcial = dr.GetInt32(dr.GetOrdinal("Activos_Parcial"));
                res.Suspendidos = dr.GetInt32(dr.GetOrdinal("Suspendidos"));
                res.Inactivos = dr.GetInt32(dr.GetOrdinal("Inactivos"));
                res.Sin_Carga = dr.GetInt32(dr.GetOrdinal("SinCarga"));
                res.En_Proceso = dr.GetInt32(dr.GetOrdinal("EnProceso"));
                res.Con_Informe = dr.GetInt32(dr.GetOrdinal("ConInforme"));
                res.IdFuncionalidad = dr.GetInt32(dr.GetOrdinal("IdFuncionalidad"));
                res.NombreFuncionalidad = dr.GetString(dr.GetOrdinal("NombreFuncionalidad"));
                
                lista.Add(res);
            }

            cn.Desconestar();
            return lista;
        }

       
        
    }
}
