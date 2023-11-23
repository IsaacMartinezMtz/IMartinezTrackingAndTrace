using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BL
{
    public class Mensaje
    {
        public static string Enviar(ML.Paquete paquete)
        {
            var accountSid = "AC0271814c53e431a1c19e3635beb6665e";
            var authToken = "4cc3a6eba033ba9cf7484a3cff451d74";

            TwilioClient.Init(accountSid, authToken);

            
            var mensajeOpcion = new CreateMessageOptions(
                new PhoneNumber("+525539711246"));
            mensajeOpcion.From = new PhoneNumber("+13187870872");
            mensajeOpcion.Body = "Paquete Registrado para enviar " +
                "Detalles: " + paquete.Detalle  +
                "Peso: " + paquete.Peso +
                "Direccion de Origen: "+ paquete.DirrecionOrigen +
                "Direccion de Destino: " + paquete.DirrecionEntrega; 

            var message = MessageResource.Create(mensajeOpcion);

            return message.ToString();

            
        }
    }


}
