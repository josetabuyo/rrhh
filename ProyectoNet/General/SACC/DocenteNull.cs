
namespace General
{
    public class DocenteNull:Docente
    {


        public override string Telefono { get { return string.Empty; } set { ;} }
        public override string Mail { get { return string.Empty; } set { ;} }
        public override string Direccion { get { return string.Empty; } set { ;} }
        public override int Id { get { return 0; } set { ;} }
        public override int Dni { get { return 0; } set { ;} }
        public override string Nombre { get { return string.Empty; } set { ;} }
        public override string Apellido { get { return string.Empty; } set { ;} }

        public DocenteNull()
        {

        }

        
    }
}
