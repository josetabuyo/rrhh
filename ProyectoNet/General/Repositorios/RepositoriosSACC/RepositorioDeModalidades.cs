using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeModalidades : General.Repositorios.IRepositorioDeModalidades
    {

        public IConexionBD conexion_bd { get; set; }
        List<Modalidad> modalidades = new List<Modalidad>();

       

        public RepositorioDeModalidades(IConexionBD conexion)
        {
            this.conexion_bd = conexion;    
        }

        public List<Modalidad> GetModalidades()
        {
            var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_GetModalidades");
            List<Modalidad> modalidades = new List<Modalidad>();
            List<InstanciaDeEvaluacion> instancias_de_evaluacion = new List<InstanciaDeEvaluacion>();
            int id_modalidad = 0;
            string descripcion_modalidad = "";
            Modalidad modalidad_anterior = new Modalidad(tablaDatos.Rows.First().GetInt("IdModalidad"), tablaDatos.Rows.First().GetString("ModalidadDescripcion"), instancias_de_evaluacion);
            

            tablaDatos.Rows.ForEach(row =>
            {
                if (modalidad_anterior.Id == row.GetInt("IdModalidad"))
                {

                    InstanciaDeEvaluacion instancia_de_evaluacion = new InstanciaDeEvaluacion(row.GetSmallintAsInt("idInstancia"), row.GetString("DescripcionInstancia"));
                    instancias_de_evaluacion.Add(instancia_de_evaluacion);
                }
                else
                {
                    id_modalidad = modalidad_anterior.Id;
                    descripcion_modalidad = modalidad_anterior.Descripcion;
                    Modalidad modalidad = new Modalidad(id_modalidad, descripcion_modalidad, instancias_de_evaluacion);
                    modalidades.Add(modalidad);
                    instancias_de_evaluacion = new List<InstanciaDeEvaluacion>();

                    InstanciaDeEvaluacion instancia_de_evaluacion = new InstanciaDeEvaluacion(row.GetSmallintAsInt("idInstancia"), row.GetString("DescripcionInstancia"));
                    instancias_de_evaluacion.Add(instancia_de_evaluacion);

                }

                modalidad_anterior = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"), instancias_de_evaluacion);

            });
            Modalidad modadidad_siguiente = new Modalidad(modalidad_anterior.Id, modalidad_anterior.Descripcion, instancias_de_evaluacion);
            modalidades.Add(modadidad_siguiente);

            return modalidades;
        }

        public Modalidad GetModalidadById(int idModalidad)
        {
            return GetModalidades().Find(m => m.Id == idModalidad);
        }

        public ModalidadNull ModalidadNull() 
        {
            return new ModalidadNull();
        }

    }
}
