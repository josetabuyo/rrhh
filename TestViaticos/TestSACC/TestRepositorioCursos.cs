using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Repositorios;
using General.Calendario;
using General;
using NDbUnit.Core;
using NDbUnit.Core.SqlClient;
using NMock2;

namespace TestViaticos
{

    [TestClass]
    public class TestRepositorioCursos
    {

        ManagerDeCalendarios managerDeCalendarios;
        CalendarioDeFeriados unCalendarioGlobal = new CalendarioDeFeriados();

        [TestInitialize]
        public void Setup()
        {
            managerDeCalendarios = new ManagerDeCalendarios(unCalendarioGlobal);
        }




          [TestMethod]
          public void deberia_poder_obtener_un_curso_del_repositorio_de_cursos_y_comprobar_que_tiene_matera_docente_horas_catedra_aula_y_alumnos_opcionalmente()
            {
                string source = @"  |id    |IdMateria     |IdDocente          |Fecha                       |HoraCatedra      |idBaja     |IdEspacioFisico   |Documento  |Apellido   |Nombre     |Telefono   |Mail                       |Direccion          |DireccionEdificio  |NumeroEdificio     |idEdificio |NombreEdificio |Aula       |Capacidad  |idCiclo    |NombreCiclo    |IdModalidad    |ModalidadDescripcion   |Desde      |Hasta      |NroDiaSemana   |idCurso    |IdAlumno
                                    |01    |01            |01                 |2012-10-13 21:36:35.077     |1                |0          |01                |31507315   |Cevey      |Belén      |3969-8706  |belen.cevey@gmail.com      |Perón 452          |San Martín         |122                |01         |Perón          |Magna      |20         |01         |Primero        |01             |Fines PURO             |12:00      |13:00      |1              |01         |01
                                    |02    |02            |02                 |2012-10-13 21:36:35.077     |3                |0          |02                |31234567   |Pérez      |Ana        |4577-4536  |ana.perez@gmail.com        |Juan B Justo 151   |9 de Julio         |500                |02         |Sarmiento      |Principal  |30         |02         |Segundo        |02             |CENS                   |10:00      |12:30      |2              |02         |02
                                    |03    |03            |03                 |2012-10-13 21:36:35.077     |4                |0          |03                |31987654   |González   |Carlos     |4504-3565  |carlos.gonzalez@gmail.com  |Av. Nazca 5002     |Florida            |252                |03         |Evita          |PB         |40         |03         |Termero        |03             |Fines                  |15:40      |17:20      |3              |03         |03";              

                Curso curso = new Curso(01, "Historia");
                
                IConexionBD conexion = TestObjects.ConexionMockeada();
                var resultado_sp = TablaDeDatos.From(source);

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));

                RepositorioDeCursos repo = new RepositorioDeCursos(conexion);
                Curso curso_bd = repo.GetCursoById(1);


                Assert.AreEqual(curso_bd.Id, curso.Id);
                Assert.IsNotNull(curso_bd.Materia);
                Assert.IsNotNull(curso_bd.Docente);
                Assert.IsNotNull(curso_bd.HorasCatedra);
                Assert.IsNotNull(curso_bd.EspacioFisico);
                Assert.IsTrue(curso_bd.Alumnos().Count() > 0);
            }

    }
}
