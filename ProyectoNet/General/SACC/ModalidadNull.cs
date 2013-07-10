using System.Collections.Generic;

namespace General
{
    public class ModalidadNull: Modalidad
    {
        
        public override int Id { get { return 0; } set { ;} }
        public override string Descripcion { get { return string.Empty; } set { ;} }
        public override List<InstanciaDeEvaluacion> InstanciasDeEvaluacion { get { return new List<InstanciaDeEvaluacion>(); } set { ;} }

        public ModalidadNull()
        {
        }
    }
}
