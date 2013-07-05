using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.Repositorios;
using General;
using NMock2;


namespace General
{
    public class TestObjects
    {
        static protected string AREA_DE_MARTA = "Area de Marta";
        static protected string AREA_DE_FABI = "Area de Fabian";
        static protected string AREA_DE_CASTAGNETO = "Area de Castagneto";
        static protected string AREA_DE_CENARD = "Area de CENARD";
        static protected string AREA_UNIDAD_MINISTRO = "Area Unidad Ministro";
        static protected string AREA_DE_FABIB = "Area de Fabian B";
        static public int LICENCIAS = 3;//"Licencias";
        static public TipoDeDocumentoSICOI NOTA = new TipoDeDocumentoSICOI(1, "Nota");
        static public TipoDeDocumentoSICOI EXPEDIENTE = new TipoDeDocumentoSICOI(2, "Expediente");
        static public TipoDeDocumentoSICOI MEMO = new TipoDeDocumentoSICOI(3, "Memo");
        static public List<Area> areas = new List<Area>();

        

        public static Area AreaDeCastagneto()
        {
            return new Area(16, AREA_DE_CASTAGNETO, "010100100000000000000000", true);
        }

        public static Area AreaDeMarta()
        {
            return new Area(54, AREA_DE_MARTA, "010100100000400000000000", true);
        }

        public static Area AreaDeFabi()
        {
            var area = new Area(939, AREA_DE_FABI, "010100100000400200000000", true);
            area.SetAlias(new Alias(1, 939, "fabiiiii"));
            return area;
        }

        public static Area AreaCenard()
        {
            var area = new Area(621, AREA_DE_CENARD, "010100100000400400000000", true);
            area.SetAlias(new Alias(2, 621, "cenard"));
            return area;
        }

       
        public static Estadia EstadiaDeAgusIniciaYTerminaElMismoDia()
        {
            Estadia estadia = new Estadia();

            estadia.Desde = new DateTime(2012, 06, 11, 9, 00, 00);
            estadia.Hasta = new DateTime(2012, 06, 11, 17, 00, 00);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia.Eventuales = 284.15M;
            estadia.CalculadoPorCategoria = 154.32M;
            estadia.AdicionalParaPasajes = 64.5M;
            estadia.Motivo = "Renovacion de Contrato";
            estadia.Provincia = new Provincia { Id = 10, CodigoAFIP = 5 };
            estadia.Provincia.Zona = new Zona(1, "N.O.A");

            return estadia;
        }

        public static Pasaje PasajeDeAgus()
        {
            Pasaje pasaje_de_fer = new Pasaje();

            //pasaje_de_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            pasaje_de_fer.Origen = new Localidad { Id = 4800 };//deberia ser provincia?
            pasaje_de_fer.Destino = new Localidad { Id = 5779 };//deberia ser provincia?
            pasaje_de_fer.Precio = 15.32M;
            pasaje_de_fer.MedioDeTransporte = new MedioDeTransporte(1, "AVion");
            pasaje_de_fer.MedioDePago = new MedioDePago(1, "Efectivo");
            pasaje_de_fer.FechaDeViaje = new DateTime(2012, 06, 11);

            return pasaje_de_fer;
        }

        public static Persona AgustinContratacionNormal()
        {
            Persona agustin = new Persona();
            agustin.Documento = 29753914;
            agustin.Nombre = "Agustin";
            agustin.Apellido = "Calcagno";
            //agustin.ModalidadDeContratacion = new ModalidadDeContratacionNormal();
            agustin.TipoDeViatico = new TipoDeViatico(1, "");

            return agustin;

        }

        public static Persona Alicia()
        {
            Persona alice = new Persona();
            alice.Documento = 5438876;
            alice.Nombre = "Alice";
            alice.Apellido = "K";
            //agustin.ModalidadDeContratacion = new ModalidadDeContratacionNormal();
            //agustin.TipoDeViatico = new TipoDeViatico(1, "");

            return alice;
        }

        public static Persona Belen()
        {
            Persona belen = new Persona();
            belen.Documento = 31507315;
            belen.Nombre = "Belen";
            belen.Apellido = "Cevey";
            belen.Area = new Area(1, "Gestion de las Personas");

            return belen;
        }
        public static Persona Carla()
        {
            Persona carla = new Persona();
            carla.Documento = 31475729;
            carla.Nombre = "Carla";
            carla.Apellido = "Acosta";
            carla.Area = new Area(1, "Gestion de las Personas");

            return carla;
        }
        public static Persona Carazo()
        {
            Persona carazo = new Persona();
            carazo.Documento = 4284003;
            carazo.Nombre = "Carazo";
            carazo.Apellido = "K";

            return carazo;
        }

        public static Persona Martinelli()
        {
            Persona martinelli = new Persona();
            martinelli.Documento = 11489469;
            martinelli.Nombre = "Luis Maria";
            martinelli.Apellido = "Martinelli";

            return martinelli;
        }

        public static Usuario Fabian()
        {
            Usuario fabian = new Usuario();
            fabian.NombreDeUsuario = "UsuDirGral";
            return fabian;
        }

        public static Usuario UsuarioMesaEntrada()
        {
            Usuario usumesa = new Usuario();
            usumesa.NombreDeUsuario = "UsuMesa";
            return usumesa;
        }

        public static Usuario UsuarioCENARD()
        {
            Usuario usucenard = new Usuario();
            usucenard.NombreDeUsuario = "usucenard";
            usucenard.Areas.Add(new Area(621, "Secretaria de Deporte"));
            return usucenard;
        }

        public static Usuario UsuarioSACC()
        {
            Usuario ususacc = new Usuario();
            ususacc.NombreDeUsuario = "ususacc";
            ususacc.Areas.Add(new Area(1, "Unidad Ministro"));
            return ususacc;
        }

        public static ComisionDeServicio ComisionDeAgus1Dia(Persona agus, List<Estadia> estadia_agus, List<Pasaje> pasaje_de_agus, EstadosDeComision estadosDeComision)
        {
            return new ComisionDeServicio(agus, estadia_agus, pasaje_de_agus, estadosDeComision);
        }

        public static ComisionDeServicio ComisionDeBelen()
        {
            var listaEstadias = new List<Estadia>();
            listaEstadias.Add(EstadiaDe1DiaYMedio());
            var listaPasajes = new List<Pasaje>();
            listaPasajes.Add(PasajeDeAgus());
            var estado = EstadosDeComision.Pendiente;
            var comision = new ComisionDeServicio();
            comision.Estadias = listaEstadias;
            comision.Pasajes = listaPasajes;
            comision.Estado = estado;
            comision.Persona = Belen();
            comision.AreaCreadora = AreaDeFabi();
            comision.AreaSuperior = AreaDeFabi();
            return comision;
        }
        public static Estadia EstadiaDe1DiaYMedio()
        {
            Estadia estadia_fer = new Estadia();

            estadia_fer.Desde = new DateTime(2012, 06, 14, 9, 00, 00);
            estadia_fer.Hasta = new DateTime(2012, 06, 15, 9, 00, 00);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia_fer.Eventuales = 284.15M;
            estadia_fer.CalculadoPorCategoria = 154.32M;
            estadia_fer.AdicionalParaPasajes = 64.5M;
            estadia_fer.Motivo = "Renovacion de Contrato";
            estadia_fer.Provincia = new Provincia { Id = 10 };

            return estadia_fer;
        }

