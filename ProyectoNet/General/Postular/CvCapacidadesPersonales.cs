using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvCapacidadesPersonales
    {
        protected string _aptitudesSociales;
        protected string _aptitudesOrganizativas;
        protected string _aptitudesTecnicas;
        protected string _otrasAptitudes;

        public string AptitudesSociales { get { return _aptitudesSociales; } set { _aptitudesSociales = value; } }
        public string AptitudesOrganizativas { get { return _aptitudesOrganizativas; } set { _aptitudesOrganizativas = value; } }
        public string AptitudesTecnicas { get { return _aptitudesTecnicas; } set { _aptitudesTecnicas = value; } }
        public string OtrasAptitudes { get { return _otrasAptitudes; } set { _otrasAptitudes = value; } }

        public CvCapacidadesPersonales(string aptitudesSociales, string aptitudesOrganizativas, string aptitudesTecnicas, string otrasAptitudes)
        {
            this._aptitudesSociales = aptitudesSociales;
            this._aptitudesOrganizativas = aptitudesOrganizativas;
            this._aptitudesTecnicas = aptitudesTecnicas;
            this._otrasAptitudes = otrasAptitudes;
        }

        public CvCapacidadesPersonales()
        {
        }
    }
}
