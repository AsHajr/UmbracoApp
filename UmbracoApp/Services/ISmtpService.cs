using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmbracoApp.ViewModels;

namespace UmbracoApp.Services
{
    public interface ISmtpService
    {
        bool SendEmail(ContactViewModel contactViewModel);
    }
}