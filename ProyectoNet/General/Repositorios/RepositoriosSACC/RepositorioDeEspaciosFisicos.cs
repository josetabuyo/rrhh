using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeEspaciosFisicos : General.Repositorios.IRepositorioDeEspaciosFisicos
    {
        protected IConexionBD conexion_bd { get; set; }
        protected static List<EspacioFisico> espacios_fisicos { get; set; }
        protected IRepositorioDeCursos repo_cursos;

        public RepositorioDeEspaciosFisicos(IConexionBD conexion, IRepositorioDeCursos repo_cursos)
        {
            this.conexion_bd = conexion;
            this.repo_cursos = repo_cursos;
        }

        public EspacioFisico GetEspacioFisicoById(int id)
        {
            return GetEspaciosFisicos().Find(e => e.Id == id);
        }

        public EspacioFisico GuardarEspaciosFisicos(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var parametros = Parametros(espacio_fisico, usuario, 0);

            conexion_bd.EjecutarSinResultado("SACC_Ins_EspacioFisico", parametros);

            return espacio_fisico;
        }

        public void ActualizarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var espacios_fisicos = GetEspaciosFisicos();
            if (
                espacios_fisicos.Exists(
                    e => e.Aula == espacio_fisico.Aula && e.Edificio.Id == espacio_fisico.Edificio.Id))
            {
                espacio_fisico.Id =
                    espacios_fisicos.Find(
                        e => e.Aula == espacio_fisico.Aula && e.Edificio.Id == espacio_fisico.Edificio.Id).Id;
                this.ModificarEspacioFisico(espacio_fisico, usuario);
            }
            else
            {
                this.GuardarEspaciosFisicos(espacio_fisico, usuario);
            }
        }

        public List<Edificio> GetEdificios()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Edificios");
            List<Edificio> edificios = new List<Edificio>();
            string numero = "";
            string dto = "";

            tablaDatos.Rows.ForEach(row =>
                                        {
                                            if (!row.GetString("Departamento").Equals(""))
                                            {
                                                numero = "Dto: " + row.GetString("Departamento");
                                            }
                                            else 
                                            {
                                                numero = "";
                                            }
                                            if (!row.GetString("Piso").Equals(""))
                                            {
                                                dto = "Piso: " + row.GetString("Piso");
                                            }
                                            else
                                            {
                                                dto = "";
                                            }
                                            Area Area = new Area(row.GetSmallintAsInt("IdArea"), row.GetString("NombreArea"));
                                            Edificio edificio = new Edificio
                                                                    {

                                                                        Id = row.GetSmallintAsInt("id"),
                                                                        Nombre = row.GetString("Nombre"),
                                                                        Direccion =
                                                                            row.GetString("Calle") + " " +
                                                                            row.GetSmallintAsInt("Numero") + " " + dto +
                                                                            " " + numero,
                                                                        Area = Area
                                                                    };
                                            
                                            edificios.Add(edificio);
                                        });

            edificios.Sort((edificio1, edificio2) => edificio1.esMayorAlfabeticamenteQue(edificio2));

            return edificios;
        }

        public List<EspacioFisico> GetEspaciosFisicos()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Espacios_Fisicos");
            espacios_fisicos = new List<EspacioFisico>();

            tablaDatos.Rows.ForEach(row =>
                                        {
                                            string direccion = row.GetString("DireccionEdificio") + " " + row.GetSmallintAsInt("NumeroEdificio");
                                            Area Area = new Area(row.GetSmallintAsInt("IdArea"), row.GetString("NombreArea"));
                                            Edificio edificio_aux = new Edificio(row.GetSmallintAsInt("idEdificio"),
                                                                                 row.GetString("NombreEdificio"),
                                                                                 direccion,
                                                                                 Area);
                                            EspacioFisico espacio_fisico = new EspacioFisico
                                                                               {
                                                                                   Id = row.GetSmallintAsInt("id"),
                                                                                   Aula = row.GetString("Aula"),
                                                                                   Edificio = edificio_aux,
                                                                                   Capacidad =
                                                                                       row.GetSmallintAsInt("Capacidad")
                                                                               };

                                            espacios_fisicos.Add(espacio_fisico);
                                        });

            espacios_fisicos.Sort(
                (espacio_fisico1, espacio_fisico2) => espacio_fisico1.esMayorAlfabeticamenteQue(espacio_fisico2));
            return espacios_fisicos;

        }

        public EspacioFisico ModificarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var parametros = Parametros(espacio_fisico, usuario, 0);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_EspacioFisico", parametros);

            return espacio_fisico;
        }

        public void QuitarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var idBaja = CrearBaja(usuario);

            var parametros = Parametros(espacio_fisico, usuario, idBaja);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_EspacioFisico", parametros);
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }


        public bool EspacioFisicoAsignadoACurso(EspacioFisico un_espacio_fisico)
        {
            List<Curso> cursos = repo_cursos.GetCursos();
            // aca pincha porque el espacio físico es null
            return cursos.Exists(c => c.EspacioFisico.Id == un_espacio_fisico.Id);

        }

        private static Dictionary<string, object> Parametros(EspacioFisico espacio_fisico, Usuario usuario, int id_baja)
        {
            var parametros = new Dictionary<string, object>();
            if (espacio_fisico.Id != 0)
                parametros.Add("@IdEspacioFisico", espacio_fisico.Id);

            parametros.Add("@Aula", espacio_fisico.Aula);
            parametros.Add("@IdEdificio", espacio_fisico.Edificio.Id);
            parametros.Add("@Capacidad", espacio_fisico.Capacidad);
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");
            if (id_baja != 0)
                parametros.Add("@IdBaja", id_baja);

            return parametros;
        }

    }
}