using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public  class Credencial
    {
      public long Id;
      public string Tipo;
      public DateTime FechaAlta;
      public string UsuarioAlta;
      public string Organismo;
      public int IdFoto;
      public string CodigoMagnetico { get; set; }
      public string Estado;
      public bool Impresa;

      public Credencial() { }


      public Credencial(long id, string tipo, DateTime fechaAlta, string usuarioAlta, string organismo, int idfoto, string codigoMagnetico, string estado)
      {
          this.Id = id;
          this.Tipo = tipo;
          this.FechaAlta = fechaAlta;
          this.UsuarioAlta = usuarioAlta;
          this.Organismo = organismo;
          this.IdFoto = idfoto;
          this.CodigoMagnetico = codigoMagnetico;       

          this.Estado = estado;
      }



    }
}
