using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoApp.Services;

namespace UmbracoApp.Composers
{
    public class RegisterServicesComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<ISmtpService, SmtpService>(Lifetime.Singleton);
        }
    }
}