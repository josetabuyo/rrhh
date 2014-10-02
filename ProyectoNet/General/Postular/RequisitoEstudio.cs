using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace TestViaticos
{
    public class RequisitoEstudio: RequisitoPerfil
    {
        protected NivelDeEstudio nivel_de_estudio;
        protected string descripcion_requisito;
        protected NivelDeEstudio nivelDeEstudio;

        public RequisitoEstudio(NivelDeEstudio nivelDeEstudio)
        {
            this.nivel_de_estudio = nivelDeEstudio;
        }

        public RequisitoEstudio(string descripcion_requisito, NivelDeEstudio nivelDeEstudio)
        {
            this.descripcion_requisito = descripcion_requisito;
            this.nivelDeEstudio = nivelDeEstudio;
        }
    }
}
