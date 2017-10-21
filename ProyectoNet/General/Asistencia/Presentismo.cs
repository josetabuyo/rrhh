using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class Presentismo
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private Persona _persona;
        public Persona Persona { get { return _persona; } set { _persona = value; } }

        private string _mes;
        public string Mes { get { return _mes; } set { _mes = value; } }

        private TipoDePlantaGeneral _planta;
        public TipoDePlantaGeneral Planta { get { return _planta; } set { _planta = value; } }

        private int _justificadas;
        public int Justificadas { get { return _justificadas; } set { _justificadas = value; } }
        
        private int _injustificadas;
        public int Injustificadas { get { return _injustificadas; } set { _injustificadas = value; } }
        
        private int _no_afecta;
        public int NoAfecta { get { return _no_afecta; } set { _no_afecta = value; } }

        private int _porcentaje_cobro;
        public int PorcentajeCobro { get { return _porcentaje_cobro; } set { _porcentaje_cobro = value; } }

        public Presentismo()
        {
            
        }
        public Presentismo(int id, Persona persona, TipoDePlantaGeneral planta, string mes, int justificadas, int injustificadas, int no_afecta, int porcentaje_cobro)
        {
            this.Id = id;
            this.Persona = persona;
            this.Planta = planta;
            this.Mes = mes;
            this.Justificadas = justificadas;
            this.Injustificadas = injustificadas;
            this.NoAfecta = no_afecta;
            this.PorcentajeCobro = porcentaje_cobro;
        }

    }

    
}
