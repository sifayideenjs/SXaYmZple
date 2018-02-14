using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;

[assembly: OwinStartup(typeof(APISelfHost.Startup))]

namespace APISelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssembliesResolver());
            app.UseWebApi(config);
        }
    }
}
