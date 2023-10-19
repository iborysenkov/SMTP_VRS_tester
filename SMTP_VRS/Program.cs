using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SMTP_VRS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SendMail(GetuserName(), Getpassword());
            Console.ReadLine();
        }

        public static void SendMail(string fromaddres, string password)
        {
                SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = false,
                Host = "mail.sat.box",
                Port = 25,
                Credentials = new NetworkCredential(fromaddres, password)
            };
            string subject = "mysubject";
            string body = "my test message";
            try
            {
                Console.WriteLine("sending email ......");
                email.Send(fromaddres, ToAddress(), subject, body);
                Console.WriteLine("email sent");
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }
        public static string GetuserName()
        {
            Console.WriteLine("Enter vessel VRS email: ");
            string Vrs_email = Console.ReadLine();
            return Vrs_email;

        }

        public static string Getpassword()
        {
            return "MsC-Vr5!";

        }

        public static string ToAddress()
        {
            return "borysenkov.ievgen@msc.com";

        }
    }
}
