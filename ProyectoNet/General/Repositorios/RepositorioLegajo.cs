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
                    lista_estudios.Add(new Estudio {
                        nombreDeNivel = row.GetString("Nivel","Sin información"),
                        titulo = row.GetString("Titulo", "Sin información"),
                        fechaEgreso = row.GetDateTime("Fecha_Egreso",new DateTime(1900,1,1))
                    }); 
                });
            
            }

            lista_estudios.Sort((estudio1, estudio2) => estudio2.fechaEgreso.CompareTo(estudio1.fechaEgreso));

            return JsonConvert.SerializeObject(lista_estudios.ToArray()); 

        }

        public string getFamiliares(int doc)
        {
            List<Persona> lista_personas = new List<Persona>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc_Titular", doc);
            var tablaDatos = conexion.Ejecutar("dbo.LEG_GET_DDJJ_Familiares", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    lista_personas.Add(new Persona
                    {
                        Nombre = row.GetString("Nombre", "Sin información"),
                        Apellido = row.GetString("Apellido", "Sin información"),
                        nombreDeNivel = row.GetString("Nivel", "Sin información"),
                        titulo = row.GetString("Titulo", "Sin información"),
                        fechaEgreso = row.GetDateTime("Fecha_Egreso", new DateTime(1900, 1, 1))
                    });
                });

            }

            lista_estudios.Sort((estudio1, estudio2) => estudio2.fechaEgreso.CompareTo(estudio1.fechaEgreso));

            return JsonConvert.SerializeObject(lista_estudios.ToArray());

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
