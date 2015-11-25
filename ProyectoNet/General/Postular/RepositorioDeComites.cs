using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using General.Repositorios;
using General.Postular;

namespace General
{
    public class RepositorioDeComites : RepositorioLazySingleton<Comite>
    {
        protected IConexionBD conexion_bd;
        private static RepositorioDeComites _instancia;

        private RepositorioDeComites(IConexionBD conexion) :base(conexion, 10)
        {
        }

        public static RepositorioDeComites Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeComites(conexion);
            return _instancia;
        }

        /*public RepositorioDeComites(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }*/

        public List<Comite> All()
        {
            return this.Obtener();
        }    

        protected override List<Comite> ObtenerDesdeLaBase()
        {
            var parametros = new Dictionary<string, object>();
            var tablaComites = conexion.Ejecutar("dbo.CV_Get_Comites", parametros);

            List<Comite> comites = new List<Comite>();

            //tablaCVs.Rows.ForEach(row =>
            //comites.Add(new Comite(){ Id = row.GetInt("Id"), Numero = row.GetInt("Numero")}));

            comites = CorteDeControlComite(tablaComites);

            comites.ForEach(c =>
            CorteDeControlIntegrante(tablaComites, c)
            );
            return comites;
        }

        protected override void GuardarEnLaBase(Comite objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Comite objeto)
        {
            throw new NotImplementedException();
        }

        /*public List<Comite> GetComites()
        {
            var parametros = new Dictionary<string, object>();
            var tablaComites = conexion_bd.Ejecutar("dbo.CV_Get_Comites", parametros);

            List<Comite> comites = new List<Comite>();

            //tablaCVs.Rows.ForEach(row =>
            //comites.Add(new Comite(){ Id = row.GetInt("Id"), Numero = row.GetInt("Numero")}));

            comites = CorteDeControlComite(tablaComites);

            comites.ForEach(c=>
            CorteDeControlIntegrante(tablaComites, c)
            );
            return comites;

        }*/


        public Comite GetComiteById(int id)
        {
            return this.ObtenerDesdeLaBase().Find(c => c.Id.Equals(id));
        }



        private List<Comite> CorteDeControlComite(TablaDeDatos tablaComite)
        {
            var lista = ArmarFilas(tablaComite, "Id");
            var comites = new List<Comite>();
            if (lista.Count > 0)
            {
                var comites_anonimos = (from RowDeDatos dRow in lista
                                            select new
                                            {
                                                Id = dRow.GetSmallintAsInt("Id", 0),
                                                Numero = dRow.GetSmallintAsInt("Numero", 0)
                                            }).Distinct().ToList();

                comites = comites_anonimos.Select(i =>
                    new Comite()
                    {
                        Id = i.Id,
                        Numero = i.Numero
                    }).ToList();

            }
            return comites;
        }

        private void CorteDeControlIntegrante(TablaDeDatos tablaComite, Comite comite)
        {
            var lista = ArmarFilas(tablaComite, "IdIntegrante");

            if (lista.Count > 0)
            {
                var integrantes_anonimos = (from RowDeDatos dRow in lista
                                        select new 
                                        {
                                            IdComite = dRow.GetSmallintAsInt("Id"),
                                            Id = dRow.GetSmallintAsInt("IdIntegrante", 0),
                                            NroDocumento = dRow.GetInt("NroDocumento", 0),
                                            Nombre = dRow.GetString("integranteNombre", string.Empty),
                                            Apellido = dRow.GetString("integranteApellido", string.Empty),
                                            EsTitular = dRow.GetBoolean("integranteTitular")
                                        }).Where(c=>c.IdComite == comite.Id).Distinct().ToList();

                integrantes_anonimos.Select(i =>
                    new IntegranteComite() { 
                        Id = i.Id, 
                        NroDocumento = i.NroDocumento,
                        Nombre = i.Nombre, 
                        Apellido = i.Apellido, 
                        EsTitular = i.EsTitular
                    }).ToList().ForEach(idi => comite.Integrantes.Add(idi));

            }

        }

        private List<RowDeDatos> ArmarFilas(TablaDeDatos tabla, string campo_id)
        {
            var lista = new List<RowDeDatos>();
            tabla.Rows.ForEach(r =>
            {
                if (!(r.GetObject(campo_id) is DBNull))
                    lista.Add(r);
            });

            return lista;
        }
    }
}
