using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;
using System.Reflection;
using General;

namespace General
{
    public class GraficoContratos : Grafico
    {
        public List<EstadoContrato> Estados;
        //public override List<Resumen> tabla_resumen;
        //public override List<Dotacion> tabla_detalle;


        public override void CrearDatos(List<RowDeDatos> list)
        {

            List<PersonaContrato> tabla = new List<PersonaContrato>();

            list.ForEach(row =>
            {
                PersonaContrato persona = crearPersonaContrato(row);
                tabla.Add(persona);
            });
            this.tabla_detalle_contratos = tabla;
        }

        private PersonaContrato crearPersonaContrato(RowDeDatos row)
        {
            return new PersonaContrato(
                        row.GetInt("Nro_Documento", 0),
                        row.GetString("Nombre", "Sin Dato"),
                        row.GetString("Apellido", "Sin Dato"),
                        row.GetInt("Id_Area_Actual", 0),
                        row.GetString("Area_Actual", ""),
                        row.GetString("Area_Actual", ""),
                        0,//orden
                        row.GetInt("NroInforme", 0),
                        row.GetString("estado_seleccion_descriptivo", ""),
                        row.GetString("estado_seleccion_corto", ""),
                        row.GetSmallintAsInt("estado_seleccion", 0),//id_estado,
                        row.GetString("CUIL", ""),
                        row.GetDateTime("FechaIngreso", DateTime.MinValue)
                        );
        }
         

        public override void GraficoPorArea()
        {
            List<PersonaContrato> tabla_personas = this.tabla_detalle_contratos.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();

            Estados.ForEach(e =>
            {
                Contador nuevo_estado = new Contador(e.Id, e.Nombre, e.NombreCorto, e.Id, "C");
                nuevo_estado.Orden = e.Orden;
                contador.Add(nuevo_estado);
            });

            tabla_personas.ForEach(p =>
            {
                contador.Find(estado => estado.Id == p.IdEstado).PersonasContrato.Add(p);
            });

            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.OrderBy(c=> c.Orden).ToList().ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.PersonasContrato.Count, total, registro.Orden, registro.Id));
            });

            this.tabla_resumen = tabla.ToList();
            //this.tabla_resumen = tabla.OrderBy(t => t.Id).ToList();
        }

        public override void GraficoPorSecretarias()
        {

            throw new NotImplementedException();
        }

        public override void GraficoPorSubSecretarias()
        {
            throw new NotImplementedException();
        }


    }
}
