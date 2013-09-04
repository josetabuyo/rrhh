namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using General;

    public class AreaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
    }
}
