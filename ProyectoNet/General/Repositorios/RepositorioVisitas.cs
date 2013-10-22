using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using General;
using General.Repositorios;
using System.Data.SqlClient;

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
        
/*            
        List<FuncionarioVisita> lFuncionarios = new List<FuncionarioVisita>();
        // Llamar al WS
        lFuncionarios.Add( new FuncionarioVisita() { Id=1, Apellido="NOVOA", Nombre="MARTA", Documento=0, Tratamiento ="Dra.", Telefono=43790000, LugarTrabajo="Dir.RRHH - MDS - Piso 21 - Ala Belgrano."} );
        lFuncionarios.Add( new FuncionarioVisita() { Id=2, Apellido="SPINAZZOLA", Nombre="GUSTAVO", Documento=0, Tratamiento ="Dr.", Telefono=43790000, LugarTrabajo="Dir.RRHH - MDS - Piso 21 - Ala Moreno."});
*/

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
        List<PersonaVisita> lPersonas = new List<PersonaVisita>();
        /****************************/
        // Llamar al WS        
        lPersonas.Add(new PersonaVisita() { Id = 1, Nombre = "RUBEN ATILIO", Apellido = "ACOSTA", Documento = 11225580, Telefono = 0 });
        lPersonas.Add(new PersonaVisita() { Id = 2, Nombre = "DANIEL REMIGIO", Apellido = "MIÑO", Documento = 7911354, Telefono = 0 });
        lPersonas.Add(new PersonaVisita() { Id = 3, Nombre = "ALCIDES", Apellido = "DIAZ", Documento = 10002067, Telefono = 0 });
        lPersonas.Add(new PersonaVisita() { Id = 4, Nombre = "ROLANDO", Apellido = "GOMEZ", Documento = 11886072, Telefono = 0 });
        lPersonas.Add(new PersonaVisita() { Id = 5, Nombre = "ROBERTO", Apellido = "ORTIGOZA", Documento = 12329256, Telefono = 0 });
        lPersonas.Add(new PersonaVisita() { Id = 6, Nombre = "OSVALDO ROBERTO", Apellido = "SANCHEZ", Documento = 12229412, Telefono = 0 });
        /****************************/
        IEnumerable<PersonaVisita> ieP = lPersonas.Where(p => p.Apellido.ToUpper().Contains(Apellido.ToUpper()) && p.Nombre.ToUpper().Contains(Nombre.ToUpper()));
        List<PersonaVisita> lPerResult = new List<PersonaVisita>();
        foreach (PersonaVisita p in ieP) lPerResult.Add(p);
        return lPerResult;
    }


    public List<AutorizacionVisita> getAutorizaciones(string Apellido, string Nombre, int Documento)
    {
        List<AutorizacionVisita> lAutorizaciones = new List<AutorizacionVisita>();
        /****************************/
        // Llamar al WS        

        List<FuncionarioVisita> lF = this.getFuncionariosHabilitados();
        List<PersonaVisita> lP = this.getPersonas("", "", 0);
        List<MotivoVisita> lM = this.getMotivoVista();

        lAutorizaciones.Add(new AutorizacionVisita() { Id = 1, Acompanantes = 2, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[2], Representa = "Presidencia", PersonaAutorizada = lP[3] });
        lAutorizaciones.Add(new AutorizacionVisita() { Id = 2, Acompanantes = 1, Acreditado = true, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[0], Representa = "Ministerio de Economia", PersonaAutorizada = lP[1] });
        lAutorizaciones.Add(new AutorizacionVisita() { Id = 3, Acompanantes = 0, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[1], Lugar = lF[1].LugarTrabajo, Motivo = lM[3], Representa = "Municipalidad Avellaneda", PersonaAutorizada = lP[4] });
        lAutorizaciones.Add(new AutorizacionVisita() { Id = 4, Acompanantes = 3, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[5], Representa = "-", PersonaAutorizada = lP[2] });
        lAutorizaciones.Add(new AutorizacionVisita() { Id = 5, Acompanantes = 2, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[1], Lugar = lF[1].LugarTrabajo, Motivo = lM[0], Representa = "Provincia Misiones", PersonaAutorizada = lP[5] });

        /****************************/
        IEnumerable<AutorizacionVisita> ieAut = lAutorizaciones.Where(a => a.PersonaAutorizada.Apellido.ToUpper().Contains(Apellido.ToUpper()) && a.PersonaAutorizada.Nombre.ToUpper().Contains(Nombre.ToUpper()));
        List<AutorizacionVisita> lAutResult = new List<AutorizacionVisita>();
        foreach (AutorizacionVisita p in ieAut) lAutResult.Add(p);
        return lAutResult;
    }

}