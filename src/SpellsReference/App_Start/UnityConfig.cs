using System.Web.Mvc;
using Unity;
using System.Web.Http;
using SpellsReference.Data.Repositories;
using SpellsReference.Data;
using Unity.Lifetime;

namespace SpellsReference
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Add dependencies here
            container.RegisterType<IContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<ISpellRepository, SpellRepository>();
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}