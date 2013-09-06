using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using General;

public class FichaAlumnoDto
{
    public int Id { get; set; }
    public string Calificacion { get; set; }
    public int DNIAlumno { get; set; }
    public int IdCurso { get; set; }
    public string Fecha { get; set; }
    public int IdInstancia { get; set; }
    public string DescripcionInstancia { get; set; }
}

public class FichaAlumnoEvaluacionPorCursoDto
{

    public int CodigoError { get; set; }
    public string MensajeError { get; set; }
    //public int Id { get; set; }
    //public string Nombre { get; set; }
    public string Materia { get; set; }
    public string Docente { get; set; }
    public string Ciclo { get; set; }
    //public Alumno Alumno { get; set; }
    public string Estado { get; set; }
    //public string FechaInicio { get; set; }
    public string CalificacionFinal { get; set; }
    public string FechaFin { get; set; }
    public EvaluacionDto[] Evaluaciones { get; set; }
    
}