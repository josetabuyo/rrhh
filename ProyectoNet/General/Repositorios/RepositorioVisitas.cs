using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using General;
using General.Repositorios;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de RepositorioVisitas
/// </summary>
public class RepositorioVisitas
{
    private int _UserId;
    public int UserId
    {
        set { this._UserId = value; }
        get { return this._UserId; }
    }

    private string _IP;
    public string IP
    {
        set { this._IP = value; }
        get { return this._IP; }
    }


    public RepositorioVisitas(int UserId_Param)
    {
        UserId = UserId_Param;
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



    public List<AutorizacionVisita> getAutorizaciones(string Apellido, string Nombre, int Documento)
    {
        ConexionDB cn = new ConexionDB("[dbo].[CtlAcc_SEL_Autorizaciones_Hoy]");
        cn.AsignarParametro("@Apellido", Apellido);
        cn.AsignarParametro("@Nombre", Nombre);
        cn.AsignarParametro("@Documento", Documento);
        SqlDataReader dr = cn.EjecutarConsulta();

        AutorizacionVisita unaAutorizacion;
        List<AutorizacionVisita> lAutorizaciones = new List<AutorizacionVisita>();
        while (dr.Read())
        {
            /***********************************/
            /***********************************/
            unaAutorizacion = new AutorizacionVisita { Id = Convert.ToInt32(dr[0]), Acompanantes = Convert.ToInt32(dr[1]), Acreditado = Convert.ToBoolean(dr[2]), FechaAut = Convert.ToDateTime(dr[3]), Funcionario = new FuncionarioVisita() { Id = Convert.ToInt32(dr[4]) }, Lugar = Convert.ToString(dr[5]), Motivo = new MotivoVisita() { Id = Convert.ToInt32(dr[6]) }, Representa = Convert.ToString(dr[7]), PersonaAutorizada = new PersonaVisita() { Id = Convert.ToInt32(dr[8]) } };
            /***********************************/
            /***********************************/
            lAutorizaciones.Add(unaAutorizacion);
        }
        return lAutorizaciones;
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
        try
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[CtlAcc_INS_Autorizacion]", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdFuncionario", System.Data.SqlDbType.Int, 4).Value = unaAutorizacion.Id;            
            cmd.Parameters.Add("@IdPersona", System.Data.SqlDbType.Int, 4).Value = unaAutorizacion.PersonaAutorizada.Id;
            cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.BigInt, 8).Value = unaAutorizacion.Telefono;
            cmd.Parameters.Add("@IdMotivo", System.Data.SqlDbType.TinyInt, 1).Value = unaAutorizacion.Motivo.Id;
            cmd.Parameters.Add("@Lugar", System.Data.SqlDbType.VarChar, 64).Value = unaAutorizacion.Lugar;
            cmd.Parameters.Add("@Representa", System.Data.SqlDbType.VarChar, 64).Value = unaAutorizacion.Representa;
            cmd.Parameters.Add("@Acompanantes", System.Data.SqlDbType.TinyInt, 1).Value = unaAutorizacion.Acompanantes;
            cmd.Parameters.Add("@Log_UserId", System.Data.SqlDbType.Int, 4).Value = this.UserId;
            cmd.Parameters.Add("@Log_IP", System.Data.SqlDbType.VarChar, 16).Value = this.IP.ToString();
            cmd.Parameters.Add("@IdAutorizacion", System.Data.SqlDbType.Int, 4).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            unaAutorizacion.Id = (int)cmd.Parameters["@IdAutorizacion"].Value;
            cnn.Close();
            cnn.Dispose();
            return unaAutorizacion;
        }
        catch
        {
            return null;
        }
    }




}