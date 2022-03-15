

using System;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoApp.Services;
using UmbracoApp.ViewModels;

namespace UmbracoApp.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly ISmtpService _smtpService;

        public ContactSurfaceController(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        [HttpGet]
        public ActionResult RenderForm()
        {
            ContactViewModel contactViewModel = new ContactViewModel()
            {
                ContactFormId = CurrentPage.Id
            };
            return PartialView("~/Views/Partials/Contact/contactForm.cshtml", contactViewModel);
        }

        [HttpPost]
        public ActionResult RenderForm(ContactViewModel contactViewModel)
        {
            return PartialView("~/Views/Partials/Contact/contactForm.cshtml", contactViewModel);
        }

            [HttpPost]
        public ActionResult SubmitForm(ContactViewModel contactViewModel)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = _smtpService.SendEmail(contactViewModel);
            }

            var contactPage = UmbracoContext.Content.GetById(false, contactViewModel.ContactFormId);

            var successMessage = contactPage.Value<IHtmlString>("successMessage");
            var errorMessage = contactPage.Value<IHtmlString>("errorMessage");

            return PartialView("~/Views/Partials/Contact/result.cshtml", success ? successMessage : errorMessage);
        }

        
    }
}