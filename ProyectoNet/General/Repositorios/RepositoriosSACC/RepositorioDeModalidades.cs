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

            var campos_del_corte = new List<string>() { "IdModalidad", "idInstancia" };

            return GetModalidadesFrom(tablaDatos.Rows, campos_del_corte);
        }

        protected List<Modalidad> GetModalidadesFrom(List<RowDeDatos> tabla, List<string> columnas)
        {
            var modalidades_anonimas = (from RowDeDatos dRow in tabla select new { Id = dRow.GetInt(columnas.First()), Descripcion = dRow.GetString("ModalidadDescripcion") }).Distinct().ToList();
            var modalidades = new List<Modalidad>();
            var columnas_todas = new List<string>(columnas);
            columnas.RemoveAt(0);
            modalidades_anonimas.ForEach(modalidad => modalidades.Add(new Modalidad(modalidad.Id, modalidad.Descripcion, InstanciasFrom(modalidad.Id, tabla.FindAll(row => row.GetInt(columnas_todas.First()) == modalidad.Id), columnas))));
            return modalidades;
        }

        protected List<InstanciaDeEvaluacion> InstanciasFrom(int id_modalidad, List<RowDeDatos> rows, List<string> columnas)
        {
            var instancias_anonimas = (from RowDeDatos dRow in rows select new { Id = dRow.GetSmallintAsInt(columnas.First()), Descripcion = dRow.GetString("DescripcionInstancia") }).Distinct().ToList();
            var instancias = new List<InstanciaDeEvaluacion>();

            instancias_anonimas.ForEach(instancia => instancias.Add(new InstanciaDeEvaluacion(instancia.Id, instancia.Descripcion)));

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
