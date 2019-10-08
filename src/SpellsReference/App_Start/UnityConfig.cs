using System.Web.Mvc;
using Unity;
using System.Web.Http;
using SpellsReference.Data.Repositories;

namespace SpellsReference
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Add dependencies here
            container.RegisterType<IAccountRepository, AccountRepository>();
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}