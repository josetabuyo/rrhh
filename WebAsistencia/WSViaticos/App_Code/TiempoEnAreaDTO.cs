using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TiempoEnAreaDTO
{
    public TiempoEnAreaDTO(TimeSpan tiempo)
    {
        dias = tiempo.Days;
        horas = tiempo.Hours;
        minutos = tiempo.Minutes;
    }

    public int dias { get; set; }
    public int horas { get; set; }
    public int minutos { get; set; }
}
