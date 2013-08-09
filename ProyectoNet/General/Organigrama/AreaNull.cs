namespace General.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AreaNull : Area
    {
        public AreaNull()
        {
            this.Alias = string.Empty;
            this.Asistentes = new List<Asistente>();
            this.Codigo = string.Empty;
            this.Contacto = new List<ContactoArea>();
            this.Dependencias = new List<Area>();
            this.Direccion = string.Empty;
            this.Fax = string.Empty;
            this.Id = -1;
            this.Mail = string.Empty;
            this.Nombre = string.Empty;
            this.Personas = new List<Persona>();
            this.PresentaDDJJ = false;
            this.Responsables = new List<Persona>();
            this.Telefono = string.Empty;
        }

    }
}
