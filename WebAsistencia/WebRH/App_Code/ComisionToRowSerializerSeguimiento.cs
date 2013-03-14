using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using WSViaticos;
using WebRhUI;

/// <summary>
/// Descripción breve de ComisionToRowSerializer
/// </summary>
public class ComisionToRowSerializerSeguimiento : EntityToRowConverter<ComisionDeServicio>
{
    private ControladorDeWebControls controlador;

    public ComisionToRowSerializerSeguimiento()
    {
        controlador = new ControladorDeWebControls();
    }

    public override List<object> Serialize(ComisionDeServicio comision)
    {
        int dias_faltantes = DiasFaltantesParaLaEstadia(comision);
        string aviso_menor_72_horas = AvisoSolicitudMenorA72Horas(comision);

        return new List<object>() {  html_ckb(comision), 
            comision.Persona.Documento.ToString(), 
            comision.Persona.Apellido + ", " + comision.Persona.Nombre,
            MostarFechaDesde(comision),
            MostrarFechaHasta(comision),
            //comision.Estadias[0].Desde.Date.ToShortDateString() + " (" + comision.Estadias[0].Provincia.Nombre + ")",
            //comision.Estadias[0].Hasta.Date.ToShortDateString() + " (" + comision.Estadias[0].Provincia.Nombre + ")",
            comision.AreaActual.Nombre,
            //img_semaforo(dias_faltantes),
            comision.TransicionesRealizadas.Last().Accion.DescripcionEstadoInbox + " " + aviso_menor_72_horas,
//            comision.Estado.ToString(),
            boton_verMas(comision)            
        };
    }

    private string MostarFechaDesde(ComisionDeServicio comision)
    {
        return comision.Estadias.First().Desde.Date.ToShortDateString() + "<br> (" + comision.Estadias.First().Provincia.Nombre + ")";
    }

    private string MostrarFechaHasta(ComisionDeServicio comision)
    {
        return comision.Estadias.Last().Desde.Date.ToShortDateString() + "<br> (" + comision.Estadias.Last().Provincia.Nombre + ")";
    }

    private string boton_verMas(ComisionDeServicio comision)
    {
        //return controlador.DibujarLinkConImagen(comision, "VerDetalle", "../Imagenes/icons-lupa-finish.jpg", "30", "30");
        return controlador.DibujarLink(comision, "VerDetalle", "Editar");
    }


    private string img_semaforo(int dias_faltantes)
    {
        string imagen;

        if (dias_faltantes > 5)
        {
            imagen = "<img width=\"20\" height=\"30\" src=\"../Imagenes/verde_semaforo.png\"/>";

            //semaforo.ImageUrl = "../Imagenes/verde_semaforo.png";
        }
        else
        {
            imagen = "<img width=\"20\" height=\"30\" src=\"../Imagenes/rojo_semaforo.png\"/>";
            //semaforo.ImageUrl = "../Imagenes/rojo_semaforo.png";
        }
        return imagen;
        //return ContruirSemaforo(dias_faltantes);
    }


    private string MostrarDiasFaltantes(int dias)
    {
        if (dias < 0) return "Vencido";
        return dias.ToString();


    }

    private int DiasFaltantesParaLaEstadia(ComisionDeServicio una_comision)
    {
        //ordenar las estadias por la que tiene la fecha desde mas cercana, no por el orden de la lista
        return (una_comision.Estadias[0].Desde - DateTime.Today).Days;

    }

    private string AvisoSolicitudMenorA72Horas(ComisionDeServicio una_comision)
    {
        //ordenar las estadias por la que tiene la fecha desde mas cercana, no por el orden de la lista
       Estadia primera_estadia = una_comision.Estadias.OrderBy(f => f.Desde).First();

       bool menor_a_72_horas = ValidacionesEnComisionesDeServicios.Validar72Horas(una_comision.FechaCreacion, primera_estadia.Desde);

        
       if (menor_a_72_horas)
       {
           return "*";
       }else{
           return "";
       }       
    }


    private string html_ckb(ComisionDeServicio comision)
    {
        return controlador.DibujarChecboxPara(comision);// "<input type=\"checkbox\" runat=\"server\" id=\"ControlListaDeSolicitudes1_|" + comision.Id + "\" name=\"ControlListaDeSolicitudes1$|" + comision.Id + "\" />";
    }
}