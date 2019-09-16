using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Csv
{
    public class CSV
    {

        public int id { get; set; }
        //public DateTime fechaConformidadUsuario { get; set; }
        public string csv { get; set; }
        public int tipo_doc_electronico { get; set; }
        public int id_doc { get; set; }
               
        public CSV()
        {
        }
        public CSV(int id, string csv, int tipo_doc_electronico, int id_doc)
        {
            this.id = id;
            this.csv = csv;
            this.tipo_doc_electronico = tipo_doc_electronico;
            this.id_doc = id_doc;

        }

    }
}
