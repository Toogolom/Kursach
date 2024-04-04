﻿namespace PIS.Service
{
    using System;
    using System.Net.Mail;
    using System.Net;
    using PIS.Interface;

    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _senderEmail = "toogolom@gmail.com";
        private readonly string _senderPassword = "gljk jzqs rmwq gizt";
        private readonly IEmailRepository _emailRepository;

        public EmailService (IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public bool SendEmail(string recipientEmail, string subject, string body)
        {

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    
                    smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(_senderEmail, recipientEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SaveEmail(string recipientEmail, string body, DateTime date)
        {
            try
            {
                Email email = new Email(recipientEmail, body, date);
                await _emailRepository.SaveEmail(email);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
