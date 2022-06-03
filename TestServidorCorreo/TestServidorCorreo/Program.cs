using System;
using System.Net;
using System.Net.Mail;

namespace TestServidorCorreo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter para enviar correo");
            Console.ReadLine();
            var fromAddress = new MailAddress("fernando.romero@iq-online.com", "From Name");
            var toAddress = new MailAddress("fernando.romero@iq-online.com", "To Name");
            const string fromPassword = "Irlanda.2022";
            const string subject = "Subject";
            const string body = "Prueba notificación";
            MailMessage msg = null;

            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            var smtp = new SmtpClient
            {
                //Host = "bog-smtp-02",
                Host = "smtp.office365.com",
                //Port = 25,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            {

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    Console.WriteLine("Envio correo");
                    Console.ReadLine();
                }

            }
            catch (Exception e) {
                Console.WriteLine("{0} Exception caught.", e);
                Console.ReadLine();
            }
            
        }
    }
}
