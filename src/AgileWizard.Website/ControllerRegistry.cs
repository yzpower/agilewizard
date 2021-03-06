﻿using AgileWizard.Domain.Services;
using StructureMap.Configuration.DSL;
using AgileWizard.Website.Models;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Website
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<ISessionStateRepository>().Use<SessionStateRepository>();
        }
    }
}