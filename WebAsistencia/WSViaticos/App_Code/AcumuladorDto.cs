using System;
using General;

public class AcumuladorDto:Acumulador
{
    public int Id { get; set; }
    public string Valor { get; set; }
    public DateTime Fecha { get; set; }
    public int IdCurso { get; set; }
    public int IdAlumno { get; set; }

    public override int HorasNoAsistidas()
    {
        throw new NotImplementedException();
    }

    public override int HorasAsistidas()
    {
        throw new NotImplementedException();
    }

    public override int AcumularHorasNoAsistidas(int valor_acumulado)
    {
        throw new NotImplementedException();
    }

    public override int AcumularHorasAsistidas(int valor_acumulado)
    {
        throw new NotImplementedException();
    }
}
