using System;
using System.Collections.Generic;
using WebRhUI;
using WSViaticos;

public class CargaAreaToRowSerializer : EntityToRowConverter<Area>
{
    private ControladorDeWebControls controlador;
   
    public CargaAreaToRowSerializer()
    {
        controlador = new ControladorDeWebControls();
    }

    public override List<object> Serialize(Area area)
    {

        return new List<object>() { 
            
            area.Codigo, 
            area.Nombre,
            area.datos_del_responsable.Apellido + ", " + area.datos_del_responsable.Nombre,
            this.ObtenerAsistentes(area),
            //falta agregar el boton para los datos de los asistentes
            this.ObtenerTelefonos(area),
            //area.Fax,
            //area.Mail,
            area.Direccion
       };
    }

    private string ObtenerTelefonos(Area area)
    {
        return "probando Carga Area To Row Seriaizer";
    }

        private string boton_quitar(Estadia estadia)
        {
            //return controlador.DibujarLink(estadia, "QuitarEstadia");
            return controlador.DibujarLinkParaRequest(estadia, "EstadiaAQuitar");
        }


        private string ObtenerAsistentes(Area un_area) {

            string NombresAsistentes = ""; ;

            if (un_area.Asistentes[0].Apellido != "")
            {
                foreach (Asistente asistente in un_area.Asistentes)
                {

                    NombresAsistentes += asistente.Apellido + ' '
                                             + asistente.Nombre;

                }
            }
            return NombresAsistentes;
        }


}
