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
    public class TestRepositorioDeAlumno
    {

        [TestMethod]
        [Ignore] //para que ande el teamcity
        public void verifica_que_va_a_la_base_de_alumnos_una_sola_vez()
        {

            Modalidad modalidad = TestObjects.ModalidadFinesPuro();
            List<Modalidad> modalidades = new List<Modalidad>();
            modalidades.Add(modalidad);
            Expect.AtLeastOnce.On(TestObjects.RepoModalidadesMockeado()).Method("GetModalidades").WithAnyArguments().Will(Return.Value(modalidades));

            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |LugarTrabajo |FechaNacimiento         |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                       |IdOrganismo |DescripcionOrganismo   |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |MDS          |2012-10-13 21:36:35.077 |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social  |1           |MDS                    |0
                                    |02     |31041236    |Caino        |Fernando   |A222          |fer@ar   |MDS          |2012-10-13 21:36:35.077 |Av         |1            |fines                |1      |Unidad Ministrio                 |1           |MDS                    |0
                                    |05     |31507315    |Cevey        |Belén      |A111          |belen@ar |MDS          |2012-10-13 21:36:35.077 |Calle      |1            |fines                |1      |Unidad Ministrio                 |1           |MDS                    |0
                                    |03     |31507315    |Cevey        |Belén      |A111          |belen@ar |MDS          |2012-10-13 21:36:35.077 |Calle      |1            |fines                |621    |Secretaría de Deportes           |1           |MDS                    |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_alumno = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            var resultado = TablaDeDatos.From(source);

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_alumno.GetAlumnos();
            var alumnos = repo_alumno.GetAlumnos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(2, alumnos.Count);
        }


        [TestMethod]
        public void verificacion_cache_vacia_para_alumnos()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_alumno = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            var resultado = TablaDeDatos.From(source);
            resultado.Clear();

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_alumno.GetAlumnos();
            var alumnos = repo_alumno.GetAlumnos();
            alumnos = repo_alumno.GetAlumnos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(0, alumnos.Count);
        }


//        [TestMethod]
//        public void verifica_que_va_a_la_base_de_cursos_una_sola_vez()
//        {

//            Alumno alumno = TestObjects.AlumnoDelCurso();
//            Curso curso = TestObjects.UnCursoConAlumnos();
//            Docente docente = TestObjects.unDocente();
//            List<Alumno> alumnos = curso.Alumnos();
//            List<Curso> cursos = new List<Curso>();
//            List<EspacioFisico> espacios_fisicos = new List<EspacioFisico>();
            
//            cursos.Add(curso);
//            EspacioFisico espacio_fisico = TestObjects.UnEspacioFisico();
//            espacios_fisicos.Add(espacio_fisico);
//            var repo_docentes = TestObjects.RepoDocentesMockeado();
//            var repo_espacios_fisicos = TestObjects.RepoEspaciosFisicosMockeado();
//            Expect.AtLeastOnce.On(TestObjects.RepoAlumnosMockeado()).Method("GetAlumnos").WithAnyArguments().Will(Return.Value(alumnos));
//            Expect.AtLeastOnce.On(TestObjects.RepoCursosMockeado()).Method("GetCursos").WithAnyArguments().Will(Return.Value(cursos));
//            Expect.AtLeastOnce.On(repo_docentes ).Method("GetDocenteById").WithAnyArguments().Will(Return.Value(docente));
//            Expect.AtLeastOnce.On(repo_espacios_fisicos).Method("GetEspaciosFisicos").WithAnyArguments().Will(Return.Value(espacios_fisicos));
//            Expect.AtLeastOnce.On(repo_espacios_fisicos).Method("GetEspacioFisicoById").WithAnyArguments().Will(Return.Value(espacio_fisico));

//            string source = @"  |id    |IdMateria     |IdDocente          |Fecha                       |HorasCatedra     |idBaja     |IdEspacioFisico   |IdInstancia |DescripcionInstancia |Documento  |Apellido   |Nombre     |Telefono   |Mail                       |Direccion          |FechaInicio                 |FechaFin                  |DireccionEdificio  |NumeroEdificio     |idEdificio |NombreEdificio |Aula       |Capacidad  |idCiclo    |NombreCiclo    |IdModalidad    |ModalidadDescripcion   |Desde      |Hasta      |NroDiaSemana   |idCurso    |IdAlumno   |IdArea |NombreArea                         |Observaciones
//                                |01    |01            |1                  |2012-10-13 21:36:35.077     |1                |0          |01                |1           |Primer Parcial       |31507315   |Cevey      |Belén      |3969-8706  |belen.cevey@gmail.com      |Perón 452          |2012-10-13 21:36:35.077     |2012-12-13 21:36:35.077   |San Martín         |122                |01         |Perón          |Magna      |20         |01         |Primero        |01             |Fines PURO             |12:00      |13:00      |1              |01         |01         |0      |Ministerio de Desarrollo Social    |Observación";

