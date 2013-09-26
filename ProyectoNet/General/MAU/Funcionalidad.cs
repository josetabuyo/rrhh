using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministracionDeUsuarios
{
    public class Funcionalidad
    {
        protected string nombre;
        protected List<Funcionalidad> sub_funcionalidades;
        protected int profundidad_en_el_arbol;

        public Funcionalidad()
        {
        }

        public Funcionalidad(string nombre)
        {
            Inicializar(nombre, 1);
        }

        public Funcionalidad(string nombre, int profundidad_en_el_arbol)
        {
            Inicializar(nombre, profundidad_en_el_arbol);
        }

        private void Inicializar(string nombre, int profundidad_en_el_arbol)
        {
            this.nombre = nombre;
            this.sub_funcionalidades = new List<Funcionalidad>();
            this.profundidad_en_el_arbol = profundidad_en_el_arbol;
        }

        public void AgregarFuncionalidad(Funcionalidad funcionalidad)
        {
            funcionalidad.profundidad_en_el_arbol = this.profundidad_en_el_arbol + 1;
            this.sub_funcionalidades.Add(funcionalidad);
        }

        public override bool Equals(object obj)
        {
            return ((Funcionalidad)obj).nombre.Equals(this.nombre);
        }

        public override int GetHashCode()
        {
            return this.nombre.GetHashCode();
        }

        public List<Permiso> PropagarPermiso(string tipo_de_permiso)
        {
            var tipo = Permiso.CONCEDIDO;
            List<Permiso> permisos = new List<Permiso>();
            this.sub_funcionalidades.ForEach(f => { permisos.Add(new Permiso(tipo, f, f.PropagarPermiso(tipo))); });
            return permisos;
        }

        public override string ToString()
        {
            return this.nombre;
        }

        public int GradoDeEspecificidad()
        {
            return this.profundidad_en_el_arbol;
        }
    }
}
