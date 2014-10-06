<%@ WebHandler Language="C#" Class="Captcha" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.SessionState;

public class Captcha : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hola a todos");

        context.Response.ContentType = "image/GIF";
        Random autoRand = new Random();
        Bitmap imagen_GIF = new System.Drawing.Bitmap(150, 50);
        Graphics grafico = System.Drawing.Graphics.FromImage(imagen_GIF);
        grafico.Clear(Color.FromArgb(Convert.ToInt32(autoRand.Next(240, 255)), Convert.ToInt32(autoRand.Next(240, 255)), Convert.ToInt32(autoRand.Next(240, 255))));
        string[] fuente = { "Baskerville Old Face", "Times New Roman", "Comic Sans MS", "Courier New", "Arial" };

        for (int x = 0; x < 80; x++)
        {
            string letra_fondo = ObtenerCaracter(autoRand);
            Font tipo_fuente = new Font(fuente[Convert.ToInt32(autoRand.Next(0, fuente.Length - 1))], Convert.ToInt32(autoRand.Next(15, 25)));
            grafico.DrawString(letra_fondo, tipo_fuente, new System.Drawing.SolidBrush(Color.FromArgb(autoRand.Next(185, 255), autoRand.Next(185, 255), autoRand.Next(185, 255))), Convert.ToInt32(autoRand.Next(-15, 150)), Convert.ToInt32(autoRand.Next(-10, 50)));
        }

        string randomNum = string.Empty;

        for (int x = 0; x < 6; x++)
        {

            randomNum += ObtenerCaracter(autoRand);
        }

       
      //  context.Session["Usuario"] = "UsuarioDeSistema";
        // context.Session.Add("Usuario", "UsuarioDelSistema");
        context.Session["RandomNumero"] = randomNum;


        char[] codigo = randomNum.ToCharArray();

        //Posicion de inicio del eje X
        int posX = 5;
        foreach (char c in codigo)
        {
            //Asignamos la fuente
            Font tipo_fuente = new Font(fuente[Convert.ToInt32(autoRand.Next(0, fuente.Length - 1))], Convert.ToInt32(autoRand.Next(17, 21)), FontStyle.Bold);

            //Añadimos al gráfico
            grafico.DrawString(c.ToString(), tipo_fuente, new System.Drawing.SolidBrush(Color.FromArgb(autoRand.Next(0, 135), autoRand.Next(0, 135), autoRand.Next(0, 135))), posX, autoRand.Next(5, 20));

            //Aumentamos posicion del eje X
            posX += 20;
        }


        for (int x = 0; x < 1500; x++)
        {
            string letra_fondo = ".";
            Font tipo_fuente = new Font(fuente[Convert.ToInt32(autoRand.Next(0, fuente.Length - 1))], Convert.ToInt32(autoRand.Next(5, 7)));

            grafico.DrawString(letra_fondo, tipo_fuente, new System.Drawing.SolidBrush(Color.FromArgb(autoRand.Next(0, 255), autoRand.Next(0, 255), autoRand.Next(0, 255))), Convert.ToInt32(autoRand.Next(0, 150)), Convert.ToInt32(autoRand.Next(0, 50)));

        }

        imagen_GIF.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
        grafico.Dispose();
        imagen_GIF.Dispose();
    }

    private string ObtenerCaracter(Random autoRand)
    {
        string retorno = "";
        //En esta condicion podemos modificar la frecuencia con la que apareceran números o letras (de un numero al azar entre 0 y 6, cuando sale 0 es una letra, en caso contrario, un número)

        if ((autoRand.Next(0, 6)).ToString() == "0")
        {
            int i_letra = System.Convert.ToInt32(autoRand.Next(65, 90));

            //Convertimos el numero ASCII obtenido en letra
            retorno = ((char)i_letra).ToString();
        }
        else
        {
            retorno = System.Convert.ToInt32(autoRand.Next(0, 9)).ToString();
        }
        return retorno;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}