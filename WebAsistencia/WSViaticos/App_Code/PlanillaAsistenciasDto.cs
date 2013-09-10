using General;
using System;

public class PlanillaAsistenciasDto
{
    public int CodigoError { get; set; }
    public string MensajeError { get; set; }
    public Alumno[] Alumnos { get; set; }
    public DetalleAsistenciasPorAlumno[] DetalleAsistenciasPorAlumno { get; set; }
    public DateTime[] HorariosDeCursada { get; set; }
    public int HorasCatedra { get; set; }
}