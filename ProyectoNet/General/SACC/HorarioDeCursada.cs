
using System;
namespace General
{
    public class HorarioDeCursada
    {
        private DayOfWeek _dia;

        private TimeSpan _hora_inicio;
        private TimeSpan _hora_fin;


        public DayOfWeek Dia { get { return _dia; } set { _dia = value; } }
        public TimeSpan HoraDeInicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }
        
        public TimeSpan HoraDeFin
        {
            get { return _hora_fin; }
            set { _hora_fin = value; }
        }
        public HorarioDeCursada()
        {

        }
        /// <summary>
        /// Crea una instancia de Horario de Cursada
        /// hora_inicio y hora_fin deben estar en formato HH:MM
        /// </summary>
        /// <param name="hora_inicio"></param>
        /// <param name="hora_fin"></param>
        public HorarioDeCursada(DayOfWeek dia, string hora_inicio, string hora_fin)
        {
            try
            {
                this._dia = dia;
                this.HoraDeInicio = TimeSpan.Parse(hora_inicio);
                this.HoraDeFin = TimeSpan.Parse(hora_fin);
            }
            catch (FormatException f)
            {
                throw f;
            }
            catch (OverflowException o)
            {
                throw o;
            }
            
        }
        
    }
}
