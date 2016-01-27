using System;
using Dominio;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeFormularios
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeFormularios(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public void GuardarDatos(Formulario formulario, Usuario usuario)
        {

            //var personas = RepositorioDePersonas.NuevoRepositorioDePersonas(conexion_bd).BuscarPersonas("{Documento:" + formulario.nroDocumento + "}");
            var parametros = new Dictionary<string, object>();

            foreach (var unCampo in formulario.campos)
            {
                parametros = new Dictionary<string, object>();
                parametros.Add("@idFormulario", formulario.idFormulario);
                parametros.Add("@idPersona", formulario.idPersona);
                parametros.Add("@idUsuario", usuario.Id);
                parametros.Add("@clave", unCampo.clave);
                parametros.Add("@valor", unCampo.valor);
                conexion_bd.EjecutarSinResultado("dbo.FORM_Ins_Generico", parametros).ToString();
            }

            //INSERTO EN LA TABLA FORM_Cabecera la version de ese formulario para saber luego si fue impreso y/o recibido
            //GuardarVersion(formulario, usuario, false);
            parametros = new Dictionary<string, object>();
            parametros.Add("@idTipoFormulario", formulario.idFormulario);
            parametros.Add("@idPersona", formulario.idPersona);
            parametros.Add("@idUsuario", usuario.Id);

            var idFormularioCabecera = conexion_bd.EjecutarEscalar("dbo.FORM_Ins_Cabecera", parametros).ToString();
        }

        public Formulario GetFormulario(string criterio, Usuario usuario)
        {

            var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
            int id_persona = (int)((JValue)criterio_deserializado["idPersona"]);
            int id_form = (int)((JValue)criterio_deserializado["idFormulario"]);

            var persona = RepositorioDePersonas.NuevoRepositorioDePersonas(conexion_bd).BuscarPersonas("{Id:" + id_persona + "}");
            if (persona.Count == 0) throw new Exception("Persona No encontrada");

            int documento = persona[0].Documento;

            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", id_persona);
            parametros.Add("@idFormulario", id_form);
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

                formulario = new Formulario(id_form, id_persona, campos);
            }
            else
            {
                campos.AddRange(traerDatosPersonales(documento));

                campos.AddRange(traerNivelGrado(documento));

                campos.AddRange(traer_estudios(documento));

                campos.AddRange(traer_domicilio(documento));

                formulario = new Formulario(id_form, id_persona, campos);

                this.GuardarDatos(formulario, usuario);

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
                campos.Add(new Campo("domicilio_numero", primer_fila.GetSmallintAsInt("Número").ToString()));
                campos.Add(new Campo("domicilio_piso", primer_fila.GetString("Piso")));
                campos.Add(new Campo("domicilio_depto", primer_fila.GetString("Dpto")));
                campos.Add(new Campo("domicilio_cp", primer_fila.GetSmallintAsInt("Codigo_Postal").ToString()));
                campos.Add(new Campo("domicilio_provincia", primer_fila.GetString("Provincia_DESC", "No hay dato").ToString()));
                campos.Add(new Campo("domicilio_localidad", primer_fila.GetString("nombrelocalidad", "No hay dato").ToString()));
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
            var contador = 1;

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    campos.Add(new Campo("nivel_estudio_" + contador, row.GetString("Nivel")));
                    campos.Add(new Campo("titulo_obtenido_" + contador, row.GetString("Titulo")));
                    campos.Add(new Campo("institucion_" + contador, "No declarado"));
                    campos.Add(new Campo("fecha_egreso_" + contador, row.GetDateTime("Fecha_Egreso").ToShortDateString().ToString()));

                    contador++;
                });

            }

            return campos;
        }

        private List<Campo> traerNivelGrado(int documento)
        {
            List<Campo> campos = new List<Campo>();
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Documento", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.CON_CONSULTA_RAPIDA_Contratos", parametros);

            if (tablaDatos.Rows.Count > 0)
            {
                var nivel = tablaDatos.Rows[0].GetString("NivelGrado").Substring(0, 1);
                var grado = tablaDatos.Rows[0].GetString("NivelGrado").Substring(1, 1);
                var funcion = tablaDatos.Rows[0].GetString("FuncionAntiguedadCertificados");

                campos.Add(new Campo("nivel", nivel));
                campos.Add(new Campo("grado", grado));
                campos.Add(new Campo("funcion", funcion));
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
                  campos.Add(new Campo("modalidad", row.GetString("Tipo_planta_Desc").ToString()));
              });

            }

            return campos;
        }

        public void GuardarVersion(Formulario form, Usuario usuario, bool impreso)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idTipoFormulario", form.idFormulario);
            parametros.Add("@idPersona", form.idPersona);
            //parametros.Add("@idUsuario", usuario.Id);
            if (impreso) {
                parametros.Add("@impreso", impreso);
                parametros.Add("@fechaImpreso", DateTime.Today);
            }
                

            var tablaDatos = conexion_bd.Ejecutar("dbo.FORM_UPD_Cabecera", parametros);

        }

        public int GetUltimaCabeceraFormulario(Formulario form, Usuario usuario)
        {
            var id = 0;
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idTipoFormulario", form.idFormulario);
            parametros.Add("@idPersona", form.idPersona);
            var tablaDatos = conexion_bd.Ejecutar("dbo.FORM_GET_Cabecera", parametros);

            if (tablaDatos.Rows.Count > 0)
                id = Int32.Parse(tablaDatos.Rows[0].GetInt("id").ToString());

            
            return id;

        }
    }
}
