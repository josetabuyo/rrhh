namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class ContactoArea
    {
        public int Id_Area { get; set; }
    }


    public class ContactoPersonalizado : ContactoArea
    {
        public List<Asistente> Asistentes { get; set; }

    }


    public class ContactoNoPersonalizado : ContactoArea
    {
        public string Nombre_Area { get; set; }
        public string Responsable { get; set; }
        public string Direccion { get; set; }
        public String Telefono { get; set; }
        public String Fax { get; set; }
        public String Mail { get; set; }
    }

}
