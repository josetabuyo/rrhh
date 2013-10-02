using General;
using System;

public class PlanillaAsistenciasDto
{
    public int CodigoError { get; set; }
    public string MensajeError { get; set; }
    public Alumno[] Alumnos { get; set; }
    public DetalleAsistenciasDto[] DetalleAsistenciasPorAlumno { get; set; }
    public FechaDeCursada[] FechasDeCursada { get; set; }
    public int HorasCatedra { get; set; }

    public string Docente { get; set; }
}
public class FechaDeCursada
{
    public string Dia { get; set; }
    public string NombreDia { get; set; }
    public DateTime Fecha { get; set; }
    public int HorasCatedra { get; set; }
}