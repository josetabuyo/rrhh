namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using General;

    public enum EstadosDeComision
    {
        Pendiente,
        Aprobada,
        Rechazada
    }

    public class ComisionDeServicio
    {
        protected int _Id;
        private Persona _Persona;
        private EstadosDeComision _Estado;
        private bool _Baja;
        private DateTime _FechaCreacion;

        // Representa el Área y Estado en la que el viático está (Arreglar Después)
        public Area AreaSuperior { get; set; }

        public Area AreaCreadora { get; set; }

        public Area AreaActual
        {
            get
            {
                TransicionDeViatico ultimaTransicion = TransicionesRealizadas[0];

                TransicionesRealizadas.ForEach((t) =>
                {
                    if (t.Fecha > ultimaTransicion.Fecha)
                    {
                        ultimaTransicion = t;
                    }
                });

                return ultimaTransicion.AreaDestino;
            }

            set { return; }
        }

        public String EstadoActual { get; set; }

        // HACE FALTA AGREGAR UNA FECHA EN LA COMISION?? XQ LA TIENE LA ESTADIA
        public List<Estadia> Estadias { get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public List<TransicionDeViatico> TransicionesRealizadas { get; set; }
        public int Id { get { return _Id; } set { _Id = value; } }
        public Persona Persona { get { return _Persona; } set { _Persona = value; } }
        public EstadosDeComision Estado { get { return _Estado; } set { _Estado = value; } }
        public bool Baja { get { return _Baja; } set { _Baja = value; } }
        public DateTime FechaCreacion { get { return _FechaCreacion; } set { _FechaCreacion = value; } }

        // es necesario mantener este constructor??
        public ComisionDeServicio()
        {
            this.Estadias = new List<Estadia>();
            this.Pasajes = new List<Pasaje>();
            this.TransicionesRealizadas = new List<TransicionDeViatico>();
        }

        public ComisionDeServicio(Persona persona, List<Estadia> estadia, List<Pasaje> pasaje, EstadosDeComision estado)
        {
            this.Estadias = estadia;
            this.Pasajes = pasaje;
            this.TransicionesRealizadas = new List<TransicionDeViatico>();

            this._Persona = persona;
            this.Estado = estado;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((ComisionDeServicio)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        public bool PuedeGuardarse()
        {
            Estadia estadia = new Estadia();
            var estadias_anteriores = estadia.GetEstadiasPorPersona(this.Persona);

            if (estadias_anteriores.Count == 0)
            {
                return true;
            }

            DateTime fecha_maxima = ObtenerFechaMaximaEstadia(this.Estadias);
            DateTime fecha_minima = ObtenerFechaMinimaEstadia(this.Estadias);

            foreach (Estadia una_estadia in estadias_anteriores)
            {
                if (fecha_minima <= una_estadia.Desde && fecha_maxima >= una_estadia.Hasta)
                {
                    return false;
                }
                else
                {
                    if (fecha_minima > una_estadia.Desde && fecha_maxima < una_estadia.Hasta)
                    {
                        return false;
                    }
                }
                return true;
            }
            return true;
        }

        public DateTime ObtenerFechaMaximaEstadia(List<Estadia> estadias)
        {
            DateTime maxDate = DateTime.MinValue;
            foreach (Estadia una_estadia in Estadias)
            {
                if (maxDate < una_estadia.Hasta)
                {
                    maxDate = una_estadia.Hasta;
                }
            }
            return maxDate;
        }

        public int esMayorAlfabeticamenteQue(ComisionDeServicio otraComision)
        {
            if (this.AreaCreadora == otraComision.AreaCreadora)
            {
                this.Estadias.Sort((estadia1, estadia2) => estadia1.esMayorAlfabeticamenteQue(estadia2));
            }
            return this.AreaCreadora.Nombre.CompareTo(otraComision.AreaCreadora.Nombre);
        }

        public DateTime ObtenerFechaMinimaEstadia(List<Estadia> estadias)
        {
            DateTime minDate = DateTime.MaxValue;
            foreach (Estadia una_estadia in Estadias)
            {
                if (minDate > una_estadia.Desde)
                {
                    minDate = una_estadia.Desde;
                }
            }
            return minDate;
        }

        public decimal ImporteTotal()
        {
            return this.Estadias.Select(e => e.AdicionalParaPasajes + e.Eventuales + e.CalculadoPorCategoria).Sum() + this.Pasajes.Select(p => p.Precio).Sum();
        }

        public bool TuEstadoEs(EstadosDeComision estado)
        {

            return this.Estado.Equals(estado);
        }

        public bool TuAreaCreadoraEstaEn(List<Area> areas)
        {
            return areas.Contains(this.AreaCreadora);
        }


        public bool TenesAlgunaEstadiaEnElPeriodo(DateTime fechaDesde, DateTime fechaHasta)
        {
            Periodo periodo = new Periodo(fechaDesde, fechaHasta);
            return this.Estadias.Any(e => periodo.Incluis(e));
        }
    }
}