        public static Estadia EstadiaDeAgusIniciaUnDiaYTerminaAlDiaSiguiente()
        {
            Estadia estadia = new Estadia();

            estadia.Desde = new DateTime(2012, 06, 11, 9, 00, 00);
            estadia.Hasta = new DateTime(2012, 06, 12, 17, 00, 00);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia.Eventuales = 284.15M;
            estadia.CalculadoPorCategoria = 154.32M;
            estadia.AdicionalParaPasajes = 64.5M;
            estadia.Motivo = "Renovacion de Contrato";
            estadia.Provincia = new Provincia { Id = 10, CodigoAFIP = 5 };
            estadia.Provincia.Zona = new Zona(1, "N.O.A");

            return estadia;
        }

        public static Estadia EstadiaDeAgusIniciaUnDiaYTerminaAlosDosDiasSiguientes()
        {
            Estadia estadia = new Estadia();

            estadia.Desde = new DateTime(2012, 06, 11, 9, 00, 00);
            estadia.Hasta = new DateTime(2012, 06, 13, 17, 00, 00);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia.Eventuales = 284.15M;
            estadia.CalculadoPorCategoria = 154.32M;
            estadia.AdicionalParaPasajes = 64.5M;
            estadia.Motivo = "Renovacion de Contrato";
            estadia.Provincia = new Provincia { Id = 10, CodigoAFIP = 5 };
            estadia.Provincia.Zona = new Zona(1, "N.O.A");

            return estadia;
        }


        public static Estadia EstadiaDeAgusIniciaUnDiaYTerminaAlCuartoDia()
        {
            Estadia estadia = new Estadia();

            estadia.Desde = new DateTime(2012, 06, 11, 13, 00, 00);
            estadia.Hasta = new DateTime(2012, 06, 15, 14, 00, 00);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia.Eventuales = 284.15M;
            estadia.CalculadoPorCategoria = 154.32M;
            estadia.AdicionalParaPasajes = 64.5M;
            estadia.Motivo = "Renovacion de Contrato";
            estadia.Provincia = new Provincia { Id = 10, CodigoAFIP = 5 };
            estadia.Provincia.Zona = new Zona(1, "N.O.A");

            return estadia;
        }

        public static Estadia EstadiaDeAgusIniciaUnDiaYTerminaAlSiguienteDiaDespues12Antes12()
        {
            Estadia estadia = new Estadia();

            estadia.Desde = new DateTime(2012, 06, 11, 12, 00, 01);
            estadia.Hasta = new DateTime(2012, 06, 12, 11, 59, 59);

            //explicar para que sirve cada uno
            //estadia_fer.ComisionDeServicio = comision_fer;//hace falta que se conozcan los dos?
            estadia.Eventuales = 284.15M;
            estadia.CalculadoPorCategoria = 154.32M;
            estadia.AdicionalParaPasajes = 64.5M;
            estadia.Motivo = "Renovacion de Contrato";
            estadia.Provincia = new Provincia { Id = 10, CodigoAFIP = 5 };
            estadia.Provincia.Zona = new Zona(1, "N.O.A");

            return estadia;
        }

        public static List<Area> AreasDeFabiYMarta()
        {
            return new List<Area>() { AreaDeFabi(), AreaDeMarta() };
        }

        public static List<Area> AreasDeFabiYMartaYCenard()
        {
            return new List<Area>() { AreaDeFabi(), AreaDeMarta(), AreaCenard() };
        }

        public static List<Area> DependenciaEntreFabyYMarta()
        {
            return new List<Area>() { AreaDeFabi(), AreaDeMarta() };
        }

        public static List<List<Area>> DependenciasEntreFabyYMarta()
        {
            return new List<List<Area>>() { DependenciaEntreFabyYMarta() };
        }

        public static List<List<Area>> DependenciasEntreFabyMartaYCarlos()
        {
            return new List<List<Area>>() { DependenciaEntreFabyYMarta(), DependenciaEntreMartaYCarlos() };
        }

        public static List<Area> DependenciaEntreMartaYCarlos()
        {
            return new List<Area>() { AreaDeMarta(), AreaDeCastagneto() };
        }

        public static List<Area> AreasDeFabiMartaYCarlos()
        {
            return new List<Area>() { AreaDeFabi(), AreaDeMarta(), AreaDeCastagneto() };
        }

        public static Organigrama OrganigramaFabyMarta()
        {
            return new Organigrama(AreasDeFabiYMarta(), DependenciasEntreFabyYMarta());
        }

        public static Organigrama OrganigramaFabyMartayCenard()
        {
            return new Organigrama(AreasDeFabiYMartaYCenard(), DependenciasEntreFabyYMarta());
        }

        public static IConexionBD ConexionMockeada()
        {
            var mocks = new Mockery();
            var mock_conexion_bd = mocks.NewMock<IConexionBD>();
            return mock_conexion_bd;
        }

        private static IRepositorioDeAlumnos repo_alumnos_mockeados;
 
        public static IRepositorioDeAlumnos RepoAlumnosMockeado()
        {
            if (repo_alumnos_mockeados == null)
            {
            var mocks = new Mockery();
            repo_alumnos_mockeados =  mocks.NewMock<IRepositorioDeAlumnos>();
            }
            return repo_alumnos_mockeados;
        }

        private static IRepositorioDeCursos repo_cursos_mockeados;
       
        public static IRepositorioDeCursos RepoCursosMockeado()
        {
            if (repo_cursos_mockeados == null)
            {
            var mocks = new Mockery();
            repo_cursos_mockeados = mocks.NewMock<IRepositorioDeCursos>();
            }
            return repo_cursos_mockeados;
        }


        private static IRepositorioDeEspaciosFisicos repo_espacios_fisicos_mockeados;

        public static IRepositorioDeEspaciosFisicos RepoEspaciosFisicosMockeado()
        {
            if (repo_espacios_fisicos_mockeados == null)
            {
                var mocks = new Mockery();
                repo_espacios_fisicos_mockeados = mocks.NewMock<IRepositorioDeEspaciosFisicos>();
            }
            return repo_espacios_fisicos_mockeados;
        }


        private static IRepositorioDeDocentes repo_docentes_mockeados;

        public static IRepositorioDeDocentes RepoDocentesMockeado()
        {
            if (repo_docentes_mockeados == null)
            {
                var mocks = new Mockery();
                repo_docentes_mockeados = mocks.NewMock<IRepositorioDeDocentes>();
            }
            return repo_docentes_mockeados;
        }

