using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using General;
using General.Repositorios;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Descripción breve de RepositorioVisitas
/// </summary>
public class RepositorioVisitas
{
    private int _UserId = -1;
    public int UserId
    {
        set { this._UserId = value; }
        get { return this._UserId; }
    }

    private string _IP = string.Empty;
    public string IP
    {
        set { this._IP = value; }
        get { return this._IP; }
    }

    public RepositorioVisitas()
    {
    }


    public RepositorioVisitas(int UserId_Param, string IP_Param)
    {
        this.UserId = UserId_Param;
        this.IP = IP_Param;
    }


    public List<FuncionarioVisita> getFuncionariosHabilitados()
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_Funcionario]");
        cn.AsignarParametro("@IdUser", this.UserId);
        SqlDataReader dr = cn.EjecutarConsulta();

        FuncionarioVisita unFuncionario;
        List<FuncionarioVisita> lFuncionarios = new List<FuncionarioVisita>();
        while (dr.Read())
        {
            unFuncionario = new FuncionarioVisita { Id = Convert.ToInt32(dr[0]), Apellido = dr[1].ToString(), Nombre = dr[2].ToString(), Documento = Convert.ToInt32(dr[3]), Tratamiento = dr[4].ToString(), Telefono = Convert.ToInt32(dr[5]), LugarTrabajo = dr[6].ToString() };
            lFuncionarios.Add(unFuncionario);
        }
        return lFuncionarios;
    }


    public List<MotivoVisita> getMotivoVista()
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_Motivo]");
        SqlDataReader dr = cn.EjecutarConsulta();
        MotivoVisita unMotivo;
        List<MotivoVisita> lMotivos = new List<MotivoVisita>();
        while (dr.Read())
        {
            unMotivo = new MotivoVisita { Id = Convert.ToInt32(dr[0]), Motivo = Convert.ToString(dr[1].ToString()) };
            lMotivos.Add(unMotivo);
        }
        return lMotivos;
    }


    public List<PersonaVisita> getPersonas(string Apellido, string Nombre, int Documento)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_Persona]");
        cn.AsignarParametro("@Apellido", Apellido);
        cn.AsignarParametro("@Nombre", Nombre);
        cn.AsignarParametro("@Documento", Documento); 

        SqlDataReader dr = cn.EjecutarConsulta();
        PersonaVisita unaPersona;
        List<PersonaVisita> lPerResult = new List<PersonaVisita>();
        while (dr.Read())
        {
            unaPersona = new PersonaVisita { Id = Convert.ToInt32(dr[0]), Nombre = Convert.ToString(dr[1].ToString()), Apellido = Convert.ToString(dr[2].ToString()), Documento = Convert.ToInt32(dr[3])};
            lPerResult.Add(unaPersona);
        }
        return lPerResult;
    }

    public PersonaVisita savePersona(PersonaVisita unaPersona)
    {
        try
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[CtlAcc_INS_Persona]", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar, 64).Value = unaPersona.Apellido;
            cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 64).Value = unaPersona.Nombre;
            cmd.Parameters.Add("@Documento", System.Data.SqlDbType.Int, 4).Value = unaPersona.Documento;
            cmd.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int, 4).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            unaPersona.Id = (int)cmd.Parameters["@IdPersona"].Value;
            cnn.Close();
            cnn.Dispose();
            return unaPersona;
        }
        catch
        {
            return null;
        }
    }

    public AutorizacionVisita saveAutorizacion(AutorizacionVisita unaAutorizacion)
    {
        SqlTransaction tran = null;
        SqlConnection cnn = null;
        try
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[CtlAcc_INS_Autorizacion]", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdFuncionario", System.Data.SqlDbType.Int, 4).Value = unaAutorizacion.Funcionario.Id;
            cmd.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int, 4).Value = unaAutorizacion.PersonaAutorizada.Id;
            cmd.Parameters.Add("@IdMotivo", System.Data.SqlDbType.TinyInt, 1).Value = unaAutorizacion.Motivo.Id;
            cmd.Parameters.Add("@Lugar", System.Data.SqlDbType.VarChar, 64).Value = unaAutorizacion.Lugar;
            cmd.Parameters.Add("@Representa", System.Data.SqlDbType.VarChar, 64).Value = unaAutorizacion.Representa;
            cmd.Parameters.Add("@Log_UserId", System.Data.SqlDbType.Int, 4).Value = this.UserId;
            cmd.Parameters.Add("@Log_IP", System.Data.SqlDbType.VarChar, 16).Value = this.IP.ToString();
            cmd.Parameters.Add("@IdAutorizacion", System.Data.SqlDbType.Int, 4).Direction = System.Data.ParameterDirection.Output;
            tran = cnn.BeginTransaction();
            cmd.Transaction = tran;
            cmd.ExecuteNonQuery();
            unaAutorizacion.Id = (int)cmd.Parameters["@IdAutorizacion"].Value;
            cmd.Dispose();
            foreach (DateTime fecha in unaAutorizacion.FechasAut)
            {
                cmd.CommandText = "[dbo].[CtlAcc_INS_AutorizacionFecha]";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@IdAutorizacion", System.Data.SqlDbType.Int, 4).Value = unaAutorizacion.Id;
                cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.SmallDateTime).Value = fecha;
                cmd.ExecuteNonQuery();
            }
            tran.Commit();
        }
        catch
        {
            if (tran != null)
                tran.Rollback();
            unaAutorizacion = null;
        }
        finally
        {
            if(cnn != null)
                if (cnn.State != System.Data.ConnectionState.Closed)
                {
                    cnn.Close();
                    cnn.Dispose();
                }
        }
        return unaAutorizacion;
    }

    public List<AutorizacionVisitaExtracto> getAutorizaciones(DateTime Fecha)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_Autorizaciones]");
        cn.AsignarParametro("@Fecha", Fecha);
        SqlDataReader dr = cn.EjecutarConsulta();
        AutorizacionVisitaExtracto unaAutExt;
        List<AutorizacionVisitaExtracto> lAutExt = new List<AutorizacionVisitaExtracto>();
        while (dr.Read())
        {
            unaAutExt = new AutorizacionVisitaExtracto { Autorización = Convert.ToInt32(dr[0]), Apellido = dr[1].ToString(), Nombre = dr[2].ToString(), Documento = Convert.ToInt32(dr[3]), Representa = dr[4].ToString(), Funcionario = dr[5].ToString(), Lugar = dr[6].ToString()};
            lAutExt.Add(unaAutExt);
        }
        dr.Close();
        dr.Dispose();
        return lAutExt;
    }


    public bool savePersonaAcreditacion( AcreditacionVisita acreditacion, PersonaVisitaAcreditada persona )
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_INS_PersonaAutorizacionFecha]");
        cn.AsignarParametro("@IdAutorizacion", acreditacion.Autorizacion.Id);
        cn.AsignarParametro("@Fecha", acreditacion.Fecha);
        cn.AsignarParametro("@Apellido", persona.Apellido);
        cn.AsignarParametro("@Nombre", persona.Nombre);
        cn.AsignarParametro("@Documento", persona.Documento);
        cn.AsignarParametro("@NroCredencial", persona.NroCredencial);
        try {
            cn.EjecutarSinResultado();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public List<PersonaVisitaAcreditada> getPersonasAcreditacion(AcreditacionVisita acreditacion)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_PersonasAcreditacion]");
        cn.AsignarParametro("@IdAutorizacion", acreditacion.Autorizacion.Id);
        cn.AsignarParametro("@Fecha", acreditacion.Fecha);
        SqlDataReader dr = cn.EjecutarConsulta();
        PersonaVisitaAcreditada unaPersona;
        List<PersonaVisitaAcreditada> lPerAcred = new List<PersonaVisitaAcreditada>();
        while (dr.Read())
        {
            unaPersona = new PersonaVisitaAcreditada() { Id = Convert.ToInt32(dr[0]), Apellido = dr[1].ToString(), Nombre = dr[2].ToString(), Documento = Convert.ToInt32(dr[3]), NroCredencial = dr[4].ToString() };
            lPerAcred.Add(unaPersona);
        }
        dr.Close();
        dr.Dispose();
        return lPerAcred;
    }

    public bool eliminarPersonaAcreditacion(AcreditacionVisita acreditacion, PersonaVisitaAcreditada persona)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_DEL_PersonasAcreditacion]");
        cn.AsignarParametro("@IdAutorizacion", acreditacion.Autorizacion.Id);
        cn.AsignarParametro("@Fecha", acreditacion.Fecha);
        cn.AsignarParametro("@IdPersona", persona.Id);
        try
        {
            cn.EjecutarSinResultado();
        }
        catch
        {
            return false;
        }
        return true;
    }


    public bool saveAcreditacion(AcreditacionVisita acreditacion)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_INS_Acreditacion]");
        cn.AsignarParametro("@IdAutorizacion", acreditacion.Autorizacion.Id);
        cn.AsignarParametro("@Fecha", acreditacion.Fecha);
        cn.AsignarParametro("@Log_UserId", this.UserId);
        cn.AsignarParametro("@Log_IP", this.IP.ToString());
        try
        {
            cn.EjecutarSinResultado();
        }
        catch
        {
            return false;
        }
        return true;
    }

}