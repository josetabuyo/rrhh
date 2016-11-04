using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;

namespace General
{
    public abstract class Grafico
    {
        public List<Resumen> tabla_resumen;
        public List<Dotacion> tabla_detalle;
        public List<PersonaContrato> tabla_detalle_contratos;

        public Grafico()
        {
        }


        public abstract void CrearDatos(List<RowDeDatos> list);

        protected Dotacion crearPersonaDotacion(RowDeDatos row)
        {
            return new Dotacion(
                        row.GetInt("id_persona", 0),
                        row.GetInt("legajo", 0),
                        row.GetInt("nrodocumento", 0),
                        row.GetString("apellido", "Sin Dato"),
                        row.GetString("nombre", "Sin Dato"),
                        row.GetSmallintAsInt("id_sexo", 0),
                        row.GetString("descrip_sexo", "Sin Dato"),
                        row.GetString("nivel", "Sin Dato"),
                        row.GetString("grado", "Sin Dato"),
                        row.GetInt("id_area", 0),
                        row.GetString("area", "Sin Dato"),
                        row.GetString("area_descrip_corta", "Sin Dato"),
                        row.GetString("area_descrip_media", "Sin Dato"),
                        row.GetSmallintAsInt("id_planta", -1),
                        row.GetString("planta", "Sin Dato"),
                        row.GetInt("IdEstudio", -1),
                        row.GetString("Nivel_Estudios", "Sin Dato"),
                        row.GetString("Titulo_Obtenido", "Sin Dato"),
                        row.GetDateTime("FechaNacimiento", DateTime.Today),
                        row.GetInt("IdSecretaria", -1),
                        row.GetInt("IdSubSecretaria", -1),
                        row.GetString("area_descrip_secretaria", "S/Nombre"),
                        row.GetString("area_descrip_subsecretaria", "S/Nombre"),
                        row.GetString("area_descrip_secretaria_corta", "S/Nombre"),
                        row.GetString("area_descrip_subsecretaria_corta", "S/Nombre"),
                        row.GetInt("Orden", 999999)
                        );
        
        }


        protected Resumen GenerarRegistroResumen(string nivel, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }

        protected Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total));
            return registro_resumen;
        }
        protected Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total, int orden)
        {
            Resumen registro_resumen =
                       new Resumen(nivel, descripcion, cantidad, ((float)cantidad * (float)100 / (float)total), orden);
            return registro_resumen;
        }
        protected Resumen GenerarRegistroResumen(string nivel, string descripcion, int cantidad, int total, int orden, int idEstado)
        {
            Resumen registro_resumen =
                       new Resumen(idEstado.ToString(), descripcion, cantidad, ((float)cantidad * (float)100 / (float)total), orden);
            return registro_resumen;
        }

        public bool ContienePersonas()
        {
            if (this.tabla_detalle.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool ContienePersonasAContratar()
        {
            if (this.tabla_detalle_contratos.Count == 0)
            {
                return false;
            }
            return true;
        }

        public abstract void GraficoPorArea();
        public abstract void GraficoPorSecretarias();
        public abstract void GraficoPorSubSecretarias();

        //public abstract void GraficoPorAfiliacionGremial();
        /*{
            List<Dotacion> tabla_personas = this.tabla_detalle.ToList();
            List<Resumen> tabla = new List<Resumen>();

            int sin_datos = tabla_personas.Count;
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", total, total));
            tabla.Add(GenerarRegistroResumen("Sin Datos", sin_datos, total));
            this.tabla_resumen = tabla.OrderByDescending(t => t.Cantidad).ToList();
        }*/

        
    }
}
