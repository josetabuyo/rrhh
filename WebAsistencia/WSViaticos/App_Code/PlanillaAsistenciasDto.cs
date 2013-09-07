using General;

public class PlanillaAsistenciasDto
{
    public int CodigoError { get; set; }
    public string MensajeError { get; set; }
    public Alumno[] Alumnos { get; set; }
    public DetalleAsistenciasPorAlumno[] DetalleAsistenciasPorAlumno { get; set; }
    public HorarioDeCursada[] HorariosDeCursada { get; set; }
    public int HorasCatedra { get; set; }
}