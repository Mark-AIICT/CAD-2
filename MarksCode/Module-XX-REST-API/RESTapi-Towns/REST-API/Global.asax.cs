using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace REST_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = true;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //GlobalConfiguration.Configuration.EnableSwagger(c => c.SingleApiVersion("v1", "Australian Towns API"))
            //            .EnableSwaggerUi();

            List<Models.Town> db = new List<Models.Town>
            {
                new Models.Town(){PostCode=1111, TownName="Woollongong"},
                new Models.Town(){PostCode=2222, TownName="Goondawindi"},
                new Models.Town(){PostCode=3333, TownName="Coonabarabran"},
                new Models.Town(){PostCode=4444, TownName="Mamungkukumpurangkuntjunya Hill"},


            };

            Application.Add("inMemoryDatabase", db);
        }                   

    }
}
