using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DetalleAsistenciasDto
{
    public int IdAlumno { get; set; }
    public int IdCurso { get; set; }
    public AcumuladorDto[] Asistencias { get; set; }
    public int AsistenciasPeriodo { get; set; }
    public int AsistenciasTotal { get; set; }
    public int InasistenciasPeriodo { get; set; }
    public int InasistenciasTotal { get; set; }
}
