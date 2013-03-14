using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class RepositorioDeAccionesDeTransicion
    {
        public List<AccionDeTransicion> GetAccionesDeTransicion()
        {
            var lista = new List<AccionDeTransicion>();
            lista.Add(new AccionDeTransicion(1, "Aprobar", "Aprobó", "Pendiente"));
            lista.Add(new AccionDeTransicion(2, "Solicitar Modificación", "Solicitó Modificación", "Se Solicitó Modificación"));
            lista.Add(new AccionDeTransicion(3, "Rechazar", "Rechazó", "Rechazado"));
            lista.Add(new AccionDeTransicion(4, "Solicitar", "Solicitó", "Pendiente"));
            return lista;
        }

        public List<AccionDeTransicion> GetAccionesDeTransicionParaUnViaticoEnCirculacion()
        {
            var lista = new List<AccionDeTransicion>();
            lista.Add(new AccionDeTransicion(1, "Aprobar", "Aprobó", "Pendiente"));
            lista.Add(new AccionDeTransicion(2, "Solicitar Modificación", "Solicitó Modificación", "Se Solicitó Modificación"));
            lista.Add(new AccionDeTransicion(3, "Rechazar", "Rechazó", "Rechazado"));
            return lista;
        }

        public AccionDeTransicion GetAccionDeTransicionById(int id)
        {
            return GetAccionesDeTransicion().First(a => a.Id == id);
        }

        public AccionDeTransicion GetAccionSolicitar()
        {
            return new AccionDeTransicion(4, "Solicitar", "Solicitó", "Pendiente");
        }
    }
}
