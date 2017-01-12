using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class GraficoBienes: Grafico
    {
        public List<EstadoMoBi> Estados;


        public override void CrearDatos(List<Repositorios.RowDeDatos> list)
        {
            List<MoBi_Bien> tabla = new List<MoBi_Bien>();

            list.ForEach(row =>
            {
                MoBi_Bien bien = crearBien(row);
                tabla.Add(bien);
            });
            this.tabla_detalle_bienes = tabla;
        }

        private MoBi_Bien crearBien(RowDeDatos row)
        {
            return new MoBi_Bien(
                       row.GetInt("Id_Bien", 0),
                       row.GetInt("Id_TipoBien", 0),
                       row.GetString("Descrip_Bien", "Sin Dato"),
                       row.GetString("Estado", "Sin Dato"),
                       row.GetInt("Id_Estado", 0),
                       row.GetDateTime("Fecha_Desde", DateTime.MinValue)
                       );
        }


        public override void GraficoPorArea()
        {
            List<MoBi_Bien> tabla_bienes = this.tabla_detalle_bienes.ToList();
            List<Resumen> tabla = new List<Resumen>();
            List<Contador> contador = new List<Contador>();

            Estados.ForEach(e =>
            {
                Contador nuevo_estado = new Contador(e.Id, e.Codigo, e.Nombre, e.Id, "B");
                nuevo_estado.Orden = e.Id;
                contador.Add(nuevo_estado);
            });

            tabla_bienes.ForEach(p =>
            {
                contador.Find(estado => estado.Id == p.Id_Estado).MoBi_Bien.Add(p);    
            });

            int total = tabla_bienes.Count;
            tabla.Add(GenerarRegistroResumen("Total", "Total", total, total));

            contador.OrderBy(c => c.Orden).ToList().ForEach(registro =>
            {
                if (registro.MoBi_Bien.Count > 0)
                {
                tabla.Add(GenerarRegistroResumen(registro.Descripcion, registro.DescripcionGrafico, registro.MoBi_Bien.Count, total, registro.Orden, registro.Id));    
                }
                
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
