using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeModalidades
    {

        //public IConexionBD conexion_bd { get; set; }
       

        //public RepositorioDeModalidades(IConexionBD conexion)
        //{
        //    this.conexion_bd = conexion;    
        //}

        //public List<Modalidad> GetModalidades()
        //{
        //    var tablaDatos = conexion_bd.Ejecutar("dbo.SACC_GetModalidades");
        //    List<Modalidad> modalidades = new List<Modalidad>();
        //    List<InstanciaDeEvaluacion> instancias_de_evaluacion = new List<InstanciaDeEvaluacion>();
        //    int id_estructura = 0;
        //    int id_modalidad = 0;
        //    string descripcion_estructura = "";
        //    string descripcion_modalidad = "";
        //    int modalidad_anterior = tablaDatos.Rows.First().GetInt("IdModalidad");

        //    tablaDatos.Rows.ForEach(row =>
        //    {
        //        if (modalidad_anterior == row.GetInt("IdModalidad"))
        //        {
        //            InstanciaDeEvaluacion instancia_de_evaluacion = new InstanciaDeEvaluacion(row.GetInt("idInstancia"), row.GetString("DescripcionInstancia"));
        //            instancias_de_evaluacion.Add(instancia_de_evaluacion);
        //        }
        //        else
        //        {
        //            EstructuraDeEvaluacion estructura_de_evaluacion = new EstructuraDeEvaluacion(row.GetInt("idEstructura"), row.GetString("DescripcionEstructura"), instancias_de_evaluacion);
        //            Modalidad modalidad = new Modalidad(row.GetInt("IdModalidad"), row.GetString("ModalidadDescripcion"), estructura_de_evaluacion);
        //            modalidades.Add(modalidad);
        //            modalidad_anterior = row.GetInt("IdModalidad");
        //        }

        //         id_estructura = row.GetInt("IdEstructura");
        //         descripcion_estructura = row.GetString("DescripcionEstructura");
        //         id_modalidad = row.GetInt("IdModalidad");
        //         descripcion_modalidad = row.GetString("ModalidadDescripcion");
        //    });           
        //    EstructuraDeEvaluacion estructura_de_evaluacion2 = new EstructuraDeEvaluacion(id_estructura, descripcion_estructura, instancias_de_evaluacion);
        //    Modalidad modalidad2 = new Modalidad(id_modalidad, descripcion_modalidad, estructura_de_evaluacion2);
        //    modalidades.Add(modalidad2);

        //     return modalidades;
        //}

        //public Modalidad GetModalidadById(int idModalidad)
        //{
        //    return GetModalidades().Find(m => m.Id == idModalidad);
        //}

    }
}
