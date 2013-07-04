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
    public class TestRepositorioEvaluaciones
    {

        private IConexionBD conexionMock;
        private IRepositorioDeAlumnos mock_repoalumnos;
        private IRepositorioDeCursos mock_repocursos;
        [TestInitialize]
        public void SetUp()
        {
           conexionMock = TestObjects.ConexionMockeada();
           mock_repoalumnos = TestObjects.RepoAlumnosMockeado();
           mock_repocursos = TestObjects.RepoCursosMockeado();
        }

        [TestMethod]
        public void deberia_poder_obtener_todas_las_evaluaciones()
        {

            Alumno alumno = TestObjects.AlumnoMinisterio();
            Curso curso = TestObjects.UnCursoConAlumnos();
            Expect.AtLeastOnce.On(mock_repoalumnos).Method("GetAlumnoByDNI").WithAnyArguments().Will(Return.Value(alumno));
            Expect.AtLeastOnce.On(mock_repocursos).Method("GetCursoById").WithAnyArguments().Will(Return.Value(curso));
        


            string source = @"  |idAlumno |IdCurso |idInstanciaEvaluacion |DescripcionInstanciaEvaluacion   |Calificacion |fechaEvaluacion         |idUsuario |fecha                      
                                |287872   |14      |01                    |Primer Parcial                   |A1           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |287872   |14      |02                    |Segundo Parcial                  |A2           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |03                    |Recuperatorio Primer Parcial     |A5           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |04                    |Recuperatorio Segundo Parcial    |A6           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    
                                |284165   |14      |05                    |Examen Final                     |A8           |2012-10-13 21:36:35.077 |0         |2012-10-13 21:36:35.077    ";

            IConexionBD conexion = TestObjects.ConexionMockeada();
            var resultado_sp = TablaDeDatos.From(source);

            Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

            RepositorioDeEvaluacion repo = new RepositorioDeEvaluacion(conexion, mock_repoalumnos, mock_repocursos);

            Assert.AreEqual(5, repo.GetEvaluaciones().Count);
        }
           
    }
}
