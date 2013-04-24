using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestViaticos.TestSACC
{
    [TestClass]
    class TestRepositorioEvaluaciones
    {
        private string source;
        public void setup()
        {
            /*
                [idAlumno]
			   ,[idCurso]
			   ,[idInstanciaEvaluacion]
			   ,[Calificacion]
			   ,[fechaEvaluacion]
			   ,[idUsuario]
			   ,[fecha]
			   ,[idBaja]
             */
            source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |Calificacion |fechaEvaluacion         |idUsuario |fecha   |idBaja
                         |287872   |14      |01                    |1            |2012-10-13 21:36:35.077 |0         |null    |null
                         |287872   |14      |01                    |2            |2012-10-13 21:36:35.077 |0         |null    |null
                         |284165   |14      |01                    |5            |2012-10-13 21:36:35.077 |0         |null    |null
                         |284165   |14      |01                    |6            |2012-10-13 21:36:35.077 |0         |null    |null
                         |284165   |14      |01                    |8            |2012-10-13 21:36:35.077 |0         |null    |null";
        }
    }
}
