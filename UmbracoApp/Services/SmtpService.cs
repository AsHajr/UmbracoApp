using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Umbraco.Core.Logging;
using UmbracoApp.Controllers;
using UmbracoApp.ViewModels;

namespace UmbracoApp.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly ILogger _logger;
        public SmtpService(ILogger logger)
        {
            _logger = logger;
        }
        public bool SendEmail(ContactViewModel contactViewModel)
        {
            try
            {
                MailMessage message = new MailMessage();

                SmtpClient client = new SmtpClient();

                string toAddress = "to@test.com";
                string fromAddress = "from@test.com";

                message.Subject = $"Enquiry from: {contactViewModel.Name} - {contactViewModel.Email}";
                message.Body = contactViewModel.Message;
                message.To.Add(new MailAddress(toAddress, toAddress));
                message.From = new MailAddress(fromAddress, fromAddress);

                client.Send(message);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(typeof(ContactSurfaceController), e, "error sending email");
                return false;
            }

        }

    }
}