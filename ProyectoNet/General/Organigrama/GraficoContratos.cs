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
                        row.GetInt("id_area", 0),
                        row.GetString("Area_Real", ""),
                        row.GetString("Area_Real", ""),
                        0
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
                    if (contador.Exists(area => area.Id == p.IdArea))
                    {
                        contador.Find(area => area.Id == p.IdArea).PersonasContrato.Add(p);
                    }
                    else
                    {
                        Contador nueva_area = new Contador(p.IdArea, p.Area, p.AreaDescripCorta,0, "");
                        nueva_area.PersonasContrato.Add(p);
                        nueva_area.Orden = p.OrdenArea;
                        contador.Add(nueva_area);

                    }
                }
                else
                {
                    Contador nueva_area = new Contador(p.IdArea, p.Area, p.AreaDescripCorta,0, "");
                    nueva_area.PersonasContrato.Add(p);
                    nueva_area.Orden = p.OrdenArea;
                    contador.Add(nueva_area);
                }

            });
            int total = tabla_personas.Count;
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.ForEach(registro =>
            {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.Personas.Count, total, registro.Orden));
            });

            this.tabla_resumen = tabla.OrderBy(t => t.Orden).ToList();
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
