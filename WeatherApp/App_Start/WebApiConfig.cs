using System.Web.Http;
using System.Web.Http.Cors;

namespace WeatherApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // CORS for all WebAPI controllers
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
