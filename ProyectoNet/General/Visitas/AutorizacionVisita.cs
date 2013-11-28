using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class AutorizacionVisita
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

        private PersonaVisita _Persona;
        public PersonaVisita PersonaAutorizada
        {
            set { this._Persona = value; }
            get { return this._Persona; }
        }

        private FuncionarioVisita _Funcionario;
        public FuncionarioVisita Funcionario
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

        private long _Telefono;
        public long Telefono
        {
            set { this._Telefono = value; }
            get { return this._Telefono; }
        }

    }

}