        private static IRepositorioDeMaterias repo_materias_mockeados;

        public static IRepositorioDeMaterias RepoMateriasMockeado()
        {
            if (repo_materias_mockeados == null)
            {
                var mocks = new Mockery();
                repo_materias_mockeados = mocks.NewMock<IRepositorioDeMaterias>();
            }
            return repo_materias_mockeados;
        }

        private static IRepositorioDeModalidades repo_modalidades_mockeados;

        public static IRepositorioDeModalidades RepoModalidadesMockeado()
        {
            if (repo_modalidades_mockeados == null)
            {
                var mocks = new Mockery();
                repo_modalidades_mockeados = mocks.NewMock<IRepositorioDeModalidades>();
            }
            return repo_modalidades_mockeados;
        }

        private static RepositorioDeComisionesDeServicio UnRepositorioCon(IConexionBD mock_conexion_bd)
        {
            var un_repositorio = new RepositorioDeComisionesDeServicio(mock_conexion_bd);
            return un_repositorio;
        }

        private static GeneradorDeDataTables GeneradorDeTablas()
        {
            return new GeneradorDeDataTables();
        }

        public static TablaDeDatos TablaViaticoConUnaEstadiaUnPasajeYUnaTransicion()
        {
            var tabla_viatico = new TablaDeDatos();
            tabla_viatico.Columns.Add("Id", typeof(int));
            tabla_viatico.Columns.Add("Baja", typeof(bool));
            tabla_viatico.Columns.Add("Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("IdAreaCreadora", typeof(int));
            tabla_viatico.Columns.Add("DescripcionAreaCreadora", typeof(string));
            tabla_viatico.Columns.Add("Persona_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Persona_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Persona_Documento", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Id", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Desde", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Hasta", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Provincia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Provincia_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Eventuales", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_AdicionalParaPasajes", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_CalculadoPorCategoria", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_Motivo", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_FechaDeViaje", typeof(DateTime));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Precio", typeof(Decimal));
            tabla_viatico.Columns.Add("Transicion_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Id_Accion", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("Transicion_Comentario", typeof(string));
            tabla_viatico.Columns.Add("Telefono_Area", typeof(string));
            tabla_viatico.Columns.Add("Cuil_Persona", typeof(string));
            tabla_viatico.Columns.Add("Legajo_Persona", typeof(int));
            tabla_viatico.Columns.Add("Nivel_Funcion", typeof(string));
            tabla_viatico.Columns.Add("Grado_Rango", typeof(string));
            tabla_viatico.Columns.Add("Categoria_Persona", typeof(string));
            tabla_viatico.Columns.Add("Id_Zona", typeof(int));
            tabla_viatico.Columns.Add("Nombre_Zona", typeof(string));

            tabla_viatico.LoadDataRow(new object[] {1,                                      //Id     
                                                    true,                                   //Baja  
                                                    DateTime.Parse("12/07/12"),             //Fecha 
                                                    1,                                      //IdAreaCreadora  
                                                    "Area_Creadora",                        //DescripcionAreaCreadora  
                                                    "pepe",                                 //Persona_Nombre  
                                                    "lopez",                                //Persona_Apellido  
                                                    12345123,                               //Persona_Documento  
                                                    1,                                      //Persona_Area_Id  
                                                    "Area_persona",                         //Persona_Area_Descripcion  
                                                    1,                                      //Estadia_Id  
                                                    DateTime.Parse("12/07/12"),             //Estadia_Desde  
                                                    DateTime.Parse("15/07/12"),             //Estadia_Hasta  
                                                    1,                                      //Estadia_Provincia_Id  
                                                    "Catamarca",                            //Estadia_Provincia_Nombre  
                                                    123.5,                                  //Estadia_Eventuales  
                                                    123.5,                                  //Estadia_AdicionalParaPasajes  
                                                    123.5,                                  //Estadia_CalculadoPorCategoria  
                                                    "un_motivo",                            //Estadia_Motivo  
                                                    1,                                      //Pasaje_Id  
                                                    1,                                      //Pasaje_LocalidadOrigen_Id  
                                                    "Guadalajara",                          //Pasaje_LocalidadOrigen_Nombre  
                                                    2,                                      //Pasaje_LocalidadDestino_Id  
                                                    "pernambuco",                           //Pasaje_LocalidadDestino_Nombre  
                                                    DateTime.Parse("12/07/12"),             //Pasaje_FechaDeViaje  
                                                    1,                                      //Pasaje_MedioDeTransporte_Id  
                                                    "Avion",                                //Pasaje_MedioDeTransporte_Nombre  
                                                    1,                                      //Pasaje_MedioDePago_Id  
                                                    "tarjeta",                              //Pasaje_MedioDePago_Nombre  
                                                    345.5,                                  //Pasaje_Precio  
                                                    1,                                      //Transicion_Id  
                                                    1,                                      //Transicion_AreaOrigen_Id  
                                                    "un_area",                              //Transicion_AreaOrigen_Descripcion  
                                                    "fabian",                               //Transicion_AreaOrigen_Responsable_Nombre  
                                                    "miranda",                              //Transicion_AreaOrigen_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaOrigen_Responsable_Documento  
                                                    2,                                      //Transicion_AreaDestino_Id  
                                                    "otra_area",                            //Transicion_AreaDestino_Descripcion  
                                                    "marta",                                //Transicion_AreaDestino_Responsable_Nombre  
                                                    "novoa",                                //Transicion_AreaDestino_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaDestino_Responsable_Documento 
                                                    1,                                      //Transicion_Id_Accion  
                                                    DateTime.Parse("12/5/12"),              //Transicion_Fecha  
                                                    "un_comentario",                        //Transicion_Comentario
                                                    "1234567",                              //Telefono_Area
                                                    "1234567",                              //Cuil_Persona
                                                    1234567,                                //Legajo_Persona
                                                    "una_funcion",                          //Nivel_Funcion
                                                    "Un_Grado",                             //Grado_Rango
                                                    "Una_Categoria",                        //Categoria_Persona
                                                    1,                                      //Id_Zona
                                                    "una_zona"},                            //Nombre_Zona
                                                    true);
            return tabla_viatico;
        }

        public static TablaDeDatos TablaViaticoSinEstadiasPasajesNiTransiciones()
        {
            var tabla_viatico = new TablaDeDatos();
            tabla_viatico.Columns.Add("Id", typeof(int));
            tabla_viatico.Columns.Add("Baja", typeof(bool));
            tabla_viatico.Columns.Add("Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("IdAreaCreadora", typeof(int));
            tabla_viatico.Columns.Add("DescripcionAreaCreadora", typeof(string));
            tabla_viatico.Columns.Add("Persona_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Persona_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Persona_Documento", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Id", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Desde", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Hasta", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Provincia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Provincia_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Eventuales", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_AdicionalParaPasajes", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_CalculadoPorCategoria", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_Motivo", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_FechaDeViaje", typeof(DateTime));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Precio", typeof(Decimal));
            tabla_viatico.Columns.Add("Transicion_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Id_Accion", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("Transicion_Comentario", typeof(string));
            tabla_viatico.Columns.Add("Telefono_Area", typeof(string));
            tabla_viatico.Columns.Add("Cuil_Persona", typeof(string));
            tabla_viatico.Columns.Add("Legajo_Persona", typeof(int));
            tabla_viatico.Columns.Add("Nivel_Funcion", typeof(string));
            tabla_viatico.Columns.Add("Grado_Rango", typeof(string));
            tabla_viatico.Columns.Add("Categoria_Persona", typeof(string));
            tabla_viatico.Columns.Add("Id_Zona", typeof(int));
            tabla_viatico.Columns.Add("Nombre_Zona", typeof(string));

            tabla_viatico.LoadDataRow(new object[] {1,                                      //Id     
                                                    true,                                   //Baja  
                                                    DateTime.Parse("12/07/12"),             //Fecha 
                                                    1,                                      //IdAreaCreadora  
                                                    "Area_Creadora",                        //DescripcionAreaCreadora  
                                                    "pepe",                                 //Persona_Nombre  
                                                    "lopez",                                //Persona_Apellido  
                                                    12345123,                               //Persona_Documento  
                                                    1,                                      //Persona_Area_Id  
                                                    "Area_persona",                         //Persona_Area_Descripcion  
                                                    null,                                   //Estadia_Id  
                                                    null,                                   //Estadia_Desde  
                                                    null,                                   //Estadia_Hasta  
                                                    null,                                   //Estadia_Provincia_Id  
                                                    null,                                   //Estadia_Provincia_Nombre  
                                                    null,                                   //Estadia_Eventuales  
                                                    null,                                   //Estadia_AdicionalParaPasajes  
                                                    null,                                   //Estadia_CalculadoPorCategoria  
                                                    null,                                   //Estadia_Motivo  
                                                    null,                                   //Pasaje_Id  
                                                    null,                                   //Pasaje_LocalidadOrigen_Id  
                                                    null,                                   //Pasaje_LocalidadOrigen_Nombre  
                                                    null,                                   //Pasaje_LocalidadDestino_Id  
                                                    null,                                   //Pasaje_LocalidadDestino_Nombre  
                                                    null,                                   //Pasaje_FechaDeViaje  
                                                    null,                                   //Pasaje_MedioDeTransporte_Id  
                                                    null,                                   //Pasaje_MedioDeTransporte_Nombre  
                                                    null,                                   //Pasaje_MedioDePago_Id  
                                                    null,                                   //Pasaje_MedioDePago_Nombre  
                                                    null,                                   //Pasaje_Precio  
                                                    null,                                   //Transicion_Id  
                                                    null,                                   //Transicion_AreaOrigen_Id  
                                                    null,                                   //Transicion_AreaOrigen_Descripcion  
                                                    null,                                   //Transicion_AreaOrigen_Responsable_Nombre  
                                                    null,                                   //Transicion_AreaOrigen_Responsable_Apellido  
                                                    null,                                   //Transicion_AreaOrigen_Responsable_Documento  
                                                    null,                                   //Transicion_AreaDestino_Id  
                                                    null,                                   //Transicion_AreaDestino_Descripcion  
                                                    null,                                   //Transicion_AreaDestino_Responsable_Nombre  
                                                    null,                                   //Transicion_AreaDestino_Responsable_Apellido  
                                                    null,                                   //Transicion_AreaDestino_Responsable_Documento 
                                                    null,                                   //Transicion_Id_Accion  
                                                    null,                                   //Transicion_Fecha  
                                                    null,                                   //Transicion_Comentario
                                                    "1234567",                              //Telefono_Area
                                                    "1234567",                              //Cuil_Persona
                                                    1234567,                                //Legajo_Persona
                                                    "una_funcion",                          //Nivel_Funcion
                                                    "Un_Grado",                             //Grado_Rango
                                                    "Una_Categoria",                        //Categoria_Persona
                                                    1,                                      //Id_Zona
                                                    "una_zona"},                            //Nombre_Zona
                                                    true);
            return tabla_viatico;
        }

        public static TablaDeDatos TablaViaticoConDosEstadiasDosPasajesYDosTransiciones()
        {
            var tabla_viatico = new TablaDeDatos();
            tabla_viatico.Columns.Add("Id", typeof(int));
            tabla_viatico.Columns.Add("Baja", typeof(bool));
            tabla_viatico.Columns.Add("Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("IdAreaCreadora", typeof(int));
            tabla_viatico.Columns.Add("DescripcionAreaCreadora", typeof(string));
            tabla_viatico.Columns.Add("Persona_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Persona_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Persona_Documento", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Id", typeof(int));
            tabla_viatico.Columns.Add("Persona_Area_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Desde", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Hasta", typeof(DateTime));
            tabla_viatico.Columns.Add("Estadia_Provincia_Id", typeof(int));
            tabla_viatico.Columns.Add("Estadia_Provincia_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Estadia_Eventuales", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_AdicionalParaPasajes", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_CalculadoPorCategoria", typeof(Decimal));
            tabla_viatico.Columns.Add("Estadia_Motivo", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadOrigen_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_LocalidadDestino_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_FechaDeViaje", typeof(DateTime));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDeTransporte_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Id", typeof(int));
            tabla_viatico.Columns.Add("Pasaje_MedioDePago_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Pasaje_Precio", typeof(Decimal));
            tabla_viatico.Columns.Add("Transicion_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaOrigen_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Id", typeof(int));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Descripcion", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Nombre", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Apellido", typeof(string));
            tabla_viatico.Columns.Add("Transicion_AreaDestino_Responsable_Documento", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Id_Accion", typeof(int));
            tabla_viatico.Columns.Add("Transicion_Fecha", typeof(DateTime));
            tabla_viatico.Columns.Add("Transicion_Comentario", typeof(string));
            tabla_viatico.Columns.Add("Telefono_Area", typeof(string));
            tabla_viatico.Columns.Add("Cuil_Persona", typeof(string));
            tabla_viatico.Columns.Add("Legajo_Persona", typeof(int));
            tabla_viatico.Columns.Add("Nivel_Funcion", typeof(string));
            tabla_viatico.Columns.Add("Grado_Rango", typeof(string));
            tabla_viatico.Columns.Add("Categoria_Persona", typeof(string));
            tabla_viatico.Columns.Add("Id_Zona", typeof(int));
            tabla_viatico.Columns.Add("Nombre_Zona", typeof(string));

            tabla_viatico.LoadDataRow(new object[] {1,                                      //Id     
                                                    true,                                   //Baja  
                                                    DateTime.Parse("12/07/12"),             //Fecha 
                                                    1,                                      //IdAreaCreadora  
                                                    "Area_Creadora",                        //DescripcionAreaCreadora  
                                                    "pepe",                                 //Persona_Nombre  
                                                    "lopez",                                //Persona_Apellido  
                                                    12345123,                               //Persona_Documento  
                                                    1,                                      //Persona_Area_Id  
                                                    "Area_persona",                         //Persona_Area_Descripcion  
                                                    1,                                      //Estadia_Id  
                                                    DateTime.Parse("12/07/12"),             //Estadia_Desde  
                                                    DateTime.Parse("15/07/12"),             //Estadia_Hasta  
                                                    1,                                      //Estadia_Provincia_Id  
                                                    "Catamarca",                            //Estadia_Provincia_Nombre  
                                                    123.5,                                  //Estadia_Eventuales  
                                                    123.5,                                  //Estadia_AdicionalParaPasajes  
                                                    123.5,                                  //Estadia_CalculadoPorCategoria  
                                                    "un_motivo",                            //Estadia_Motivo  
                                                    1,                                      //Pasaje_Id  
                                                    1,                                      //Pasaje_LocalidadOrigen_Id  
                                                    "Guadalajara",                          //Pasaje_LocalidadOrigen_Nombre  
                                                    2,                                      //Pasaje_LocalidadDestino_Id  
                                                    "pernambuco",                           //Pasaje_LocalidadDestino_Nombre  
                                                    DateTime.Parse("12/07/12"),             //Pasaje_FechaDeViaje  
                                                    1,                                      //Pasaje_MedioDeTransporte_Id  
                                                    "Avion",                                //Pasaje_MedioDeTransporte_Nombre  
                                                    1,                                      //Pasaje_MedioDePago_Id  
                                                    "tarjeta",                              //Pasaje_MedioDePago_Nombre  
                                                    345.5,                                  //Pasaje_Precio  
                                                    1,                                      //Transicion_Id  
                                                    1,                                      //Transicion_AreaOrigen_Id  
                                                    "un_area",                              //Transicion_AreaOrigen_Descripcion  
                                                    "fabian",                               //Transicion_AreaOrigen_Responsable_Nombre  
                                                    "miranda",                              //Transicion_AreaOrigen_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaOrigen_Responsable_Documento  
                                                    2,                                      //Transicion_AreaDestino_Id  
                                                    "otra_area",                            //Transicion_AreaDestino_Descripcion  
                                                    "marta",                                //Transicion_AreaDestino_Responsable_Nombre  
                                                    "novoa",                                //Transicion_AreaDestino_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaDestino_Responsable_Documento 
                                                    1,                                      //Transicion_Id_Accion  
                                                    DateTime.Parse("12/5/12"),              //Transicion_Fecha  
                                                    "un_comentario",                        //Transicion_Comentario
                                                    "1234567",                              //Telefono_Area
                                                    "1234567",                              //Cuil_Persona
                                                    1234567,                                //Legajo_Persona
                                                    "una_funcion",                          //Nivel_Funcion
                                                    "Un_Grado",                             //Grado_Rango
                                                    "Una_Categoria",                        //Categoria_Persona
                                                    1,                                      //Id_Zona
                                                    "una_zona"},                            //Nombre_Zona
                                                    true);

            tabla_viatico.LoadDataRow(new object[] {1,                                      //Id     
                                                    true,                                   //Baja 
                                                    DateTime.Parse("12/07/12"),             //Fecha 
                                                    1,                                      //IdAreaCreadora  
                                                    "Area_Creadora",                        //DescripcionAreaCreadora  
                                                    "pepe",                                 //Persona_Nombre  
                                                    "lopez",                                //Persona_Apellido  
                                                    12345123,                               //Persona_Documento  
                                                    1,                                      //Persona_Area_Id  
                                                    "Area_persona",                         //Persona_Area_Descripcion  
                                                    2,                                      //Estadia_Id  
                                                    DateTime.Parse("12/07/12"),             //Estadia_Desde  
                                                    DateTime.Parse("15/07/12"),             //Estadia_Hasta  
                                                    1,                                      //Estadia_Provincia_Id  
                                                    "Catamarca",                            //Estadia_Provincia_Nombre  
                                                    123.5,                                  //Estadia_Eventuales  
                                                    123.5,                                  //Estadia_AdicionalParaPasajes  
                                                    123.5,                                  //Estadia_CalculadoPorCategoria  
                                                    "un_motivo",                            //Estadia_Motivo  
                                                    2,                                      //Pasaje_Id  
                                                    1,                                      //Pasaje_LocalidadOrigen_Id  
                                                    "Guadalajara",                          //Pasaje_LocalidadOrigen_Nombre  
                                                    2,                                      //Pasaje_LocalidadDestino_Id  
                                                    "pernambuco",                           //Pasaje_LocalidadDestino_Nombre  
                                                    DateTime.Parse("12/07/12"),             //Pasaje_FechaDeViaje  
                                                    1,                                      //Pasaje_MedioDeTransporte_Id  
                                                    "Avion",                                //Pasaje_MedioDeTransporte_Nombre  
                                                    1,                                      //Pasaje_MedioDePago_Id  
                                                    "tarjeta",                              //Pasaje_MedioDePago_Nombre  
                                                    345.5,                                  //Pasaje_Precio  
                                                    2,                                      //Transicion_Id  
                                                    1,                                      //Transicion_AreaOrigen_Id  
                                                    "un_area",                              //Transicion_AreaOrigen_Descripcion  
                                                    "fabian",                               //Transicion_AreaOrigen_Responsable_Nombre  
                                                    "miranda",                              //Transicion_AreaOrigen_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaOrigen_Responsable_Documento  
                                                    2,                                      //Transicion_AreaDestino_Id  
                                                    "otra_area",                            //Transicion_AreaDestino_Descripcion  
                                                    "marta",                                //Transicion_AreaDestino_Responsable_Nombre  
                                                    "novoa",                                //Transicion_AreaDestino_Responsable_Apellido  
                                                    1234567,                                //Transicion_AreaDestino_Responsable_Documento 
                                                    1,                                      //Transicion_Id_Accion  
                                                    DateTime.Parse("12/5/12"),              //Transicion_Fecha  
                                                    "un_comentario",                        //Transicion_Comentario
                                                    "1234567",                              //Telefono_Area
                                                    "1234567",                              //Cuil_Persona
                                                    1234567,                                //Legajo_Persona
                                                    "una_funcion",                          //Nivel_Funcion
                                                    "Un_Grado",                             //Grado_Rango
                                                    "Una_Categoria",                        //Categoria_Persona
                                                    1,                                      //Id_Zona
                                                    "una_zona"},                            //Nombre_Zona
                                                    true);
            return tabla_viatico;
        }

        public static List<ComisionDeServicio> Comisiones()
        {
            Estadia estadia1 = new Estadia();
            estadia1.Desde = new DateTime(2012, 10, 22);
            estadia1.Hasta = new DateTime(2012, 10, 23);
            estadia1.Provincia = Cordoba();
            estadia1.Eventuales = 150;
            Estadia estadia1Bis = new Estadia();
            estadia1Bis.Desde = new DateTime(2012, 10, 10);
            estadia1Bis.Hasta = new DateTime(2012, 10, 15);
            estadia1Bis.Provincia = Cordoba();
            estadia1Bis.Eventuales = 150;
            Estadia estadia1Bis2 = new Estadia();
            estadia1Bis2.Desde = new DateTime(2012, 10, 10);
            estadia1Bis2.Hasta = new DateTime(2012, 10, 15);
            estadia1Bis2.Provincia = Salta();
            estadia1Bis2.Eventuales = 150;
            Estadia estadia2 = new Estadia();
            estadia2.Desde = new DateTime(2012, 11, 12);
            estadia2.Hasta = new DateTime(2012, 11, 12);
            estadia2.Provincia = Cordoba();
            estadia2.Eventuales = 150;
            Estadia estadia3 = new Estadia();
            estadia3.Desde = new DateTime(2012, 11, 17);
            estadia3.Hasta = new DateTime(2012, 11, 19);
            estadia3.Provincia = Tucuman();
            estadia3.Eventuales = 150;
            Estadia estadia4 = new Estadia();
            estadia4.Desde = new DateTime(2012, 10, 12);
            estadia4.Hasta = new DateTime(2012, 10, 16);
            estadia4.Provincia = Salta();
            estadia4.Eventuales = 150;
            Estadia estadia5 = new Estadia();
            estadia5.Desde = new DateTime(2012, 11, 16);
            estadia5.Hasta = new DateTime(2012, 11, 16);
            estadia5.Provincia = Salta();

            Persona belen = Belen();
            Persona carla = Carla();

            ComisionDeServicio comision1 = new ComisionDeServicio();
            ComisionDeServicio comision2 = new ComisionDeServicio();
            ComisionDeServicio comision3 = new ComisionDeServicio();
            ComisionDeServicio comision4 = new ComisionDeServicio();
            ComisionDeServicio comision5 = new ComisionDeServicio();
            comision1.AreaCreadora = AreaDeFabi();
            comision1.Estado = EstadosDeComision.Pendiente;
            comision1.Estadias.Add(estadia1);
            comision1.Estadias.Add(estadia1Bis);
            comision1.Estadias.Add(estadia1Bis2);
            comision1.Persona = carla;
            comision2.AreaCreadora = AreaDeFabi();
            comision2.Estado = EstadosDeComision.Aprobada;
            comision2.Estadias.Add(estadia2);
            comision2.Estadias.Add(estadia3);
            comision2.Persona = carla;
            comision3.AreaCreadora = AreaDeMarta();
            comision3.Estado = EstadosDeComision.Pendiente;
            comision3.Estadias.Add(estadia3);
            comision3.Persona = belen;
            comision4.AreaCreadora = AreaDeCastagneto();
            comision4.Estado = EstadosDeComision.Pendiente;
            comision4.Estadias.Add(estadia4);
            comision4.Estadias.Add(estadia3);
            comision4.Persona = belen;
            comision5.AreaCreadora = AreaDeCastagneto();
            comision5.Estado = EstadosDeComision.Pendiente;
            comision5.Estadias.Add(estadia5);

            comision5.Persona = belen;

            return new List<ComisionDeServicio>() { comision1, comision2, comision3, comision4, comision5 };
        }

        private static void Stub(object objeto, string atributo, object valor)
        {
            Expect.AtLeastOnce.On(objeto).Method(atributo).WithAnyArguments().Will(Return.Value(valor));
        }

        public static Provincia Salta()
        {
            return new Provincia(9, "SALTA");
        }

        public static Provincia Cordoba()
        {
            return new Provincia(3, "CORDOBA");
        }

        public static Provincia Tucuman()
        {
            return new Provincia(14, "TUCUMAN");
        }

        public static List<Area> AreasCompletas()
        {

            Responsable responsable_fabianMiranda = new Responsable("Fabián", "Miranda", "4567-2222", "4544-3322", "fabian.miranda@ministerio.gov.ar");
            Responsable responsable_martaNovoa = new Responsable("Marta", "Novoa", "4567-1111", "4544-1111", "marta.novoa@ministerio.gov.ar");
            Responsable responsable_mirandaGarcia = new Responsable("Miranda", "García", "4567-1111", "4544-1111", "miranda.garcia@ministerio.gov.ar");

            Asistente asistente_juanGarcia = new Asistente("Juan", "García", "Secretaria", 1, "4444-5555", "4444-1111", "juan.garcia@mds.gov.ar");
            Asistente asistente_marianaJuan = new Asistente("Mariana", "Juan", "Secretaria", 1, "4444-5555", "4444-1111", "mariana.juan@ministerio.gov.ar");
            Asistente asistente_AnaGonzalez = new Asistente("Ana", "González", "Secretaria", 1, "4444-1111", "4444-1111", "ana.gonzalez@ministerio.gov.ar");


            Asistente asistente_mariaPerez = new Asistente("María", "Pérez", "Secretaria", 1, "4444-5555", "4444-1111", "maria.perez@ministerio.gov.ar");
            Asistente asistente_anaPaz = new Asistente("Ana", "Paz", "Secretaria", 1, "4444-5555", "4444-1111", "ana.paz@ministerio.gov.ar");
            Asistente asistente_pabloRodriguez = new Asistente("Pablo", "Rodríguez", "Asesor", 1, "4444-1111", "4444-1111", "pablo.rodriguez@ministerio.gov.ar");
            Asistente asistente_diegoMartinez = new Asistente("Diego", "Martínez", "Asesor", 1, "4444-1111", "4444-1111", "diego.martinez@ministerio.gov.ar");

            List<Area> areas = new List<Area>();
            Area area1 = new Area(1, "RRHH", responsable_fabianMiranda);
            Area area2 = new Area(2, "Dirección", responsable_martaNovoa);
            Area area3 = new Area(3, "Viáticos", responsable_mirandaGarcia);

            List<Asistente> lista_de_asistentes_area1 = new List<Asistente>();
            List<Asistente> lista_de_asistentes_area2 = new List<Asistente>();
            List<Asistente> lista_de_asistentes_area3 = new List<Asistente>();

            area1.Telefono = "4333-1111";
            area2.Telefono = "4333-2222";
            area3.Telefono = "4333-3333";

            area1.Mail = "area1@ministerio.gob.ar";
            area2.Mail = "area2@ministerio.gob.ar";
            area3.Mail = "area3@mds.gob.ar";

            area1.Fax = "4888-1111";
            area2.Fax = "4999-2222";
            area3.Fax = "4999-3333";

            area1.Direccion = "9 de Julio 1925";
            area2.Direccion = "17 de Agosto 1850";
            area3.Direccion = "25 de Mayo 1810";

            lista_de_asistentes_area1.Add(asistente_juanGarcia);
            lista_de_asistentes_area1.Add(asistente_AnaGonzalez);
            lista_de_asistentes_area1.Add(asistente_marianaJuan);

            lista_de_asistentes_area2.Add(asistente_mariaPerez);
            lista_de_asistentes_area2.Add(asistente_anaPaz);
            lista_de_asistentes_area2.Add(asistente_pabloRodriguez);

            lista_de_asistentes_area3.Add(asistente_diegoMartinez);

            area1.Asistentes = lista_de_asistentes_area1;
            area2.Asistentes = lista_de_asistentes_area2;
            area3.Asistentes = lista_de_asistentes_area3;

            areas.Add(area1);
            areas.Add(area2);
            areas.Add(area3);

            return areas;
        }


        public static TablaDeDatos TablaDeAliasConDosAlias()
        {

            string source2 = @" |Id     	|Id_Area        |Alias          |
                                |1	        |3              |area de fabi   |
                                |2	        |4              |area de marta  |";


            return TablaDeDatos.From(source2);

        }

        public static List<Documento> DocumentosCompletos()
        {
            
            TipoDeDocumentoSICOI tipo_documento = NOTA;
            TipoDeDocumentoSICOI tipo_documento_exp = EXPEDIENTE;
            TipoDeDocumentoSICOI tipo_documento_memo = MEMO;
            CategoriaDeDocumentoSICOI categoria_licencia = new CategoriaDeDocumentoSICOI(3, "Licencia");
            CategoriaDeDocumentoSICOI categoria_renuncia = new CategoriaDeDocumentoSICOI(2, "Renuncia");
            CategoriaDeDocumentoSICOI categoria_nombramiento = new CategoriaDeDocumentoSICOI(1, "Nombramiento");
            CategoriaDeDocumentoSICOI categoria_documento = new CategoriaDeDocumentoSICOI(02, "Baja");
            Documento documento1 = new Documento(tipo_documento, "01", categoria_documento, AreaDeFabi(), "Extracto", "Comentario Urgente");
            List<Documento> documentos = new List<Documento>();
            documento1.fecha = DateTime.Parse("12/12/12");
            documento1.ticket = "AAA021";

            Documento documento_uno = new Documento(tipo_documento_exp, "1-12", categoria_nombramiento, new Area(1, "RRHH"), "Primer Documento creado a los fines de probar el filtro", "Urgente");
            Documento documento_dos = new Documento(tipo_documento_exp, "2-12", categoria_renuncia, new Area(2, "Secretaría de Deportes"), "Segundo Documento creado a los fines de probar el filtro", "Rápido");
            Documento documento_tres = new Documento(tipo_documento_memo, "1-12", categoria_licencia, new Area(3, "Subsecretaría de abordaje territorial"), "Tercer Documento creado a los fines de probar el filtro",  "Muy Urgente");
            Documento documento_cuatro = new Documento(tipo_documento_memo, "3-11", categoria_licencia, new Area(1, "RRHH"), "Cuarto Documento creado a los fines de probar el filtro", "Normal");
            documento_uno.fecha = DateTime.Parse("12/01/13");
            documento_dos.fecha = DateTime.Parse("12/01/12");
            documento_tres.fecha = DateTime.Parse("15/01/13");
            documento_uno.numero = "123456";
            documento_dos.numero = "456";
            documento_tres.numero = "123";
            documento_uno.ticket = "AAB321";
            documento_dos.ticket = "CCB452";
            documento_tres.ticket = "CAB999";
            documento_cuatro.ticket = "AAB199";
            
            return new List<Documento> { documento1, documento_uno, documento_dos, documento_tres, documento_cuatro };
            
        }

        private static Mensajeria _mensajeria;
        public static Mensajeria Mensajeria()
        {
            if (_mensajeria != null) return _mensajeria;
            var transicion = new TransicionDeDocumento(AreaDeCastagneto(), AreaDeFabi(), DateTime.Now.AddDays(-2), UnaNota(), "T");
            var transiciones = new List<TransicionDeDocumento>();
            transiciones.Add(transicion);
            _mensajeria = new Mensajeria(transiciones);
            return _mensajeria;
        }

        public static Documento UnaNota()
        {
            return new Documento(3, new TipoDeDocumentoSICOI(1, "nota"), "001", new CategoriaDeDocumentoSICOI(1, "despido"), AreaDeFabi(), "extracto blah");
        }

        public static Documento OtraNota()
        {
            return new Documento(4, new TipoDeDocumentoSICOI(1, "nota"), "001", new CategoriaDeDocumentoSICOI(1, "contratacion"), AreaDeFabi(), "extracto bleh");
        }

        public static Curso UnCursoConAlumnos()
        {
            Curso un_curso = new Curso(1, "Historia");
            un_curso.AgregarAlumno(new Alumno(1, "Fer", "Caino", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(2, "Jor", "Castle", 28753951, "", "", "",  areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(3, "Ger", "Caino", 28753951, "", "", "",  areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(4, "Zambri", "Zambri", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(5, "Javi", "Lurgo", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            Materia una_materia = MateriaCens();

            un_curso.AgregarDiaDeCursada(DayOfWeek.Tuesday);
            un_curso.AgregarDiaDeCursada(DayOfWeek.Wednesday);
            un_curso.Materia = una_materia;

            return un_curso;
        }

        public static Curso UnCursoConAlumnosYMateriaPura()
        {
            Curso un_curso = new Curso(1, "Historia");
            un_curso.AgregarAlumno(new Alumno(1, "Fer", "Caino", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(2, "Jor", "Castle", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(3, "Ger", "Caino", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(4, "Zambri", "Zambri", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            un_curso.AgregarAlumno(new Alumno(5, "Javi", "Lurgo", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro")));
            Materia una_materia = MateriaPuro();

            un_curso.AgregarDiaDeCursada(DayOfWeek.Tuesday);
            un_curso.AgregarDiaDeCursada(DayOfWeek.Wednesday);
            un_curso.Materia = una_materia;

            return un_curso;
        }

        public static Materia MateriaCens()
        { 
            List<InstanciaDeEvaluacion> instancias = new List<InstanciaDeEvaluacion>() {PrimerParcial(), SegundoParcial() };
            Modalidad modalidad_cens = new Modalidad(1, "Cens", instancias);

            return new Materia(1, "Historia CENS", modalidad_cens);
        }

        public static Materia MateriaPuro()
        {
            List<InstanciaDeEvaluacion> instancias = new List<InstanciaDeEvaluacion>() { CalificacionFinal() };
            Modalidad modalidad_cens = new Modalidad(1, "Puro", instancias);

            return new Materia(1, "Geografia Puro", modalidad_cens);
        }



        public static List<Curso> UnListadoDeCursoConEdificios()
        {
            List<Curso> cursos = new List<Curso>();
            EspacioFisico espacio_fisico1 = new EspacioFisico();
            EspacioFisico espacio_fisico2 = new EspacioFisico();
            EspacioFisico espacio_fisico3 = new EspacioFisico();
            
            Edificio julio_de_9 = new Edificio(1,"9 de Julio","9 de julio",new Area(54,"Area de Marta"));
            Edificio moreno = new Edificio(2,"Moreno","moreno",new Area(939,"Secretaria de Coordinacion y Monitoreo"));
            Edificio cenard = new Edificio(3,"Cenard","Libertador",new Area(621,"Secretaria de Deporte"));
            
            Curso curso_uno = new Curso(1, "Historia");
            curso_uno.EspacioFisico = espacio_fisico1;
            curso_uno.EspacioFisico.Edificio = julio_de_9;
            cursos.Add(curso_uno);
            Curso curso_dos = new Curso(2, "Quimica");
            curso_dos.EspacioFisico = espacio_fisico2;
            curso_dos.EspacioFisico.Edificio = moreno;
            cursos.Add(curso_dos);
            Curso curso_tres = new Curso(3, "Filosofia");
            curso_tres.EspacioFisico = espacio_fisico3;
            curso_tres.EspacioFisico.Edificio = cenard;
            cursos.Add(curso_tres);

            return cursos;
        }

        public static List<EspacioFisico> EspaciosFisicos()
        {
            List<EspacioFisico> listado_espacios = new List<EspacioFisico>();
            
            EspacioFisico espacio_fisico1 = new EspacioFisico();
            EspacioFisico espacio_fisico2 = new EspacioFisico();
            EspacioFisico espacio_fisico3 = new EspacioFisico();

            Edificio julio_de_9 = new Edificio(1, "9 de Julio", "9 de julio", new Area(54, "Area de Marta"));
            Edificio moreno = new Edificio(2, "Moreno", "moreno", new Area(939, "Secretaria de Coordinacion y Monitoreo"));
            Edificio cenard = new Edificio(3, "Cenard", "Libertador", new Area(621, "Secretaria de Deporte"));

            espacio_fisico1.Edificio = julio_de_9;
            espacio_fisico2.Edificio = moreno;
            espacio_fisico3.Edificio = cenard;
            
            listado_espacios.Add(espacio_fisico1);
            listado_espacios.Add(espacio_fisico2);
            listado_espacios.Add(espacio_fisico3);

            return listado_espacios;
        }

        public static Alumno UnAlumnoDelCurso()
        {
            return new Alumno(1, "Fer", "Caino", 28753951, "", "", "", areas, new Modalidad(1, "Fines Puro"));    
        }

        public static Alumno UnAlumnoNuevo()
        {
            return new Alumno(100, "Andrea", "Bruzos", 13500315, "3969-8706", "belen.cevey@gmail.com", "Peron 525", areas, new Modalidad(1, "Fines Puro"));
        }

        public static List<Alumno> AlumnosNuevos()
        {
            List<Alumno> lista = new List<Alumno>() {
                                                    new Alumno(9, "Ana", "Ran", 28000951, "", "", "", new List<Area>(){new Area(1, AREA_UNIDAD_MINISTRO), new Area(621, AREA_DE_CENARD)}, new Modalidad(1, "Fines Puro")),
                                                    new Alumno(8, "Carla", "Ren", 33700051, "", "", "", new List<Area>(){new Area(939, AREA_DE_FABI)}, new Modalidad(1, "Fines Puro")),
                                                    new Alumno(7, "Nadia", "Rey", 11700051, "", "", "", new List<Area>(){new Area(621, AREA_DE_CENARD)}, new Modalidad(1, "Fines Puro"))
                                                    };
            return lista;
        }

        public static Alumno AlumnoMinisterio()
        {
            return new Alumno(9, "Ana", "Ran", 28000951, "", "", "", new List<Area>() { new Area(1, "Ministerio") }, new Modalidad(1, "Fines Puro"));
        }


        public static InstanciaDeEvaluacion PrimerParcial()
        {
            return new InstanciaDeEvaluacion(1, "Primer Parcial");
        }


        internal static InstanciaDeEvaluacion SegundoParcial()
        {
            return new InstanciaDeEvaluacion(2, "Segundo Parcial");
        }

        internal static InstanciaDeEvaluacion CalificacionFinal()
        {
            return new InstanciaDeEvaluacion(3, "Calificacion Final");
        }

        internal static InstanciaDeEvaluacion FinalNulo()
        {
            return new InstanciaDeEvaluacion(1, "Final");
        }

        public static Organigrama OrganigramaConDosRamas()
        {
            Area area_de_faby;
            Area area_de_marta;
            Area area_de_castagneto;
            Area unidad_ministro;
            Area area_de_fabyB;
            List<Area> dependencia_faby_marta;
            List<Area> dependencia_carlos_unidad_ministro;
            List<Area> dependencia_marta_unidad_ministro;
            List<Area> dependencia_FabyB_Carlos;
            List<Area> areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB;
            List<List<Area>> lista_de_dependencias_faby_marta_carlos_y_um_fabyb;
            Organigrama organigrama_fabi_marta_castagneto_um_fabyB;

            area_de_marta = AreaDeMarta();//id 54
            area_de_faby = AreaDeFabi();//id 939
            area_de_castagneto = AreaDeCastagneto(); //id 16
            unidad_ministro = new Area(1, AREA_UNIDAD_MINISTRO, "1", true);
            area_de_fabyB = new Area(621, AREA_DE_CENARD, "939B", true);

            dependencia_faby_marta =DependenciaEntreFabyYMarta();
            dependencia_carlos_unidad_ministro = new List<Area>() { area_de_castagneto, unidad_ministro };
            dependencia_FabyB_Carlos = new List<Area>() { area_de_fabyB, area_de_castagneto };
            dependencia_marta_unidad_ministro = new List<Area>() { area_de_marta, unidad_ministro };

            areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB = new List<Area>() { area_de_faby, area_de_marta, area_de_castagneto, unidad_ministro, area_de_fabyB };
            lista_de_dependencias_faby_marta_carlos_y_um_fabyb = new List<List<Area>>() { dependencia_faby_marta, dependencia_carlos_unidad_ministro, dependencia_FabyB_Carlos, dependencia_marta_unidad_ministro };

            return new Organigrama(areas_de_faby_y_marta_y_carlos_unidad_ministro_y_fabyB, lista_de_dependencias_faby_marta_carlos_y_um_fabyb);
        }

        internal static Docente Docente()
        {
            return new Docente();
        }

        internal static Modalidad unaModalidad()
        {
            return new Modalidad(1, "Fines");
        }

        internal static General.Docente unDocente()
        {
            return new Docente(1, 31507315, "Belen", "Cevey");
        }
    }
}
