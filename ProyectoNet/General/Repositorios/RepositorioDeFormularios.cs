using System;
using Dominio;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeFormularios
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeFormularios(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public int GuardarDatos(Formulario formulario)
        {

            //var personas = RepositorioDePersonas.NuevoRepositorioDePersonas(conexion_bd).BuscarPersonas("{Documento:" + formulario.nroDocumento + "}");
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idFormulario", formulario.idFormulario);
            parametros.Add("@idPersona", formulario.idPersona);
            parametros.Add("@idUsuario", formulario.idUsuario);

            foreach (var unCampo in formulario.campos)
            {
                parametros.Add("@clave", unCampo.clave);
                parametros.Add("@valor", unCampo.valor);
            }

            var id = conexion_bd.EjecutarEscalar("dbo.FORM_Ins_Generico", parametros).ToString();

            return Int32.Parse(id);
        }

        public Formulario GetFormulario(string criterio)
        {

            var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
            int id_persona = (int)((JValue)criterio_deserializado["idPersona"]);
            int documento = 123;

            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", id_persona);
            var tablaDatos = conexion_bd.Ejecutar("dbo.Form_Get_Generico", parametros);
            List<Campo> campos = new List<Campo>();
            Formulario formulario = new Formulario();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    campos.Add(new Campo(row.GetString("clave"), row.GetString("valor")));
                });

                var fila = tablaDatos.Rows[0];

                formulario = new Formulario(fila.GetSmallintAsInt("idFormulario"), fila.GetInt("idPersona"), campos, fila.GetInt("idUsuario"));

            }
            else
            {
                campos.AddRange(traerDatosPersonales(documento));

                campos.AddRange(traerNivelGrado(documento));

                campos.AddRange(traer_estudios(documento));

                campos.AddRange(traer_domicilio(documento));

            }

            return formulario;
        }

        private List<Campo> traer_domicilio(int documento)
        {
            List<Campo> campos = new List<Campo>();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.LEG_GET_Domicilios", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var primer_fila = tablaDatos.Rows[0];
                campos.Add(new Campo("domicilio_calle", primer_fila.GetString("Calle")));
                campos.Add(new Campo("domicilio_numero", primer_fila.GetString("Número")));
                campos.Add(new Campo("domicilio_piso", primer_fila.GetString("Piso")));
                campos.Add(new Campo("domicilio_depto", primer_fila.GetString("Dpto")));
                campos.Add(new Campo("domicilio_cp", primer_fila.GetString("Codigo_Postal")));
                campos.Add(new Campo("domicilio_provincia", primer_fila.GetString("Provincia")));
                campos.Add(new Campo("domicilio_localidad", primer_fila.GetString("Localidad")));
                campos.Add(new Campo("domicilio_telefono", ""));
             

            }

            return campos;
        }

        private List<Campo> traer_estudios(int documento)
        {
            List<Campo> campos = new List<Campo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@NroDocumento", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.LEG_GET_Estudios_Realizados", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    campos.Add(new Campo("nivel_estudio", row.GetString("Nivel")));
                    campos.Add(new Campo("titulo_obtenido", row.GetString("Titulo")));
                    campos.Add(new Campo("institucion", "No declarado"));
                });

            }

            return campos;
        }

        private List<Campo> traerNivelGrado(int documento)
        {
            List<Campo> campos = new List<Campo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Doc", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.CON_CONSULTA_RAPIDA_Contratos", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var nivel = tablaDatos.Rows[0].GetString("NivelGrado").Substring(0,1);
                var grado = tablaDatos.Rows[0].GetString("NivelGrado").Substring(1, 2);

                campos.Add(new Campo("apellido", nivel));
                campos.Add(new Campo("nombre", grado));

            }

            return campos;
        }

        private List<Campo> traerDatosPersonales(int documento)
        {
            List<Campo> campos = new List<Campo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@doc", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.LEG_GET_Datos_Personales", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
              {
                  campos.Add(new Campo("apellido", row.GetString("Apellido")));
                  campos.Add(new Campo("nombre", row.GetString("Nombre")));
                  campos.Add(new Campo("tipo_documento", row.GetSmallintAsInt("Tipo_Documento").ToString()));
                  campos.Add(new Campo("documento", row.GetSmallintAsInt("Nro_Documento").ToString()));
              });

            }

            return campos;
        }
    }
}