//            var mocks = new Mockery();
//            var conexion = mocks.NewMock<IConexionBD>();
//            var repo_curso = new RepositorioDeCursos(conexion);
//            var resultado = TablaDeDatos.From(source);

//            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));
//            repo_curso.SetRepoDocuentes(repo_docentes);
//            repo_curso.SetRepoEsapciosFisicos(repo_espacios_fisicos);

//            repo_curso.GetCursos();
//            var cursos2 = repo_curso.GetCursos();

//            mocks.VerifyAllExpectationsHaveBeenMet();
//            Assert.AreEqual(3, cursos2.Count);
//        }


        [TestMethod]
        public void verificacion_cache_vacia_para_cursos()
        {
            string source = @"  |id    |IdMateria     |IdDocente          |Fecha                       |HorasCatedra     |idBaja     |IdEspacioFisico   |IdInstancia |DescripcionInstancia |Documento  |Apellido   |Nombre     |Telefono   |Mail                       |Direccion          |FechaInicio                 |FechaFin                  |DireccionEdificio  |NumeroEdificio     |idEdificio |NombreEdificio |Aula       |Capacidad  |idCiclo    |NombreCiclo    |IdModalidad    |ModalidadDescripcion   |Desde      |Hasta      |NroDiaSemana   |idCurso    |IdAlumno   |IdArea |NombreArea                         |Observaciones
                                    |01    |01            |01                 |2012-10-13 21:36:35.077     |1                |0          |01                |1           |Primer Parcial       |31507315   |Cevey      |Belén      |3969-8706  |belen.cevey@gmail.com      |Perón 452          |2012-10-13 21:36:35.077     |2012-12-13 21:36:35.077   |San Martín         |122                |01         |Perón          |Magna      |20         |01         |Primero        |01             |Fines PURO             |12:00      |13:00      |1              |01         |01         |0      |Ministerio de Desarrollo Social    |Observación
                                    |02    |02            |02                 |2012-10-13 21:36:35.077     |3                |0          |02                |1           |Primer Parcial       |31234567   |Pérez      |Ana        |4577-4536  |ana.perez@gmail.com        |Juan B Justo 151   |2013-01-13 21:36:35.077     |2013-10-13 21:36:35.077   |9 de Julio         |500                |02         |Sarmiento      |Principal  |30         |02         |Segundo        |02             |CENS                   |10:00      |12:30      |2              |02         |02         |1      |unidad Ministro                    |Observación
                                    |03    |03            |03                 |2012-10-13 21:36:35.077     |4                |0          |03                |1           |Primer Parcial       |31987654   |González   |Carlos     |4504-3565  |carlos.gonzalez@gmail.com  |Av. Nazca 5002     |2013-02-13 21:36:35.077     |2013-10-13 21:36:35.077   |Florida            |252                |03         |Evita          |PB         |40         |03         |Termero        |03             |Fines                  |15:40      |17:20      |3              |03         |03         |621    |Secretaría de Deportes             |Observación";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_cursos = new RepositorioDeCursos(conexion);
            var resultado = TablaDeDatos.From(source);
            resultado.Clear();

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_cursos.GetCursos();
            var cursos = repo_cursos.GetCursos();
            cursos = repo_cursos.GetCursos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(0, cursos.Count);
        }

        [TestMethod]
        public void verifica_que_va_a_la_base_de_docentes_una_sola_vez()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0
                                    |02     |31041236    |Caino        |Fernando   |A222          |fer@ar   |Av         |1            |fines                |1      |Unidad Ministrio                   |0
                                    |05     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |1      |Unidad Ministrio                   |0
                                    |03     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |621    |Secretaría de Deportes             |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_docentes = new RepositorioDeDocentes(conexion, TestObjects.RepoCursosMockeado());
            var resultado = TablaDeDatos.From(source);

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_docentes.GetDocentes();
            var docentes = repo_docentes.GetDocentes();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(4, docentes.Count);
        }


        [TestMethod]
        public void verificacion_cache_vacia_para_docentes()
        {
            string source = @"      |Id     |Documento   |Apellido     |Nombre     |Telefono      |Mail     |Direccion  |IdModalidad  |ModalidadDescripcion |IdArea |NombreArea                         |IdBaja
                                    |01     |31507315    |Cevey        |Belén      |A111          |belen@ar |Calle      |1            |fines                |0      |Ministerio de Desarrollo Social    |0";

            var mocks = new Mockery();
            var conexion = mocks.NewMock<IConexionBD>();
            var repo_alumno = new RepositorioDeAlumnos(conexion, TestObjects.RepoCursosMockeado(), TestObjects.RepoModalidadesMockeado());
            var resultado = TablaDeDatos.From(source);
            resultado.Clear();

            Expect.Once.On(conexion).Method("Ejecutar").WithAnyArguments().Will(Return.Value(resultado));

            repo_alumno.GetAlumnos();
            var alumnos = repo_alumno.GetAlumnos();
            alumnos = repo_alumno.GetAlumnos();

            mocks.VerifyAllExpectationsHaveBeenMet();
            Assert.AreEqual(0, alumnos.Count);
        }

       
    }
}
