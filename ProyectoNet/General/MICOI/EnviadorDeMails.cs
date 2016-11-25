using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace General
{
    public class EnviadorDeMails
    {
        public void EnviarMail(NetworkCredential cred, string to, string asunto, string cuerpo, Action on_success, Action on_error)
        {
            try{
 	            
                MailMessage msg = new MailMessage();
                msg.To.Add(to);
                msg.From = new MailAddress("rhusuarios@desarrollosocial.gov.ar");
                msg.Subject = asunto;
                msg.IsBodyHtml = true;
                msg.Body = cuerpo;
               
                SmtpClient client = new SmtpClient("owa.desarrollosocial.gob.ar", 25);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = cred; // Send our account login details to the client.
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Send(msg);          // Send our email.                
            }
            catch(Exception e){
                on_error.Invoke();
                return;
            }
            on_success.Invoke();
        }
    }
}
