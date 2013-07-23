using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace General.Repositorios
{
    public class RepositorioDeModalidades : RepositorioLazy<List<Modalidad>>, General.Repositorios.IRepositorioDeModalidades
    {

        public IConexionBD conexion_bd { get; set; }
        List<Modalidad> modalidades = new List<Modalidad>();

       

        public RepositorioDeModalidades(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            this.cache = new CacheNoCargada<List<Modalidad>>();
        }

        public List<Modalidad> GetModalidades()
        {
            return cache.Ejecutar(ObtenerModalidadesDesdeLaBase, this);
        }

        public List<Modalidad> ObtenerModalidadesDesdeLaBase()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_GetModalidades");


            var campos_del_corte = new List<string>() { "IdModalidad", "IdInstancia" };

            return GetModalidadesFrom(tablaDatos.Rows, campos_del_corte);
        }

        protected List<Modalidad> GetModalidadesFrom(List<RowDeDatos> tabla, List<string> columnas)
        {

            var ids_modalidad = (from RowDeDatos dRow in tabla select dRow.GetInt(columnas.First())).Distinct().ToList();

            var modalidades = new List<Modalidad>();

            ids_modalidad.ForEach(id_modalidad => modalidades.Add(new Modalidad(id_modalidad, "", InstanciasFrom(id_modalidad, tabla.FindAll(row => row.GetInt(columnas.First()) == id_modalidad), columnas))));

            return modalidades;
        }

        protected List<InstanciaDeEvaluacion> InstanciasFrom(int id_modalidad, List<RowDeDatos> rows, List<string> columnas)
        {
            var ids_instancia = (from RowDeDatos dRow in rows select dRow.GetInt(columnas.First())).Distinct().ToList();

            var instancias = new List<InstanciaDeEvaluacion>();

            ids_instancia.ForEach(id_instancia => instancias.Add(new InstanciaDeEvaluacion(id_instancia, "")));

            return instancias;
        }

        public Modalidad GetModalidadById(int idModalidad)
        {
            return GetModalidades().Find(m => m.Id == idModalidad);
        }

        public ModalidadNull ModalidadNull() 
        {
            return new ModalidadNull();
        }

    }
}
