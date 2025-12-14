using System;
using System.Configuration;

namespace PinePawRetreat
{
    public static class EmailServiceCredentials
    {

        public static string SmtpHost =>
            Environment.GetEnvironmentVariable("PPR_SMTP_HOST");

        public static int SmtpPort =>
            int.TryParse(Environment.GetEnvironmentVariable("PPR_SMTP_PORT"), out var p) ? p : 587;

        public static string SmtpUser =>
            Environment.GetEnvironmentVariable("PPR_SMTP_USER");

        public static string SmtpPass =>
            Environment.GetEnvironmentVariable("PPR_SMTP_PASS");

        public static string FromAddress =>
            ConfigurationManager.AppSettings["emailFromAddress"];

        public static string FromName =>
            ConfigurationManager.AppSettings["emailFromName"];

        public static string AppName =>
            ConfigurationManager.AppSettings["emailAppName"];

        public static void Validate()
        {
            if (string.IsNullOrWhiteSpace(SmtpHost))
                throw new InvalidOperationException("Missing env var: PPR_SMTP_HOST");

            if (string.IsNullOrWhiteSpace(SmtpUser))
                throw new InvalidOperationException("Missing env var: PPR_SMTP_USER");

            if (string.IsNullOrWhiteSpace(SmtpPass))
                throw new InvalidOperationException("Missing env var: PPR_SMTP_PASS");

            if (string.IsNullOrWhiteSpace(FromAddress))
                throw new InvalidOperationException("Missing appSetting: emailFromAddress");

            if (string.IsNullOrWhiteSpace(FromName))
                throw new InvalidOperationException("Missing appSetting: emailFromName");
        }
    }
}
