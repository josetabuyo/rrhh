using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Todas las respuestas a mensajes al ws pueden heredar de esta clase
/// que provee la funcionalidad de ofrecer una descripcion acotada del error
/// que se produjo en el servidor
/// </summary>
public abstract class RespuestaWS
{
    protected string msg;
    public string Accion { get; set; }
    public String MensajeDeErrorAmigable
    {
        get
        {
            return msg;
        }
        set
        {
            msg = value;
            DioError = true;
        }
    }
    public String DefaultErrorMessage { get { return this.Exception.Message; } set { } }
    public String ExceptionStack { get { return this.Exception.StackTrace; } set { } }
    public bool DioError { get; set; }
    protected Exception Exception;
    public RespuestaWS()
    {
        this.Exception = new Exception("");
    }

    public void setException(Exception e)
    {
        this.Exception = e;
        this.DioError = true;
    }
}