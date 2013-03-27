﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeEspaciosFisicos
    {
        private IConexionBD conexion_bd { get; set; }
        public static List<EspacioFisico> espacios_fisicos { get; set; }
        
        public RepositorioDeEspaciosFisicos(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        //public Materia GetMateriaById(int id)
        //{
        //    return GetMaterias().Find(m => m.Id.Equals(id));
        //}

        //public Materia GetMateriaByNombre(string nombre)
        //{
        //    return GetMaterias().Find(m => m.Nombre.Equals(nombre));
        //}

        //public List<Materia> GetMaterias()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Materias");
        //    materias = new List<Materia>();

        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));                
        //        Modalidad modeliadad_aux = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"));
                
        //        Materia materia = new Materia
        //        {
        //            Id = row.GetSmallintAsInt("Id"),
        //            Nombre = row.GetString("Nombre"),
        //            Modalidad = modeliadad_aux,
        //            Ciclo = ciclo
        //        };

        //        materias.Add(materia);
        //    });

        //    materias.Sort((materia1, materia2) => materia1.esMayorAlfabeticamenteQue(materia2));
        //    return materias;
        //}

        //public Materia GuardarMaterias(Materia materia, Usuario usuario)
        //{
        //    var parametros = Parametros(materia, usuario, 0);

        //    conexion_bd.EjecutarSinResultado("SACC_Ins_Materia", parametros);

        //    return materia;
        //}

        //public Materia ActualizarMaterias(Materia materia, Usuario usuario)
        //{
        //    var parametros = Parametros(materia, usuario, 0);

        //    conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);

        //    return materia;
        //}

        //public void QuitarMateria(Materia materia, Usuario usuario)
        //{           
        //    var idBaja = CrearBaja(usuario);

        //    var parametros = Parametros(materia, usuario, idBaja);

        //    conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Materia", parametros);
        //}

        //private int CrearBaja(Usuario usuario)
        //{
        //    var parametros = new Dictionary<string, object>();

        //    parametros.Add("@Motivo", ""); 
        //    parametros.Add("@IdUsuario", usuario.Id);
        //    parametros.Add("@Fecha", "");

        //    int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

        //    return id;
        //}


        //public bool MateriaAsignadaACurso(Materia una_materia)
        //{
        //    List<Curso> cursos = new RepositorioDeCursos(conexion_bd).GetCursos();
        //    return cursos.Exists(c => c.Materia.Id == una_materia.Id);
        //}

        //private static Dictionary<string, object> Parametros(Materia materia, Usuario usuario,int id_baja)
        //{
        //    var parametros = new Dictionary<string, object>();
        //    if (materia.Id != 0)
        //        parametros.Add("@IdMateria", materia.Id);
            
        //    parametros.Add("@Nombre", materia.Nombre);
        //    parametros.Add("@IdModalidad", materia.Modalidad.Id);
        //    parametros.Add("@Ciclo", materia.Ciclo.Id);
        //    parametros.Add("@IdUsuario", usuario.Id);
        //    parametros.Add("@Fecha", "");
        //    if (id_baja != 0)            
        //        parametros.Add("@IdBaja", id_baja); 
            
        //    return parametros;
        //}

        //public List<Ciclo> GetCiclos()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Ciclos");
        //    List<Ciclo> ciclos = new List<Ciclo>();

        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        Ciclo ciclo = new Ciclo(row.GetSmallintAsInt("idCiclo"), row.GetString("NombreCiclo"));

        //        ciclos.Add(ciclo);
        //    });

        //    return ciclos;
        //}


        public EspacioFisico GuardarEspaciosFisicos(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var parametros = Parametros(espacio_fisico, usuario, 0);

            conexion_bd.EjecutarSinResultado("SACC_Ins_EspacioFisico", parametros);

            return espacio_fisico;
        }

        public void ActualizarEspacioFisico(EspacioFisico espacio_fisico, Usuario usuario)
        {
            var espacios_fisicos = GetEspaciosFisicos();
            if (espacios_fisicos.Exists(e => e.Aula == espacio_fisico.Aula && e.Edificio.Id == espacio_fisico.Edificio.Id))
            {
                espacio_fisico.Id = espacios_fisicos.Find(e => e.Aula == espacio_fisico.Aula && e.Edificio.Id == espacio_fisico.Edificio.Id).Id;
                this.ModificarEspacioFisico(espacio_fisico, usuario);
            }else
            {
                this.GuardarEspaciosFisicos(espacio_fisico, usuario);
            }
        }

        public List<Edificio> GetEdificios()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_Get_Edificios");
            List<Edificio> edificios = new List<Edificio>();

            tablaDatos.Rows.ForEach(row =>
            {

                Edificio edificio = new Edificio
                {

                    Id = row.GetSmallintAsInt("id"),
                    Nombre = row.GetString("Nombre"),
                    Direccion = row.GetString("Calle")
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
                Edificio edificio_aux = new Edificio(row.GetSmallintAsInt("idEdificio"), row.GetString("NombreEdificio"), row.GetString("DireccionEdificio"));
                EspacioFisico espacio_fisico = new EspacioFisico
                {
                    Id = row.GetSmallintAsInt("id"),
                    Aula = row.GetString("Aula"),
                    Edificio = edificio_aux,
                    Capacidad = row.GetSmallintAsInt("Capacidad")
                };

                espacios_fisicos.Add(espacio_fisico);
            });
            
            espacios_fisicos.Sort((espacio_fisico1, espacio_fisico2) => espacio_fisico1.esMayorAlfabeticamenteQue(espacio_fisico2));
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
            List<Curso> cursos = new RepositorioDeCursos(conexion_bd).GetCursos();
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

        internal EspacioFisico GetEspacioFisicoById(int id)
        {
           //if(id == 0)
           //{
           //    return new EspacioFisicoNull();
           //}else
           //{
               return GetEspaciosFisicos().Find(e => e.Id.Equals(id));
           //}
        }
    }
}
