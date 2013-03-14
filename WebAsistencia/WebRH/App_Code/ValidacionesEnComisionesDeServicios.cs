using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ValidacionesEnComisionesDeServicios
/// </summary>
public static class ValidacionesEnComisionesDeServicios
{

    public static bool Validar72Horas(DateTime fecha_creacion, DateTime fecha_viaje)
    {

        TimeSpan diferencia = fecha_viaje - fecha_creacion;
        var dia_semana = fecha_creacion.DayOfWeek;


        if ((diferencia.TotalDays < 5)) //Si bien son 72 horas se cuentan los posibles Fines de Semana para hacer el cálculo
        {
            if ((diferencia.TotalDays < 3))
            {
                return true;
            }
            else
            {
                if (dia_semana != DayOfWeek.Monday && dia_semana != DayOfWeek.Tuesday)
                { // Si no se piede Lunes o Martes entonces no se llega con los días hábiles

                    return true;
                }
                else { return false; }
            } // Se debería agregar el Domingo para 5 días, pero no se trabaja los domingos
        }
        else { return false; }
    }
}
