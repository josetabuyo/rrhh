
namespace General
{
    public class EspacioFisicoNull:EspacioFisico
    {

        public override int Id { get { return 0; } set { ;} }
        public override string Aula { get { return string.Empty; } set { ;} }
        public override int Capacidad { get { return 0; } set { ;} }
        public override Edificio Edificio { get { return null; } set { ; } }

        public EspacioFisicoNull()
        {

        }

        
    }
}
