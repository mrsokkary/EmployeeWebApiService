using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using EmployeeService.Models;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace EmployeeService
{
    public static class WebApiConfig
    {

        //public class CustomJsonFormatter : JsonMediaTypeFormatter
        //{
        //    public CustomJsonFormatter()
        //    {
        //        this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        //    }

        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);
        //        headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    }
        //}

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //Indent Json Data
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //fromat the data to json always
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //fromat the data to xml always
            //config.Formatters.Remove(config.Formatters.JsonFormatter);

            //to return json from the brwoser;

            //1- Approach 1
            //text/html is the Accept from browser header    (Accept:text/html)
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //2- Approach 2
            //config.Formatters.Add(new CustomJsonFormatter());

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //config.Filters.Add(new RequireHttpsAttribute());

            //config.Filters.Add(new BasicAuthenticationAttribute());  //fol all
        }
    }
}
