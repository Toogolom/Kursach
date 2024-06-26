﻿namespace PIS.Interface
{

    public interface IEmailService
    {
        public bool SendEmail(string recipientEmail, string subject, string body);

        public Task<bool> SaveEmail(string recipientEmail, string body, DateTime date);

    }
}
