﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MessageBoard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            var JsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        
            JsonFormatter.SerializerSettings.ContractResolver =
              new CamelCasePropertyNamesContractResolver();


            config.Routes.MapHttpRoute(
               name: "RepliesRoute",
               routeTemplate: "api/v1/topics/{topicid}/replies/{id}",
               defaults: new { controller = "replies", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/topics/{id}",
                defaults: new {controller="topics" , id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}