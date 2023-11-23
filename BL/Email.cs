using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Email
    {
        public static string sendMail(ML.Paquete email)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "isaamarti89@gmail.com";
            string displayName = "Isaac";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(email.Correo);

                mail.Subject = "Correo De confirmacion ";
                mail.Body =
                "Paquete Registrado para enviar <br/> <hr/>" +
                "Detalles: " + email.Detalle + "<br/>" +
                "Peso: " + email.Peso + "<br/>" +
                "Direccion de Origen: " + email.DirrecionOrigen + "<br/>" +
                "Direccion de Destino: " + email.DirrecionEntrega + "<hr/>";
                
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto

                client.EnableSsl = true;//En caso de que tu servidcor de correo no utilice cifrado SSL,poner en false
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, "vrrqqfzwaziignmc");




                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }

    }
}
