using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class TipoDeDocumentoSICOI
    {
        private int _id;
        private string _descripcion;
     
        private string _sigla;


        public int Id { get { return _id; } set { _id = value; } }
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }


        public string sigla { get { return _sigla; } set { _sigla = value; } }

        public TipoDeDocumentoSICOI()
        {
                
        }

        public TipoDeDocumentoSICOI(int id, string descripcion)
        { 
            this._id = id;
            this._descripcion = descripcion;
        
        }

        public TipoDeDocumentoSICOI(int id, string descripcion, string sigla)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._sigla = sigla;
        }



    }
}
