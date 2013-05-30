using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace General
{
    public class EnviadorDeMails
    {


        public void EnviarMail(NetworkCredential cred, string to, string asunto, string cuerpo, Action on_success, Action on_error)
        {
            try{
 	            
                MailMessage msg = new MailMessage();
                msg.To.Add(to);
                msg.From = new MailAddress(cred.UserName);
                msg.Subject = asunto;
                msg.Body = cuerpo;

                SmtpClient client = new SmtpClient("mailserver.desarrollosocial.gov.ar", 25);

                client.Credentials = cred; // Send our account login details to the client.
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
