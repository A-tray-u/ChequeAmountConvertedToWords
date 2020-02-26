using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace ChequeAmountToWordsConverter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            app.UseWebApi(config);
        }
    }
}