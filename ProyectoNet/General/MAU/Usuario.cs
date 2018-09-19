using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using General;
using System.Security.Cryptography;

namespace General.MAU
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public Persona Owner { get; set; }
        public bool Habilitado { get; set; }
        public bool Verificado { get; set; }
        public string MailRegistro { get; set; }

        public List<Funcionalidad> Funcionalidades { get; set; }

        protected string clave_encriptada { get; set; }

        public Usuario()
        {
            this.Funcionalidades = new List<Funcionalidad>();
            this.Owner = new PersonaNula();
        }

        public Usuario(int id, string alias, string clave_encriptada, Persona owner, bool habilitado)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
            this.Owner = owner;
            this.Habilitado = habilitado;
            this.Funcionalidades = new List<Funcionalidad>();
        }

        public Usuario(int id, string alias, string clave_encriptada, bool habilitado)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
            this.Habilitado = habilitado;
            this.Funcionalidades = new List<Funcionalidad>();
            this.Owner = new PersonaNula();
        }

        public bool EsFirmante { get; set; }

        public virtual bool ValidarClave(string clave)
        {
            return this.clave_encriptada == Encriptador.EncriptarSHA1(clave);
        }

        public bool CambiarClave(string clave_actual, string clave_nueva)
        {
            if (!this.ValidarClave(clave_actual)) return false;
            this.clave_encriptada = Encriptador.EncriptarSHA1(clave_nueva);
            return true;
        }

        public void AgregarFuncionalidad(Funcionalidad funcionalidad)
        {
            this.Funcionalidades.Add(funcionalidad);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Id == ((Usuario)obj).Id; 
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Id;
        }


    }
}
