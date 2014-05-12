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
        private int p;
        private string p_2;
        private string p_3;
        private bool p_4;

        public int Id { get; set; }
        public string Alias { get; set; }
        public Persona Owner { get; set; }
        public bool Habilitado { get; set; }

        protected string clave_encriptada { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string alias, string clave_encriptada, Persona owner, bool habilitado)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
            this.Owner = owner;
            this.Habilitado = habilitado;
        }

        public Usuario(int id, string alias, string clave_encriptada, bool habilitado)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
            this.Habilitado = habilitado;
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
