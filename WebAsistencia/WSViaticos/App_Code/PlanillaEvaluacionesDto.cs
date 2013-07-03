using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using General;

public class EvaluacionDto
{
    public int Id { get; set; }
    public Calificacion Calificacion { get; set; }
    public int IdAlumno { get; set; }
    public int IdCurso { get; set; }
}

public class PlanillaEvaluacionesDto
{
    public int CodigoError { get; set; }
    public string MensajeError { get; set; }
    public Alumno[] Alumnos { get; set; }
    public EvaluacionDto[] Evaluaciones { get; set; }
    public InstanciaEvaluacionDto[] Instancias { get; set; }
    
}