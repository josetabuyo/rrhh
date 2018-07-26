using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;

public class GenReciboToPdfConverter : ModeloToPdfConverter
{
    public GenReciboToPdfConverter()
    {
    }

    public override Dictionary<string, string> CrearMapa(List<object> modelo)
    {        
        Recibo r = (Recibo) modelo[0];
        //////////////////////////
///        //Usuario,fecha de generacion, identificador gedo
///        string telefono = "";

/*        var dato_de_contacto = area.DatosDeContacto.OrderBy(c=> c.Orden).ToList().Find(c => c.Id == 1);
        if (dato_de_contacto != null)
        {
            telefono = dato_de_contacto.Dato;
        }
*/

//        mapa.Add("texto0", p.Documento.ToString());
        mapa.Add("texto1", r.cabecera.Area);
        mapa.Add("texto2", Convert.ToString(r.cabecera.Legajo));
        mapa.Add("texto3", r.cabecera.Agente);
        mapa.Add("texto4", r.cabecera.CUIL);
        mapa.Add("texto5", Convert.ToString(r.cabecera.Oficina));
        mapa.Add("texto6", Convert.ToString(r.cabecera.Orden));

        //recorro cada fila de la descripcion
       /* for (int i = 0; i<r.detalles.Count;i++ )
        {
        }*/
        int i = 1;
        int cantidadDetalles = r.detalles.Count();   // obtengo la cantidad de detalles para saber cual pdf utilizar

        foreach (Detalle d in r.detalles)
        {
            mapa.Add("c"+i, d.Concepto);
            mapa.Add("des"+i, d.Descripcion);
            if (d.Descripcion !="")
            {//este if es porque desde el store procedure en caso de no tener minimo 20 detalles se agregan lineas vacias
                //lo idel seria no agregarlas pero asi las usa la version de visual basic
                if (d.Aporte != 0)
                {
                    mapa.Add("h" + i, string.Format("{0:N}", d.Aporte)); //Convert.ToString(d.Aporte));
                }
                else
                {
                    mapa.Add("d" + i, string.Format("{0:N}", d.Descuento)); //Convert.ToString(d.Descuento));
                }
            
            }
            
            i++;
        }
        
        if (cantidadDetalles <= 20)
        {
            //utilizo el pdf de 1 pagina 
            mapa.Add("paginasPDF", "una"); // para saber cual pdf utilizar
            mapa.Add("totalH", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Bruto) / 100));
            mapa.Add("totalD", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Descuentos) / 100));
            // mapa.Add("neto", Convert.ToDecimal(r.cabecera.Neto).ToString("C")); esto si directamente se retorna desde el SP un float asi en el campo del pdf lo formatea bien, poque si es un string lo pone como string y no lo formatea
            //  mapa.Add("neto", string.Format("{0:C}", Convert.ToDecimal(r.cabecera.Neto) / 100));
            mapa.Add("neto", string.Format("{0:C2}", Convert.ToDecimal(r.cabecera.Neto) / 100));
            mapa.Add("categoria", r.cabecera.NivelGrado);
            mapa.Add("opcion", r.cabecera.OpcionJubilatoria);
            mapa.Add("fechaLiquidacion", r.cabecera.FechaLiquidacion);
            mapa.Add("tipoLiquidacion", Convert.ToString(r.cabecera.TipoLiquidacion));
            mapa.Add("dni", Convert.ToString(r.cabecera.Nro_Documento));
            mapa.Add("domicilio", r.cabecera.Domicilio);
            mapa.Add("fechaFirmaEmpleado", DateTime.Now.ToString("dd/MM/yyyy"));// tomo la fecha actual del server como fecha de firma del empleado
            mapa.Add("fechaDeposito", r.cabecera.Fecha_deposito.ToString("dd/MM/yyyy"));
            mapa.Add("descripcionTipoLiquidacion", r.cabecera.DescripcionTipoLiquidacionYMas);
        }
        else {
            if ((cantidadDetalles >= 21) && (cantidadDetalles <= 40))
            {
                //utilizo el pdf de 2 paginas
                mapa.Add("paginasPDF", "dos"); // para saber cual pdf utilizar
                mapa.Add("totalH1", "****");
                mapa.Add("totalD1", "****");
                // mapa.Add("neto", Convert.ToDecimal(r.cabecera.Neto).ToString("C")); esto si directamente se retorna desde el SP un float asi en el campo del pdf lo formatea bien, poque si es un string lo pone como string y no lo formatea
                //  mapa.Add("neto", string.Format("{0:C}", Convert.ToDecimal(r.cabecera.Neto) / 100));
                mapa.Add("neto1", "****");
                mapa.Add("totalH2", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Bruto) / 100));
                mapa.Add("totalD2", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Descuentos) / 100));
                mapa.Add("neto2", string.Format("{0:C2}", Convert.ToDecimal(r.cabecera.Neto) / 100));
                mapa.Add("categoria", r.cabecera.NivelGrado);
                mapa.Add("opcion", r.cabecera.OpcionJubilatoria);
                mapa.Add("fechaLiquidacion", r.cabecera.FechaLiquidacion);
                mapa.Add("tipoLiquidacion", Convert.ToString(r.cabecera.TipoLiquidacion));
                mapa.Add("dni", Convert.ToString(r.cabecera.Nro_Documento));
                mapa.Add("domicilio", r.cabecera.Domicilio);
                mapa.Add("fechaFirmaEmpleado", DateTime.Now.ToString("dd/MM/yyyy"));// tomo la fecha actual del server como fecha de firma del empleado
                mapa.Add("fechaDeposito", r.cabecera.Fecha_deposito.ToString("dd/MM/yyyy"));
                mapa.Add("descripcionTipoLiquidacion", r.cabecera.DescripcionTipoLiquidacionYMas);
            }
            else { //utilizo 3 paginas
                mapa.Add("paginasPDF", "tres"); // para saber cual pdf utilizar
                mapa.Add("totalH1", "****");
                mapa.Add("totalD1", "****");
                mapa.Add("neto1", "****");
                mapa.Add("totalH2", "****");
                mapa.Add("totalD2", "****");
                mapa.Add("neto2", "****");
                mapa.Add("totalH3", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Bruto) / 100));
                mapa.Add("totalD3", string.Format("{0:N}", Convert.ToDecimal(r.cabecera.Descuentos) / 100));
                mapa.Add("neto3", string.Format("{0:C2}", Convert.ToDecimal(r.cabecera.Neto) / 100));
                mapa.Add("categoria", r.cabecera.NivelGrado);
                mapa.Add("opcion", r.cabecera.OpcionJubilatoria);
                mapa.Add("fechaLiquidacion", r.cabecera.FechaLiquidacion);
                mapa.Add("tipoLiquidacion", Convert.ToString(r.cabecera.TipoLiquidacion));
                mapa.Add("dni", Convert.ToString(r.cabecera.Nro_Documento));
                mapa.Add("domicilio", r.cabecera.Domicilio);
                mapa.Add("fechaFirmaEmpleado", DateTime.Now.ToString("dd/MM/yyyy"));// tomo la fecha actual del server como fecha de firma del empleado
                mapa.Add("fechaDeposito", r.cabecera.Fecha_deposito.ToString("dd/MM/yyyy"));
                mapa.Add("descripcionTipoLiquidacion", r.cabecera.DescripcionTipoLiquidacionYMas);           
            
            }      

        }

        

//        mapa.Add("Nombre_usu", usr.Owner.Apellido + ", " + usr.Owner.Nombre + " (" + usr.Owner.Documento.ToString() + ")");
//        mapa.Add("Fecha_hora", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));

/*        if (domicilioNuevo.DocumentoGDE != null)
        {
            mapa.Add("Identif_Formulario", domicilioNuevo.DocumentoGDE.idDocumentoGDE.ToString());
        }
        else
        { //siempre va a haber un numero de gde, pero lo dejo porque puede cambiar al atributo numero interno de gde
            mapa.Add("Identif_Formulario", "----");
        }
*/
        

        return mapa;
    }

}

