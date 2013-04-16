using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class DocumentoDTO
{
    public DocumentoDTO()
    {
    }
    public DocumentoDTO (Documento doc, Mensajeria mensajeria)
	{
        id = doc.Id;
        numero = doc.numero;
        tipo = new TipoDeDocumentoDTO(doc.tipoDeDocumento);
        categoria = new CategoriaDTO(doc.categoriaDeDocumento);
        ticket = doc.ticket;
        extracto = doc.extracto;
        fechaDeAlta = doc.fecha.ToString("dd/MM/yyyy");
        areaCreadora = new AreaDTO(mensajeria.SeOriginoEnArea(doc));
        areaActual = new AreaDTO(mensajeria.EstaEnElArea(doc));
        areaDestino = new AreaDTO(mensajeria.AreaDestinoPara(doc));
        enAreaActualHace = new TiempoEnAreaDTO(mensajeria.TiempoEnElAreaActualPara(doc));
        comentarios = doc.comentarios;
               
        estado = "Recibido";
        if (areaDestino.id > -1) estado = "A remitir";

        var historial = new List<TransicionDeDocumentoDTO>();
        mensajeria.HistorialDetransicionesPara(doc).ForEach(t => historial.Add(new TransicionDeDocumentoDTO(t)));
	}

    public int id { get; set; }
    public string numero { get; set; }
    public string ticket { get; set; }
    public string extracto { get; set; }
    public string fechaDeAlta { get; set; }
    public string comentarios { get; set; }
    public TipoDeDocumentoDTO tipo { get; set; }
    public AreaDTO areaCreadora { get; set; }
    public AreaDTO areaActual { get; set; }
    public AreaDTO areaDestino { get; set; }
    public TiempoEnAreaDTO enAreaActualHace { get; set; }
    public List<TransicionDeDocumentoDTO> historial { get; set; }
    public string estado { get; set; }
    public CategoriaDTO categoria { get; set; }
}
