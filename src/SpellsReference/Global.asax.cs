using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Http;
using System.Security.Principal;
using SpellsReference.Security;
using Newtonsoft.Json.Serialization;
using SpellsReference.Data;
using SpellsReference.Data.Repositories;
using System.Threading;
using AutoMapper;
using SpellsReference.Models;
using SpellsReference.Models.ViewModels;

namespace SpellsReference
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);

            // Set up JSON formatting conventions
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            Database.SetInitializer(new DatabaseInitializer());

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Spell, SpellViewModel>());
            var mapper = config.CreateMapper();
        }

        void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }

        void Application_PostAuthenticateRequest()
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;
                CustomIdentity customIdentity = new CustomIdentity(ticket);

                var accountRepository = DependencyResolver.Current.GetService<IAccountRepository>();
                var userEntity = accountRepository.Get(customIdentity.Name);

                CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, userEntity);

                HttpContext.Current.User = customPrincipal;
                Thread.CurrentPrincipal = customPrincipal;
            }
        }
    }
}