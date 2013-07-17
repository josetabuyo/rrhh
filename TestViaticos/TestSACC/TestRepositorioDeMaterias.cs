using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioDeMaterias
    {

        private IConexionBD conexionMock;
        [TestInitialize]
        public void SetUp()
        {
            conexionMock = TestObjects.ConexionMockeada();
        }     

          [TestMethod]
          public void deberia_poder_obtener_todas_materias()
            {

                Modalidad modalidad = TestObjects.ModalidadFinesPuro();
                List<Modalidad> modalidades = new List<Modalidad>();
                modalidades.Add(modalidad);
                Expect.AtLeastOnce.On(TestObjects.RepoModalidadesMockeado()).Method("GetModalidades").WithAnyArguments().Will(Return.Value(modalidades));
                

                string source = @"  |Id     |Nombre             |IdModalidad  |idInstancia   |DescripcionInstancia     |idCiclo     |NombreCiclo
                                    |01     |Física             |1            |6	         |Calificación Final       |1           |Primer Ciclo
                                    |02     |Química            |1            |1	         |1° Evaluación            |1           |Primer Ciclo
                                    |03     |Historia           |1            |2	         |2° Evaluación            |1           |Primer Ciclo";
               
                
                IConexionBD conexion = TestObjects.ConexionMockeada();
                var resultado_sp = TablaDeDatos.From(source);

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

                RepositorioDeMaterias repo = new RepositorioDeMaterias(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());

                List<Materia> materias = repo.GetMaterias();

                Assert.AreEqual(3, materias.Count);
                Assert.IsTrue(materias.All( m => m.Modalidad.Equals(modalidad)));
            }

          [TestMethod]
          public void deberia_saber_si_una_materia_esta_asignada_a_un_curso()
          {  
              Curso curso = TestObjects.UnCursoConAlumnos();
              List<Curso> cursos = new List<Curso>();
              cursos.Add(curso);
              Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));

              IConexionBD conexion = TestObjects.ConexionMockeada();
             
              RepositorioDeMaterias repo = new RepositorioDeMaterias(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());

              Assert.IsTrue(repo.MateriaAsignadaACurso(TestObjects.MateriaCens()));
          }
    }
}
