using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
   public  class Credencial
    {
      public long Id;      
      public int IdTipo;
      public DateTime FechaAlta;
      public string UsuarioAlta;
	  public int IdOrganismo;
      public int IdFoto;
      public int CodigoMagnetico;
      public int IdBaja;
       
      public Credencial() { }


      public Credencial(long id, int idtipo, DateTime fechaAlta, string usuarioAlta, int idorganismo, int idfoto, int codigoMagnetico, int idBaja)
      {
          this.Id = id;
          this.IdTipo = idtipo;
          this.FechaAlta = fechaAlta;
          this.UsuarioAlta = usuarioAlta;
          this.IdOrganismo = idorganismo;
          this.IdFoto = idfoto;
          this.CodigoMagnetico = codigoMagnetico;
          this.IdBaja = idBaja;
      }


    }
}
