namespace General
{
    using System;
    using System.Collections.Generic;
    using General.Calendario;
    using System.Text;
    using General.Repositorios;
    using System.Configuration;

    public class Estadia
    {
        private int _id;
        private ComisionDeServicio _ComisionDeServicio;
        private DateTime _Desde;
        private DateTime _Hasta;
        private string _Motivo;
        private Provincia _Provincia;
        private decimal _Eventuales;
        private decimal _AdicionalParaPasajes;
        private decimal _CalculadoPorCategoria;
        private Persona _Persona;

        public int Id { get { return _id; } set { _id = value; } }

        public ComisionDeServicio ComisionDeServicio { get { return _ComisionDeServicio; } set { _ComisionDeServicio = value; } }

        public DateTime Desde { get { return _Desde; } set { _Desde = value; } }

        public DateTime Hasta { get { return _Hasta; } set { _Hasta = value; } }

        public string Motivo { get { return _Motivo; } set { _Motivo = value; } }

        public Provincia Provincia { get { return _Provincia; } set { _Provincia = value; } }

        public decimal Eventuales { get { return _Eventuales; } set { _Eventuales = value; } }

        public Persona Persona { get { return _Persona; } set { _Persona = value; } }

        public decimal AdicionalParaPasajes { get { return _AdicionalParaPasajes; } set { _AdicionalParaPasajes = value; } }

        // Este es calculado, solo lectura
        public decimal CalculadoPorCategoria { get { return _CalculadoPorCategoria; } set { _CalculadoPorCategoria = value; } }

        public Estadia() { }

        public Estadia(DateTime desde, DateTime hasta, Provincia provincia, decimal eventuales, decimal adicional_pasajes, string motivo)
        {
            this._Desde = desde;
            this._Hasta = hasta;
            this._Provincia = provincia;
            this._Eventuales = eventuales;
            this._AdicionalParaPasajes = adicional_pasajes;
            this._Motivo = motivo;


        }

        public Persona GetPersonaDelViatico()
        {
            return this.ComisionDeServicio.Persona;
        }

        public float Duracion()
        {
            CalculadorDeDias calculadorDeDias = new CalculadorDeDias();
            return calculadorDeDias.CalcularDiasDe(this);
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((Estadia)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public List<Estadia> GetEstadiasPorPersona(Persona persona)
        {
            RepositorioDeEstadias repositorio = new RepositorioDeEstadias(new ConexionBDSQL(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString));
            return repositorio.GetEstadiasPorPersona(persona.Documento);
        }

        public int esMayorAlfabeticamenteQue(Estadia otraEstadia)
        {
            return this.Provincia.Nombre.CompareTo(otraEstadia.Provincia.Nombre);
        }



    }
}