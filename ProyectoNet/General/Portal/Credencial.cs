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
      public int CodigoMagnetico;
      public int IdBaja;
       
      public Credencial() { }


      public Credencial(long id, string tipo, DateTime fechaAlta, string usuarioAlta, string organismo, int idfoto, int codigoMagnetico, int idBaja)
      {
          this.Id = id;
          this.Tipo = tipo;
          this.FechaAlta = fechaAlta;
          this.UsuarioAlta = usuarioAlta;
          this.Organismo = organismo;
          this.IdFoto = idfoto;
          this.CodigoMagnetico = codigoMagnetico;
          this.IdBaja = idBaja;
      }


    }
}
