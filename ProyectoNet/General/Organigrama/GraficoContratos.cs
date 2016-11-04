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
                        row.GetString("Apellido", "Sin Dato"),
                        row.GetString("Nombre", "Sin Dato"),
                        row.GetInt("Id_Area_Actual", 0),
                        row.GetString("Area_Actual", ""),
                        row.GetString("Area_Actual", ""),
                        0,//orden
                        row.GetInt("NroInforme", 0),
                        row.GetString("estado_seleccion_descriptivo", ""),
                        row.GetString("estado_seleccion_corto", ""),
                        row.GetSmallintAsInt("estado_seleccion", 0)//id_estado
                        );
        }
         

        public override void GraficoPorArea()
        {
            List<PersonaContrato> tabla_personas = this.tabla_detalle_contratos.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();

            tabla_personas.ForEach(p =>
            {
                if (contador.Count > 0)
                {
                    if (contador.Exists(estado => estado.Id == p.IdEstado))
                    {
                        contador.Find(estado => estado.Id == p.IdEstado).PersonasContrato.Add(p);
                    }
                    else
                    {
                        Contador nuevo_estado = new Contador(p.IdEstado, p.Estado, p.EstadoCorto, p.IdEstado, "");
                        nuevo_estado.PersonasContrato.Add(p);
                        nuevo_estado.Orden = p.OrdenArea;
                        contador.Add(nuevo_estado);

                    }
                }
                else
                {
                    Contador nuevo_estado = new Contador(p.IdEstado, p.Estado, p.EstadoCorto, p.IdEstado, "");
                    nuevo_estado.PersonasContrato.Add(p);
                    nuevo_estado.Orden = p.OrdenArea;
                    contador.Add(nuevo_estado);
                }

            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.PersonasContrato.Count, total, registro.Orden, registro.Id));
            });

           // this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();
            this.tabla_resumen = tabla.OrderBy(t => t.Id).ToList();
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
