using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gobman.CodeKatas.Abstractions.Services;
using Gobman.CodeKatas.Database;
using Gobman.CodeKatas.Implementation.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Gobman.CodeKatas.Mvc
{
    public class MvcApplication : HttpApplication
    {
        private static Container _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeIocContainer();
        }

        private void InitializeIocContainer()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            _container.Register<KataContext>(Lifestyle.Scoped);
            _container.Register<IPersonService, PersonService>(Lifestyle.Transient);

            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            _container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }
    }
}
