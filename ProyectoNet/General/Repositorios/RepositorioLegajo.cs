using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioLegajo : RepositorioLazySingleton<Legajo>
    {

        private static RepositorioLegajo _instancia;

        private RepositorioLegajo(IConexionBD conexion):base(conexion,10)
        {

        }

        public static RepositorioLegajo NuevoRepositorioDeLegajos(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioLegajo(conexion);
            return _instancia;
        }

        public string getEstudios(int doc)
        {
            List<Estudio> lista_estudios = new List<Estudio>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@NroDocumento", doc);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Estudios_Realizados", parametros);

            if (tablaDatos.Rows.Count > 0) {
                tablaDatos.Rows.ForEach(row =>
                {
                    int idUniversidad = traerMasDatosDelEstudio(row.GetInt("id"));
                    string nombre_universidad = traerNombre(idUniversidad);

                    lista_estudios.Add(new Estudio {
                        nombreDeNivel = row.GetString("Nivel","Sin información"),
                        titulo = row.GetString("Titulo", "Sin información"),
                        fechaEgreso = row.GetDateTime("Fecha_Egreso",new DateTime(1900,1,1)),
                        nombreUniversidad = nombre_universidad
                    }); 
                });
            
            }

            lista_estudios.Sort((estudio1, estudio2) => estudio2.fechaEgreso.CompareTo(estudio1.fechaEgreso));

            return JsonConvert.SerializeObject(lista_estudios.ToArray()); 

        }

        private int traerMasDatosDelEstudio(int idEstudio)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdEstudio", idEstudio);
            parametros.Add("@Tipo", 1);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Estudio_Realizado_ID", parametros);
            int idUniversidad = 0;

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    idUniversidad = row.GetSmallintAsInt("Id_Universidad", 0);

                });

            }

            return idUniversidad;
        }

        private string traerNombre(int idUniversidad)
        {
            string nombreUniversidad = "Sin datos";
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Universidades");

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    if (idUniversidad == row.GetSmallintAsInt("id",0)) {
                        nombreUniversidad = row.GetString("Universidad", "Sin datos");
                    }
                    

                });

            }

            return nombreUniversidad;
        }


        public string getFamiliares(int doc)
        {
            List<Persona> lista_personas = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc_Titular", doc);
            parametros.Add("@Id_Interna", 0);
            
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_DDJJ_Familiares", parametros);
            var list_de_familiares = new List<Object>{};


            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_familiares.Add(new 
                    {
                        Nombre = row.GetString("Nombre", "Sin información"),
                        Apellido = row.GetString("Apellido", "Sin información"),
                        Parentesco = row.GetString("Parentesco", "Sin información"),
                        Documento = row.GetInt("Nro_Doc", 0),
                        TipoDNI = row.GetString("Tipo_Doc", "Sin información"),

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_familiares);

        }

        public string getPsicofisicos(int doc)
        {
            //List<Persona> lista_personas = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Legajo", doc);
            parametros.Add("@id", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Psicofisicos", parametros);
            var list_de_examenes = new List<Object> { };


            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_examenes.Add(new
                    {
                        Folio = row.GetString("Folio_Nro", "Sin información"),
                        Motivo = row.GetString("Motivo", "Sin información"),
                        Resultado = row.GetString("Resultado", "Sin información"),
                        Organismo = row.GetString("Org_Expidió", "Sin información")

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_examenes);

        }

        public string getDesignaciones(int doc)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc", doc);
            parametros.Add("@id", 0);

            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_Designaciones", parametros);
            var list_de_designaciones = new List<Object> { };
            
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    list_de_designaciones.Add(new
                    {
                        TipoActo = row.GetString("acto_tipo", "Sin información"),
                        NroActo = row.GetInt("acto_nro", 0),
                        FechActo = row.GetDateTime("acto_fecha"),
                        Motivo = row.GetString("motivoDesc", "Sin información"),
                        SituacionRevista = row.GetString("SR", "Sin información"),
                        Folio = row.GetString("folio", "Sin información"),

                    });
                });

            }

            return JsonConvert.SerializeObject(list_de_designaciones);

        }

        protected override List<Legajo> ObtenerDesdeLaBase()
        {
            throw new NotImplementedException();
        }

        protected override void GuardarEnLaBase(Legajo legajo)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Legajo legajo)
        {
            throw new NotImplementedException();
        }




    }
}
