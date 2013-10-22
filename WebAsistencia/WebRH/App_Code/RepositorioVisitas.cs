using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;


/// <summary>
/// Descripción breve de RepositorioVisitas
/// </summary>
public class RepositorioVisitas
{
    public class Persona
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private string _Nombre;
        public string Nombre
        {
            set { this._Nombre = value; }
            get { return this._Nombre; }
        }

        private string _Apellido;
        public string Apellido
        {
            set { this._Apellido = value; }
            get { return this._Apellido; }
        }

        private int _Documento;
        public int Documento
        {
            set { this._Documento = value; }
            get { return this._Documento; }
        }

        private int _Telefono;
        public int Telefono
        {
            set { this._Telefono = value; }
            get { return this._Telefono; }
        }

    }

    public class Funcionario: Persona
    {
        private string _Tratamiento;
        public string Tratamiento
        {
            set { this._Tratamiento = value; }
            get { return this._Tratamiento; }
        }

        private string _LugarTrabajo;
        public string LugarTrabajo
        {
            set { this._LugarTrabajo = value; }
            get { return this._LugarTrabajo; }
        }
    }

    public class MotivoVisita
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private string _Motivo;
        public string Motivo
        {
            set { this._Motivo = value; }
            get { return this._Motivo; }
        }
    }

    public class Autorizacion
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private DateTime _FechaAut;
        public DateTime FechaAut
        {
            set { this._FechaAut = value; }
            get { return this._FechaAut; }
        }

        private Persona _Persona;
        public Persona PersonaAutorizada
        {
            set { this._Persona = value; }
            get { return this._Persona; }
        }

        private Funcionario _Funcionario;
        public Funcionario Funcionario
        {
            set { this._Funcionario = value; }
            get { return this._Funcionario; }
        }

        private MotivoVisita _Motivo;
        public MotivoVisita Motivo
        {
            set { this._Motivo = value; }
            get { return this._Motivo; }
        }


        private string _Lugar;
        public string Lugar
        {
            set { this._Lugar = value; }
            get { return this._Lugar; }
        }

        private string _Representa;
        public string Representa
        {
            set { this._Representa = value; }
            get { return this._Representa; }
        }

        private int _Acompanantes;
        public int Acompanantes
        {
            set { this._Acompanantes = value; }
            get { return this._Acompanantes; }
        }

        private bool _Acreditado;
        public bool Acreditado
        {
            set { this._Acreditado = value; }
            get { return this._Acreditado; }
        }

    }


    /*****************************/
    /*****************************/

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


    public List<Funcionario> getFuncionariosHabilitados()
    {
        List<Funcionario> lFuncionarios = new List<Funcionario>();
        /****************************/
        // Llamar al WS
        lFuncionarios.Add( new Funcionario() { Id=1, Apellido="NOVOA", Nombre="MARTA", Documento=0, Tratamiento ="Dra.", Telefono=43790000, LugarTrabajo="Dir.RRHH - MDS - Piso 21 - Ala Belgrano."} );
        lFuncionarios.Add( new Funcionario() { Id=2, Apellido="SPINAZZOLA", Nombre="GUSTAVO", Documento=0, Tratamiento ="Dr.", Telefono=43790000, LugarTrabajo="Dir.RRHH - MDS - Piso 21 - Ala Moreno."});
        /****************************/
        return lFuncionarios;
    }


    public List<MotivoVisita> getMotivoVista()
    {
        List<MotivoVisita> lMotivos = new List<MotivoVisita>();
        /****************************/
        // Llamar al WS
        lMotivos.Add(new MotivoVisita() { Id = 1, Motivo = "Reunión de trabajo" });
        lMotivos.Add(new MotivoVisita() { Id = 2, Motivo = "Audiencia" });
        lMotivos.Add(new MotivoVisita() { Id = 3, Motivo = "Capacitación" });
        lMotivos.Add(new MotivoVisita() { Id = 4, Motivo = "Trámites varios" });
        lMotivos.Add(new MotivoVisita() { Id = 5, Motivo = "Visita" });
        lMotivos.Add(new MotivoVisita() { Id = 6, Motivo = "Entrevista" });
        /****************************/
        return lMotivos;
    }


    public List<Persona> getPersonas(string Apellido, string Nombre, int Documento)
    {
        List<Persona> lPersonas = new List<Persona>();
        /****************************/
        // Llamar al WS        
        lPersonas.Add(new Persona() { Id = 1, Nombre = "RUBEN ATILIO", Apellido = "ACOSTA", Documento = 11225580, Telefono = 0 });        
        lPersonas.Add(new Persona() { Id = 2, Nombre = "DANIEL REMIGIO", Apellido = "MIÑO", Documento = 7911354, Telefono = 0 });   	
        lPersonas.Add(new Persona() { Id = 3, Nombre = "ALCIDES", Apellido = "DIAZ", Documento = 10002067, Telefono = 0 });
        lPersonas.Add(new Persona() { Id = 4, Nombre = "ROLANDO", Apellido = "GOMEZ", Documento = 11886072, Telefono = 0 });    
        lPersonas.Add(new Persona() { Id = 5, Nombre = "ROBERTO", Apellido = "ORTIGOZA", Documento = 12329256, Telefono = 0 });
        lPersonas.Add(new Persona() { Id = 6, Nombre = "OSVALDO ROBERTO", Apellido = "SANCHEZ", Documento = 12229412, Telefono = 0 });
        /****************************/
        IEnumerable<Persona> ieP = lPersonas.Where(p => p.Apellido.ToUpper().Contains(Apellido.ToUpper()) && p.Nombre.ToUpper().Contains(Nombre.ToUpper()));
        List<Persona> lPerResult = new List<Persona>();
        foreach( Persona p in ieP) lPerResult.Add(p);
        return lPerResult;
    }


    public List<Autorizacion> getAutorizaciones(string Apellido, string Nombre, int Documento)
    {
        List<Autorizacion> lAutorizaciones = new List<Autorizacion>();
        /****************************/
        // Llamar al WS        

        List<Funcionario> lF = this.getFuncionariosHabilitados();
        List<Persona> lP = this.getPersonas("", "", 0);
        List<MotivoVisita> lM = this.getMotivoVista();

        lAutorizaciones.Add(new Autorizacion() { Id = 1, Acompanantes = 2, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[2], Representa = "Presidencia", PersonaAutorizada = lP[3] });
        lAutorizaciones.Add(new Autorizacion() { Id = 2, Acompanantes = 1, Acreditado = true, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[0], Representa = "Ministerio de Economia", PersonaAutorizada = lP[1] });
        lAutorizaciones.Add(new Autorizacion() { Id = 3, Acompanantes = 0, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[1], Lugar = lF[1].LugarTrabajo, Motivo = lM[3], Representa = "Municipalidad Avellaneda", PersonaAutorizada = lP[4] });
        lAutorizaciones.Add(new Autorizacion() { Id = 4, Acompanantes = 3, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[0], Lugar = lF[0].LugarTrabajo, Motivo = lM[5], Representa = "-", PersonaAutorizada = lP[2] });
        lAutorizaciones.Add(new Autorizacion() { Id = 5, Acompanantes = 2, Acreditado = false, FechaAut = DateTime.Now, Funcionario = lF[1], Lugar = lF[1].LugarTrabajo, Motivo = lM[0], Representa = "Provincia Misiones", PersonaAutorizada = lP[5] });

        /****************************/
        IEnumerable<Autorizacion> ieAut = lAutorizaciones.Where(a => a.PersonaAutorizada.Apellido.ToUpper().Contains(Apellido.ToUpper()) && a.PersonaAutorizada.Nombre.ToUpper().Contains(Nombre.ToUpper()));
        List<Autorizacion> lAutResult = new List<Autorizacion>();
        foreach (Autorizacion p in ieAut) lAutResult.Add(p);
        return lAutResult;
    }





}