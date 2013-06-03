using System.Linq;
using General;
using General.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using General.Calendario;
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
          public void deberia_poder_obtener_un_curso_del_repositorio_de_cursos_y_comprobar_que_tiene_materia_docente_horas_catedra_aula_y_alumnos_opcionalmente()
            {
                string source = @"  |id    |IdMateria     |IdDocente          |Fecha                       |HorasCatedra     |idBaja     |IdEspacioFisico   |Documento  |Apellido   |Nombre     |Telefono   |Mail                       |Direccion          |FechaInicio                 |FechaFin                  |DireccionEdificio  |NumeroEdificio     |idEdificio |NombreEdificio |Aula       |Capacidad  |idCiclo    |NombreCiclo    |IdModalidad    |ModalidadDescripcion   |Desde      |Hasta      |NroDiaSemana   |idCurso    |IdAlumno   |IdArea |NombreArea
                                    |01    |01            |01                 |2012-10-13 21:36:35.077     |1                |0          |01                |31507315   |Cevey      |Belén      |3969-8706  |belen.cevey@gmail.com      |Perón 452          |2012-10-13 21:36:35.077     |2012-12-13 21:36:35.077   |San Martín         |122                |01         |Perón          |Magna      |20         |01         |Primero        |01             |Fines PURO             |12:00      |13:00      |1              |01         |01         |0      |Ministerio de Desarrollo Social 
                                    |02    |02            |02                 |2012-10-13 21:36:35.077     |3                |0          |02                |31234567   |Pérez      |Ana        |4577-4536  |ana.perez@gmail.com        |Juan B Justo 151   |2013-01-13 21:36:35.077     |2013-10-13 21:36:35.077   |9 de Julio         |500                |02         |Sarmiento      |Principal  |30         |02         |Segundo        |02             |CENS                   |10:00      |12:30      |2              |02         |02         |1      |unidad Ministro
                                    |03    |03            |03                 |2012-10-13 21:36:35.077     |4                |0          |03                |31987654   |González   |Carlos     |4504-3565  |carlos.gonzalez@gmail.com  |Av. Nazca 5002     |2013-02-13 21:36:35.077     |2013-10-13 21:36:35.077   |Florida            |252                |03         |Evita          |PB         |40         |03         |Termero        |03             |Fines                  |15:40      |17:20      |3              |03         |03         |621    |Secretaría de Deportes";              

                Curso curso = new Curso(01, "Historia");
                
                IConexionBD conexion = TestObjects.ConexionMockeada();
                var resultado_sp = TablaDeDatos.From(source);

                Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));
                
                RepositorioDeCursos repo = new RepositorioDeCursos(conexion);
                Curso curso_bd = repo.GetCursoById(1);


                Assert.AreEqual(curso_bd.Id, curso.Id);
                Assert.IsNotNull(curso_bd.Materia);
                Assert.IsNotNull(curso_bd.Docente);
                Assert.IsNotNull(curso_bd.EspacioFisico);
                Assert.IsTrue(curso_bd.Alumnos().Count() > 0);
            }


          [TestMethod]
          public void deberia_poder_traer_los_cursos_segun_el_area_responsable_del_usuario_logeado()
          {
              string source_cursos = @"  |id    |IdMateria     |IdDocente          |Fecha                       |HorasCatedra     |idBaja     |IdEspacioFisico   |Documento  |Apellido   |Nombre     |Telefono   |Mail                       |Direccion          |FechaInicio                 |FechaFin                  |DireccionEdificio  |NumeroEdificio     |idEdificio |NombreEdificio |Aula       |Capacidad  |idCiclo    |NombreCiclo    |IdModalidad    |ModalidadDescripcion   |Desde      |Hasta      |NroDiaSemana   |idCurso    |IdAlumno   |IdArea |NombreArea
                                    |01    |01            |01                 |2012-10-13 21:36:35.077     |1                |0          |01                |31507315   |Cevey      |Belén      |3969-8706  |belen.cevey@gmail.com      |Perón 452          |2012-10-13 21:36:35.077     |2012-12-13 21:36:35.077   |San Martín         |122                |01         |Perón          |Magna      |20         |01         |Primero        |01             |Fines PURO             |12:00      |13:00      |1              |01         |01         |0      |Ministerio de Desarrollo Social 
                                    |02    |02            |02                 |2012-10-13 21:36:35.077     |3                |0          |02                |31234567   |Pérez      |Ana        |4577-4536  |ana.perez@gmail.com        |Juan B Justo 151   |2013-01-13 21:36:35.077     |2013-10-13 21:36:35.077   |9 de Julio         |500                |02         |Sarmiento      |Principal  |30         |02         |Segundo        |02             |CENS                   |10:00      |12:30      |2              |02         |02         |1      |unidad Ministro
                                    |03    |03            |03                 |2012-10-13 21:36:35.077     |4                |0          |03                |31987654   |González   |Carlos     |4504-3565  |carlos.gonzalez@gmail.com  |Av. Nazca 5002     |2013-02-13 21:36:35.077     |2013-10-13 21:36:35.077   |Florida            |252                |03         |Evita          |PB         |40         |03         |Termero        |03             |Fines                  |15:40      |17:20      |3              |03         |03         |621    |Secretaría de Deportes";   

              string source_edificios = @"   |id    |Aula     |idEdificio         |NombreEdificio        |DireccionEdificio      |NumeroEdificio     |Capacidad     |IdArea    |NombreArea
                                             |01    |01       |01                 |Moreno                |Moreno                 |123                |0              |1021     |1021                 
                                             |02    |02       |02                 |9 de Julio            |9 de Julio             |456                |0              |1021     |1021                 
                                             |03    |03       |03                 |Cenard                |Libertador             |789                |0              |621      |621              ";

              string source_organigrama = @" |codigo        |Id_Area    |Descripcion                        |Baja   |Presenta_DDJJ
                                             |01000000000	|0	        |Ministerio de Desarrollo Social	|0	    |1
                                             |01010011024	|1024	    |Dirección de Diseño y Desarrollo   |0	    |1
                                             |01010100621	|621	    |Secretaría de Deporte	            |0	    |1";
              
              //Curso curso = new Curso((01, "Historia");

              Usuario usu_cenard = TestObjects.UsuarioCENARD();
              IConexionBD conexion = TestObjects.ConexionMockeada();
              RepositorioDeCursos repo = new RepositorioDeCursos(conexion);
              RepositorioDeOrganigrama repo_organigrama = new RepositorioDeOrganigrama(conexion);
             
              var resultado_sp = TablaDeDatos.From(source_cursos);

              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp));
              List<Curso> cursos = repo.GetCursos();

              var resultado_sp_org = TablaDeDatos.From(source_organigrama);
              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp_org));

              var resultado_sp_edif = TablaDeDatos.From(source_edificios);
              Expect.AtLeastOnce.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado_sp_edif));
              //List<Curso> curso_filtrado = repo.FiltrarCursosPorUsuario(cursos, usu_cenard);

              Assert.AreEqual(1, repo.FiltrarCursosPorUsuario(cursos, usu_cenard).Count());

             // List<Curso> cursos_cenard = repo.FiltrarCursosPorUsuario(cursos, usu_cenard);

          }

    }
}
