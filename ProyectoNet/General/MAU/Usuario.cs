using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using General;
using System.Security.Cryptography;

namespace AdministracionDeUsuarios
{
    public class Usuario : Persona
    {
        private string _Alias;
        public string Alias
        {
            get { return _Alias; }
            set { _Alias = value;  }
        }

        protected string clave_encriptada { get; set; }

        //public List<Area> AreasAdministradas { get; set; }
        public Usuario()
        {
            //this.AreasAdministradas = new List<Area>();
            //this.TienePermisosParaViaticos = false;
            //this.TienePermisosParaSiCoI = false;
            //this.TienePermisosParaSACC = false;
            ////this.TienePermisosParaModil = false;
            //this.FeaturesDescripcion = new List<string>();
        }

        public Usuario(int id, string alias, string clave_encriptada)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
        }

        public bool EsFirmante { get; set; }
             
        //public List<int> FuncionalidadesPermitidas { get; set; }

        //public bool TienePermisosParaSACC { get; set; }
        //public bool TienePermisosParaSiCoI { get; set; }
        //public bool TienePermisosParaModil { get; set; }
        //public bool TienePermisosParaViaticos { get; set; }

        //public List<string> FeaturesDescripcion { get; set; }


        public virtual bool ValidarClave(string clave)
        {
            return this.clave_encriptada == this.EncriptarSHA1(clave);
        }

        private string EncriptarSHA1(string CadenaOriginal)
        {
            HashAlgorithm hashValue = new SHA1CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
            hashValue.Clear();
            return (Convert.ToBase64String(byteHash));
        }        
    }
}
