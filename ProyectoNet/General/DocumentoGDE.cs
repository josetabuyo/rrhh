using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General
{
   public class DocumentoGDE
    {

       public string numero;
       public int idDocumentoGDE;
       public bool verificado;
       public Usuario usuario;

        public DocumentoGDE()
        {

        }

        public DocumentoGDE(int id, string numero, bool verificado)
        {
            this.idDocumentoGDE = id;
            this.numero = numero;
            this.verificado = verificado;
        }

    }
}
