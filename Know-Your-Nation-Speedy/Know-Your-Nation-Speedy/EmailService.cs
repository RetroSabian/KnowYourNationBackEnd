using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Linq;
using Know_Your_Nation_Speedy.Models;


namespace Know_Your_Nation_Speedy.Models{
    public class EmailService
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
        string emailFromAddress = "**********"; //Sender Email Address  
        string password = "***********"; //Sender Password   
       
        public bool SendMail(string To, string Subject, string Body)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    MailAssignment(mail, emailFromAddress, To, Subject, "<a href = 'http://ereader.retrotest.co.za/resetPassword'>Reset Password</h1>");
                    SmtpSend(mail);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void MailAssignment(MailMessage mailMessage, string From, string To, string Subject, string Body)
        {
            mailMessage.From = new MailAddress(From);
            mailMessage.To.Add(To);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = Body;
        }

        public void SmtpSend(MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
            smtp.Credentials = new NetworkCredential(emailFromAddress, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mail);
        }

        public string generateCode()
        {
            
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();

            string code = new string(Enumerable.Repeat(characters, 10).Select(s => s[rand.Next(s.Length)]).ToArray());
            return code;
        }
    }
}
